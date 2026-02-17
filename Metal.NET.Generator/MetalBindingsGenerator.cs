using System.Text;

namespace Metal.NET.Generator;

public class MetalBindingsGenerator
{
    private readonly string _outputDir;
    private readonly HashSet<string> _knownEnums = new();

    // Collect all unique MsgSend signatures needed: (returnType, [paramTypes...])
    private readonly HashSet<string> _msgSendSignatures = new();

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
        _msgSendSignatures.Clear();
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

        // First pass: collect all MsgSend signatures needed
        foreach (var cls in parsed.Classes)
        {
            CollectSignatures(cls);
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

        // Generate ObjectiveCRuntime overloads
        GenerateRuntimeOverloads();
    }

    private void GenerateStubClass(string typeName)
    {
        var sb = new StringBuilder();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();
        EmitClassBoilerplate(sb, typeName, hasLibraryImports: false);
        sb.AppendLine("}");

        var folder = GetFolderForType(typeName);
        WriteSource(folder, $"{typeName}.cs", sb.ToString());
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

        WriteSource(e.Folder, $"{e.Name}.cs", sb.ToString());
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

        if (hasLibraryImports)
        {
            sb.AppendLine("using System.Runtime.InteropServices;");
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
            sb.AppendLine($"    public {def.Name}() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register(\"alloc\")), Selector.Register(\"init\")))");
            sb.AppendLine("    {");
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
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {def.Name}Selector.{setSel}, {UnwrapParam(p.Type, "value")});");
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
        var first = true;
        foreach (var kv in selectors)
        {
            if (!first) sb.AppendLine();
            sb.AppendLine($"    public static readonly Selector {kv.Value} = Selector.Register(\"{kv.Key}\");");
            first = false;
        }
        sb.AppendLine("}");

        WriteSource(def.Folder, $"{def.Name}.cs", sb.ToString());
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
            argParts.Add("out nint errorPtr");
        }

        var argsStr = string.Join(", ", argParts);

        // Record the signature for runtime overload generation
        var runtimeParamTypes = m.Parameters.Select(p => GetRuntimeParamType(p.Type)).ToList();
        var runtimeReturnType = MapReturnRuntimeType(retType);
        RecordMsgSendSignature(runtimeReturnType, runtimeParamTypes, m.HasErrorOut);

        if (retType == "void")
        {
            sb.AppendLine($"        ObjectiveCRuntime.MsgSend({argsStr});");
        }
        else
        {
            var resultExpr = $"{retCall.Invoke}({argsStr})";
            var wrapped = WrapReturnVar(retType, resultExpr);
            if (IsObjCWrapper(retType) || retCall.NeedsWrap)
                sb.AppendLine($"        {retType} result = new({retCall.Invoke}({argsStr}));");
            else if (IsLikelyEnum(retType))
                sb.AppendLine($"        {retType} result = {wrapped};");
            else
                sb.AppendLine($"        {retType} result = {wrapped};");
        }

        if (m.HasErrorOut)
        {
            sb.AppendLine();
            sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
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
            "void" => ("ObjectiveCRuntime.MsgSend", false),
            "Bool8" or "bool" => ("ObjectiveCRuntime.MsgSendBool", false),
            "uint" => ("ObjectiveCRuntime.MsgSendUInt", false),
            "ulong" => ("ObjectiveCRuntime.MsgSendULong", false),
            "float" => ("ObjectiveCRuntime.MsgSendFloat", false),
            "double" => ("ObjectiveCRuntime.MsgSendDouble", false),
            "nuint" => ("ObjectiveCRuntime.MsgSendNUInt", false),
            "nint" => ("ObjectiveCRuntime.MsgSendPtr", false),
            _ when IsKnownValueStruct(type) => ("/* TODO: stret */", false),
            _ when IsLikelyEnum(type) => ("ObjectiveCRuntime.MsgSendUInt", false),
            _ => ("ObjectiveCRuntime.MsgSendPtr", true),
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
        return $"new({varName})";
    }

    private static string UnwrapParam(string type, string name)
    {
        if (IsKnownValueStruct(type)) return name;
        if (type is "float" or "double") return name;
        if (type is "nint") return name;
        if (type is "nuint") return $"(nuint){name}";
        if (IsLikelyEnum(type)) return $"(uint){name}";
        if (IsObjCWrapper(type)) return $"{name}.NativePtr";
        if (type is "Bool8") return name;
        if (type is "bool") return $"(byte)({name} ? 1 : 0)";
        if (type is "uint" or "int" or "byte" or "sbyte" or "short" or "ushort") return name;
        if (type is "ulong" or "long") return name;
        return name;
    }

