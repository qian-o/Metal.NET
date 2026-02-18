using System.Text.RegularExpressions;
using CppAst;

namespace Metal.NET.Generator;

/// <summary>
/// Parses metal-cpp C++ headers using CppAst (libclang) to produce binding definitions.
/// </summary>
public static partial class CppAstParser
{
    [GeneratedRegex(@"static\s+(\w+)\s*\*\s*alloc\s*\(\s*\)\s*;")]
    private static partial Regex AllocPattern();

    [GeneratedRegex(@"^namespace\s+(\w+)")]
    private static partial Regex NsPattern();

    private static readonly string[] SystemIncludes =
    [
        "/usr/include/c++/14",
        "/usr/include/x86_64-linux-gnu/c++/14",
        "/usr/lib/gcc/x86_64-linux-gnu/14/include",
        "/usr/include",
        "/usr/include/x86_64-linux-gnu",
    ];

    private static readonly HashSet<string> BindableNamespaces = ["MTL", "MTL4", "MTLFX", "CA"];

    private static readonly HashSet<string> NsNamespace = ["NS"];

    private static readonly Dictionary<string, string> OptionsTypedefs = [];

    private static readonly HashSet<string> AllocClasses = [];

    private static readonly HashSet<string> HandWrittenTypes = ["NSString", "NSError", "NSArray"];

    private static readonly HashSet<string> GeneratableNsClasses = ["NSURL"];

    private static readonly HashSet<string> ValueStructs =
    [
        "MTLOrigin", "MTLSize", "MTLRegion", "MTLViewport",
        "MTLScissorRect", "MTLClearColor", "MTLSamplePosition", "CGSize",
        "MTLSizeAndAlign", "MTLRange", "MTLResourceID",
        "MTLVertexAmplificationViewMapping",
        "MTL4Origin", "MTL4Size", "MTL4Range", "MTL4BufferRange",
        "MTL4CopySparseBufferMappingOperation", "MTL4CopySparseTextureMappingOperation",
        "MTL4UpdateSparseBufferMappingOperation", "MTL4UpdateSparseTextureMappingOperation",
        "NSRange",
    ];

    private static readonly HashSet<string> KnownWrapperTypes =
    [
        "MTLFunction", "MTLCompileOptions", "MTLComputePipelineState",
        "MTLRenderPipelineState", "MTLDepthStencilState", "MTLSamplerState",
        "MTLFence", "MTLRenderPassDescriptor", "MTLVertexDescriptor",
        "MTLRenderPipelineColorAttachmentDescriptor",
        "MTLRenderPipelineColorAttachmentDescriptorArray",
        "MTLRenderPassColorAttachmentDescriptor",
        "MTLRenderPassColorAttachmentDescriptorArray",
        "MTLRenderPassDepthAttachmentDescriptor",
        "MTLRenderPassStencilAttachmentDescriptor",
        "MTLVertexBufferLayoutDescriptor",
        "MTLVertexBufferLayoutDescriptorArray",
        "MTLVertexAttributeDescriptor",
        "MTLVertexAttributeDescriptorArray",
        "MTLStencilDescriptor",
        "MTL4PipelineState", "MTL4CommandBufferOptions", "MTL4CompilerTaskOptions",
        "MTL4CommitOptions",
        "MTLLogState", "MTLLogContainer",
        "MTLLinkedFunctions",
        "MTLArrayType", "MTLStructType", "MTLPointerType", "MTLType",
        "MTLTextureReferenceType", "MTLTensorReferenceType",
        "MTLCaptureScope", "MTLCounterSet", "MTLResidencySet",
        "MTLComputePipelineReflection", "MTLRenderPipelineReflection",
        "MTLFunctionReflection",
        "MTL4BinaryFunction", "MTL4MachineLearningPipelineState",
        "MTL4MachineLearningPipelineReflection", "MTL4PipelineOptions",
        "MTLFunctionLogDebugLocation",
    ];

    private static readonly HashSet<string> CSharpKeywords =
    [
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
        "char", "checked", "class", "const", "continue", "decimal", "default",
        "delegate", "do", "double", "else", "enum", "event", "explicit",
        "extern", "false", "finally", "fixed", "float", "for", "foreach",
        "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
        "lock", "long", "namespace", "new", "null", "object", "operator",
        "out", "override", "params", "private", "protected", "public",
        "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof",
        "stackalloc", "static", "string", "struct", "switch", "this", "throw",
        "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe",
        "ushort", "using", "virtual", "void", "volatile", "while",
    ];

