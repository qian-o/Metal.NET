using System.Text;

namespace Metal.NET.Generator;

public class MetalBindingsGenerator
{
    private readonly string outputDir;
    private readonly HashSet<string> knownEnums = [];
    private readonly HashSet<string> msgSendSignatures = [];

    private static readonly HashSet<string> RuntimeKnownEnums = [];

    public MetalBindingsGenerator(string outputDir)
    {
        this.outputDir = outputDir;
        Directory.CreateDirectory(outputDir);
    }

    private void WriteSource(string folder, string hintName, string content)
    {
        string dir = Path.Combine(outputDir, folder);
        Directory.CreateDirectory(dir);

        string path = Path.Combine(dir, hintName);
        File.WriteAllText(path, content, Encoding.UTF8);
    }

    public void Execute(ParseResult parsed)
    {
        knownEnums.Clear();
        RuntimeKnownEnums.Clear();
        msgSendSignatures.Clear();

        foreach (EnumDef e in parsed.Enums)
        {
            knownEnums.Add(e.Name);
            RuntimeKnownEnums.Add(e.Name);
        }

        HashSet<string> seenEnums = [];

        foreach (EnumDef e in parsed.Enums.OrderBy(e => e.Name))
        {
            if (seenEnums.Add(e.Name))
            {
                GenerateEnumDef(e);
            }
        }

        Dictionary<string, List<FreeFunctionDef>> freeFunctionsByClass = [];

        foreach (FreeFunctionDef f in parsed.FreeFunctions)
        {
            if (!freeFunctionsByClass.TryGetValue(f.TargetClass, out List<FreeFunctionDef>? list))
            {
                list = [];
                freeFunctionsByClass[f.TargetClass] = list;
            }

            list.Add(f);
        }

        foreach (ObjCClassDef cls in parsed.Classes)
        {
            CollectSignatures(cls);
        }

        HashSet<string> generatedClasses = [];

        foreach (ObjCClassDef cls in parsed.Classes.OrderBy(c => c.Name))
        {
            if (generatedClasses.Add(cls.Name))
            {
                freeFunctionsByClass.TryGetValue(cls.Name, out List<FreeFunctionDef>? freeFuncs);
                GenerateObjCClassDef(cls, freeFuncs);
            }
        }

        HashSet<string> stubTypes =
        [
            "MTLLogState", "MTLLogContainer",
            "MTLFXFrameInterpolatableScaler",
            "MTL4FunctionDescriptor",
            "MTLIntersectionFunctionDescriptor",
        ];

        foreach (string missingType in stubTypes.OrderBy(t => t))
        {
            if (!generatedClasses.Contains(missingType) && !seenEnums.Contains(missingType))
            {
                GenerateStubClass(missingType);
                generatedClasses.Add(missingType);
            }
        }

        GenerateMergedRuntime();
    }

    private void GenerateStubClass(string typeName)
    {
        StringBuilder sb = new();

        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        EmitClassHeader(sb, typeName, hasLibraryImports: false, isConcreteClass: false, objcClassName: null);
        EmitClassFooter(sb, typeName);

        sb.AppendLine("}");

        string folder = GetFolderForType(typeName);
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
        StringBuilder sb = new();

        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        if (e.IsFlags)
        {
            sb.AppendLine("[Flags]");
        }

        sb.AppendLine($"public enum {e.Name} : {e.UnderlyingType}");
        sb.AppendLine("{");

        for (int i = 0; i < e.Members.Count; i++)
        {
            EnumMemberDef m = e.Members[i];
            string comma = i < e.Members.Count - 1 ? "," : "";

            sb.AppendLine($"    {m.Name} = {m.Value}{comma}");

            if (i < e.Members.Count - 1)
            {
                sb.AppendLine();
            }
        }

        sb.AppendLine("}");

        WriteSource(e.Folder, $"{e.Name}.cs", sb.ToString());
    }

