using System.Text;

namespace Metal.NET.Generator;

public class MetalBindingsGenerator
{
    private readonly string outputDir;
    private readonly HashSet<string> knownEnums = [];
    private readonly HashSet<string> msgSendSignatures = [];

    public MetalBindingsGenerator(string outputDir)
    {
        this.outputDir = outputDir;
    }

    public void Execute(ParseResult parsed)
    {
        // Collect known enums for type resolution
        foreach (EnumDef e in parsed.Enums)
            knownEnums.Add(e.Name);

        // Build set of all defined class names
        HashSet<string> definedClasses = [];
        foreach (ObjCClassDef c in parsed.Classes)
            definedClasses.Add(c.Name);

        // Generate enums
        foreach (EnumDef e in parsed.Enums)
            GenerateEnum(e);

        // Generate classes
        foreach (ObjCClassDef c in parsed.Classes)
            GenerateClass(c);

        // Generate stubs for referenced but undefined types
        GenerateStubs(parsed, definedClasses);

        // Generate ObjectiveCRuntime.cs
        GenerateObjectiveCRuntime(parsed);
    }

    private void GenerateEnum(EnumDef e)
    {
        string folder = Path.Combine(outputDir, e.Folder);
        Directory.CreateDirectory(folder);

        var sb = new StringBuilder();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        if (e.IsFlags)
            sb.AppendLine("[Flags]");

        sb.AppendLine($"public enum {e.Name} : {e.UnderlyingType}");
        sb.AppendLine("{");

        for (int i = 0; i < e.Members.Count; i++)
        {
            EnumMemberDef m = e.Members[i];
            string comma = i < e.Members.Count - 1 ? "," : "";
            sb.AppendLine($"    {m.Name} = {m.Value}{comma}");
        }

        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(folder, $"{e.Name}.cs"), sb.ToString());
    }

    private void GenerateClass(ObjCClassDef c)
    {
        string folder = Path.Combine(outputDir, c.Folder);
        Directory.CreateDirectory(folder);

        var sb = new StringBuilder();
        string selectorClassName = $"{c.Name}Selector";

        bool hasParent = !string.IsNullOrEmpty(c.ParentClass);
        bool isRootObjCClass = !hasParent && c.IsClass && c.ObjCClass != null;
        bool isRootProtocol = !hasParent && !isRootObjCClass;

        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        if (hasParent)
        {
            // Derived class — use primary constructor
            sb.AppendLine($"public class {c.Name}(nint nativePtr) : {c.ParentClass}(nativePtr)");
            sb.AppendLine("{");
        }
        else if (isRootObjCClass)
        {
            // Root ObjC class with CLS registration
            sb.AppendLine($"public partial class {c.Name} : NativeObject");
            sb.AppendLine("{");
            sb.AppendLine($"    private static readonly nint Class = ObjectiveCRuntime.GetClass(\"{c.ObjCClass}\");");
            sb.AppendLine();
            sb.AppendLine($"    public {c.Name}(nint nativePtr) : base(nativePtr)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
        }
        else
        {
            // Root protocol/interface
            sb.AppendLine($"public partial class {c.Name} : NativeObject");
            sb.AppendLine("{");
            sb.AppendLine($"    public {c.Name}(nint nativePtr) : base(nativePtr)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
        }

        // Properties
        foreach (PropertyDef p in c.Properties)
        {
            sb.AppendLine();
            GenerateProperty(sb, p, selectorClassName);
        }

        // Instance methods (skip those used as property getters/setters)
        HashSet<string> propertySelectors = GetPropertySelectors(c);
        foreach (MethodDef m in c.Methods)
        {
            if (propertySelectors.Contains(m.Selector))
                continue;

            sb.AppendLine();
            GenerateMethod(sb, m, selectorClassName, isStatic: false);
        }

        // Static methods
        foreach (MethodDef m in c.StaticMethods)
        {
            sb.AppendLine();
            GenerateMethod(sb, m, selectorClassName, isStatic: true);
        }

        sb.AppendLine("}");
        sb.AppendLine();

        // Selector class
        GenerateSelectorClass(sb, c, selectorClassName);

        File.WriteAllText(Path.Combine(folder, $"{c.Name}.cs"), sb.ToString());
    }

    private void GenerateProperty(StringBuilder sb, PropertyDef p, string selectorClassName)
    {
        string returnType = MapReturnType(p.Type);
        string selectorName = ToPascalCase(SelectorToAccessorName(p.GetSelector ?? p.Name));

        if (IsObjCWrapper(p.Type))
        {
            // Nullable return for native objects
            sb.AppendLine($"    public {returnType}? {p.Name}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get");
            sb.AppendLine("        {");
            sb.AppendLine($"            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, {selectorClassName}.{selectorName});");
            sb.AppendLine($"            return ptr is not 0 ? new(ptr) : null;");
            sb.AppendLine("        }");

            if (!p.Readonly && p.SetSelector != null)
            {
                string setSelectorName = ToPascalCase(SelectorToAccessorName(p.SetSelector));
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {selectorClassName}.{setSelectorName}, value?.NativePtr ?? 0);");
            }

            sb.AppendLine("    }");
        }
        else if (p.Type == "bool")
        {
            sb.AppendLine($"    public bool {p.Name}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.MsgSendBool(NativePtr, {selectorClassName}.{selectorName});");

            if (!p.Readonly && p.SetSelector != null)
            {
                string setSelectorName = ToPascalCase(SelectorToAccessorName(p.SetSelector));
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {selectorClassName}.{setSelectorName}, (Bool8)value);");
            }

            sb.AppendLine("    }");
        }
        else if (knownEnums.Contains(p.Type))
        {
            string msgSendMethod = GetEnumMsgSendMethod(p.Type);
            sb.AppendLine($"    public {p.Type} {p.Name}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ({p.Type})ObjectiveCRuntime.{msgSendMethod}(NativePtr, {selectorClassName}.{selectorName});");

            if (!p.Readonly && p.SetSelector != null)
            {
                string setSelectorName = ToPascalCase(SelectorToAccessorName(p.SetSelector));
                string castType = GetEnumCastType(p.Type);
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {selectorClassName}.{setSelectorName}, ({castType})value);");
            }

            sb.AppendLine("    }");
        }
        else if (HeaderParser.IsKnownValueStruct(p.Type))
        {
            string msgSendMethod = $"MsgSend{p.Type}";
            sb.AppendLine($"    public {p.Type} {p.Name}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.{msgSendMethod}(NativePtr, {selectorClassName}.{selectorName});");

            if (!p.Readonly && p.SetSelector != null)
            {
                string setSelectorName = ToPascalCase(SelectorToAccessorName(p.SetSelector));
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {selectorClassName}.{setSelectorName}, value);");
            }

            sb.AppendLine("    }");
        }
        else
        {
            // Primitive types
            string msgSendMethod = GetPrimitiveMsgSendMethod(p.Type);
            sb.AppendLine($"    public {returnType} {p.Name}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.{msgSendMethod}(NativePtr, {selectorClassName}.{selectorName});");

            if (!p.Readonly && p.SetSelector != null)
            {
                string setSelectorName = ToPascalCase(SelectorToAccessorName(p.SetSelector));
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {selectorClassName}.{setSelectorName}, value);");
            }

            sb.AppendLine("    }");
        }
    }

    private void GenerateMethod(StringBuilder sb, MethodDef m, string selectorClassName, bool isStatic)
    {
        string staticKw = isStatic ? "static " : "";
        string receiver = isStatic ? "Class" : "NativePtr";
        string selectorName = ToPascalCase(SelectorToAccessorName(m.Selector));

        // Build parameter list
        var paramList = new List<string>();
        var argList = new List<string>();

        foreach (ParamDef p in m.Parameters)
        {
            string paramType = MapReturnType(p.Type);

            if (IsObjCWrapper(p.Type))
            {
                paramList.Add($"{paramType} {p.Name}");
                argList.Add($"{p.Name}.NativePtr");
            }
            else if (knownEnums.Contains(p.Type))
            {
                paramList.Add($"{p.Type} {p.Name}");
                string castType = GetEnumCastType(p.Type);
                argList.Add($"({castType}){p.Name}");
            }
            else if (p.Type == "bool")
            {
                paramList.Add($"bool {p.Name}");
                argList.Add($"(Bool8){p.Name}");
            }
            else
            {
                paramList.Add($"{paramType} {p.Name}");
                argList.Add(p.Name);
            }
        }

        if (m.HasErrorOut)
        {
            paramList.Add("out NSError? error");
        }

        string paramStr = string.Join(", ", paramList);
        string selectorRef = $"{selectorClassName}.{selectorName}";

        // Build MsgSend call arguments
        var callArgs = new List<string> { receiver, selectorRef };
        callArgs.AddRange(argList);

        if (m.HasErrorOut)
        {
            callArgs.Add("out nint errorPtr");
        }

        string callArgStr = string.Join(", ", callArgs);

        // Collect MsgSend signature
        CollectMsgSendSignature(m, isStatic);

        if (m.ReturnType == "void")
        {
            sb.AppendLine($"    public {staticKw}void {ToPascalCase(m.Name)}({paramStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        ObjectiveCRuntime.MsgSend({callArgStr});");

            if (m.HasErrorOut)
            {
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
            }

            sb.AppendLine("    }");
        }
        else if (IsObjCWrapper(m.ReturnType))
        {
            string returnType = MapReturnType(m.ReturnType);
            sb.AppendLine($"    public {staticKw}{returnType}? {ToPascalCase(m.Name)}({paramStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint ptr = ObjectiveCRuntime.MsgSendPtr({callArgStr});");

            if (m.HasErrorOut)
            {
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
            }

            sb.AppendLine($"        return ptr is not 0 ? new(ptr) : null;");
            sb.AppendLine("    }");
        }
        else if (m.ReturnType == "bool")
        {
            sb.AppendLine($"    public {staticKw}bool {ToPascalCase(m.Name)}({paramStr})");
            sb.AppendLine("    {");

            if (m.HasErrorOut)
            {
                sb.AppendLine($"        Bool8 result = ObjectiveCRuntime.MsgSendBool({callArgStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
                sb.AppendLine("        return result;");
            }
            else
            {
                sb.AppendLine($"        return ObjectiveCRuntime.MsgSendBool({callArgStr});");
            }

            sb.AppendLine("    }");
        }
        else if (knownEnums.Contains(m.ReturnType))
        {
            string msgSendMethod = GetEnumMsgSendMethod(m.ReturnType);
            sb.AppendLine($"    public {staticKw}{m.ReturnType} {ToPascalCase(m.Name)}({paramStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        return ({m.ReturnType})ObjectiveCRuntime.{msgSendMethod}({callArgStr});");
            sb.AppendLine("    }");
        }
        else if (HeaderParser.IsKnownValueStruct(m.ReturnType))
        {
            string msgSendMethod = $"MsgSend{m.ReturnType}";
            sb.AppendLine($"    public {staticKw}{m.ReturnType} {ToPascalCase(m.Name)}({paramStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        return ObjectiveCRuntime.{msgSendMethod}({callArgStr});");
            sb.AppendLine("    }");
        }
        else
        {
            // Primitive return
            string msgSendMethod = GetPrimitiveMsgSendMethod(m.ReturnType);
            string returnType = MapReturnType(m.ReturnType);
            sb.AppendLine($"    public {staticKw}{returnType} {ToPascalCase(m.Name)}({paramStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        return ObjectiveCRuntime.{msgSendMethod}({callArgStr});");
            sb.AppendLine("    }");
        }
    }

    private void GenerateSelectorClass(StringBuilder sb, ObjCClassDef c, string selectorClassName)
    {
        var selectors = new SortedDictionary<string, string>();

        // Collect from properties
        foreach (PropertyDef p in c.Properties)
        {
            if (p.GetSelector != null)
            {
                string name = ToPascalCase(SelectorToAccessorName(p.GetSelector));
                selectors.TryAdd(name, p.GetSelector);
            }

            if (p.SetSelector != null)
            {
                string name = ToPascalCase(SelectorToAccessorName(p.SetSelector));
                selectors.TryAdd(name, p.SetSelector);
            }
        }

        // Collect from instance methods (skip property selectors already added)
        HashSet<string> propertySelectors = GetPropertySelectors(c);
        foreach (MethodDef m in c.Methods)
        {
            if (propertySelectors.Contains(m.Selector))
                continue;

            string name = ToPascalCase(SelectorToAccessorName(m.Selector));
            selectors.TryAdd(name, m.Selector);
        }

        // Collect from static methods
        foreach (MethodDef m in c.StaticMethods)
        {
            string name = ToPascalCase(SelectorToAccessorName(m.Selector));
            selectors.TryAdd(name, m.Selector);
        }

        sb.AppendLine($"file static class {selectorClassName}");
        sb.AppendLine("{");

        bool first = true;
        foreach (var (name, selector) in selectors)
        {
            if (!first)
                sb.AppendLine();
            first = false;
            sb.AppendLine($"    public static readonly Selector {name} = Selector.Register(\"{selector}\");");
        }

        sb.AppendLine("}");
    }

    private void GenerateStubs(ParseResult parsed, HashSet<string> definedClasses)
    {
        HashSet<string> referencedTypes = [];

        foreach (ObjCClassDef c in parsed.Classes)
        {
            if (!string.IsNullOrEmpty(c.ParentClass))
                referencedTypes.Add(c.ParentClass);

            foreach (PropertyDef p in c.Properties)
            {
                if (IsObjCWrapper(p.Type))
                    referencedTypes.Add(p.Type);
            }

            foreach (MethodDef m in c.Methods.Concat(c.StaticMethods))
            {
                if (IsObjCWrapper(m.ReturnType))
                    referencedTypes.Add(m.ReturnType);

                foreach (ParamDef p in m.Parameters)
                {
                    if (IsObjCWrapper(p.Type))
                        referencedTypes.Add(p.Type);
                }
            }
        }

        // Exclude already defined and hand-written types
        HashSet<string> handWritten = ["NSString", "NSError", "NSArray", "NativeObject"];

        foreach (string type in referencedTypes)
        {
            if (definedClasses.Contains(type) || handWritten.Contains(type))
                continue;

            string folder = GetFolderForType(type);
            string dir = Path.Combine(outputDir, folder);
            string filePath = Path.Combine(dir, $"{type}.cs");

            if (File.Exists(filePath))
                continue;

            Directory.CreateDirectory(dir);

            var sb = new StringBuilder();
            sb.AppendLine("namespace Metal.NET;");
            sb.AppendLine();
            sb.AppendLine($"public class {type}(nint nativePtr) : NativeObject(nativePtr);");

            File.WriteAllText(filePath, sb.ToString());
        }
    }

    private void GenerateObjectiveCRuntime(ParseResult parsed)
    {
        // Collect all unique MsgSend signatures from all classes
        foreach (ObjCClassDef c in parsed.Classes)
        {
            foreach (PropertyDef p in c.Properties)
            {
                CollectPropertySignatures(p);
            }

            HashSet<string> propertySelectors = GetPropertySelectors(c);
            foreach (MethodDef m in c.Methods)
            {
                if (!propertySelectors.Contains(m.Selector))
                    CollectMsgSendSignature(m, isStatic: false);
            }

            foreach (MethodDef m in c.StaticMethods)
            {
                CollectMsgSendSignature(m, isStatic: true);
            }
        }

        string folder = Path.Combine(outputDir, "Common");
        Directory.CreateDirectory(folder);

        var sb = new StringBuilder();
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine("using System.Text;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();
        sb.AppendLine("internal static unsafe partial class ObjectiveCRuntime");
        sb.AppendLine("{");

        // Static constructor
        sb.AppendLine("    static ObjectiveCRuntime()");
        sb.AppendLine("    {");
        sb.AppendLine("        string[] frameworks =");
        sb.AppendLine("        [");
        sb.AppendLine("            \"CoreGraphics\",");
        sb.AppendLine("            \"QuartzCore\",");
        sb.AppendLine("            \"AppKit\",");
        sb.AppendLine("            \"Metal\",");
        sb.AppendLine("            \"MetalFX\",");
        sb.AppendLine("            \"MetalKit\"");
        sb.AppendLine("        ];");
        sb.AppendLine();
        sb.AppendLine("        foreach (string framework in frameworks)");
        sb.AppendLine("        {");
        sb.AppendLine("            NativeLibrary.TryLoad(framework, out _);");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine();

        // GetClass, RegisterName
        sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"objc_getClass\")]");
        sb.AppendLine("    public static partial nint GetClass(byte* name);");
        sb.AppendLine();
        sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"sel_registerName\")]");
        sb.AppendLine("    public static partial Selector RegisterName(byte* name);");
        sb.AppendLine();

        // Retain/Release helpers
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

        // GetClass(string)
        sb.AppendLine("    public static nint GetClass(string name)");
        sb.AppendLine("    {");
        sb.AppendLine("        fixed (byte* utf8 = Encoding.UTF8.GetBytes(name + '\\0'))");
        sb.AppendLine("        {");
        sb.AppendLine("            return GetClass(utf8);");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine();

        // AllocInit
        sb.AppendLine("    public static nint AllocInit(nint @class)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendPtr(MsgSendPtr(@class, Selector.Register(\"alloc\")), Selector.Register(\"init\"));");
        sb.AppendLine("    }");

        // MsgSend overloads grouped by return type
        var grouped = new SortedDictionary<string, SortedSet<string>>();
        foreach (string sig in msgSendSignatures)
        {
            // sig format: "ReturnType|ParamType1,ParamType2,..."
            int pipe = sig.IndexOf('|');
            string returnPart = sig[..pipe];
            string paramPart = sig[(pipe + 1)..];
            string methodName = GetMsgSendMethodName(returnPart);
            string regionName = methodName;

            if (!grouped.ContainsKey(regionName))
                grouped[regionName] = new SortedSet<string>(StringComparer.Ordinal);

            grouped[regionName].Add(sig);
        }

        foreach (var (region, sigs) in grouped)
        {
            sb.AppendLine();
            sb.AppendLine($"    #region {region}");

            foreach (string sig in sigs)
            {
                sb.AppendLine();
                int pipe = sig.IndexOf('|');
                string returnPart = sig[..pipe];
                string paramPart = sig[(pipe + 1)..];
                string methodName = GetMsgSendMethodName(returnPart);
                string returnTypeStr = GetMsgSendReturnType(returnPart);

                var paramParts = string.IsNullOrEmpty(paramPart)
                    ? []
                    : paramPart.Split(',').ToList();

                var paramDecls = new List<string> { "nint receiver", "Selector selector" };
                char letter = 'a';
                foreach (string pt in paramParts)
                {
                    if (pt == "out nint")
                    {
                        paramDecls.Add($"out nint {letter}");
                    }
                    else
                    {
                        paramDecls.Add($"{pt} {letter}");
                    }
                    letter++;
                }

                string paramDeclStr = string.Join(", ", paramDecls);

                sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"objc_msgSend\")]");
                sb.AppendLine($"    public static partial {returnTypeStr} {methodName}({paramDeclStr});");
            }

            sb.AppendLine();
            sb.AppendLine("    #endregion");
        }

        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(folder, "ObjectiveCRuntime.cs"), sb.ToString());
    }

    private void CollectPropertySignatures(PropertyDef p)
    {
        // Getter signature
        string getReturnSig = GetMsgSendReturnSig(p.Type);
        msgSendSignatures.Add($"{getReturnSig}|");

        // Setter signature
        if (!p.Readonly && p.SetSelector != null)
        {
            string setParamType = GetMsgSendParamType(p.Type);
            msgSendSignatures.Add($"void|{setParamType}");
        }
    }

    private void CollectMsgSendSignature(MethodDef m, bool isStatic)
    {
        string returnSig = GetMsgSendReturnSig(m.ReturnType);
        var paramTypes = new List<string>();

        foreach (ParamDef p in m.Parameters)
        {
            paramTypes.Add(GetMsgSendParamType(p.Type));
        }

        if (m.HasErrorOut)
        {
            paramTypes.Add("out nint");
        }

        string sig = $"{returnSig}|{string.Join(",", paramTypes)}";
        msgSendSignatures.Add(sig);
    }

    private string GetMsgSendReturnSig(string type)
    {
        if (type == "void") return "void";
        if (type == "bool") return "Bool8";
        if (IsObjCWrapper(type)) return "nint";
        if (type == "nint") return "nint";
        if (knownEnums.Contains(type)) return "ulong";
        if (HeaderParser.IsKnownValueStruct(type)) return type;

        return type switch
        {
            "nuint" => "nuint",
            "uint" => "uint",
            "ulong" => "ulong",
            "float" => "float",
            "double" => "double",
            _ => "nint"
        };
    }

    private string GetMsgSendParamType(string type)
    {
        if (IsObjCWrapper(type)) return "nint";
        if (type == "bool") return "Bool8";
        if (knownEnums.Contains(type)) return "ulong";
        if (HeaderParser.IsKnownValueStruct(type)) return type;

        return type switch
        {
            "nint" => "nint",
            "nuint" => "nuint",
            "uint" => "uint",
            "ulong" => "ulong",
            "float" => "float",
            "double" => "double",
            "byte" => "byte",
            _ => "nint"
        };
    }

    private static string GetMsgSendMethodName(string returnSig)
    {
        return returnSig switch
        {
            "void" => "MsgSend",
            "Bool8" => "MsgSendBool",
            "nint" => "MsgSendPtr",
            "nuint" => "MsgSendNUInt",
            "uint" => "MsgSendUInt",
            "ulong" => "MsgSendULong",
            "float" => "MsgSendFloat",
            "double" => "MsgSendDouble",
            _ when HeaderParser.IsKnownValueStruct(returnSig) => $"MsgSend{returnSig}",
            _ => "MsgSendPtr"
        };
    }

    private static string GetMsgSendReturnType(string returnSig)
    {
        return returnSig switch
        {
            "void" => "void",
            "Bool8" => "Bool8",
            "nint" => "nint",
            "nuint" => "nuint",
            "uint" => "uint",
            "ulong" => "ulong",
            "float" => "float",
            "double" => "double",
            _ => returnSig
        };
    }

    private string GetPrimitiveMsgSendMethod(string type)
    {
        return type switch
        {
            "nint" => "MsgSendPtr",
            "nuint" => "MsgSendNUInt",
            "uint" => "MsgSendUInt",
            "ulong" => "MsgSendULong",
            "float" => "MsgSendFloat",
            "double" => "MsgSendDouble",
            _ => "MsgSendPtr"
        };
    }

    private string GetEnumMsgSendMethod(string enumType)
    {
        // Most enums use ulong underlying type in Metal
        return "MsgSendULong";
    }

    private static string GetEnumCastType(string enumType)
    {
        return "ulong";
    }

    private static string MapReturnType(string type)
    {
        // The type is already mapped by HeaderParser, just return as-is
        return type;
    }

    private bool IsObjCWrapper(string type)
    {
        return HeaderParser.IsObjCWrapper(type) ||
               type is "NSString" or "NSArray" or "NSError" or "NSURL";
    }

    private static HashSet<string> GetPropertySelectors(ObjCClassDef c)
    {
        HashSet<string> selectors = [];
        foreach (PropertyDef p in c.Properties)
        {
            if (p.GetSelector != null)
                selectors.Add(p.GetSelector);
            if (p.SetSelector != null)
                selectors.Add(p.SetSelector);
        }
        return selectors;
    }

    private static string SelectorToAccessorName(string selector)
    {
        // Remove trailing colons and replace internal colons with descriptive parts
        // e.g. "newBufferWithLength:options:" → "NewBufferWithLengthOptions"
        // e.g. "setLabel:" → "SetLabel"
        // e.g. "device" → "Device"
        string cleaned = selector.TrimEnd(':');
        string[] parts = cleaned.Split(':');
        var sb = new StringBuilder();
        foreach (string part in parts)
        {
            if (part.Length > 0)
            {
                sb.Append(char.ToUpperInvariant(part[0]));
                sb.Append(part[1..]);
            }
        }
        return sb.ToString();
    }

    private static string ToPascalCase(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        // Handle names with underscores
        if (name.Contains('_'))
        {
            var sb = new StringBuilder();
            foreach (string part in name.Split('_'))
            {
                if (part.Length > 0)
                {
                    sb.Append(char.ToUpperInvariant(part[0]));
                    sb.Append(part[1..]);
                }
            }
            return sb.ToString();
        }

        // Already starts with uppercase or is a special prefix
        if (char.IsUpper(name[0]) || name.StartsWith("@"))
            return name;

        return char.ToUpperInvariant(name[0]) + name[1..];
    }

    private static string GetFolderForType(string typeName)
    {
        if (typeName.StartsWith("MTL4FX") || typeName.StartsWith("MTLFX"))
            return "MetalFX";
        if (typeName.StartsWith("CA"))
            return "QuartzCore";
        if (typeName.StartsWith("NS"))
            return "Foundation";
        return "Metal";
    }
}