    /// <summary>
    /// Parse all metal-cpp headers from the given directory and produce
    /// enums, classes, and free function definitions.
    /// </summary>
    public static ParseResult Parse(string metalCppDir, string stubsDir)
    {
        ParseResult result = new();
        OptionsTypedefs.Clear();

        ScanAllocClasses(metalCppDir);

        List<string> systemIncludes = [];

        foreach (string dir in SystemIncludes)
        {
            if (Directory.Exists(dir))
            {
                systemIncludes.Add(dir);
            }
        }

        if (systemIncludes.Count == 0)
        {
            foreach (string ver in new[] { "14", "13", "12", "11" })
            {
                string dir = $"/usr/include/c++/{ver}";

                if (Directory.Exists(dir))
                {
                    systemIncludes.Add(dir);

                    string archDir = $"/usr/include/x86_64-linux-gnu/c++/{ver}";

                    if (Directory.Exists(archDir))
                    {
                        systemIncludes.Add(archDir);
                    }

                    string gccDir = $"/usr/lib/gcc/x86_64-linux-gnu/{ver}/include";

                    if (Directory.Exists(gccDir))
                    {
                        systemIncludes.Add(gccDir);
                    }

                    break;
                }
            }

            if (Directory.Exists("/usr/include"))
            {
                systemIncludes.Add("/usr/include");
            }

            string xDir = "/usr/include/x86_64-linux-gnu";

            if (Directory.Exists(xDir))
            {
                systemIncludes.Add(xDir);
            }
        }

        List<string> umbrellaHeaders = [];

        string metalHpp = Path.Combine(metalCppDir, "Metal", "Metal.hpp");

        if (File.Exists(metalHpp))
        {
            umbrellaHeaders.Add(metalHpp);
        }

        string foundationHpp = Path.Combine(metalCppDir, "Foundation", "Foundation.hpp");

        if (File.Exists(foundationHpp))
        {
            umbrellaHeaders.Add(foundationHpp);
        }

        string quartzHpp = Path.Combine(metalCppDir, "QuartzCore", "QuartzCore.hpp");

        if (File.Exists(quartzHpp))
        {
            umbrellaHeaders.Add(quartzHpp);
        }

        string mtlfxDir = Path.Combine(metalCppDir, "MetalFX");

        if (Directory.Exists(mtlfxDir))
        {
            string mtlfxHpp = Path.Combine(mtlfxDir, "MetalFX.hpp");

            if (File.Exists(mtlfxHpp))
            {
                umbrellaHeaders.Add(mtlfxHpp);
            }
            else
            {
                foreach (string f in Directory.GetFiles(mtlfxDir, "*.hpp"))
                {
                    umbrellaHeaders.Add(f);
                }
            }
        }

        foreach (string hppPath in umbrellaHeaders)
        {
            CppParserOptions options = new()
            {
                ParseSystemIncludes = false,
                ParseMacros = true,
            };

            options.IncludeFolders.Add(metalCppDir);
            options.IncludeFolders.Add(stubsDir);

            foreach (string inc in systemIncludes)
            {
                options.SystemIncludeFolders.Add(inc);
            }

            options.AdditionalArguments.Add("-xc++");
            options.AdditionalArguments.Add("-std=c++17");
            options.AdditionalArguments.Add("-fblocks");
            options.AdditionalArguments.Add("-Wno-everything");

            CppCompilation compilation = CppParser.ParseFile(hppPath, options);

            if (compilation.HasErrors)
            {
                foreach (CppDiagnosticMessage msg in compilation.Diagnostics.Messages)
                {
                    if (msg.Type == CppLogMessageType.Error)
                    {
                        Console.Error.WriteLine($"  CppAst error in {Path.GetFileName(hppPath)}: {msg}");
                    }
                }

                continue;
            }

            foreach (CppNamespace ns in compilation.Namespaces)
            {
                WalkNamespaceEnums(ns, result);
            }

            foreach (CppNamespace ns in compilation.Namespaces)
            {
                WalkNamespaceClasses(ns, result);
            }
        }

        result.Deduplicate();

        return result;
    }

