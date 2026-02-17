using System.Text;

namespace Metal.NET.Generator;

public class MetalBindingsGenerator
{
    private readonly string _outputDir;
    private readonly HashSet<string> _knownEnums = new();

    public MetalBindingsGenerator(string outputDir)
    {
        _outputDir = outputDir;
        Directory.CreateDirectory(outputDir);
    }

    private void WriteSource(string folder, string hintName, string content)
    {
        var dir = Path.Combine(_outputDir, folder);
        Directory.CreateDirectory(dir);
        var path = Path.Combine(dir, hintName);
        File.WriteAllText(path, content, Encoding.UTF8);
    }

    public void Execute(ParseResult parsed)
    {
        _knownEnums.Clear();
        s_runtimeKnownEnums.Clear();
        foreach (var e in parsed.Enums)
        {
            _knownEnums.Add(e.Name);
            s_runtimeKnownEnums.Add(e.Name);
        }

        var seenEnums = new HashSet<string>();
        foreach (var e in parsed.Enums.OrderBy(e => e.Name))
        {
            if (seenEnums.Add(e.Name))
                GenerateEnumDef(e);
        }

        var freeFunctionsByClass = new Dictionary<string, List<FreeFunctionDef>>();
        foreach (var f in parsed.FreeFunctions)
        {
            if (!freeFunctionsByClass.TryGetValue(f.TargetClass, out var list))
            {
                list = new List<FreeFunctionDef>();
                freeFunctionsByClass[f.TargetClass] = list;
            }
            list.Add(f);
        }

        var generatedClasses = new HashSet<string>();
        foreach (var cls in parsed.Classes.OrderBy(c => c.Name))
        {
            if (generatedClasses.Add(cls.Name))
            {
                freeFunctionsByClass.TryGetValue(cls.Name, out var freeFuncs);
                GenerateObjCClassDef(cls, freeFuncs);
            }
        }

        var stubTypes = new HashSet<string>
        {
            "MTLLogState", "MTLLogContainer",
            "MTLFXFrameInterpolatableScaler",
            "MTL4FunctionDescriptor",
            "MTLIntersectionFunctionDescriptor",
        };
        foreach (var missingType in stubTypes.OrderBy(t => t))
        {
            if (!generatedClasses.Contains(missingType) && !seenEnums.Contains(missingType))
            {
                GenerateStubClass(missingType);
                generatedClasses.Add(missingType);
            }
        }
    }

    private void GenerateStubClass(string typeName)
    {
        var sb = new StringBuilder();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();
        EmitClassBoilerplate(sb, typeName, hasLibraryImports: false);
        sb.AppendLine("}");

        var folder = GetFolderForType(typeName);
        WriteSource(folder, $"{typeName}.g.cs", sb.ToString());
    }

    private static string GetFolderForType(string typeName)
    {
        if (typeName.StartsWith("CA")) return "QuartzCore";
        if (typeName.StartsWith("MTLFX")) return "MetalFX";
        if (typeName.StartsWith("NS")) return "Foundation";
        return "Metal";
    }

    private void GenerateEnumDef(EnumDef e)
    {
        var sb = new StringBuilder();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        if (e.IsFlags) sb.AppendLine("[System.Flags]");
        sb.AppendLine($"public enum {e.Name} : {e.UnderlyingType}");
        sb.AppendLine("{");
        for (int i = 0; i < e.Members.Count; i++)
        {
            var m = e.Members[i];
            var comma = i < e.Members.Count - 1 ? "," : "";
            sb.AppendLine($"    {m.Name} = {m.Value}{comma}");
        }
        sb.AppendLine("}");

        WriteSource(e.Folder, $"{e.Name}.g.cs", sb.ToString());
    }