    private void GenerateObjCClassDef(ObjCClassDef def, List<FreeFunctionDef>? freeFunctions = null)
    {
        Dictionary<string, string> selectors = [];

        foreach (PropertyDef p in def.Properties)
        {
            string getSel = p.GetSelector ?? p.Name;
            AddSelector(selectors, getSel);

            if (!p.Readonly)
            {
                string setSel = p.SetSelector ?? $"set{Capitalize(p.Name)}:";
                AddSelector(selectors, setSel);
            }
        }

        foreach (MethodDef m in def.Methods)
        {
            AddSelector(selectors, m.Selector);
        }

        foreach (MethodDef m in def.StaticMethods)
        {
            AddSelector(selectors, m.Selector);
        }

        StringBuilder sb = new();
        bool hasLibraryImports = freeFunctions != null && freeFunctions.Count > 0;

        if (hasLibraryImports)
        {
            sb.AppendLine("using System.Runtime.InteropServices;");
            sb.AppendLine();
        }

        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        bool isConcreteClass = def.IsClass && def.ObjCClass != null;
        bool hasStaticMethods = def.StaticMethods.Count > 0;
        bool hasParent = def.ParentClass != null;

        if (hasParent)
        {
            EmitDerivedClassHeader(sb, def.Name, hasLibraryImports, def.ParentClass!, isConcreteClass, isConcreteClass ? def.ObjCClass : null, !isConcreteClass && hasStaticMethods);
        }
        else
        {
            EmitClassHeader(sb, def.Name, hasLibraryImports, isConcreteClass, isConcreteClass ? def.ObjCClass : null, !isConcreteClass && hasStaticMethods);
        }

        foreach (PropertyDef p in def.Properties)
        {
            string getSelKey = p.GetSelector ?? p.Name;
            string getSel = selectors[getSelKey];
            string propType = p.Type;
            (string Invoke, _) = MapReturnCall(propType);
            string propName = ToPascalCase(p.Name);

            if (Invoke.Contains("TODO"))
            {
                continue;
            }

            string getExpr = WrapReturnInline(propType, $"{Invoke}(NativePtr, {def.Name}Selector.{getSel})");

            if (p.Readonly)
            {
                sb.AppendLine($"    public {propType} {propName}");
                sb.AppendLine("    {");
                sb.AppendLine($"        get => {getExpr};");
                sb.AppendLine("    }");
            }
            else
            {
                string setSelKey = p.SetSelector ?? $"set{Capitalize(p.Name)}:";
                string setSel = selectors[setSelKey];

                sb.AppendLine($"    public {propType} {propName}");
                sb.AppendLine("    {");
                sb.AppendLine($"        get => {getExpr};");
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {def.Name}Selector.{setSel}, {UnwrapParam(propType, "value")});");
                sb.AppendLine("    }");
            }

            sb.AppendLine();
        }

        sb.AppendLine($"    public static implicit operator nint({def.Name} value)");
        sb.AppendLine("    {");
        sb.AppendLine("        return value.NativePtr;");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine($"    public static implicit operator {def.Name}(nint value)");
        sb.AppendLine("    {");
        sb.AppendLine("        return new(value);");
        sb.AppendLine("    }");
        sb.AppendLine();

        foreach (MethodDef m in def.Methods)
        {
            if (EmitMethod(sb, def.Name, m, selectors, isStatic: false))
            {
                sb.AppendLine();
            }
        }

        foreach (MethodDef m in def.StaticMethods)
        {
            if (EmitMethod(sb, def.Name, m, selectors, isStatic: true))
            {
                sb.AppendLine();
            }
        }

        if (!hasParent)
        {
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
        }

        if (freeFunctions != null && freeFunctions.Count > 0)
        {
            foreach (FreeFunctionDef f in freeFunctions)
            {
                sb.AppendLine();
                EmitFreeFunction(sb, f);
            }
        }

        TrimTrailingBlankLine(sb);
        sb.AppendLine("}");
        sb.AppendLine();

        sb.AppendLine($"file class {def.Name}Selector");
        sb.AppendLine("{");

        bool first = true;

        foreach (KeyValuePair<string, string> kv in selectors)
        {
            if (!first)
            {
                sb.AppendLine();
            }

            sb.AppendLine($"    public static readonly Selector {kv.Value} = Selector.Register(\"{kv.Key}\");");
            first = false;
        }

        sb.AppendLine("}");