    /// <summary>
    /// Pre-scan C++ headers to build a set of classes that have static alloc() methods.
    /// </summary>
    private static void ScanAllocClasses(string metalCppDir)
    {
        AllocClasses.Clear();

        foreach (string dir in new[] { "Metal", "MetalFX", "QuartzCore", "Foundation" })
        {
            string fullDir = Path.Combine(metalCppDir, dir);

            if (!Directory.Exists(fullDir))
            {
                continue;
            }

            foreach (string file in Directory.GetFiles(fullDir, "*.hpp"))
            {
                string currentNs = "";

                foreach (string line in File.ReadLines(file))
                {
                    Match nsMatch = NsPattern().Match(line);

                    if (nsMatch.Success)
                    {
                        currentNs = nsMatch.Groups[1].Value;

                        continue;
                    }

                    Match allocMatch = AllocPattern().Match(line);

                    if (allocMatch.Success && !string.IsNullOrEmpty(currentNs))
                    {
                        AllocClasses.Add($"{currentNs}::{allocMatch.Groups[1].Value}");
                    }
                }
            }
        }
    }

    private static string NamespaceToPrefix(string ns) => ns switch
    {
        "MTL" => "MTL",
        "MTL4" => "MTL4",
        "MTLFX" => "MTLFX",
        "CA" => "CA",
        "NS" => "NS",
        _ => ns,
    };

    private static string ResolvePrefix(string? parentNs, string fallbackPrefix)
    {
        if (string.IsNullOrEmpty(parentNs))
        {
            return fallbackPrefix;
        }

        return parentNs switch
        {
            "MTL" or "MTL4" or "MTLFX" or "CA" or "NS" => NamespaceToPrefix(parentNs),
            _ => fallbackPrefix,
        };
    }

    private static string NamespaceToFolder(string ns) => ns switch
    {
        "MTL" or "MTL4" => "Metal",
        "CA" => "QuartzCore",
        "NS" => "Foundation",
        "MTLFX" => "MetalFX",
        _ => "Metal",
    };

    private static void WalkNamespaceEnums(CppNamespace ns, ParseResult result)
    {
        string nsName = ns.Name;

        if (BindableNamespaces.Contains(nsName))
        {
            foreach (CppEnum cppEnum in ns.Enums)
            {
                EnumDef? enumDef = ConvertEnum(cppEnum, nsName);

                if (enumDef != null)
                {
                    enumDef.Folder = NamespaceToFolder(nsName);
                    result.Enums.Add(enumDef);
                }
            }
        }

        foreach (CppNamespace child in ns.Namespaces)
        {
            if (child.Name == "Private")
            {
                continue;
            }

            WalkNamespaceEnums(child, result);
        }
    }

    private static void WalkNamespaceClasses(CppNamespace ns, ParseResult result)
    {
        string nsName = ns.Name;

        if (BindableNamespaces.Contains(nsName))
        {
            foreach (CppClass cppClass in ns.Classes)
            {
                if (cppClass.ClassKind == CppClassKind.Struct
                    && cppClass.Functions.Count <= 1
                    && cppClass.Fields.Count > 0
                    && cppClass.BaseTypes.Count == 0)
                {
                    continue;
                }

                string checkName = $"{NamespaceToPrefix(nsName)}{cppClass.Name}";

                if (ValueStructs.Contains(checkName))
                {
                    continue;
                }

                ObjCClassDef? classDef = ConvertClass(cppClass, nsName);

                if (classDef != null)
                {
                    classDef.Folder = NamespaceToFolder(nsName);
                    result.Classes.Add(classDef);
                }
            }

            foreach (CppFunction cppFunc in ns.Functions)
            {
                FreeFunctionDef? freeDef = ConvertFreeFunction(cppFunc, nsName);

                if (freeDef != null)
                {
                    result.FreeFunctions.Add(freeDef);
                }
            }
        }
        else if (NsNamespace.Contains(nsName))
        {
            foreach (CppClass cppClass in ns.Classes)
            {
                string fullName = $"NS{cppClass.Name}";

                if (!GeneratableNsClasses.Contains(fullName))
                {
                    continue;
                }

                if (HandWrittenTypes.Contains(fullName))
                {
                    continue;
                }

                ObjCClassDef? classDef = ConvertClass(cppClass, nsName);

                if (classDef != null)
                {
                    classDef.Folder = NamespaceToFolder(nsName);
                    result.Classes.Add(classDef);
                }
            }
        }

        foreach (CppNamespace child in ns.Namespaces)
        {
            if (child.Name == "Private")
            {
                continue;
            }

            WalkNamespaceClasses(child, result);
        }
    }