    private void GenerateObjCClassDef(ObjCClassDef def,
        List<FreeFunctionDef>? freeFunctions = null)
    {
        var selectors = new Dictionary<string, string>();

        foreach (var p in def.Properties)
        {
            var getSel = p.GetSelector ?? p.Name;
            AddSelector(selectors, getSel);
            if (!p.Readonly)
            {
                var setSel = p.SetSelector ?? $"set{Capitalize(p.Name)}:";
                AddSelector(selectors, setSel);
            }
        }
        foreach (var m in def.Methods) AddSelector(selectors, m.Selector);
        foreach (var m in def.StaticMethods) AddSelector(selectors, m.Selector);

        var sb = new StringBuilder();
        bool hasLibraryImports = freeFunctions != null && freeFunctions.Count > 0;
        bool hasErrorOut = def.Methods.Any(m => m.HasErrorOut) || def.StaticMethods.Any(m => m.HasErrorOut);

        if (hasLibraryImports)
        {
            sb.AppendLine("using System.Runtime.InteropServices;");
            sb.AppendLine();
        }

        if (hasErrorOut)
        {
            sb.AppendLine("#nullable enable");
            sb.AppendLine();
        }

        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        EmitClassBoilerplate(sb, def.Name, hasLibraryImports);

        // Alloc (for concrete classes)
        bool hasStaticMethods = def.StaticMethods.Count > 0;
        if (def.IsClass && def.ObjCClass != null)
        {
            sb.AppendLine($"    private static readonly nint s_class = ObjectiveCRuntime.GetClass(\"{def.ObjCClass}\");");
            sb.AppendLine();
            sb.AppendLine($"    public static {def.Name} New()");
            sb.AppendLine("    {");
            sb.AppendLine("        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register(\"alloc\"));");
            sb.AppendLine("        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register(\"init\"));");
            sb.AppendLine();
            sb.AppendLine($"        return new {def.Name}(ptr);");
            sb.AppendLine("    }");
            sb.AppendLine();
        }
        else if (hasStaticMethods)
        {
            sb.AppendLine($"    private static readonly nint s_class = ObjectiveCRuntime.GetClass(\"{def.Name}\");");
            sb.AppendLine();
        }

        // Properties
        foreach (var p in def.Properties)
        {
            var getSelKey = p.GetSelector ?? p.Name;
            var getSel = selectors[getSelKey];
            var retCSharp = MapReturnCall(p.Type);
            var propName = ToPascalCase(p.Name);

            if (retCSharp.Invoke.Contains("TODO"))
            {
                continue;
            }

            sb.AppendLine($"    public {p.Type} {propName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => {WrapReturn(p.Type, $"{retCSharp.Invoke}(NativePtr, {def.Name}Selector.{getSel})")};");

            if (!p.Readonly)
            {
                var setSelKey = p.SetSelector ?? $"set{Capitalize(p.Name)}:";
                var setSel = selectors[setSelKey];
                sb.AppendLine($"        set => ObjectiveCRuntime.objc_msgSend(NativePtr, {def.Name}Selector.{setSel}, {UnwrapParam(p.Type, "value")});");
            }
            sb.AppendLine("    }");
            sb.AppendLine();
        }

        // Instance methods
        foreach (var m in def.Methods)
        {
            EmitMethod(sb, def.Name, m, selectors, isStatic: false);
        }

        // Static methods
        foreach (var m in def.StaticMethods)
        {
            EmitMethod(sb, def.Name, m, selectors, isStatic: true);
        }

        // Free C functions (LibraryImport)
        if (freeFunctions != null && freeFunctions.Count > 0)
        {
            foreach (var f in freeFunctions)
            {
                EmitFreeFunction(sb, f);
            }
        }

        sb.AppendLine("}");
        sb.AppendLine();

        // Selector cache as file-scoped class (at the bottom of the file)
        sb.AppendLine($"file class {def.Name}Selector");
        sb.AppendLine("{");
        foreach (var kv in selectors)
        {
            sb.AppendLine($"    public static readonly Selector {kv.Value} = Selector.Register(\"{kv.Key}\");");
        }
        sb.AppendLine("}");

        WriteSource(def.Folder, $"{def.Name}.g.cs", sb.ToString());
    }