        WriteSource(def.Folder, $"{def.Name}.cs", sb.ToString());
    }

    private static void EmitClassHeader(StringBuilder sb, string name, bool hasLibraryImports, bool isConcreteClass, string? objcClassName, bool emitClassForStaticMethods = false)
    {
        sb.AppendLine($"public{(hasLibraryImports ? " partial" : "")} class {name} : IDisposable");
        sb.AppendLine("{");

        if (isConcreteClass && objcClassName != null)
        {
            sb.AppendLine($"    private static readonly nint Class = ObjectiveCRuntime.GetClass(\"{objcClassName}\");");
            sb.AppendLine();
        }
        else if (emitClassForStaticMethods)
        {
            sb.AppendLine($"    private static readonly nint Class = ObjectiveCRuntime.GetClass(\"{name}\");");
            sb.AppendLine();
        }

        sb.AppendLine($"    public {name}(nint nativePtr)");
        sb.AppendLine("    {");
        sb.AppendLine("        if (nativePtr is not 0)");
        sb.AppendLine("        {");
        sb.AppendLine("            ObjectiveCRuntime.Retain(NativePtr = nativePtr);");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine();

        if (isConcreteClass)
        {
            sb.AppendLine($"    public {name}() : this(ObjectiveCRuntime.AllocInit(Class))");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();
        }

        sb.AppendLine($"    ~{name}()");
        sb.AppendLine("    {");
        sb.AppendLine("        Release();");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public nint NativePtr { get; }");
        sb.AppendLine();
    }

    private static void EmitDerivedClassHeader(StringBuilder sb, string name, bool hasLibraryImports, string parentClass, bool isConcreteClass = false, string? objcClassName = null, bool emitClassForStaticMethods = false)
    {
        sb.AppendLine($"public{(hasLibraryImports ? " partial" : "")} class {name}(nint nativePtr) : {parentClass}(nativePtr)");
        sb.AppendLine("{");

        if (isConcreteClass && objcClassName != null)
        {
            sb.AppendLine($"    private static readonly nint Class = ObjectiveCRuntime.GetClass(\"{objcClassName}\");");
            sb.AppendLine();
        }
        else if (emitClassForStaticMethods)
        {
            sb.AppendLine($"    private static readonly nint Class = ObjectiveCRuntime.GetClass(\"{name}\");");
            sb.AppendLine();
        }

        if (isConcreteClass)
        {
            sb.AppendLine($"    public {name}() : this(ObjectiveCRuntime.AllocInit(Class))");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();
        }
    }

    private static void EmitClassFooter(StringBuilder sb, string name)
    {
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
    }

    private bool EmitMethod(StringBuilder sb, string typeName, MethodDef m, Dictionary<string, string> selectors, bool isStatic)
    {
        string selField = $"{typeName}Selector.{selectors[m.Selector]}";
        string retType = m.ReturnType;
        string methodName = ToPascalCase(m.Name);

        List<string> paramList = [];

        foreach (ParamDef p in m.Parameters)
        {
            paramList.Add($"{p.Type} {p.Name}");
        }

        if (m.HasErrorOut)
        {
            paramList.Add("out NSError? error");
        }

        string paramsStr = string.Join(", ", paramList);
        string staticMod = isStatic ? "static " : "";
        string receiver = isStatic ? "Class" : "NativePtr";

        (string Invoke, bool NeedsWrap) = MapReturnCall(retType);

        if (Invoke.Contains("TODO"))
        {
            return false;
        }

        sb.AppendLine($"    public {staticMod}{retType} {methodName}({paramsStr})");
        sb.AppendLine("    {");

        List<string> argParts = [receiver, selField];

        foreach (ParamDef p in m.Parameters)
        {
            argParts.Add(UnwrapParam(p.Type, p.Name));
        }

        if (m.HasErrorOut)
        {
            argParts.Add("out nint errorPtr");
        }

        string argsStr = string.Join(", ", argParts);

        List<string> runtimeParamTypes = [.. m.Parameters.Select(p => GetRuntimeParamType(p.Type))];
        string runtimeReturnType = MapReturnRuntimeType(retType);
        RecordMsgSendSignature(runtimeReturnType, runtimeParamTypes, m.HasErrorOut);

        if (retType == "void")
        {
            sb.AppendLine($"        ObjectiveCRuntime.MsgSend({argsStr});");
        }
        else
        {
            string callExpr = $"{Invoke}({argsStr})";

            if (IsObjCWrapper(retType) || NeedsWrap)
            {
                sb.AppendLine($"        {retType} result = new({callExpr});");
            }
            else if (IsLikelyEnum(retType))
            {
                sb.AppendLine($"        {retType} result = ({retType}){callExpr};");
            }
            else
            {
                sb.AppendLine($"        {retType} result = {callExpr};");
            }
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

        return true;
    }

    private static void EmitFreeFunction(StringBuilder sb, FreeFunctionDef f)
    {
        List<string> publicParams = [];
        List<string> externParams = [];
        List<string> forwardArgs = [];

        foreach (ParamDef p in f.Parameters)
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

        string externParamsStr = string.Join(", ", externParams);
        string publicParamsStr = string.Join(", ", publicParams);
        string forwardArgsStr = string.Join(", ", forwardArgs);

        bool wrapReturn = f.ReturnType != "void" && f.ReturnType != "nint" && IsObjCWrapper(f.ReturnType);
        string externReturnType = wrapReturn ? "nint" : f.ReturnType;

        sb.AppendLine($"    [LibraryImport(\"{f.FrameworkLibrary}\", EntryPoint = \"{f.NativeName}\")]");
        sb.AppendLine($"    private static partial {externReturnType} _{f.NativeName}({externParamsStr});");
        sb.AppendLine();

        sb.AppendLine($"    public static {f.ReturnType} {ToPascalCase(f.Name)}({publicParamsStr})");
        sb.AppendLine("    {");

        if (f.ReturnType == "void")
        {
            sb.AppendLine($"        _{f.NativeName}({forwardArgsStr});");
        }
        else if (wrapReturn)
        {
            sb.AppendLine($"        return new(_{f.NativeName}({forwardArgsStr}));");
        }
        else
        {
            sb.AppendLine($"        return _{f.NativeName}({forwardArgsStr});");
        }

        sb.AppendLine("    }");
    }

    private static string WrapReturnInline(string type, string expr)
    {
        if (IsLikelyEnum(type))
        {
            return $"({type}){expr}";
        }

        (_, bool NeedsWrap) = MapReturnCall(type);

        if (!NeedsWrap)
        {
            return expr;
        }

        return $"new({expr})";
    }

    private static (string Invoke, bool NeedsWrap) MapReturnCall(string type)
    {
        return type switch
        {
            "void" => ("ObjectiveCRuntime.MsgSend", false),
            "Bool8" or "bool" => ("ObjectiveCRuntime.MsgSendBool", false),
            "int" => ("ObjectiveCRuntime.MsgSendInt", false),
            "uint" => ("ObjectiveCRuntime.MsgSendUInt", false),
            "float" => ("ObjectiveCRuntime.MsgSendFloat", false),
            "double" => ("ObjectiveCRuntime.MsgSendDouble", false),
            "nuint" => ("ObjectiveCRuntime.MsgSendNUInt", false),
            "nint" => ("ObjectiveCRuntime.MsgSendPtr", false),
            _ when IsKnownValueStruct(type) => ($"ObjectiveCRuntime.MsgSend{type}", false),
            _ when IsLikelyEnum(type) => ("ObjectiveCRuntime.MsgSendULong", false),
            _ => ("ObjectiveCRuntime.MsgSendPtr", true),
        };
    }

    private static string UnwrapParam(string type, string name) => type switch
    {
        _ when IsKnownValueStruct(type) => name,
        "float" or "double" => name,
        "nint" or "nuint" => name,
        _ when IsLikelyEnum(type) => $"(ulong){name}",
        _ when IsObjCWrapper(type) => $"{name}.NativePtr",
        "Bool8" => name,
        "bool" => $"(byte)({name} ? 1 : 0)",
        "uint" or "int" or "byte" or "sbyte" or "short" or "ushort" => name,
        _ => name,
    };

    private static string GetRuntimeParamType(string type) => type switch
    {
        _ when IsKnownValueStruct(type) => type,
        "float" or "double" => type,
        "nint" => "nint",
        "nuint" => "nuint",
        _ when IsLikelyEnum(type) => "ulong",
        _ when IsObjCWrapper(type) => "nint",
        "Bool8" => "Bool8",
        "bool" => "byte",
        "uint" or "int" or "byte" or "sbyte" or "short" or "ushort" => type,
        _ => "nint",
    };

    private static bool IsObjCWrapper(string type) => HeaderParser.IsObjCWrapper(type);

    private static bool IsKnownValueStruct(string type) => HeaderParser.IsKnownValueStruct(type);

    private static bool IsLikelyEnum(string type) => HeaderParser.IsLikelyEnum(type) || RuntimeKnownEnums.Contains(type);

    private static void AddSelector(Dictionary<string, string> dict, string selector)
    {
        if (dict.ContainsKey(selector))
        {
            return;
        }

        string fieldName = SelectorToFieldName(selector);

        if (dict.Values.Any(v => v == fieldName))
        {
            int colonCount = selector.Count(c => c == ':');
            fieldName += colonCount.ToString();
        }

        dict[selector] = fieldName;
    }

    private static string SelectorToFieldName(string selector)
    {
        string[] parts = selector.Split(':');
        StringBuilder sb = new();

        foreach (string part in parts)
        {
            if (part.Length > 0)
            {
                sb.Append(char.ToUpperInvariant(part[0]));
                sb.Append(part[1..]);
            }
        }

        string name = sb.ToString();

        if (HeaderParser.IsCSharpKeyword(name))
        {
            name = $"@{name}";
        }

        return name;
    }

    private static string MapReturnRuntimeType(string retType) => retType switch
    {
        "void" => "void",
        "Bool8" or "bool" => "Bool8",
        "int" => "int",
        "uint" => "uint",
        "float" => "float",
        "double" => "double",
        "nuint" => "nuint",
        "nint" => "nint",
        _ when IsLikelyEnum(retType) => "ulong",
        _ when IsKnownValueStruct(retType) => retType,
        _ => "nint",
    };

    private static string MsgSendMethodName(string runtimeReturnType) => runtimeReturnType switch
    {
        "void" => "MsgSend",
        "nint" => "MsgSendPtr",
        "Bool8" => "MsgSendBool",
        "int" => "MsgSendInt",
        "uint" => "MsgSendUInt",
        "ulong" => "MsgSendULong",
        "float" => "MsgSendFloat",
        "double" => "MsgSendDouble",
        "nuint" => "MsgSendNUInt",
        _ when IsKnownValueStruct(runtimeReturnType) => $"MsgSend{runtimeReturnType}",
        _ => "MsgSendPtr",
    };

    private void RecordMsgSendSignature(string runtimeReturnType, List<string> runtimeParamTypes, bool hasErrorOut)
    {
        string key = $"{runtimeReturnType}|{string.Join(",", runtimeParamTypes)}{(hasErrorOut ? "|err" : "")}";
        msgSendSignatures.Add(key);
    }

    private void CollectSignatures(ObjCClassDef cls)
    {
        foreach (PropertyDef p in cls.Properties)
        {
            (string Invoke, bool NeedsWrap) = MapReturnCall(p.Type);

            if (Invoke.Contains("TODO"))
            {
                continue;
            }

            string getRetType = MapReturnRuntimeType(p.Type);
            RecordMsgSendSignature(getRetType, [], false);

            if (!p.Readonly)
            {
                string setParamType = GetRuntimeParamType(p.Type);
                RecordMsgSendSignature("void", [setParamType], false);
            }
        }

        foreach (MethodDef m in cls.Methods.Concat(cls.StaticMethods))
        {
            (string Invoke, bool NeedsWrap) = MapReturnCall(m.ReturnType);

            if (Invoke.Contains("TODO"))
            {
                continue;
            }

            List<string> runtimeParamTypes = [.. m.Parameters.Select(p => GetRuntimeParamType(p.Type))];
            string runtimeReturnType = MapReturnRuntimeType(m.ReturnType);
            RecordMsgSendSignature(runtimeReturnType, runtimeParamTypes, m.HasErrorOut);
        }
    }

    private void GenerateMergedRuntime()
    {
        StringBuilder sb = new();

        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine("using System.Text;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();
        sb.AppendLine("internal static unsafe partial class ObjectiveCRuntime");
        sb.AppendLine("{");

        sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"objc_getClass\")]");
        sb.AppendLine("    public static partial nint GetClass(byte* name);");
        sb.AppendLine();
        sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"sel_registerName\")]");
        sb.AppendLine("    public static partial Selector RegisterName(byte* name);");
        sb.AppendLine();
        sb.AppendLine("    public static nint Retain(nint obj)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendPtr(obj, Selector.Register(\"retain\"));");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static void Release(nint obj)");
        sb.AppendLine("    {");
        sb.AppendLine("        MsgSend(obj, Selector.Register(\"release\"));");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint GetClass(string name)");
        sb.AppendLine("    {");
        sb.AppendLine("        fixed (byte* utf8 = Encoding.UTF8.GetBytes(name + '\\0'))");
        sb.AppendLine("        {");
        sb.AppendLine("            return GetClass(utf8);");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint AllocInit(nint @class)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendPtr(MsgSendPtr(@class, Selector.Register(\"alloc\")), Selector.Register(\"init\"));");
        sb.AppendLine("    }");
        sb.AppendLine();

        Dictionary<string, List<string>> overloadsByGroup = [];
        HashSet<string> emittedSigs = [];

        foreach (string sig in msgSendSignatures.OrderBy(s => s))
        {
            string[] parts = sig.Split('|');
            string retType = parts[0];
            string paramTypesStr = parts[1];
            bool hasErrorOut = parts.Length > 2 && parts[2] == "err";
            string[] paramTypes = string.IsNullOrEmpty(paramTypesStr) ? [] : paramTypesStr.Split(',');

            string methodName = MsgSendMethodName(retType);

            List<string> paramParts = ["nint receiver", "Selector selector"];
            char letter = 'a';

            foreach (string pt in paramTypes)
            {
                paramParts.Add($"{pt} {letter}");
                letter++;
            }

            if (hasErrorOut)
            {
                paramParts.Add("out nint error");
            }

            string paramStr = string.Join(", ", paramParts);
            string dedupKey = $"{retType} {methodName}({paramStr})";

            if (!emittedSigs.Add(dedupKey))
            {
                continue;
            }

            if (!overloadsByGroup.TryGetValue(methodName, out List<string>? list))
            {
                list = [];
                overloadsByGroup[methodName] = list;
            }

            StringBuilder overloadSb = new();
            overloadSb.AppendLine($"    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"objc_msgSend\")]");
            overloadSb.Append($"    public static partial {retType} {methodName}({paramStr});");
            list.Add(overloadSb.ToString());
        }

        foreach (KeyValuePair<string, List<string>> group in overloadsByGroup.OrderBy(g => g.Key))
        {
            sb.AppendLine($"    #region {group.Key}");
            sb.AppendLine();

            for (int i = 0; i < group.Value.Count; i++)
            {
                sb.AppendLine(group.Value[i]);
                sb.AppendLine();
            }

            sb.AppendLine("    #endregion");
            sb.AppendLine();
        }

        TrimTrailingBlankLine(sb);
        sb.AppendLine("}");

        WriteSource("Common", "ObjectiveCRuntime.cs", sb.ToString());
    }

    private static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        return char.ToUpperInvariant(s[0]) + s[1..];
    }

    private static string ToPascalCase(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }

        if (name.StartsWith('@'))
        {
            name = name[1..];
        }

        if (char.IsUpper(name[0]))
        {
            return name;
        }

        return char.ToUpperInvariant(name[0]) + name[1..];
    }

    private static void TrimTrailingBlankLine(StringBuilder sb)
    {
        string newLine = Environment.NewLine;
        string doubleNewLine = newLine + newLine;

        if (sb.Length >= doubleNewLine.Length)
        {
            string tail = sb.ToString(sb.Length - doubleNewLine.Length, doubleNewLine.Length);

            if (tail == doubleNewLine)
            {
                sb.Remove(sb.Length - newLine.Length, newLine.Length);
            }
        }
    }
}
