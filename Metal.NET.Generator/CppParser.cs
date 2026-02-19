using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Regex-based parser for metal-cpp C++ headers.
/// Extracts enums, classes, methods, free functions, and ObjC selector mappings.
/// </summary>
partial class CppParser(string metalCppDir, GeneratorContext context)
{
    /// <summary>
    /// Methods to skip during parsing.
    /// </summary>
    static readonly HashSet<string> SkipMethods = ["alloc", "init", "retain", "release", "autorelease", "copy", "retainCount"];

    #region Bridge Files

    public void ParseBridgeFiles()
    {
        string[] bridgeFiles =
        [
            Path.Combine(metalCppDir, "Metal", "MTLHeaderBridge.hpp"),
            Path.Combine(metalCppDir, "Foundation", "NSPrivate.hpp"),
            Path.Combine(metalCppDir, "QuartzCore", "CAPrivate.hpp"),
            Path.Combine(metalCppDir, "MetalFX", "MTLFXPrivate.hpp"),
        ];

        foreach (string file in bridgeFiles)
        {
            if (!File.Exists(file)) continue;
            string content = File.ReadAllText(file);

            foreach (Match m in SelectorDefRegex().Matches(content))
            {
                context.SelectorMap[m.Groups[1].Value] = m.Groups[2].Value;
            }

            foreach (Match m in ClassDefRegex().Matches(content))
            {
                context.RegisteredClasses.Add(m.Groups[1].Value);
            }
        }

        Console.WriteLine($"  Parsed {context.SelectorMap.Count} selectors, {context.RegisteredClasses.Count} class registrations");
    }

    #endregion

    #region Header Files