    private static EnumDef? ConvertEnum(CppEnum cppEnum, string ns)
    {
        string prefix = NamespaceToPrefix(ns);
        string enumName;
        string underlyingType;

        if (!string.IsNullOrEmpty(cppEnum.Name))
        {
            enumName = cppEnum.Name;
            underlyingType = MapEnumUnderlyingType(cppEnum.IntegerType);
        }
        else
        {
            string? intTypeName = cppEnum.IntegerType?.GetDisplayName();

            if (string.IsNullOrEmpty(intTypeName))
            {
                return null;
            }

            enumName = intTypeName;
            underlyingType = MapEnumUnderlyingType(cppEnum.IntegerType);
        }

        string fullName = $"{prefix}{enumName}";
        bool isFlags = string.IsNullOrEmpty(cppEnum.Name);

        if (isFlags)
        {
            OptionsTypedefs[$"{ns}.{enumName}"] = fullName;
        }

        EnumDef enumDef = new()
        {
            Name = fullName,
            UnderlyingType = underlyingType,
            IsFlags = isFlags,
        };

        HashSet<string> seen = [];

        foreach (CppEnumItem item in cppEnum.Items)
        {
            string memberName = item.Name;

            if (memberName.Length > 0 && char.IsDigit(memberName[0]))
            {
                memberName = $"_{memberName}";
            }

            if (string.IsNullOrEmpty(memberName))
            {
                memberName = item.Name;
            }

            if (!seen.Add(memberName))
            {
                continue;
            }

            string? exprText = item.ValueExpression?.ToString();
            string value;

            if (item.Value < 0 && !string.IsNullOrEmpty(exprText) && long.TryParse(exprText, out long parsedValue) && parsedValue >= 0)
            {
                value = exprText;
            }
            else
            {
                value = item.Value.ToString();
            }

            if (item.Value < 0
                && value == item.Value.ToString()
                && (underlyingType == "ulong" || underlyingType == "uint" || underlyingType == "ushort" || underlyingType == "byte"))
            {
                if (underlyingType == "ulong")
                {
                    value = unchecked((ulong)item.Value).ToString();
                }
                else if (underlyingType == "uint")
                {
                    value = unchecked((uint)item.Value).ToString();
                }
                else if (underlyingType == "ushort")
                {
                    value = unchecked((ushort)item.Value).ToString();
                }
                else
                {
                    value = unchecked((byte)item.Value).ToString();
                }
            }

            enumDef.Members.Add(new EnumMemberDef
            {
                Name = memberName,
                Value = value,
            });
        }

        return enumDef.Members.Count > 0 ? enumDef : null;
    }

    private static string MapEnumUnderlyingType(CppType? type)
    {
        if (type == null)
        {
            return "uint";
        }

        while (type is CppTypedef td)
        {
            type = td.ElementType;
        }

        type = UnwrapType(type);

        string displayName = type.GetDisplayName();

        return displayName switch
        {
            "UInteger" or "NS::UInteger" or "unsigned long" or "unsigned long long" => "ulong",
            "Integer" or "NS::Integer" or "long" or "long long" => "long",
            "unsigned int" or "uint32_t" => "uint",
            "int" or "int32_t" => "int",
            "unsigned short" or "uint16_t" => "ushort",
            "short" or "int16_t" => "short",
            "unsigned char" or "uint8_t" => "byte",
            "char" or "int8_t" => "sbyte",
            _ => "uint",
        };
    }