    private static void EmitClassBoilerplate(StringBuilder sb, string name, bool hasLibraryImports)
    {
        sb.AppendLine($"public{(hasLibraryImports ? " partial" : "")} class {name} : IDisposable");
        sb.AppendLine("{");
        sb.AppendLine($"    public {name}(nint nativePtr)");
        sb.AppendLine("    {");
        sb.AppendLine("        ObjectiveCRuntime.Retain(NativePtr = nativePtr);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine($"    ~{name}()");
        sb.AppendLine("    {");
        sb.AppendLine("        Release();");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public nint NativePtr { get; }");
        sb.AppendLine();
        sb.AppendLine($"    public static implicit operator nint({name} value)");
        sb.AppendLine("    {");
        sb.AppendLine("        return value.NativePtr;");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine($"    public static implicit operator {name}(nint value)");
        sb.AppendLine("    {");
        sb.AppendLine("        return new(value);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public void Dispose()");
        sb.AppendLine("    {");
        sb.AppendLine("        Release();");
        sb.AppendLine();
        sb.AppendLine("        GC.SuppressFinalize(this);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    private void Release()");
        sb.AppendLine("    {");
        sb.AppendLine("        if (NativePtr is not 0)");
        sb.AppendLine("        {");
        sb.AppendLine("            ObjectiveCRuntime.Release(NativePtr);");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine();
    }

    private void EmitMethod(StringBuilder sb, string typeName, MethodDef m, Dictionary<string, string> selectors, bool isStatic)
    {
        var selField = $"{typeName}Selector.{selectors[m.Selector]}";
        var retType = m.ReturnType;
        var methodName = ToPascalCase(m.Name);

        var paramList = new List<string>();
        foreach (var p in m.Parameters)
        {
            paramList.Add($"{MapParamType(p.Type)} {p.Name}");
        }
        if (m.HasErrorOut) paramList.Add("out NSError? error");

        var paramsStr = string.Join(", ", paramList);
        var staticMod = isStatic ? "static " : "";
        var receiver = isStatic ? "s_class" : "NativePtr";

        var retCall = MapReturnCall(retType);

        if (retCall.Invoke.Contains("TODO"))
        {
            return;
        }

        sb.AppendLine($"    public {staticMod}{retType} {methodName}({paramsStr})");
        sb.AppendLine("    {");

        var argParts = new List<string> { receiver, selField };
        foreach (var p in m.Parameters)
        {
            argParts.Add(UnwrapParam(p.Type, p.Name));
        }
        if (m.HasErrorOut)
        {
            sb.AppendLine("        nint errorPtr = 0;");
            argParts.Add("out errorPtr");
        }

        var argsStr = string.Join(", ", argParts);
        var hasParams = m.Parameters.Count > 0 || m.HasErrorOut;

        if (retType == "void")
        {
            sb.AppendLine($"        ObjectiveCRuntime.objc_msgSend({argsStr});");
        }
        else if (retType is "Bool8" or "bool" && hasParams)
        {
            sb.AppendLine($"        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend({argsStr}) is not 0;");
        }
        else if (retType == "nuint" && hasParams)
        {
            sb.AppendLine($"        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend({argsStr});");
        }
        else if (retType == "float" && hasParams)
        {
            sb.AppendLine($"        var result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend({argsStr}));");
        }
        else if (retType == "double" && hasParams)
        {
            sb.AppendLine($"        var result = BitConverter.Int64BitsToDouble((long)ObjectiveCRuntime.intptr_objc_msgSend({argsStr}));");
        }
        else if (retType == "uint" && hasParams)
        {
            sb.AppendLine($"        var result = (uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend({argsStr});");
        }
        else if (IsLikelyEnum(retType) && hasParams)
        {
            sb.AppendLine($"        var result = ({retType})(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend({argsStr});");
        }
        else if (retType == "ulong" && hasParams)
        {
            sb.AppendLine($"        var result = (ulong)ObjectiveCRuntime.intptr_objc_msgSend({argsStr});");
        }
        else
        {
            var resultExpr = $"{retCall.Invoke}({argsStr})";
            sb.AppendLine($"        var result = {WrapReturnVar(retType, resultExpr)};");
        }

        if (m.HasErrorOut)
        {
            sb.AppendLine("        error = errorPtr is not 0 ? new NSError(errorPtr) : null;");
        }

        if (retType != "void")
        {
            sb.AppendLine();
            sb.AppendLine("        return result;");
        }

        sb.AppendLine("    }");
        sb.AppendLine();
    }

    private void EmitFreeFunction(StringBuilder sb, FreeFunctionDef f)
    {
        var publicParams = new List<string>();
        var externParams = new List<string>();
        var forwardArgs = new List<string>();

        foreach (var p in f.Parameters)
        {
            publicParams.Add($"{p.Type} {p.Name}");

            if (IsObjCWrapper(p.Type))
            {
                externParams.Add($"nint {p.Name}");
                forwardArgs.Add($"{p.Name}.NativePtr");
            }
            else
            {
                externParams.Add($"{p.Type} {p.Name}");
                forwardArgs.Add(p.Name);
            }
        }

        var externParamsStr = string.Join(", ", externParams);
        var publicParamsStr = string.Join(", ", publicParams);
        var forwardArgsStr = string.Join(", ", forwardArgs);

        bool wrapReturn = f.ReturnType != "void" && f.ReturnType != "nint"
            && IsObjCWrapper(f.ReturnType);
        var externReturnType = wrapReturn ? "nint" : f.ReturnType;

        sb.AppendLine($"    [LibraryImport(\"{f.FrameworkLibrary}\", EntryPoint = \"{f.NativeName}\")]");
        sb.AppendLine($"    private static partial {externReturnType} {f.NativeName}({externParamsStr});");
        sb.AppendLine();

        sb.AppendLine($"    public static {f.ReturnType} {ToPascalCase(f.Name)}({publicParamsStr})");
        sb.AppendLine("    {");
        if (f.ReturnType == "void")
        {
            sb.AppendLine($"        {f.NativeName}({forwardArgsStr});");
        }
        else if (wrapReturn)
        {
            sb.AppendLine($"        return new {f.ReturnType}({f.NativeName}({forwardArgsStr}));");
        }
        else
        {
            sb.AppendLine($"        return {f.NativeName}({forwardArgsStr});");
        }
        sb.AppendLine("    }");
        sb.AppendLine();
    }

    private static (string Invoke, bool NeedsWrap) MapReturnCall(string type)
    {
        return type switch
        {
            "void" => ("ObjectiveCRuntime.objc_msgSend", false),
            "Bool8" or "bool" => ("ObjectiveCRuntime.bool8_objc_msgSend", false),
            "uint" => ("ObjectiveCRuntime.uint_objc_msgSend", false),
            "ulong" => ("ObjectiveCRuntime.ulong_objc_msgSend", false),
            "float" => ("ObjectiveCRuntime.float_objc_msgSend", false),
            "double" => ("ObjectiveCRuntime.double_objc_msgSend", false),
            "nuint" => ("ObjectiveCRuntime.nuint_objc_msgSend", false),
            "nint" => ("ObjectiveCRuntime.intptr_objc_msgSend", false),
            _ when IsKnownValueStruct(type) => ("/* TODO: stret */", false),
            _ when IsLikelyEnum(type) => ("ObjectiveCRuntime.uint_objc_msgSend", false),
            _ => ("ObjectiveCRuntime.intptr_objc_msgSend", true),
        };
    }

    private static string WrapReturn(string type, string expr)
    {
        if (IsLikelyEnum(type))
            return $"({type})({expr})";
        var call = MapReturnCall(type);
        if (!call.NeedsWrap) return expr;
        return $"new {type}({expr})";
    }

    private static string WrapReturnVar(string type, string varName)
    {
        if (IsLikelyEnum(type))
            return $"({type}){varName}";
        var call = MapReturnCall(type);
        if (!call.NeedsWrap) return varName;
        return $"new {type}({varName})";
    }

    private static string UnwrapParam(string type, string name)
    {
        if (IsKnownValueStruct(type)) return name;
        if (type is "float" or "double") return name;
        if (type is "nint") return name;
        if (type is "nuint") return $"(nint){name}";
        if (IsLikelyEnum(type)) return $"(nint)(uint){name}";
        if (IsObjCWrapper(type)) return $"{name}.NativePtr";
        if (type is "Bool8") return $"(nint){name}.Value";
        if (type is "bool") return $"(nint)({name} ? 1 : 0)";
        if (type is "uint" or "int" or "byte" or "sbyte" or "short" or "ushort")
            return $"(nint){name}";
        if (type is "ulong" or "long")
            return $"(nint){name}";
        return $"(nint){name}";
    }

    private static bool IsObjCWrapper(string type) => CppAstParser.IsObjCWrapper(type);
    private static bool IsKnownValueStruct(string type) => CppAstParser.IsKnownValueStruct(type);
    private static bool IsLikelyEnum(string type) => CppAstParser.IsLikelyEnum(type) || s_runtimeKnownEnums.Contains(type);

    private static readonly HashSet<string> s_runtimeKnownEnums = new();

    private static string MapParamType(string type)
    {
        return type switch
        {
            "nuint" => "uint",
            "nint" => "int",
            _ => type,
        };
    }

    private static void AddSelector(Dictionary<string, string> dict, string selector)
    {
        if (dict.ContainsKey(selector))
            return;

        var fieldName = SelectorToFieldName(selector);

        // Check for collision: if the same field name already exists for a different selector,
        // disambiguate by counting colons (number of arguments)
        if (dict.Values.Any(v => v == fieldName))
        {
            var colonCount = selector.Count(c => c == ':');
            fieldName += colonCount.ToString();
        }

        dict[selector] = fieldName;
    }

    private static string SelectorToFieldName(string selector)
    {
        var parts = selector.Split(':');
        var sb = new StringBuilder();
        foreach (var part in parts)
        {
            if (part.Length > 0)
            {
                sb.Append(char.ToUpperInvariant(part[0]));
                sb.Append(part.Substring(1));
            }
        }
        var name = sb.ToString();
        if (CppAstParser.IsCSharpKeyword(name))
            name = $"@{name}";
        return name;
    }

    private static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return char.ToUpperInvariant(s[0]) + s.Substring(1);
    }

    private static string ToPascalCase(string name)
    {
        if (string.IsNullOrEmpty(name)) return name;

        if (name.StartsWith("@"))
            name = name.Substring(1);

        if (char.IsUpper(name[0]))
            return name;

        return char.ToUpperInvariant(name[0]) + name.Substring(1);
    }
}