    public void ParseAllHeaders()
    {
        string[] subdirs = ["Metal", "Foundation", "QuartzCore", "MetalFX"];

        foreach (string subdir in subdirs)
        {
            string dir = Path.Combine(metalCppDir, subdir);
            if (!Directory.Exists(dir)) continue;

            foreach (string file in Directory.GetFiles(dir, "*.hpp"))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.Contains("Private") || fileName.Contains("HeaderBridge") ||
                    fileName.Contains("Defines") || fileName.Contains("Types") ||
                    fileName.Contains("Version") || fileName.Contains("GPUAddress") ||
                    fileName.Contains("IOCompressor") || fileName.Contains("AccelerationStructureTypes"))
                    continue;
                if (fileName is "Metal.hpp" or "Foundation.hpp" or "QuartzCore.hpp" or "MetalFX.hpp")
                    continue;

                string content = File.ReadAllText(file);
                ParseEnums(content);
                ParseClasses(content, file);
                ParseFreeFunctions(content, subdir, file);
            }
        }
    }

    #endregion

    #region Enum Parsing

    void ParseEnums(string content)
    {
        List<(string Ns, int Pos)> nsPositions = [];
        foreach (Match nm in NamespacePatternRegex().Matches(content))
            nsPositions.Add((nm.Groups[1].Value, nm.Index));

        foreach (Match m in EnumPatternRegex().Matches(content))
        {
            string nsPrefix = m.Groups[1].Value;
            bool isFlags = m.Groups[2].Value == "OPTIONS";
            string cppType = m.Groups[3].Value.Trim();
            string name = m.Groups[4].Value.Trim();
            string body = m.Groups[5].Value;

            string backingType = MapEnumBackingType(cppType);

            string cppNamespace = nsPrefix switch
            {
                "NS" => "NS",
                "CA" => "CA",
                "MTLFX" => "MTLFX",
                _ => "MTL"
            };
            for (int i = nsPositions.Count - 1; i >= 0; i--)
            {
                if (nsPositions[i].Pos < m.Index)
                {
                    cppNamespace = nsPositions[i].Ns;
                    break;
                }
            }

            string prefix = TypeMapper.GetPrefix(cppNamespace);
            string csEnumName = prefix + name;
            context.EnumBackingTypes[csEnumName] = backingType;

            List<EnumMember> members = ParseEnumMembers(body, name, prefix);
            context.Enums.Add(new EnumDef(cppNamespace, name, backingType, isFlags, members));
        }
    }

    static string MapEnumBackingType(string cppType) => cppType.Trim() switch
    {
        "NS::UInteger" or "UInteger" => "ulong",
        "NS::Integer" or "Integer" => "long",
        "uint32_t" => "uint",
        "int32_t" => "int",
        "uint8_t" => "byte",
        "std::uint64_t" or "uint64_t" => "ulong",
        "std::int64_t" or "int64_t" => "long",
        _ => "ulong"
    };

    static List<EnumMember> ParseEnumMembers(string body, string cppEnumName, string nsPrefix)
    {
        List<(string CppName, string Value)> rawMembers = [];
        Dictionary<string, string> cppNameToValue = [];
        int nextImplicitValue = 0;

        foreach (string rawLine in body.Split('\n'))
        {
            string line = rawLine.Trim().TrimEnd(',');
            if (string.IsNullOrWhiteSpace(line)) continue;

            Match memberMatch = EnumMemberRegex().Match(line);
            if (!memberMatch.Success) continue;

            string cppMemberName = memberMatch.Groups[1].Value;
            string csValue;

            if (memberMatch.Groups[2].Success)
            {
                string value = memberMatch.Groups[2].Value.Trim();
                csValue = EvaluateEnumValue(value, cppNameToValue);
                if (long.TryParse(csValue, out long parsed))
                    nextImplicitValue = (int)(parsed + 1);
            }
            else
            {
                csValue = nextImplicitValue.ToString();
                nextImplicitValue++;
            }

            cppNameToValue[cppMemberName] = csValue;
            rawMembers.Add((cppMemberName, csValue));
        }

        string stripPrefix = ComputeEnumStripPrefix(cppEnumName, rawMembers.Select(m => m.CppName).ToList());

        List<EnumMember> members = [];
        foreach (var (cppName, value) in rawMembers)
        {
            string csName = cppName.StartsWith(stripPrefix)
                ? cppName[stripPrefix.Length..]
                : cppName;

            if (csName.Length > 0 && char.IsDigit(csName[0]))
                csName = nsPrefix + csName;

            if (string.IsNullOrEmpty(csName))
                csName = cppName;

            members.Add(new EnumMember(csName, value));
        }

        return members;
    }

    static string ComputeEnumStripPrefix(string cppEnumName, List<string> memberNames)
    {
        if (memberNames.Count == 0) return cppEnumName;

        if (memberNames.All(m => m.StartsWith(cppEnumName)))
            return cppEnumName;

        string lcp = memberNames[0];
        foreach (string name in memberNames.Skip(1))
        {
            int i = 0;
            while (i < lcp.Length && i < name.Length && lcp[i] == name[i])
                i++;
            lcp = lcp[..i];
            if (lcp.Length == 0) break;
        }

        if (lcp.Length == 0) return cppEnumName;

        bool atWordBoundary = memberNames.All(m =>
            m.Length <= lcp.Length || char.IsUpper(m[lcp.Length]) || char.IsDigit(m[lcp.Length]));

        if (atWordBoundary)
            return lcp;

        for (int i = lcp.Length - 1; i > 0; i--)
        {
            if (char.IsUpper(lcp[i]))
                return lcp[..i];
        }

        return lcp;
    }

    static string EvaluateEnumValue(string value, Dictionary<string, string> cppNameToValue)
    {
        try
        {
            string resolved = value;

            foreach (var (cppName, memberValue) in cppNameToValue)
            {
                if (resolved.Contains(cppName))
                    resolved = resolved.Replace(cppName, memberValue);
            }

            resolved = HexUllSuffixRegex().Replace(resolved, "$1");
            resolved = DecimalUllSuffixRegex().Replace(resolved, "$1");
            resolved = HexUlSuffixRegex().Replace(resolved, "$1");
            resolved = DecimalUlSuffixRegex().Replace(resolved, "$1");
            resolved = resolved.Replace("NS::UIntegerMax", "18446744073709551615");
            resolved = resolved.Replace("NS::IntegerMax", "9223372036854775807");
            resolved = LSuffixRegex().Replace(resolved, "$1");
            resolved = resolved.Trim();
            while (resolved.StartsWith('(') && resolved.EndsWith(')'))
                resolved = resolved[1..^1].Trim();

            Match shiftMatch = ShiftPatternRegex().Match(resolved);
            if (shiftMatch.Success)
                return (1L << int.Parse(shiftMatch.Groups[1].Value)).ToString();

            if (resolved.StartsWith("0x", StringComparison.OrdinalIgnoreCase) &&
                ulong.TryParse(resolved[2..], System.Globalization.NumberStyles.HexNumber, null, out ulong hexVal))
                return hexVal.ToString();

            if (long.TryParse(resolved, out long signedVal))
                return signedVal.ToString();

            if (ulong.TryParse(resolved, out ulong numVal))
                return numVal.ToString();

            ulong? evalResult = TryEvaluateExpression(resolved);
            if (evalResult.HasValue)
                return evalResult.Value.ToString();

            return value.Trim().Replace("ULL", "").Replace("UL", "");
        }
        catch
        {
            return value.Trim();
        }
    }

    static ulong? TryEvaluateExpression(string expr)
    {
        try
        {
            expr = expr.Replace(" ", "");

            if (expr.Contains('|') && !expr.Contains('~'))
            {
                ulong result = 0;
                foreach (string part in expr.Split('|'))
                {
                    if (TryParseSimpleValue(part.Trim(), out ulong v))
                        result |= v;
                    else
                        return null;
                }
                return result;
            }

            Match andNotMatch = AndNotPatternRegex().Match(expr);
            if (andNotMatch.Success)
                return ulong.Parse(andNotMatch.Groups[1].Value) & ~ulong.Parse(andNotMatch.Groups[2].Value);

            if (TryParseSimpleValue(expr, out ulong val))
                return val;

            return null;
        }
        catch { return null; }
    }

    static bool TryParseSimpleValue(string s, out ulong value)
    {
        s = s.Trim();
        if (s.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            return ulong.TryParse(s[2..], System.Globalization.NumberStyles.HexNumber, null, out value);

        Match shiftMatch = SimpleShiftPatternRegex().Match(s);
        if (shiftMatch.Success)
        {
            value = ulong.Parse(shiftMatch.Groups[1].Value) << int.Parse(shiftMatch.Groups[2].Value);
            return true;
        }

        return ulong.TryParse(s, out value);
    }

    #endregion

    #region Free Function Parsing

    void ParseFreeFunctions(string content, string subdir, string filePath)
    {
        string libraryPath = subdir switch
        {
            "Metal" => "/System/Library/Frameworks/Metal.framework/Metal",
            "MetalFX" => "/System/Library/Frameworks/MetalFX.framework/MetalFX",
            "Foundation" => "/System/Library/Frameworks/Foundation.framework/Foundation",
            "QuartzCore" => "/System/Library/Frameworks/QuartzCore.framework/QuartzCore",
            _ => "/System/Library/Frameworks/Metal.framework/Metal"
        };

        string cppNamespace = subdir switch
        {
            "Metal" => "MTL",
            "MetalFX" => "MTLFX",
            "Foundation" => "NS",
            "QuartzCore" => "CA",
            _ => "MTL"
        };

        string targetClassName = Path.GetFileNameWithoutExtension(filePath);

        foreach (Match m in ExternCRegex().Matches(content))
        {
            string returnType = m.Groups[1].Value.Trim();
            string cFuncName = m.Groups[2].Value.Trim();
            string paramsStr = m.Groups[3].Value.Trim();

            if (TypeMapper.IsUnmappableCppType(returnType)) continue;

            List<ParamDef> parameters = ParseParameters(paramsStr);
            if (parameters.Any(p => TypeMapper.IsUnmappableCppType(p.CppType) || p.CppType == "ARRAY_PARAM")) continue;
            if (parameters.Any(p => p.CppType.Contains("Handler") || p.CppType.Contains("Block") ||
                p.CppType.Contains("function") || p.CppType.Contains("Function"))) continue;

            string prefix = TypeMapper.GetPrefix(cppNamespace);
            string cppName = cFuncName.StartsWith(prefix) ? cFuncName[prefix.Length..] : cFuncName;

            context.FreeFunctions.Add(new FreeFunctionDef(cFuncName, returnType, cppName, parameters, libraryPath, cppNamespace, targetClassName));
        }
    }

    #endregion

    #region Class Parsing

    void ParseClasses(string content, string filePath)
    {
        List<(string Ns, int Pos)> namespacePositions = [];
        foreach (Match m in NamespacePatternRegex().Matches(content))
            namespacePositions.Add((m.Groups[1].Value, m.Index));

        foreach (Match cm in ClassPatternRegex().Matches(content))
        {
            string className = cm.Groups[1].Value;
            bool isCopying = cm.Groups[2].Value == "Copying";
            string? baseNsPrefix = cm.Groups[4].Success && cm.Groups[4].Value.Length > 0 ? cm.Groups[4].Value : null;
            string? baseClassName = cm.Groups[5].Success && cm.Groups[5].Value.Length > 0 ? cm.Groups[5].Value : null;

            string ns = "MTL";
            for (int i = namespacePositions.Count - 1; i >= 0; i--)
            {
                if (namespacePositions[i].Pos < cm.Index)
                {
                    ns = namespacePositions[i].Ns;
                    break;
                }
            }

            int braceStart = content.IndexOf('{', cm.Index + cm.Length);
            if (braceStart < 0) continue;
            int braceEnd = FindMatchingBrace(content, braceStart);
            if (braceEnd < 0) continue;

            string classBody = content[(braceStart + 1)..braceEnd];
            List<(string ReturnType, string Name, bool IsStatic, bool IsConst, List<ParamDef> Params)> rawMethods = ParseMethodDeclarations(classBody);

            Dictionary<(string MethodName, int ParamCount, int OverloadIndex), ImplInfo> implInfo = ParseInlineImplementations(content, ns, className);

            List<MethodInfo> methods = [];
            Dictionary<(string, int), int> overloadCounter = [];
            foreach (var (retType, name, isStatic, isConst, parameters) in rawMethods)
            {
                if (SkipMethods.Contains(name)) continue;

                (string, int) countKey = (name, parameters.Count);
                if (!overloadCounter.TryGetValue(countKey, out int idx))
                    idx = 0;
                overloadCounter[countKey] = idx + 1;

                (string, int, int) key = (name, parameters.Count, idx);
                bool usesClassTarget = implInfo.TryGetValue(key, out ImplInfo? info) && info.UsesClassTarget;
                string? selAccessor = info?.Accessor;

                methods.Add(new MethodInfo
                {
                    CppName = name,
                    ReturnType = retType,
                    IsStatic = isStatic,
                    IsConst = isConst,
                    Parameters = parameters,
                    UsesClassTarget = usesClassTarget,
                    SelectorAccessor = selAccessor
                });
            }

            string? csBaseClassName = null;
            if (baseClassName != null)
            {
                if (!string.IsNullOrEmpty(baseNsPrefix))
                {
                    string baseNs = baseNsPrefix.TrimEnd(':', ' ');
                    csBaseClassName = TypeMapper.GetPrefix(baseNs) + baseClassName;
                }
                else
                {
                    csBaseClassName = TypeMapper.GetPrefix(ns) + baseClassName;
                }
            }

            context.Classes.Add(new ClassDef
            {
                CppNamespace = ns,
                Name = className,
                IsCopying = isCopying,
                BaseClassName = csBaseClassName,
                Methods = methods
            });
        }
    }

    static int FindMatchingBrace(string content, int openPos)
    {
        int depth = 0;
        for (int i = openPos; i < content.Length; i++)
        {
            if (content[i] == '{') depth++;
            else if (content[i] == '}') { depth--; if (depth == 0) return i; }
        }
        return -1;
    }

    List<(string ReturnType, string Name, bool IsStatic, bool IsConst, List<ParamDef> Params)> ParseMethodDeclarations(string classBody)
    {
        List<(string, string, bool, bool, List<ParamDef>)> result = [];

        string cleaned = SingleLineCommentRegex().Replace(classBody, "");
        cleaned = MultiLineCommentRegex().Replace(cleaned, "");

        foreach (string rawLine in cleaned.Split('\n'))
        {
            string line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("public:") ||
                line.StartsWith("private:") || line.StartsWith("protected:") ||
                line.StartsWith("//") ||
                (line.StartsWith("class ") && !line.Contains('(')) ||
                (line.StartsWith("struct ") && !line.Contains('(')) ||
                line.StartsWith("using ") ||
                line.StartsWith("typedef ") || line.StartsWith("friend "))
                continue;

            Match methodMatch = MethodDeclRegex().Match(line);
            if (!methodMatch.Success) continue;

            bool isStatic = methodMatch.Groups[1].Success;
            string returnType = methodMatch.Groups[2].Value.Trim();
            string name = methodMatch.Groups[3].Value.Trim();
            string paramsStr = methodMatch.Groups[4].Value.Trim();
            bool isConst = methodMatch.Groups[5].Success;

            if (returnType is "class" or "struct") continue;

            List<ParamDef> parameters = ParseParameters(paramsStr);
            result.Add((returnType, name, isStatic, isConst, parameters));
        }

        return result;
    }

    Dictionary<(string MethodName, int ParamCount, int OverloadIndex), ImplInfo> ParseInlineImplementations(
        string content, string ns, string className)
    {
        Dictionary<(string, int, int), ImplInfo> result = [];
        Dictionary<(string, int), int> countTracker = [];
        string nsPattern = Regex.Escape(ns);

        Regex implRegex = new(
            $@"_\w+_INLINE\s+.+?\s+{nsPattern}::{Regex.Escape(className)}::(\w+)\s*\(([^)]*)\)\s*(?:const\s*)?\{{(.*?)\}}",
            RegexOptions.Singleline);

        foreach (Match m in implRegex.Matches(content))
        {
            string methodName = m.Groups[1].Value;
            string paramsStr = m.Groups[2].Value;
            string body = m.Groups[3].Value;

            int paramCount = string.IsNullOrWhiteSpace(paramsStr) ? 0 : SplitParams(paramsStr).Count;

            bool usesClassTarget = ClsCheckRegex().IsMatch(body);

            Match selMatch = SelMatchRegex().Match(body);
            string? accessor = selMatch.Success ? selMatch.Groups[1].Value : null;

            (string, int) key = (methodName, paramCount);
            if (!countTracker.TryGetValue(key, out int idx))
                idx = 0;
            countTracker[key] = idx + 1;

            result[(methodName, paramCount, idx)] = new ImplInfo(accessor, usesClassTarget);
        }

        return result;
    }

    #endregion

    #region Parameter Parsing

    List<ParamDef> ParseParameters(string paramsStr)
    {
        if (string.IsNullOrWhiteSpace(paramsStr)) return [];

        List<ParamDef> parameters = [];
        foreach (string part in SplitParams(paramsStr))
        {
            string p = part.Trim();
            if (string.IsNullOrWhiteSpace(p)) continue;

            if (p.Contains("[]"))
            {
                string cleaned = p.Replace("[]", "").Replace("const ", "").Trim();
                int lastSpace = cleaned.LastIndexOf(' ');
                if (lastSpace < 0)
                {
                    parameters.Add(new ParamDef("ARRAY_PARAM", "array"));
                    continue;
                }

                string elemType = cleaned[..lastSpace].Trim().TrimEnd('*').Trim();
                string name = cleaned[(lastSpace + 1)..].Trim().TrimStart('*');

                bool isPrimitive = elemType is "NS::UInteger" or "NS::Integer" or "float" or "double";
                bool hasPointerStar = cleaned[..lastSpace].Trim().Contains('*');

                if (!isPrimitive && hasPointerStar)
                    parameters.Add(new ParamDef($"OBJ_ARRAY:{elemType}", name));
                else if (isPrimitive)
                {
                    string primType = elemType switch
                    {
                        "NS::UInteger" => "nuint",
                        "NS::Integer" => "nint",
                        _ => elemType
                    };
                    parameters.Add(new ParamDef($"PRIM_ARRAY:{primType}", name));
                }
                else
                    parameters.Add(new ParamDef("ARRAY_PARAM", name));
                continue;
            }

            string cleanedParam = p.Replace("const ", "").Trim();

            int paramLastSpace = cleanedParam.LastIndexOf(' ');
            if (paramLastSpace < 0)
            {
                parameters.Add(new ParamDef(cleanedParam, "param"));
                continue;
            }

            string type = cleanedParam[..paramLastSpace].Trim();
            string paramName = cleanedParam[(paramLastSpace + 1)..].Trim();

            if (paramName.StartsWith('*'))
            {
                type += "*";
                paramName = paramName[1..];
            }

            parameters.Add(new ParamDef(type.Trim(), paramName));
        }

        // Post-process: detect StructType* + NS::UInteger count pairs and convert to STRUCT_ARRAY
        for (int i = 0; i < parameters.Count - 1; i++)
        {
            ParamDef param = parameters[i];
            ParamDef next = parameters[i + 1];

            if (param.CppType.EndsWith("*") && next.CppType is "NS::UInteger" && next.Name is "count")
            {
                string baseType = param.CppType[..^1].Trim();

                string resolved = baseType;
                Match nsMatch = NamespaceTypeRegex().Match(baseType);
                if (nsMatch.Success)
                    resolved = TypeMapper.GetPrefix(nsMatch.Groups[1].Value) + nsMatch.Groups[2].Value.Trim();

                if (TypeMapper.StructTypes.Contains(resolved))
                {
                    parameters[i] = new ParamDef($"STRUCT_ARRAY:{baseType}", param.Name);
                }
            }
        }

        return parameters;
    }

    static List<string> SplitParams(string paramsStr)
    {
        List<string> result = [];
        int depth = 0;
        int start = 0;

        for (int i = 0; i < paramsStr.Length; i++)
        {
            char c = paramsStr[i];
            if (c == '<' || c == '(') depth++;
            else if (c == '>' || c == ')') depth--;
            else if (c == ',' && depth == 0)
            {
                result.Add(paramsStr[start..i]);
                start = i + 1;
            }
        }

        result.Add(paramsStr[start..]);
        return result;
    }

    #endregion

    #region Generated Regex

    [GeneratedRegex(@"_\w+_PRIVATE_DEF_SEL\(\s*(\w+)\s*,\s*""([^""]+)""\s*\)")]
    private static partial Regex SelectorDefRegex();

    [GeneratedRegex(@"_\w+_PRIVATE_DEF_CLS\(\s*(\w+)\s*\)")]
    private static partial Regex ClassDefRegex();

    [GeneratedRegex(@"_(\w+)_(ENUM|OPTIONS)\s*\(\s*([^,]+?)\s*,\s*(\w+)\s*\)\s*\{([^}]*)\}", RegexOptions.Singleline)]
    private static partial Regex EnumPatternRegex();

    [GeneratedRegex(@"namespace\s+(MTL4FX|MTL4|MTLFX|MTL|NS|CA)\s*\{", RegexOptions.Multiline)]
    private static partial Regex NamespacePatternRegex();

    [GeneratedRegex(@"^(\w+)\s*(?:=\s*(.+))?$")]
    private static partial Regex EnumMemberRegex();

    [GeneratedRegex(@"(0x[\da-fA-F]+)ULL")]
    private static partial Regex HexUllSuffixRegex();

    [GeneratedRegex(@"(\d+)ULL")]
    private static partial Regex DecimalUllSuffixRegex();

    [GeneratedRegex(@"(0x[\da-fA-F]+)UL")]
    private static partial Regex HexUlSuffixRegex();

    [GeneratedRegex(@"(\d+)UL")]
    private static partial Regex DecimalUlSuffixRegex();

    [GeneratedRegex(@"(-?\d+)L\b")]
    private static partial Regex LSuffixRegex();

    [GeneratedRegex(@"^1\s*<<\s*(\d+)$")]
    private static partial Regex ShiftPatternRegex();

    [GeneratedRegex(@"^(\d+)&~(\d+)$")]
    private static partial Regex AndNotPatternRegex();

    [GeneratedRegex(@"^(\d+)<<(\d+)$")]
    private static partial Regex SimpleShiftPatternRegex();

    [GeneratedRegex(@"extern\s+""C""\s+(.+?)\s+(\w+)\s*\(([^)]*)\)\s*;", RegexOptions.Multiline)]
    private static partial Regex ExternCRegex();

    [GeneratedRegex(@"class\s+(\w+)\s*:\s*public\s+NS::(Referencing|Copying)\s*<\s*(\w+)(?:\s*,\s*((?:[\w:]+::)?)(\w+))?\s*>", RegexOptions.Multiline)]
    private static partial Regex ClassPatternRegex();

    [GeneratedRegex(@"//[^\n]*")]
    private static partial Regex SingleLineCommentRegex();

    [GeneratedRegex(@"/\*.*?\*/", RegexOptions.Singleline)]
    private static partial Regex MultiLineCommentRegex();

    [GeneratedRegex(@"^(static\s+)?(.+?)\s+(\w+)\s*\(([^)]*)\)\s*(const)?\s*;?\s*$")]
    private static partial Regex MethodDeclRegex();

    [GeneratedRegex(@"_\w+_PRIVATE_CLS\(")]
    private static partial Regex ClsCheckRegex();

    [GeneratedRegex(@"_\w+_PRIVATE_SEL\(\s*(\w+)\s*\)")]
    private static partial Regex SelMatchRegex();

    [GeneratedRegex(@"^(MTL4FX|MTL4|MTLFX|MTL|NS|CA|CG)\s*::\s*(.+)$")]
    private static partial Regex NamespaceTypeRegex();

    #endregion
}