    private static ObjCClassDef? ConvertClass(CppClass cppClass, string ns)
    {
        if (string.IsNullOrEmpty(cppClass.Name))
        {
            return null;
        }

        if (cppClass.Name == "Private" || cppClass.Name.Contains('<'))
        {
            return null;
        }

        if (cppClass.Name.StartsWith('_'))
        {
            return null;
        }

        string prefix = NamespaceToPrefix(ns);
        string fullName = $"{prefix}{cppClass.Name}";

        if (HandWrittenTypes.Contains(fullName))
        {
            return null;
        }

        bool isClass = cppClass.Functions.Any(fn =>
            fn.StorageQualifier == CppStorageQualifier.Static &&
            fn.Name == "alloc" &&
            fn.Parameters.Count == 0)
            || AllocClasses.Contains($"{ns}::{cppClass.Name}");

        string? objCClass = isClass ? fullName : null;

        ObjCClassDef def = new()
        {
            Name = fullName,
            IsClass = isClass,
            ObjCClass = objCClass,
        };

        HashSet<string> methodSigs = [];
        HashSet<string> potentialPropertyNames = [];
        HashSet<string> addedPropertyNames = [];

        foreach (CppFunction fn in cppClass.Functions)
        {
            if (fn.Visibility != CppVisibility.Public)
            {
                continue;
            }

            if (fn.StorageQualifier == CppStorageQualifier.Static)
            {
                continue;
            }

            if (fn.Parameters.Count != 0)
            {
                continue;
            }

            if (fn.Name.StartsWith("new") || fn.Name == "init" || fn.Name == "alloc")
            {
                continue;
            }

            if (fn.Name == cppClass.Name || fn.Name.StartsWith('~') || fn.Name.StartsWith("operator"))
            {
                continue;
            }

            string? retType = MapType(fn.ReturnType, ns, prefix);

            if (retType == null || retType == "void")
            {
                continue;
            }

            string pcName = char.ToUpperInvariant(fn.Name[0]) + fn.Name[1..];
            potentialPropertyNames.Add(pcName);
        }

        foreach (CppFunction fn in cppClass.Functions)
        {
            if (fn.Name == cppClass.Name || fn.Name.StartsWith('~') || fn.Name.StartsWith("operator"))
            {
                continue;
            }

            if (fn.Visibility != CppVisibility.Public)
            {
                continue;
            }

            if (fn.Name == "init" || fn.Name == "alloc")
            {
                continue;
            }

            bool isStatic = fn.StorageQualifier == CppStorageQualifier.Static;

            MethodDef? methodDef = ConvertMethod(fn, ns, prefix);

            if (methodDef == null)
            {
                continue;
            }

            string pcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name[1..];
            string sig = $"{(isStatic ? "s:" : "")}{pcName}({string.Join(",", methodDef.Parameters.Select(p => p.Type))})";

            if (!methodSigs.Add(sig))
            {
                continue;
            }

            bool isProperty = fn.Parameters.Count == 0
                && methodDef.ReturnType != "void"
                && !fn.Name.StartsWith("new")
                && !isStatic;

            bool hasSetter = false;
            string setterName = $"set{Capitalize(fn.Name)}";

            if (isProperty)
            {
                hasSetter = cppClass.Functions.Any(f =>
                    f.Name == setterName && f.Parameters.Count == 1 && f.Visibility == CppVisibility.Public);
            }

            if (isProperty && !isStatic)
            {
                string propPcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name[1..];

                if (addedPropertyNames.Add(propPcName))
                {
                    def.Properties.Add(new PropertyDef
                    {
                        Name = fn.Name,
                        Type = methodDef.ReturnType,
                        Readonly = !hasSetter,
                        GetSelector = fn.Name,
                        SetSelector = hasSetter ? $"set{Capitalize(fn.Name)}:" : null,
                    });
                }
            }
            else
            {
                if (fn.Name.StartsWith("set") && fn.Name.Length > 3 && char.IsUpper(fn.Name[3])
                    && fn.Parameters.Count == 1)
                {
                    string propPcName = fn.Name[3..];

                    if (potentialPropertyNames.Contains(propPcName))
                    {
                        continue;
                    }
                }

                string methodPcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name[1..];

                if (potentialPropertyNames.Contains(methodPcName))
                {
                    continue;
                }

                if (isStatic)
                {
                    def.StaticMethods.Add(methodDef);
                }
                else
                {
                    def.Methods.Add(methodDef);
                }
            }
        }

        return def;
    }

