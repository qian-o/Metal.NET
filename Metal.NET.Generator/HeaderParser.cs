using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Parses metal-cpp C++ headers using regex/string processing to produce binding definitions.
/// Does not depend on CppAst or libclang.
/// </summary>
public static partial class HeaderParser
{
    [GeneratedRegex(@"static\s+(\w+)\s*\*\s*alloc\s*\(\s*\)\s*;")]
    private static partial Regex AllocPattern();

    [GeneratedRegex(@"^namespace\s+(\w+)")]
    private static partial Regex NsPattern();

    [GeneratedRegex(@"_(MTL|NS|CA|MTLFX)_ENUM\s*\(\s*(.+?)\s*,\s*(\w+)\s*\)")]
    private static partial Regex EnumMacroPattern();

    [GeneratedRegex(@"_(MTL|NS|CA|MTLFX)_OPTIONS\s*\(\s*(.+?)\s*,\s*(\w+)\s*\)")]
    private static partial Regex OptionsMacroPattern();

    [GeneratedRegex(@"^\s*(\w+)\s*=\s*(.+?)\s*,?\s*$")]
    private static partial Regex EnumMemberWithValuePattern();

    [GeneratedRegex(@"^\s*(\w+)\s*,?\s*$")]
    private static partial Regex EnumMemberNoValuePattern();

    [GeneratedRegex(@"_(MTL|NS|CA|MTLFX)_PRIVATE_DEF_SEL\s*\(\s*(\w+)\s*,")]
    private static partial Regex DefSelAccessorPattern();

    [GeneratedRegex(@"_(MTL|NS|CA|MTLFX)_PRIVATE_DEF_CLS\s*\(\s*(\w+)\s*\)")]
    private static partial Regex DefClsPattern();

    [GeneratedRegex(@"_(MTL|NS|CA|MTLFX)_INLINE\s+(.+?)\s+(\w+)::(\w+)::(\w+)\s*\(")]
    private static partial Regex InlineImplPattern();

    [GeneratedRegex(@"_(MTL|NS|CA|MTLFX)_PRIVATE_SEL\s*\(\s*(\w+)\s*\)")]
    private static partial Regex PrivateSelUsagePattern();

    [GeneratedRegex(@"class\s+(\w+)\s*:\s*public\s+(.+)")]
    private static partial Regex ClassDeclPattern();

    [GeneratedRegex(@"extern\s+""C""\s+(.+?)\s+(\w+)\s*\((.*?)\)\s*;")]
    private static partial Regex ExternCPattern();

    [GeneratedRegex(@"^(\d+)\s*<<\s*(\d+)$")]
    private static partial Regex ShiftExprPattern();

    [GeneratedRegex(@"(0[xX][0-9a-fA-F]+|[0-9]+)(ULL|ull|UL|ul|LL|ll|U|u|L|l)\b")]
    private static partial Regex IntegerSuffixPattern();

    private static readonly HashSet<string> BindableNamespaces = ["MTL", "MTL4", "MTLFX", "CA"];

    private static readonly HashSet<string> NsNamespace = ["NS"];

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
    public static ParseResult Parse(string metalCppDir)
    {
        ParseResult result = new();

        HashSet<string> allocClasses = ScanAllocClasses(metalCppDir);

        // Phase 1: Build accessor → selector map from HeaderBridge/Private files
        Dictionary<string, string> selectorMap = BuildSelectorMap(metalCppDir);

        // Phase 2: Build set of ObjC-registered class names from CLS macros
        HashSet<string> clsRegistrations = BuildClsRegistrations(metalCppDir);

        // Phase 3: Build inline implementation map: (ns, class, method) → accessor
        Dictionary<string, string> inlineMap = BuildInlineMap(metalCppDir);

        // Phase 4-8: Parse all .hpp files
        foreach (string dir in new[] { "Metal", "MetalFX", "QuartzCore", "Foundation" })
        {
            string fullDir = Path.Combine(metalCppDir, dir);

            if (!Directory.Exists(fullDir))
            {
                continue;
            }

            foreach (string file in Directory.GetFiles(fullDir, "*.hpp"))
            {
                string fileName = Path.GetFileName(file);

                if (fileName.EndsWith("Private.hpp") || fileName.EndsWith("Defines.hpp")
                    || fileName.EndsWith("HeaderBridge.hpp"))
                {
                    continue;
                }

                string content = File.ReadAllText(file);
                string[] lines = File.ReadAllLines(file);

                ParseEnums(content, lines, result);
                ParseClasses(lines, allocClasses, clsRegistrations, selectorMap, inlineMap, result);
                ParseFreeFunctions(lines, result);
            }
        }

        result.Deduplicate();

        return result;
    }

    private static string NamespaceToPrefix(string ns) => ns switch
    {
        "MTL" => "MTL",
        "MTL4" => "MTL4",
        "MTLFX" => "MTLFX",
        "MTL4FX" => "MTL4FX",
        "CA" => "CA",
        "NS" => "NS",
        _ => ns,
    };

