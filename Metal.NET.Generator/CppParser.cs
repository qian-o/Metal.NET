using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

class CppParser(string metalCppDir, GeneratorContext context)
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

        foreach (var file in bridgeFiles)
        {
            if (!File.Exists(file)) continue;
            string content = File.ReadAllText(file);

            foreach (Match m in Regex.Matches(content,
                @"_\w+_PRIVATE_DEF_SEL\(\s*(\w+)\s*,\s*""([^""]+)""\s*\)"))
            {
                context.SelectorMap[m.Groups[1].Value] = m.Groups[2].Value;
            }

            foreach (Match m in Regex.Matches(content, @"_\w+_PRIVATE_DEF_CLS\(\s*(\w+)\s*\)"))
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

        foreach (var subdir in subdirs)
        {
            string dir = Path.Combine(metalCppDir, subdir);
            if (!Directory.Exists(dir)) continue;

            foreach (var file in Directory.GetFiles(dir, "*.hpp"))
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
        var enumRegex = new Regex(
            @"_(\w+)_(ENUM|OPTIONS)\s*\(\s*([^,]+?)\s*,\s*(\w+)\s*\)\s*\{([^}]*)\}",
            RegexOptions.Singleline);

        var namespaceRegex = new Regex(@"namespace\s+(MTL4FX|MTL4|MTLFX|MTL|NS|CA)\s*\{", RegexOptions.Multiline);
        var nsPositions = new List<(string Ns, int Pos)>();
        foreach (Match nm in namespaceRegex.Matches(content))
            nsPositions.Add((nm.Groups[1].Value, nm.Index));

        foreach (Match m in enumRegex.Matches(content))
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

            var members = ParseEnumMembers(body, name, prefix);
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
        var rawMembers = new List<(string CppName, string Value)>();
        var cppNameToValue = new Dictionary<string, string>();
        int nextImplicitValue = 0;

        foreach (var rawLine in body.Split('\n'))
        {
            var line = rawLine.Trim().TrimEnd(',');
            if (string.IsNullOrWhiteSpace(line)) continue;

            var memberMatch = Regex.Match(line, @"^(\w+)\s*(?:=\s*(.+))?$");
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

        var members = new List<EnumMember>();
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
        foreach (var name in memberNames.Skip(1))
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

            resolved = Regex.Replace(resolved, @"(0x[\da-fA-F]+)ULL", "$1");
            resolved = Regex.Replace(resolved, @"(\d+)ULL", "$1");
            resolved = Regex.Replace(resolved, @"(0x[\da-fA-F]+)UL", "$1");
            resolved = Regex.Replace(resolved, @"(\d+)UL", "$1");
            resolved = resolved.Replace("NS::UIntegerMax", "18446744073709551615");
            resolved = resolved.Replace("NS::IntegerMax", "9223372036854775807");
            resolved = Regex.Replace(resolved, @"(-?\d+)L\b", "$1");
            resolved = resolved.Trim();
            while (resolved.StartsWith('(') && resolved.EndsWith(')'))
                resolved = resolved[1..^1].Trim();

            var shiftMatch = Regex.Match(resolved, @"^1\s*<<\s*(\d+)$");
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
                foreach (var part in expr.Split('|'))
                {
                    if (TryParseSimpleValue(part.Trim(), out ulong v))
                        result |= v;
                    else
                        return null;
                }
                return result;
            }

            var andNotMatch = Regex.Match(expr, @"^(\d+)&~(\d+)$");
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

        var shiftMatch = Regex.Match(s, @"^(\d+)<<(\d+)$");
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

        var externRegex = new Regex(
            @"extern\s+""C""\s+(.+?)\s+(\w+)\s*\(([^)]*)\)\s*;",
            RegexOptions.Multiline);

        foreach (Match m in externRegex.Matches(content))
        {
            string returnType = m.Groups[1].Value.Trim();
            string cFuncName = m.Groups[2].Value.Trim();
            string paramsStr = m.Groups[3].Value.Trim();

            if (TypeMapper.IsUnmappableCppType(returnType)) continue;

            var parameters = ParseParameters(paramsStr);
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
        var classRegex = new Regex(
            @"class\s+(\w+)\s*:\s*public\s+NS::(Referencing|Copying)\s*<\s*(\w+)(?:\s*,\s*((?:[\w:]+::)?)(\w+))?\s*>",
            RegexOptions.Multiline);

        var namespaceRegex = new Regex(@"namespace\s+(MTL4FX|MTL4|MTLFX|MTL|NS|CA)\s*\{", RegexOptions.Multiline);

        var namespacePositions = new List<(string Ns, int Pos)>();
        foreach (Match m in namespaceRegex.Matches(content))
            namespacePositions.Add((m.Groups[1].Value, m.Index));

        foreach (Match cm in classRegex.Matches(content))
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
            var rawMethods = ParseMethodDeclarations(classBody);

            var implInfo = ParseInlineImplementations(content, ns, className);

            var methods = new List<MethodInfo>();
            var overloadCounter = new Dictionary<(string, int), int>();
            foreach (var (retType, name, isStatic, isConst, parameters) in rawMethods)
            {
                if (SkipMethods.Contains(name)) continue;

                var countKey = (name, parameters.Count);
                if (!overloadCounter.TryGetValue(countKey, out int idx))
                    idx = 0;
                overloadCounter[countKey] = idx + 1;

                var key = (name, parameters.Count, idx);
                bool usesClassTarget = implInfo.TryGetValue(key, out var info) && info.UsesClassTarget;
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
        var result = new List<(string, string, bool, bool, List<ParamDef>)>();

        var cleaned = Regex.Replace(classBody, @"//[^\n]*", "");
        cleaned = Regex.Replace(cleaned, @"/\*.*?\*/", "", RegexOptions.Singleline);

        foreach (var rawLine in cleaned.Split('\n'))
        {
            var line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("public:") ||
                line.StartsWith("private:") || line.StartsWith("protected:") ||
                line.StartsWith("//") ||
                (line.StartsWith("class ") && !line.Contains('(')) ||
                (line.StartsWith("struct ") && !line.Contains('(')) ||
                line.StartsWith("using ") ||
                line.StartsWith("typedef ") || line.StartsWith("friend "))
                continue;

            var methodMatch = Regex.Match(line,
                @"^(static\s+)?(.+?)\s+(\w+)\s*\(([^)]*)\)\s*(const)?\s*;?\s*$");
            if (!methodMatch.Success) continue;

            bool isStatic = methodMatch.Groups[1].Success;
            string returnType = methodMatch.Groups[2].Value.Trim();
            string name = methodMatch.Groups[3].Value.Trim();
            string paramsStr = methodMatch.Groups[4].Value.Trim();
            bool isConst = methodMatch.Groups[5].Success;

            if (returnType is "class" or "struct") continue;

            var parameters = ParseParameters(paramsStr);
            result.Add((returnType, name, isStatic, isConst, parameters));
        }

        return result;
    }

    Dictionary<(string MethodName, int ParamCount, int OverloadIndex), ImplInfo> ParseInlineImplementations(
        string content, string ns, string className)
    {
        var result = new Dictionary<(string, int, int), ImplInfo>();
        var countTracker = new Dictionary<(string, int), int>();
        string nsPattern = Regex.Escape(ns);

        var implRegex = new Regex(
            $@"_\w+_INLINE\s+.+?\s+{nsPattern}::{Regex.Escape(className)}::(\w+)\s*\(([^)]*)\)\s*(?:const\s*)?\{{(.*?)\}}",
            RegexOptions.Singleline);

        foreach (Match m in implRegex.Matches(content))
        {
            string methodName = m.Groups[1].Value;
            string paramsStr = m.Groups[2].Value;
            string body = m.Groups[3].Value;

            int paramCount = string.IsNullOrWhiteSpace(paramsStr) ? 0 : SplitParams(paramsStr).Count;

            bool usesClassTarget = Regex.IsMatch(body, @"_\w+_PRIVATE_CLS\(");

            var selMatch = Regex.Match(body, @"_\w+_PRIVATE_SEL\(\s*(\w+)\s*\)");
            string? accessor = selMatch.Success ? selMatch.Groups[1].Value : null;

            var key = (methodName, paramCount);
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

        var parameters = new List<ParamDef>();
        foreach (var part in SplitParams(paramsStr))
        {
            var p = part.Trim();
            if (string.IsNullOrWhiteSpace(p)) continue;

            if (p.Contains("[]"))
            {
                var cleaned = p.Replace("[]", "").Replace("const ", "").Trim();
                var lastSpace = cleaned.LastIndexOf(' ');
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

            var cleanedParam = p.Replace("const ", "").Trim();

            var paramLastSpace = cleanedParam.LastIndexOf(' ');
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
            var param = parameters[i];
            var next = parameters[i + 1];

            if (param.CppType.EndsWith("*") && next.CppType is "NS::UInteger" && next.Name is "count")
            {
                string baseType = param.CppType[..^1].Trim();

                string resolved = baseType;
                var nsMatch = Regex.Match(baseType, @"^(MTL4FX|MTL4|MTLFX|MTL|NS|CA|CG)\s*::\s*(.+)$");
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
        var result = new List<string>();
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
}