    private static MethodDef? ConvertMethod(CppFunction fn, string ns, string prefix)
    {
        string? retType = MapType(fn.ReturnType, ns, prefix);

        if (retType == null)
        {
            return null;
        }

        string selector = BuildSelector(fn);

        MethodDef methodDef = new()
        {
            Name = fn.Name,
            Selector = selector,
            ReturnType = retType,
        };

        bool hasErrorOut = false;

        foreach (CppParameter param in fn.Parameters)
        {
            if (IsErrorOutParam(param))
            {
                hasErrorOut = true;

                continue;
            }

            string? paramType = MapType(param.Type, ns, prefix);

            if (paramType == null)
            {
                return null;
            }

            string paramName = string.IsNullOrEmpty(param.Name) ? $"param{methodDef.Parameters.Count}" : param.Name;

            if (CSharpKeywords.Contains(paramName))
            {
                paramName = $"@{paramName}";
            }

            methodDef.Parameters.Add(new ParamDef
            {
                Name = paramName,
                Type = paramType,
            });
        }

        methodDef.HasErrorOut = hasErrorOut;

        return methodDef;
    }

    private static string BuildSelector(CppFunction fn)
    {
        if (fn.Parameters.Count == 0)
        {
            return fn.Name;
        }

        List<string> parts = [fn.Name];

        for (int i = 1; i < fn.Parameters.Count; i++)
        {
            string pName = fn.Parameters[i].Name;

            if (string.IsNullOrEmpty(pName))
            {
                pName = $"param{i}";
            }

            parts.Add(pName);
        }

        return string.Join(":", parts) + ":";
    }

    private static bool IsErrorOutParam(CppParameter param)
    {
        CppType type = param.Type;

        if (type is CppPointerType ptr1 && ptr1.ElementType is CppPointerType ptr2)
        {
            CppType innerType = UnwrapType(ptr2.ElementType);

            if (innerType is CppClass cls && cls.Name == "Error")
            {
                return true;
            }
        }

        return false;
    }

    private static FreeFunctionDef? ConvertFreeFunction(CppFunction fn, string ns)
    {
        string prefix = NamespaceToPrefix(ns);

        string? retType = MapType(fn.ReturnType, ns, prefix);

        if (retType == null)
        {
            return null;
        }

        string nativeName = $"{prefix}{fn.Name}";
        string? targetClass = MapFreeFunctionTarget(fn.Name, prefix);

        if (targetClass == null)
        {
            return null;
        }

        FreeFunctionDef def = new()
        {
            NativeName = nativeName,
            Name = fn.Name,
            ReturnType = retType,
            TargetClass = targetClass,
            FrameworkLibrary = "/System/Library/Frameworks/Metal.framework/Metal",
        };

        foreach (CppParameter param in fn.Parameters)
        {
            string? paramType = MapType(param.Type, ns, prefix);

            if (paramType == null)
            {
                return null;
            }

            string paramName = string.IsNullOrEmpty(param.Name) ? $"param{def.Parameters.Count}" : param.Name;

            if (CSharpKeywords.Contains(paramName))
            {
                paramName = $"@{paramName}";
            }

            def.Parameters.Add(new ParamDef
            {
                Name = paramName,
                Type = paramType,
            });
        }

        return def;
    }

    private static string? MapFreeFunctionTarget(string funcName, string prefix)
    {
        if (funcName.Contains("Device"))
        {
            return $"{prefix}Device";
        }

        if (funcName.Contains("Counter"))
        {
            return $"{prefix}Device";
        }

        return null;
    }