    private static string NamespaceToFolder(string ns) => ns switch
    {
        "MTL" or "MTL4" => "Metal",
        "CA" => "QuartzCore",
        "NS" => "Foundation",
        "MTLFX" or "MTL4FX" => "MetalFX",
        _ => "Metal",
    };

    private static HashSet<string> ScanAllocClasses(string metalCppDir)
    {
        HashSet<string> allocClasses = [];

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
                        allocClasses.Add($"{currentNs}::{allocMatch.Groups[1].Value}");
                    }
                }
            }
        }

        return allocClasses;
    }

    private static Dictionary<string, string> BuildSelectorMap(string metalCppDir)
    {
        Dictionary<string, string> map = [];

        foreach (string dir in new[] { "Metal", "MetalFX", "QuartzCore", "Foundation" })
        {
            string fullDir = Path.Combine(metalCppDir, dir);

            if (!Directory.Exists(fullDir))
            {
                continue;
            }

            foreach (string file in Directory.GetFiles(fullDir, "*.hpp"))
            {
                string[] lines = File.ReadAllLines(file);

                for (int i = 0; i < lines.Length; i++)
                {
                    Match selMatch = DefSelAccessorPattern().Match(lines[i]);

                    if (!selMatch.Success)
                    {
                        continue;
                    }

                    string accessor = selMatch.Groups[2].Value;

                    // The selector string is on the next line, in quotes
                    if (i + 1 < lines.Length)
                    {
                        string nextLine = lines[i + 1].Trim();
                        int q1 = nextLine.IndexOf('"');
                        int q2 = nextLine.LastIndexOf('"');

                        if (q1 >= 0 && q2 > q1)
                        {
                            string selector = nextLine.Substring(q1 + 1, q2 - q1 - 1);
                            map[accessor] = selector;
                        }
                    }
                }
            }
        }

        return map;
    }

    private static HashSet<string> BuildClsRegistrations(string metalCppDir)
    {
        HashSet<string> set = [];

        foreach (string dir in new[] { "Metal", "MetalFX", "QuartzCore", "Foundation" })
        {
            string fullDir = Path.Combine(metalCppDir, dir);

            if (!Directory.Exists(fullDir))
            {
                continue;
            }

            foreach (string file in Directory.GetFiles(fullDir, "*.hpp"))
            {
                foreach (string line in File.ReadLines(file))
                {
                    Match clsMatch = DefClsPattern().Match(line);

                    if (clsMatch.Success)
                    {
                        set.Add(clsMatch.Groups[2].Value);
                    }
                }
            }
        }

        return set;
    }

    private static Dictionary<string, string> BuildInlineMap(string metalCppDir)
    {
        Dictionary<string, string> map = [];

        foreach (string dir in new[] { "Metal", "MetalFX", "QuartzCore", "Foundation" })
        {
            string fullDir = Path.Combine(metalCppDir, dir);

            if (!Directory.Exists(fullDir))
            {
                continue;
            }

            foreach (string file in Directory.GetFiles(fullDir, "*.hpp"))
            {
                string[] lines = File.ReadAllLines(file);

                for (int i = 0; i < lines.Length; i++)
                {
                    Match implMatch = InlineImplPattern().Match(lines[i]);

                    if (!implMatch.Success)
                    {
                        continue;
                    }

                    string nsName = implMatch.Groups[3].Value;
                    string className = implMatch.Groups[4].Value;
                    string methodName = implMatch.Groups[5].Value;
                    string key = $"{nsName}::{className}::{methodName}";

                    // Search the body for _*_PRIVATE_SEL(accessor)
                    for (int j = i + 1; j < lines.Length && j < i + 10; j++)
                    {
                        Match selUsage = PrivateSelUsagePattern().Match(lines[j]);

                        if (selUsage.Success)
                        {
                            map[key] = selUsage.Groups[2].Value;

                            break;
                        }

                        if (lines[j].Trim() == "}")
                        {
                            break;
                        }
                    }
                }
            }
        }

        return map;
    }

    private static void ParseEnums(string content, string[] lines, ParseResult result)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            bool isFlags = false;
            Match enumMatch = EnumMacroPattern().Match(line);

            if (!enumMatch.Success)
            {
                enumMatch = OptionsMacroPattern().Match(line);

                if (enumMatch.Success)
                {
                    isFlags = true;
                }
            }

            if (!enumMatch.Success)
            {
                continue;
            }

            string macroPrefix = enumMatch.Groups[1].Value;
            string underlyingTypeStr = enumMatch.Groups[2].Value.Trim();
            string enumName = enumMatch.Groups[3].Value;

            string prefix = macroPrefix switch
            {
                "MTL" => DetermineEnumPrefix(lines, i),
                "NS" => "NS",
                "CA" => "CA",
                "MTLFX" => DetermineEnumPrefix(lines, i),
                _ => macroPrefix,
            };

            string fullName = $"{prefix}{enumName}";
            string underlyingType = MapEnumUnderlyingType(underlyingTypeStr);

            EnumDef enumDef = new()
            {
                Name = fullName,
                UnderlyingType = underlyingType,
                IsFlags = isFlags,
                Folder = NamespaceToFolder(prefix),
            };

            // Parse members until closing brace
            HashSet<string> seen = [];

            long nextAutoValue = 0;

            for (int j = i + 1; j < lines.Length; j++)
            {
                string memberLine = lines[j].Trim();

                if (memberLine.StartsWith("}"))
                {
                    break;
                }

                Match memberMatch = EnumMemberWithValuePattern().Match(memberLine);
                string memberName;
                string resolvedValue;

                if (memberMatch.Success)
                {
                    memberName = memberMatch.Groups[1].Value;
                    string value = memberMatch.Groups[2].Value.Trim();
                    resolvedValue = ResolveEnumValue(value, underlyingType);

                    if (long.TryParse(resolvedValue, out long parsedVal))
                    {
                        nextAutoValue = parsedVal + 1;
                    }
                    else
                    {
                        nextAutoValue++;
                    }
                }
                else
                {
                    Match noValueMatch = EnumMemberNoValuePattern().Match(memberLine);

                    if (!noValueMatch.Success)
                    {
                        continue;
                    }

                    memberName = noValueMatch.Groups[1].Value;

                    if (memberName == "{" || memberName == "}" || memberName.StartsWith("//"))
                    {
                        continue;
                    }

                    resolvedValue = nextAutoValue.ToString();
                    nextAutoValue++;
                }

                if (memberName.Length > 0 && char.IsDigit(memberName[0]))
                {
                    memberName = $"_{memberName}";
                }

                if (!seen.Add(memberName))
                {
                    continue;
                }

                enumDef.Members.Add(new EnumMemberDef
                {
                    Name = memberName,
                    Value = resolvedValue,
                });
            }

            if (enumDef.Members.Count > 0)
            {
                result.Enums.Add(enumDef);
            }
        }
    }

    private static string DetermineEnumPrefix(string[] lines, int enumLineIndex)
    {
        // Walk backwards to find the enclosing namespace
        for (int k = enumLineIndex - 1; k >= 0; k--)
        {
            Match nsMatch = NsPattern().Match(lines[k]);

            if (nsMatch.Success)
            {
                return NamespaceToPrefix(nsMatch.Groups[1].Value);
            }
        }

        return "MTL";
    }

    private static string MapEnumUnderlyingType(string typeStr)
    {
        return typeStr switch
        {
            "NS::UInteger" or "UInteger" or "unsigned long" or "unsigned long long" => "ulong",
            "NS::Integer" or "Integer" or "long" or "long long" => "long",
            "unsigned int" or "uint32_t" => "uint",
            "int" or "int32_t" => "int",
            "unsigned short" or "uint16_t" => "ushort",
            "short" or "int16_t" => "short",
            "unsigned char" or "uint8_t" => "byte",
            "char" or "int8_t" => "sbyte",
            "std::uint64_t" or "uint64_t" => "ulong",
            _ => "uint",
        };
    }

    private static string ResolveEnumValue(string expr, string underlyingType)
    {
        string trimmed = expr.TrimEnd(',').Trim();

        // Strip outer parentheses
        while (trimmed.StartsWith('(') && trimmed.EndsWith(')'))
        {
            trimmed = trimmed[1..^1].Trim();
        }

        // Handle known C++ constants
        if (trimmed is "NS::UIntegerMax" or "UIntegerMax")
        {
            return underlyingType == "ulong" ? ulong.MaxValue.ToString() : uint.MaxValue.ToString();
        }

        if (trimmed is "NS::IntegerMax" or "IntegerMax")
        {
            return underlyingType == "long" ? long.MaxValue.ToString() : int.MaxValue.ToString();
        }

        // Strip C++ integer literal suffixes from all numeric literals in the expression
        string stripped = IntegerSuffixPattern().Replace(trimmed, "$1");

        // Handle simple shift expressions like "1 << 40"
        Match shiftMatch = ShiftExprPattern().Match(stripped);

        if (shiftMatch.Success)
        {
            long baseVal = long.Parse(shiftMatch.Groups[1].Value);
            int shift = int.Parse(shiftMatch.Groups[2].Value);
            ulong result = (ulong)baseVal << shift;

            return result.ToString();
        }

        // Handle hex literals (with or without suffixes already stripped)
        if (stripped.StartsWith("0x") || stripped.StartsWith("0X"))
        {
            if (ulong.TryParse(stripped[2..], System.Globalization.NumberStyles.HexNumber, null, out ulong hexVal))
            {
                return hexVal.ToString();
            }
        }

        // Handle negative values with unsigned types
        if (long.TryParse(stripped, out long longVal))
        {
            if (longVal < 0)
            {
                if (underlyingType == "ulong")
                {
                    return unchecked((ulong)longVal).ToString();
                }

                if (underlyingType == "uint")
                {
                    return unchecked((uint)longVal).ToString();
                }

                if (underlyingType == "ushort")
                {
                    return unchecked((ushort)longVal).ToString();
                }

                if (underlyingType == "byte")
                {
                    return unchecked((byte)longVal).ToString();
                }
            }

            return longVal.ToString();
        }

        // Handle cast expressions like "static_cast<NS::UInteger>(-1)"
        if (stripped.Contains("static_cast"))
        {
            int parenStart = stripped.IndexOf('(');
            int parenEnd = stripped.LastIndexOf(')');

            if (parenStart >= 0 && parenEnd > parenStart)
            {
                string innerExpr = stripped[(parenStart + 1)..parenEnd].Trim();
                string innerResolved = ResolveEnumValue(innerExpr, underlyingType);

                if (long.TryParse(innerResolved, out long castVal) && castVal < 0)
                {
                    if (underlyingType == "ulong")
                    {
                        return unchecked((ulong)castVal).ToString();
                    }

                    if (underlyingType == "uint")
                    {
                        return unchecked((uint)castVal).ToString();
                    }
                }

                return innerResolved;
            }
        }

        // For complex expressions (e.g., bitwise operations referencing other enum members),
        // return the numeric string if possible, otherwise return as-is
        return stripped;
    }

    private static void ParseClasses(
        string[] lines,
        HashSet<string> allocClasses,
        HashSet<string> clsRegistrations,
        Dictionary<string, string> selectorMap,
        Dictionary<string, string> inlineMap,
        ParseResult result)
    {
        string currentNs = "";
        bool inNamespace = false;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            Match nsMatch = NsPattern().Match(line);

            if (nsMatch.Success)
            {
                currentNs = nsMatch.Groups[1].Value;
                inNamespace = false;

                continue;
            }

            if (!string.IsNullOrEmpty(currentNs) && !inNamespace && line.Trim() == "{")
            {
                inNamespace = true;

                continue;
            }

            if (!inNamespace)
            {
                continue;
            }

            if (!BindableNamespaces.Contains(currentNs) && !NsNamespace.Contains(currentNs))
            {
                continue;
            }

            Match classMatch = ClassDeclPattern().Match(line);

            if (!classMatch.Success)
            {
                continue;
            }

            string className = classMatch.Groups[1].Value;

            if (string.IsNullOrEmpty(className) || className == "Private"
                || className.Contains('<') || className.StartsWith('_'))
            {
                continue;
            }

            string prefix = NamespaceToPrefix(currentNs);
            string fullName = $"{prefix}{className}";

            if (HandWrittenTypes.Contains(fullName))
            {
                continue;
            }

            if (NsNamespace.Contains(currentNs) && !GeneratableNsClasses.Contains(fullName))
            {
                continue;
            }

            if (ValueStructs.Contains(fullName))
            {
                continue;
            }

            // Find the class body
            List<RawMethodDecl> rawMethods = [];
            int classStart = i;
            int classBraceDepth = 0;
            bool foundOpenBrace = false;
            bool inPublic = false;

            for (int j = i; j < lines.Length; j++)
            {
                string cline = lines[j];

                if (!foundOpenBrace)
                {
                    if (cline.Contains('{'))
                    {
                        foundOpenBrace = true;
                        classBraceDepth = 1;

                        continue;
                    }

                    continue;
                }

                foreach (char ch in cline)
                {
                    if (ch == '{')
                    {
                        classBraceDepth++;
                    }
                    else if (ch == '}')
                    {
                        classBraceDepth--;
                    }
                }

                if (classBraceDepth <= 0)
                {
                    break;
                }

                string trimmed = cline.Trim();

                if (trimmed == "public:")
                {
                    inPublic = true;

                    continue;
                }

                if (trimmed == "private:" || trimmed == "protected:")
                {
                    inPublic = false;

                    continue;
                }

                if (!inPublic)
                {
                    continue;
                }

                if (trimmed.EndsWith(';'))
                {
                    RawMethodDecl? raw = ParseMethodDeclaration(trimmed, className);

                    if (raw is not null)
                    {
                        rawMethods.Add(raw);
                    }
                }
            }

            bool isClass = rawMethods.Any(m => m.IsStatic && m.Name == "alloc" && m.Params.Count == 0)
                || allocClasses.Contains($"{currentNs}::{className}");

            string? objCClass = isClass ? fullName : null;

            ObjCClassDef def = new()
            {
                Name = fullName,
                IsClass = isClass,
                ObjCClass = objCClass,
                Folder = NamespaceToFolder(currentNs),
            };

            HashSet<string> methodSigs = [];
            HashSet<string> potentialPropertyNames = [];
            HashSet<string> addedPropertyNames = [];

            // First pass: identify potential properties (non-static, 0-param, non-void return)
            foreach (RawMethodDecl m in rawMethods)
            {
                if (m.IsStatic || m.Params.Count != 0)
                {
                    continue;
                }

                if (m.Name.StartsWith("new") || m.Name == "init" || m.Name == "alloc")
                {
                    continue;
                }

                if (m.Name == className || m.Name.StartsWith('~') || m.Name.StartsWith("operator"))
                {
                    continue;
                }

                string? retType = MapType(m.ReturnType, currentNs, prefix);

                if (retType is null || retType == "void")
                {
                    continue;
                }

                string pcName = char.ToUpperInvariant(m.Name[0]) + m.Name[1..];
                potentialPropertyNames.Add(pcName);
            }

            // Second pass: convert methods
            foreach (RawMethodDecl m in rawMethods)
            {
                if (m.Name == className || m.Name.StartsWith('~') || m.Name.StartsWith("operator"))
                {
                    continue;
                }

                if (m.Name == "init" || m.Name == "alloc")
                {
                    continue;
                }

                string? retType = MapType(m.ReturnType, currentNs, prefix);

                if (retType is null)
                {
                    continue;
                }

                // Resolve selector
                string selector = ResolveSelector(currentNs, className, m.Name, m.Params, selectorMap, inlineMap);

                MethodDef methodDef = new()
                {
                    Name = m.Name,
                    Selector = selector,
                    ReturnType = retType,
                };

                bool hasErrorOut = false;
                bool paramFailed = false;

                foreach (RawParamInfo p in m.Params)
                {
                    if (IsErrorOutParam(p.Type))
                    {
                        hasErrorOut = true;

                        continue;
                    }

                    string? paramType = MapType(p.Type, currentNs, prefix);

                    if (paramType is null)
                    {
                        paramFailed = true;

                        break;
                    }

                    string paramName = string.IsNullOrEmpty(p.Name) ? $"param{methodDef.Parameters.Count}" : p.Name;

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

                if (paramFailed)
                {
                    continue;
                }

                methodDef.HasErrorOut = hasErrorOut;

                string pcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name[1..];
                string sig = $"{(m.IsStatic ? "s:" : "")}{pcName}({string.Join(",", methodDef.Parameters.Select(p => p.Type))})";

                if (!methodSigs.Add(sig))
                {
                    continue;
                }

                bool isProperty = m.Params.Count == 0
                    && methodDef.ReturnType != "void"
                    && !m.Name.StartsWith("new")
                    && !m.IsStatic;

                bool hasSetter = false;
                string setterName = $"set{Capitalize(m.Name)}";

                if (isProperty)
                {
                    hasSetter = rawMethods.Any(f =>
                        f.Name == setterName && f.Params.Count == 1 && !f.IsStatic);
                }

                if (isProperty && !m.IsStatic)
                {
                    string propPcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name[1..];

                    if (addedPropertyNames.Add(propPcName))
                    {
                        string? setSelector = null;

                        if (hasSetter)
                        {
                            setSelector = ResolveSelector(currentNs, className, setterName, [new RawParamInfo("", "")], selectorMap, inlineMap);
                        }

                        def.Properties.Add(new PropertyDef
                        {
                            Name = m.Name,
                            Type = methodDef.ReturnType,
                            Readonly = !hasSetter,
                            GetSelector = selector,
                            SetSelector = setSelector,
                        });
                    }
                }
                else
                {
                    if (m.Name.StartsWith("set") && m.Name.Length > 3 && char.IsUpper(m.Name[3])
                        && m.Params.Count == 1)
                    {
                        string propPcName = m.Name[3..];

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

                    if (m.IsStatic)
                    {
                        def.StaticMethods.Add(methodDef);
                    }
                    else
                    {
                        def.Methods.Add(methodDef);
                    }
                }
            }

            result.Classes.Add(def);
        }
    }

    private static string ResolveSelector(
        string ns,
        string className,
        string methodName,
        List<RawParamInfo> methodParams,
        Dictionary<string, string> selectorMap,
        Dictionary<string, string> inlineMap)
    {
        // Try to find via inline implementation map
        string inlineKey = $"{ns}::{className}::{methodName}";

        if (inlineMap.TryGetValue(inlineKey, out string? accessor))
        {
            if (selectorMap.TryGetValue(accessor, out string? selector))
            {
                return selector;
            }

            // If we have the accessor but no selector string, construct from accessor
            return AccessorToSelector(accessor);
        }

        // Fallback: construct selector from method name and params
        if (methodParams.Count == 0)
        {
            return methodName;
        }

        // For setter with 1 param, the selector is methodName:
        if (methodParams.Count == 1)
        {
            return $"{methodName}:";
        }

        // Multi-param: methodName:paramName2:paramName3:...
        List<string> parts = [methodName];

        for (int i = 1; i < methodParams.Count; i++)
        {
            string pName = methodParams[i].Name;

            if (string.IsNullOrEmpty(pName))
            {
                pName = $"param{i}";
            }

            parts.Add(pName);
        }

        return string.Join(":", parts) + ":";
    }

    private static string AccessorToSelector(string accessor)
    {
        // Convert accessor like "addDebugMarker_range_" to "addDebugMarker:range:"
        if (!accessor.Contains('_'))
        {
            return accessor;
        }

        // Split by underscores and rejoin with colons
        // Trailing underscore means trailing colon
        bool trailingUnderscore = accessor.EndsWith('_');
        string[] parts = accessor.Split('_', StringSplitOptions.RemoveEmptyEntries);

        string result = string.Join(":", parts);

        if (trailingUnderscore)
        {
            result += ":";
        }

        return result;
    }

    private static bool IsErrorOutParam(string typeStr)
    {
        // Detect NS::Error** pattern
        string cleaned = typeStr.Replace(" ", "");

        return cleaned.Contains("Error**");
    }

    private static void ParseFreeFunctions(string[] lines, ParseResult result)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            Match externMatch = ExternCPattern().Match(lines[i]);

            if (!externMatch.Success)
            {
                continue;
            }

            string returnTypeStr = externMatch.Groups[1].Value.Trim();
            string funcName = externMatch.Groups[2].Value;
            string paramsStr = externMatch.Groups[3].Value.Trim();

            // Determine the namespace/prefix from the function name
            string prefix;

            if (funcName.StartsWith("MTL"))
            {
                prefix = "MTL";
            }
            else if (funcName.StartsWith("CA"))
            {
                prefix = "CA";
            }
            else
            {
                continue;
            }

            string ns = prefix;
            string? retType = MapType(returnTypeStr, ns, prefix);

            if (retType is null)
            {
                continue;
            }

            string? targetClass = MapFreeFunctionTarget(funcName, prefix);

            if (targetClass is null)
            {
                continue;
            }

            FreeFunctionDef def = new()
            {
                NativeName = funcName,
                Name = funcName,
                ReturnType = retType,
                TargetClass = targetClass,
                FrameworkLibrary = "/System/Library/Frameworks/Metal.framework/Metal",
            };

            // Parse parameters
            if (!string.IsNullOrEmpty(paramsStr))
            {
                List<RawParamInfo> rawParams = ParseParameterList(paramsStr);
                bool paramFailed = false;

                foreach (RawParamInfo p in rawParams)
                {
                    string? paramType = MapType(p.Type, ns, prefix);

                    if (paramType is null)
                    {
                        paramFailed = true;

                        break;
                    }

                    string paramName = string.IsNullOrEmpty(p.Name) ? $"param{def.Parameters.Count}" : p.Name;

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

                if (paramFailed)
                {
                    continue;
                }
            }

            result.FreeFunctions.Add(def);
        }
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

    private static RawMethodDecl? ParseMethodDeclaration(string line, string className)
    {
        // Remove trailing semicolon and const qualifier
        string decl = line.TrimEnd(';').Trim();

        if (decl.EndsWith("const"))
        {
            decl = decl[..^5].Trim();
        }

        // Skip friend declarations
        if (decl.StartsWith("friend "))
        {
            return null;
        }

        // Skip using declarations
        if (decl.StartsWith("using "))
        {
            return null;
        }

        // Skip typedefs
        if (decl.StartsWith("typedef "))
        {
            return null;
        }

        bool isStatic = false;

        if (decl.StartsWith("static "))
        {
            isStatic = true;
            decl = decl[7..].Trim();
        }

        // Skip virtual
        if (decl.StartsWith("virtual "))
        {
            decl = decl[8..].Trim();
        }

        // Find the parameter list
        int parenOpen = decl.IndexOf('(');

        if (parenOpen < 0)
        {
            return null;
        }

        int parenClose = decl.LastIndexOf(')');

        if (parenClose < 0 || parenClose < parenOpen)
        {
            return null;
        }

        string beforeParen = decl[..parenOpen].Trim();
        string paramsStr = decl[(parenOpen + 1)..parenClose].Trim();

        // Split beforeParen into return type and method name
        // The method name is the last token, possibly preceded by * for pointer return
        int lastSpace = -1;

        for (int k = beforeParen.Length - 1; k >= 0; k--)
        {
            if (beforeParen[k] == ' ' || beforeParen[k] == '\t')
            {
                lastSpace = k;

                break;
            }

            // Handle pointer return like "Buffer*"
            if (beforeParen[k] == '*')
            {
                // Find the space before the pointer+name
                for (int m = k - 1; m >= 0; m--)
                {
                    if (beforeParen[m] == ' ' || beforeParen[m] == '\t')
                    {
                        lastSpace = m;

                        break;
                    }
                }

                break;
            }
        }

        if (lastSpace < 0)
        {
            return null;
        }

        string returnType = beforeParen[..lastSpace].Trim();
        string methodNamePart = beforeParen[lastSpace..].Trim();

        // methodNamePart might have leading *, separate pointer from name
        string methodName;

        if (methodNamePart.StartsWith('*'))
        {
            returnType += "*";
            methodName = methodNamePart.TrimStart('*').Trim();
        }
        else
        {
            methodName = methodNamePart;
        }

        if (string.IsNullOrEmpty(methodName))
        {
            return null;
        }

        // Skip operator overloads, destructors, constructors
        if (methodName.StartsWith("operator") || methodName.StartsWith('~'))
        {
            return null;
        }

        List<RawParamInfo> paramList = [];

        if (!string.IsNullOrEmpty(paramsStr))
        {
            paramList = ParseParameterList(paramsStr);
        }

        return new RawMethodDecl(methodName, returnType.Trim(), isStatic, paramList);
    }

    private static List<RawParamInfo> ParseParameterList(string paramsStr)
    {
        List<RawParamInfo> paramList = [];

        // Split by commas, but respect angle brackets and parentheses
        List<string> parts = SplitParams(paramsStr);

        foreach (string part in parts)
        {
            string p = part.Trim();

            if (string.IsNullOrEmpty(p) || p == "void")
            {
                continue;
            }

            // Find the parameter name: last word token
            // Handle patterns like: "const NS::String* marker", "NS::Range range", "NS::Error** error"
            int lastSp = p.LastIndexOf(' ');

            if (lastSp < 0)
            {
                // Type only, no name
                paramList.Add(new RawParamInfo(p, ""));

                continue;
            }

            // Detect C-style array parameters (e.g., "const MTL::Buffer* const buffers[]")
            if (p.Contains("[]"))
            {
                paramList.Add(new RawParamInfo(p, ""));

                continue;
            }

            string possibleName = p[(lastSp + 1)..].Trim();

            // If possibleName starts with *, it's part of the type
            if (possibleName.StartsWith('*'))
            {
                string paramType = p[..lastSp].Trim() + possibleName[..(possibleName.LastIndexOf('*') + 1)];
                string paramName = possibleName.TrimStart('*');

                if (string.IsNullOrEmpty(paramName))
                {
                    paramList.Add(new RawParamInfo(p, ""));
                }
                else
                {
                    paramList.Add(new RawParamInfo(paramType.Trim(), paramName));
                }
            }
            else if ((char.IsLetter(possibleName[0]) || possibleName[0] == '_')
                && !possibleName.Contains("::") && !possibleName.Contains('*'))
            {
                string paramType = p[..lastSp].Trim();
                paramList.Add(new RawParamInfo(paramType, possibleName));
            }
            else
            {
                paramList.Add(new RawParamInfo(p, ""));
            }
        }

        return paramList;
    }

    private static List<string> SplitParams(string s)
    {
        List<string> result = [];
        int depth = 0;
        int start = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (c == '<' || c == '(')
            {
                depth++;
            }
            else if (c == '>' || c == ')')
            {
                depth--;
            }
            else if (c == ',' && depth == 0)
            {
                result.Add(s[start..i]);
                start = i + 1;
            }
        }

        if (start < s.Length)
        {
            result.Add(s[start..]);
        }

        return result;
    }

    private static string? MapType(string typeStr, string ns, string prefix)
    {
        if (string.IsNullOrWhiteSpace(typeStr))
        {
            return null;
        }

        string t = typeStr.Trim();

        // Reject array types
        if (t.Contains("[]"))
        {
            return null;
        }

        // Strip leading const
        if (t.StartsWith("const "))
        {
            t = t[6..].Trim();
        }

        // Check for function pointers, blocks, std::function, handler types
        if (t.Contains("function") || t.Contains("block") || t.Contains("Block")
            || t.Contains("(*)") || t.Contains("(^"))
        {
            return null;
        }

        // Handle class prefix like "class "
        if (t.StartsWith("class "))
        {
            t = t[6..].Trim();
        }

        // Handle pointer types
        if (t.EndsWith('*'))
        {
            string inner = t[..^1].Trim();

            // Strip trailing const
            if (inner.EndsWith("const"))
            {
                inner = inner[..^5].Trim();
            }

            // Strip leading const again
            if (inner.StartsWith("const "))
            {
                inner = inner[6..].Trim();
            }

            // void*
            if (inner == "void")
            {
                return "nint";
            }

            // char* / const char*
            if (inner == "char" || inner == "unsigned char")
            {
                return "nint";
            }

            // Double pointer (e.g., NS::Object**)
            if (inner.EndsWith('*'))
            {
                return "nint";
            }

            // Qualified class pointer: NS::ClassName*
            return MapClassPointer(inner, ns, prefix);
        }

        // Handle reference types
        if (t.EndsWith('&'))
        {
            string inner = t[..^1].Trim();

            if (inner.StartsWith("const "))
            {
                inner = inner[6..].Trim();
            }

            if (inner == "char")
            {
                return "nint";
            }

            // Treat as pointer
            return MapClassPointer(inner, ns, prefix);
        }

        // Primitive types
        return t switch
        {
            "void" => "void",
            "bool" => "Bool8",
            "char" or "unsigned char" => "byte",
            "short" => "short",
            "unsigned short" => "ushort",
            "int" => "int",
            "unsigned int" => "uint",
            "long" or "long long" => "nint",
            "unsigned long" or "unsigned long long" => "nuint",
            "float" => "float",
            "double" => "double",
            "int8_t" => "sbyte",
            "uint8_t" => "byte",
            "int16_t" => "short",
            "uint16_t" => "ushort",
            "int32_t" => "int",
            "uint32_t" => "uint",
            "int64_t" => "nint",
            "uint64_t" => "nuint",
            "size_t" => "nuint",
            _ => MapQualifiedType(t, ns, prefix),
        };
    }

    private static string? MapQualifiedType(string t, string ns, string prefix)
    {
        // Handle NS:: qualified types
        if (t.StartsWith("NS::"))
        {
            string nsType = t[4..];

            return nsType switch
            {
                "UInteger" => "nuint",
                "Integer" => "nint",
                "String" => "NSString",
                "Error" => "NSError",
                "Array" => "NSArray",
                "URL" => "NSURL",
                "Range" => "NSRange",
                "Number" or "Data" or "Dictionary" or "Object" or "Bundle"
                    or "Notification" or "ProcessInfo" or "Set" => "nint",
                _ => MapGenericClassName(nsType, "NS"),
            };
        }

        // Handle MTL:: qualified types
        if (t.StartsWith("MTL::"))
        {
            string mtlType = t[5..];

            return MapGenericClassName(mtlType, "MTL");
        }

        // Handle MTL4:: qualified types
        if (t.StartsWith("MTL4::"))
        {
            string mtl4Type = t[6..];

            return MapGenericClassName(mtl4Type, "MTL4");
        }

        // Handle CA:: qualified types
        if (t.StartsWith("CA::"))
        {
            string caType = t[4..];

            if (caType == "Texture")
            {
                return "nint";
            }

            return MapGenericClassName(caType, "CA");
        }

        // Handle MTLFX:: qualified types
        if (t.StartsWith("MTLFX::"))
        {
            string mtlfxType = t[7..];

            return MapGenericClassName(mtlfxType, "MTLFX");
        }

        // Handle MTL4FX:: qualified types
        if (t.StartsWith("MTL4FX::"))
        {
            string mtl4fxType = t[8..];

            return MapGenericClassName(mtl4fxType, "MTL4FX");
        }

        // Typedefs not namespace-qualified
        return t switch
        {
            "UInteger" => "nuint",
            "Integer" => "nint",
            "CFTimeInterval" => "double",
            "IOSurfaceRef" => "nint",
            "CGColorSpaceRef" => "nint",
            "dispatch_queue_t" => "nint",
            "dispatch_data_t" => "nint",
            "task_id_token_t" => "nint",
            "kern_return_t" => "uint",
            "CGSize" => "CGSize",
            "GPUAddress" => "nuint",
            _ => MapGenericClassName(t, prefix),
        };
    }

    private static string? MapClassPointer(string className, string ns, string prefix)
    {
        // Strip const
        if (className.StartsWith("const "))
        {
            className = className[6..].Trim();
        }

        // Handle class prefix
        if (className.StartsWith("class "))
        {
            className = className[6..].Trim();
        }

        // Void pointer already handled
        if (className == "void")
        {
            return "nint";
        }

        if (className == "char" || className == "unsigned char")
        {
            return "nint";
        }

        // Handle qualified names with ::
        if (className.Contains("::"))
        {
            return MapQualifiedType(className, ns, prefix);
        }

        return MapGenericClassName(className, prefix);
    }

    private static string? MapGenericClassName(string name, string prefix)
    {
        // Skip handler/callback types (std::function wrappers and block types)
        if (name.Contains("Handler"))
        {
            return null;
        }

        // Special class name mappings
        string? mapped = name switch
        {
            "String" => "NSString",
            "Error" => "NSError",
            "Array" => "NSArray",
            "URL" => "NSURL",
            "Number" or "Data" or "Dictionary" or "Object" or "Bundle"
                or "Notification" or "ProcessInfo" or "Set" or "float4x4" => "nint",
            "Referencing" or "Copying" or "SecureCoding" or "_Base" => null,
            "Architecture" or "AccelerationStructureSizes" => "nint",
            _ => "!UNMAPPED!",
        };

        if (mapped != "!UNMAPPED!")
        {
            return mapped;
        }

        // If name already has a known prefix, use it directly
        if (name.StartsWith("MTL") || name.StartsWith("CA") || name.StartsWith("NS") || name.StartsWith("MTLFX"))
        {
            return name;
        }

        string fullName = $"{prefix}{name}";

        if (ValueStructs.Contains(fullName))
        {
            return fullName;
        }

        return fullName;
    }

    private static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        return char.ToUpperInvariant(s[0]) + s[1..];
    }

    /// <summary>Returns true if the given type name is a known value struct.</summary>
    public static bool IsKnownValueStruct(string type) => ValueStructs.Contains(type);

    /// <summary>Returns true if the given type name represents an Objective-C wrapper.</summary>
    public static bool IsObjCWrapper(string type)
    {
        if (ValueStructs.Contains(type) || IsLikelyEnum(type))
        {
            return false;
        }

        return type.StartsWith("MTL") || type.StartsWith("NS") || type.StartsWith("CA");
    }

    /// <summary>Returns true if the given type name is likely an enum based on naming conventions.</summary>
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

    /// <summary>Returns true if the given name is a C# keyword.</summary>
    public static bool IsCSharpKeyword(string name) => CSharpKeywords.Contains(name);

    private sealed class RawMethodDecl(string name, string returnType, bool isStatic, List<RawParamInfo> @params)
    {
        public string Name { get; } = name;

        public string ReturnType { get; } = returnType;

        public bool IsStatic { get; } = isStatic;

        public List<RawParamInfo> Params { get; } = @params;
    }

    private sealed class RawParamInfo(string type, string name)
    {
        public string Type { get; } = type;

        public string Name { get; } = name;
    }
}