    /// <summary>
    /// Map a C# parameter type to the actual runtime type used in MsgSend overload signatures.
    /// </summary>
    private static string GetRuntimeParamType(string type)
    {
        if (IsKnownValueStruct(type)) return type;
        if (type is "float" or "double") return type;
        if (type is "nint") return "nint";
        if (type is "nuint") return "nuint";
        if (IsLikelyEnum(type)) return "uint";
        if (IsObjCWrapper(type)) return "nint";
        if (type is "Bool8") return "Bool8";
        if (type is "bool") return "byte";
        if (type is "uint" or "int" or "byte" or "sbyte" or "short" or "ushort") return type;
        if (type is "ulong" or "long") return type;
        return "nint";
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

    private static string MapReturnRuntimeType(string retType)
    {
        if (retType == "void") return "void";
        if (retType is "Bool8" or "bool") return "Bool8";
        if (retType is "uint") return "uint";
        if (retType is "ulong") return "ulong";
        if (retType is "float") return "float";
        if (retType is "double") return "double";
        if (retType is "nuint") return "nuint";
        if (retType is "nint") return "nint";
        if (IsLikelyEnum(retType)) return "uint";
        // Value structs need stret — not supported, should be filtered before calling this
        if (IsKnownValueStruct(retType)) return "nint";
        // ObjC wrapper or nint
        return "nint";
    }

    private static string MsgSendMethodName(string runtimeReturnType) => runtimeReturnType switch
    {
        "void" => "MsgSend",
        "nint" => "MsgSendPtr",
        "Bool8" => "MsgSendBool",
        "uint" => "MsgSendUInt",
        "ulong" => "MsgSendULong",
        "float" => "MsgSendFloat",
        "double" => "MsgSendDouble",
        "nuint" => "MsgSendNUInt",
        _ => "MsgSendPtr", // fallback
    };

    private void RecordMsgSendSignature(string runtimeReturnType, List<string> runtimeParamTypes, bool hasErrorOut)
    {
        var key = $"{runtimeReturnType}|{string.Join(",", runtimeParamTypes)}{(hasErrorOut ? "|err" : "")}";
        _msgSendSignatures.Add(key);
    }

    private void CollectSignatures(ObjCClassDef cls)
    {
        // Collect from properties
        foreach (var p in cls.Properties)
        {
            var retCall = MapReturnCall(p.Type);
            if (retCall.Invoke.Contains("TODO")) continue;

            var getRetType = MapReturnRuntimeType(p.Type);
            RecordMsgSendSignature(getRetType, new List<string>(), false);

            if (!p.Readonly)
            {
                var setParamType = GetRuntimeParamType(p.Type);
                RecordMsgSendSignature("void", new List<string> { setParamType }, false);
            }
        }

        // Collect from methods
        foreach (var m in cls.Methods.Concat(cls.StaticMethods))
        {
            var retCall = MapReturnCall(m.ReturnType);
            if (retCall.Invoke.Contains("TODO")) continue;

            var runtimeParamTypes = m.Parameters.Select(p => GetRuntimeParamType(p.Type)).ToList();
            var runtimeReturnType = MapReturnRuntimeType(m.ReturnType);
            RecordMsgSendSignature(runtimeReturnType, runtimeParamTypes, m.HasErrorOut);
        }
    }

    private void GenerateRuntimeOverloads()
    {
        var sb = new StringBuilder();
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();
        sb.AppendLine("public static unsafe partial class ObjectiveCRuntime");
        sb.AppendLine("{");

        var emittedSigs = new HashSet<string>();

        foreach (var sig in _msgSendSignatures.OrderBy(s => s))
        {
            var parts = sig.Split('|');
            var retType = parts[0];
            var paramTypesStr = parts[1];
            bool hasErrorOut = parts.Length > 2 && parts[2] == "err";
            var paramTypes = string.IsNullOrEmpty(paramTypesStr) ? Array.Empty<string>() : paramTypesStr.Split(',');

            var methodName = MsgSendMethodName(retType);
            var csRetType = retType == "void" ? "void" : retType;

            // Build parameter list
            var paramParts = new List<string> { "nint receiver", "Selector selector" };
            char letter = 'a';
            foreach (var pt in paramTypes)
            {
                paramParts.Add($"{pt} {letter}");
                letter++;
            }
            if (hasErrorOut)
            {
                paramParts.Add("out nint error");
            }

            var paramStr = string.Join(", ", paramParts);

            // Deduplicate: same method name + same param types = same overload
            var dedupKey = $"{csRetType} {methodName}({paramStr})";
            if (!emittedSigs.Add(dedupKey))
                continue;

            sb.AppendLine($"    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"objc_msgSend\")]");
            sb.AppendLine($"    public static partial {csRetType} {methodName}({paramStr});");
            sb.AppendLine();
        }

        sb.AppendLine("}");

        WriteSource("Common", "ObjectiveCRuntime.Generated.cs", sb.ToString());
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