    /// <summary>
    /// Map a CppAst type to a C# type string.
    /// Returns null if the type is unsupported (blocks, std::function, etc.).
    /// </summary>
    private static string? MapType(CppType? type, string ns, string prefix)
    {
        if (type == null)
        {
            return null;
        }

        type = UnwrapType(type);

        if (type is CppPrimitiveType prim)
        {
            return prim.Kind switch
            {
                CppPrimitiveKind.Void => "void",
                CppPrimitiveKind.Bool => "Bool8",
                CppPrimitiveKind.Char => "byte",
                CppPrimitiveKind.Short => "short",
                CppPrimitiveKind.Int => "int",
                CppPrimitiveKind.LongLong => "nint",
                CppPrimitiveKind.UnsignedChar => "byte",
                CppPrimitiveKind.UnsignedShort => "ushort",
                CppPrimitiveKind.UnsignedInt => "uint",
                CppPrimitiveKind.UnsignedLongLong => "nuint",
                CppPrimitiveKind.Float => "float",
                CppPrimitiveKind.Double => "double",
                CppPrimitiveKind.Long => "nint",
                CppPrimitiveKind.UnsignedLong => "nuint",
                _ => null,
            };
        }

        if (type is CppPointerType ptr)
        {
            CppType elem = UnwrapType(ptr.ElementType);

            if (elem is CppPrimitiveType { Kind: CppPrimitiveKind.Void })
            {
                return "nint";
            }

            if (elem is CppPrimitiveType { Kind: CppPrimitiveKind.Char })
            {
                return "nint";
            }

            if (elem is CppClass cls)
            {
                return MapClassName(cls.Name, cls, prefix);
            }

            if (elem is CppEnum)
            {
                return "nint";
            }

            if (elem is CppFunctionType)
            {
                return null;
            }

            return "nint";
        }

        if (type is CppReferenceType refType)
        {
            CppType elem = UnwrapType(refType.ElementType);

            if (elem is CppPrimitiveType { Kind: CppPrimitiveKind.Char })
            {
                return "nint";
            }

            return MapType(new CppPointerType(refType.ElementType), ns, prefix);
        }

        if (type is CppClass classType)
        {
            return MapClassName(classType.Name, classType, prefix);
        }

        if (type is CppEnum enumType)
        {
            return MapEnumName(enumType.Name, enumType, prefix);
        }

        if (type is CppTypedef td)
        {
            string tdName = td.Name;

            if (tdName == "UInteger") return "nuint";
            if (tdName == "Integer") return "nint";
            if (tdName == "CFTimeInterval") return "double";
            if (tdName == "IOSurfaceRef") return "nint";
            if (tdName == "CGColorSpaceRef") return "nint";
            if (tdName == "dispatch_queue_t") return "nint";
            if (tdName == "dispatch_data_t") return "nint";
            if (tdName == "task_id_token_t") return "nint";
            if (tdName == "kern_return_t") return "uint";
            if (tdName == "CGSize") return "CGSize";

            string? parentNs = td.FullParentName;

            if (!string.IsNullOrEmpty(parentNs))
            {
                string key = $"{parentNs}.{tdName}";

                if (OptionsTypedefs.TryGetValue(key, out string? enumTypeName))
                {
                    return enumTypeName;
                }
            }

            return MapType(td.ElementType, ns, prefix);
        }

        if (type is CppBlockFunctionType)
        {
            return null;
        }

        if (type is CppUnexposedType unexposed)
        {
            string name = unexposed.GetDisplayName();

            if (name.Contains("function") || name.Contains("block") || name.Contains("Block"))
            {
                return null;
            }

            return "nint";
        }

        if (type is CppArrayType)
        {
            return null;
        }

        return null;
    }

    private static CppType UnwrapType(CppType type)
    {
        while (type is CppQualifiedType qualified)
        {
            type = qualified.ElementType;
        }

        return type;
    }

    private static string? MapClassName(string name, CppClass cls, string prefix)
    {
        if (name == "String") return "NSString";
        if (name == "Error") return "NSError";
        if (name == "Array") return "NSArray";
        if (name == "URL") return "NSURL";
        if (name == "Number") return "nint";
        if (name == "Data") return "nint";
        if (name == "Dictionary") return "nint";
        if (name == "Object") return "nint";
        if (name == "Bundle") return "nint";
        if (name == "Notification") return "nint";
        if (name == "ProcessInfo") return "nint";
        if (name == "Set") return "nint";
        if (name == "CGSize") return "CGSize";
        if (name == "float4x4") return "nint";

        if (name == "Texture")
        {
            string? parentNs = cls.FullParentName;

            if (parentNs == "CA")
            {
                return "nint";
            }
        }

        string actualPrefix = ResolvePrefix(cls.FullParentName, prefix);
        string fullName = $"{actualPrefix}{name}";

        if (name.StartsWith("MTL") || name.StartsWith("CA") || name.StartsWith("NS") || name.StartsWith("MTLFX"))
        {
            fullName = name;
        }

        if (ValueStructs.Contains(fullName))
        {
            return fullName;
        }

        if (name == "Referencing" || name == "Copying" || name == "SecureCoding" || name == "_Base")
        {
            return null;
        }

        if (name == "Architecture" || name == "AccelerationStructureSizes")
        {
            return "nint";
        }

        return fullName;
    }

    private static string MapEnumName(string name, CppEnum cppEnum, string prefix)
    {
        if (name.StartsWith("MTL") || name.StartsWith("CA") || name.StartsWith("NS"))
        {
            return name;
        }

        string actualPrefix = ResolvePrefix(cppEnum.FullParentName, prefix);

        return $"{actualPrefix}{name}";
    }

    private static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        return char.ToUpperInvariant(s[0]) + s[1..];
    }

    public static bool IsKnownValueStruct(string type) => ValueStructs.Contains(type);

    public static bool IsObjCWrapper(string type)
    {
        if (ValueStructs.Contains(type) || IsLikelyEnum(type))
        {
            return false;
        }

        return type.StartsWith("MTL") || type.StartsWith("NS") || type.StartsWith("CA");
    }

    public static bool IsLikelyEnum(string type)
    {
        if (KnownWrapperTypes.Contains(type))
        {
            return false;
        }

        if (ValueStructs.Contains(type))
        {
            return false;
        }

        if (!type.StartsWith("MTL"))
        {
            return false;
        }

        return type.Contains("Format")
            || type.EndsWith("Action") || type.EndsWith("Mode") || type.EndsWith("Type")
            || type.EndsWith("Function") || type.EndsWith("Operation") || type.EndsWith("Factor")
            || type.EndsWith("Mask") || type.EndsWith("Options") || type.EndsWith("Filter")
            || type.EndsWith("Usage") || type.EndsWith("Version") || type.EndsWith("Status")
            || type.EndsWith("Set") || type.EndsWith("Winding") || type.EndsWith("Granularity")
            || type.EndsWith("Stages") || type.EndsWith("State") || type.EndsWith("Tier")
            || type.EndsWith("Scope") || type.EndsWith("Access") || type.EndsWith("Level")
            || type.EndsWith("Layout") || type.EndsWith("Destination") || type.EndsWith("Point")
            || type.EndsWith("Basis") || type.EndsWith("Caps") || type.EndsWith("Visibility")
            || type.EndsWith("Family") || type.EndsWith("Priority") || type.EndsWith("Method")
            || type.EndsWith("Mutability") || type.EndsWith("Class") || type.EndsWith("Color")
            || type.EndsWith("Option") || type.EndsWith("Validation") || type.EndsWith("Signature")
            || type.EndsWith("Functions") || type.EndsWith("Configuration") || type.EndsWith("Reflection")
            || type.EndsWith("Location") || type.EndsWith("PageSize");
    }

    public static bool IsCSharpKeyword(string name) => CSharpKeywords.Contains(name);
}

/// <summary>Result of parsing all metal-cpp headers.</summary>
public class ParseResult
{
    public List<EnumDef> Enums { get; } = [];

    public List<ObjCClassDef> Classes { get; } = [];

    public List<FreeFunctionDef> FreeFunctions { get; } = [];

    public void Deduplicate()
    {
        Dictionary<string, EnumDef> seenEnums = [];

        foreach (EnumDef e in Enums)
        {
            if (!seenEnums.ContainsKey(e.Name))
            {
                seenEnums[e.Name] = e;
            }
        }

        Enums.Clear();
        Enums.AddRange(seenEnums.Values);

        Dictionary<string, ObjCClassDef> seenClasses = [];

        foreach (ObjCClassDef c in Classes)
        {
            if (!seenClasses.ContainsKey(c.Name))
            {
                seenClasses[c.Name] = c;
            }
        }

        Classes.Clear();
        Classes.AddRange(seenClasses.Values);

        Dictionary<string, FreeFunctionDef> seenFuncs = [];

        foreach (FreeFunctionDef f in FreeFunctions)
        {
            if (!seenFuncs.ContainsKey(f.NativeName))
            {
                seenFuncs[f.NativeName] = f;
            }
        }

        FreeFunctions.Clear();
        FreeFunctions.AddRange(seenFuncs.Values);
    }
}
