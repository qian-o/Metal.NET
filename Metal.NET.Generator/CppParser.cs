using System.Text;
using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Regex-based parser for metal-cpp C++ headers.
/// Extracts enums, classes, methods, free functions, and ObjC selector mappings.
/// </summary>
partial class CppParser(string metalCppDir, GeneratorContext context)
{
    /// <summary>Methods to skip during parsing (ObjC runtime methods handled by the framework).</summary>
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
            if (!File.Exists(file))
            {
                continue;
            }

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
            if (!Directory.Exists(dir))
            {
                continue;
            }

            foreach (string file in Directory.GetFiles(dir, "*.hpp"))
            {
                string fileName = Path.GetFileName(file);

                if (fileName.Contains("Private") || fileName.Contains("HeaderBridge") ||
                    fileName.Contains("Defines") || fileName.Contains("Version") ||
                    fileName.Contains("GPUAddress") || fileName.Contains("IOCompressor"))
                {
                    continue;
                }

                if (fileName is "Metal.hpp" or "Foundation.hpp" or "QuartzCore.hpp" or "MetalFX.hpp")
                {
                    continue;
                }

                string content = File.ReadAllText(file);

                // Always parse structs from all non-excluded files (including Types files)
                ParseStructs(content);

                // Skip Types files for enum/class/function parsing
                if (fileName.Contains("Types"))
                {
                    continue;
                }

                ParseBlockTypeAliases(content);
                ParseEnums(content);
                ParseClasses(content);
                ParseFreeFunctions(content, subdir, file);
            }
        }
    }

    #endregion

    #region Block Type Alias Parsing

    /// <summary>
    /// Known inline block signatures mapped to delegate names.
    /// These appear directly in method signatures without a <c>using</c> alias.
    /// </summary>
    static readonly Dictionary<string, string> InlineBlockDelegateNames = new()
    {
        ["void*, NS::UInteger"] = "MTLDeallocator",
        ["NS::String*, NS::String*, MTL::LogLevel, NS::String*"] = "MTLLogHandler",
        ["MTL::Function*, NS::Error*"] = "MTLNewFunctionCompletionHandler",
    };

    /// <summary>Override parameter names for known inline block types.</summary>
    static readonly Dictionary<string, string[]> InlineBlockParamNames = new()
    {
        ["MTLDeallocator"] = ["pointer", "length"],
        ["MTLLogHandler"] = ["subsystem", "category", "logLevel", "message"],
    };

    void ParseBlockTypeAliases(string content)
    {
        List<(string Ns, int Pos)> nsPositions = [];
        foreach (Match nm in NamespacePatternRegex().Matches(content))
        {
            nsPositions.Add((nm.Groups[1].Value, nm.Index));
        }

        foreach (Match m in BlockTypeAliasRegex().Matches(content))
        {
            string aliasName = m.Groups[1].Value;
            string paramStr = m.Groups[2].Value;

            if (aliasName == "ObserverBlock")
            {
                continue;
            }

            string ns = "MTL";
            for (int i = nsPositions.Count - 1; i >= 0; i--)
            {
                if (nsPositions[i].Pos < m.Index)
                {
                    ns = nsPositions[i].Ns;
                    break;
                }
            }

            string prefix = TypeMapper.GetPrefix(ns);
            string csDelegateName = prefix + aliasName;

            if (aliasName == "DeviceNotificationHandlerBlock")
            {
                continue;
            }

            if (context.BlockTypeAliases.Any(b => b.CsDelegateName == csDelegateName))
            {
                continue;
            }

            List<BlockParam> blockParams = ParseBlockParams(paramStr, ns);
            context.BlockTypeAliases.Add(new BlockTypeAlias(ns, aliasName, csDelegateName, blockParams));
        }

        foreach (Match m in InlineBlockMethodRegex().Matches(content))
        {
            string inlineParamStr = m.Groups[2].Value.Trim();

            string normalized = Regex.Replace(inlineParamStr, @"\s+", " ").Replace("const ", "").Trim();
            string typesOnly = ExtractTypesFromInlineBlock(normalized);

            if (!InlineBlockDelegateNames.TryGetValue(typesOnly, out string? delegateName))
            {
                continue;
            }

            if (context.BlockTypeAliases.Any(b => b.CsDelegateName == delegateName))
            {
                continue;
            }

            string ns = "MTL";
            for (int i = nsPositions.Count - 1; i >= 0; i--)
            {
                if (nsPositions[i].Pos < m.Index)
                {
                    ns = nsPositions[i].Ns;
                    break;
                }
            }

            List<BlockParam> blockParams = ParseBlockParams(inlineParamStr, ns);

            if (InlineBlockParamNames.TryGetValue(delegateName, out string[]? overrideNames))
            {
                for (int pi = 0; pi < overrideNames.Length && pi + 1 < blockParams.Count; pi++)
                {
                    blockParams[pi + 1] = blockParams[pi + 1] with { Name = overrideNames[pi] };
                }
            }

            context.BlockTypeAliases.Add(new BlockTypeAlias(ns, delegateName, delegateName, blockParams));
        }
    }

    static string ExtractTypesFromInlineBlock(string paramStr)
    {
        List<string> types = [];
        foreach (string part in paramStr.Split(','))
        {
            string p = part.Trim();
            if (string.IsNullOrWhiteSpace(p))
            {
                continue;
            }

            string[] tokens = p.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length >= 2 && !tokens[^1].Contains("::") && !tokens[^1].EndsWith('*'))
            {
                types.Add(string.Join(" ", tokens[..^1]));
            }
            else
            {
                types.Add(p);
            }
        }

        return string.Join(", ", types);
    }

    static List<BlockParam> ParseBlockParams(string paramStr, string defaultNs)
    {
        List<BlockParam> result = [new BlockParam("nint", "nint", "block")]; // ObjC block pointer is always first

        int paramIndex = 0;
        foreach (string part in paramStr.Split(','))
        {
            string p = part.Trim().Replace("const ", "").Trim();
            if (string.IsNullOrWhiteSpace(p))
            {
                continue;
            }

            string[] tokens = p.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string cppType;
            string paramName;

            if (tokens.Length >= 2 && !tokens[^1].Contains("::") && !tokens[^1].EndsWith('*'))
            {
                cppType = string.Join(" ", tokens[..^1]);
                paramName = tokens[^1].TrimStart('*');
            }
            else
            {
                cppType = p;
                paramName = InferParamNameFromType(cppType, paramIndex);
            }

            string csType = MapBlockParamType(cppType, defaultNs);
            paramName = SanitizeParamName(paramName, paramIndex);

            result.Add(new BlockParam(cppType, csType, paramName));
            paramIndex++;
        }

        HashSet<string> usedNames = [];
        for (int i = 0; i < result.Count; i++)
        {
            string name = result[i].Name;
            if (!usedNames.Add(name))
            {
                int suffix = 2;
                while (!usedNames.Add($"{name}{suffix}"))
                {
                    suffix++;
                }
                result[i] = result[i] with { Name = $"{name}{suffix}" };
            }
        }

        return result;
    }

    static string InferParamNameFromType(string cppType, int index)
    {
        string t = cppType.TrimEnd('*').Trim();

        if (t == "void")
        {
            return "pointer";
        }

        Match nsMatch = Regex.Match(t, @"(?:[\w]+::)?(\w+)$");
        if (nsMatch.Success)
        {
            string typeName = nsMatch.Groups[1].Value;
            return char.ToLower(typeName[0]) + typeName[1..];
        }

        return $"param{index}";
    }

    static string MapBlockParamType(string cppType, string defaultNs)
    {
        string t = cppType.Trim();

        if (t.EndsWith('*'))
        {
            return "nint";
        }

        return t switch
        {
            "NS::UInteger" or "NSUInteger" => "nuint",
            "NS::Integer" or "NSInteger" => "nint",
            "uint64_t" or "std::uint64_t" => "ulong",
            "int64_t" or "std::int64_t" => "long",
            "uint32_t" => "uint",
            "int32_t" => "int",
            "float" => "float",
            "double" => "double",
            "bool" => "bool",
            _ when t.Contains("::") => MapEnumOrValueType(t, defaultNs),
            _ => "nint"
        };
    }

    /// <summary>
    /// Block handler parameters pass enum/value types as their raw numeric backing type.
    /// </summary>
    static string MapEnumOrValueType(string cppType, string defaultNs)
    {
        if (Regex.IsMatch(cppType, @"^(MTL4FX|MTL4|MTLFX|MTL|NS|CA)\s*::\s*(.+)$"))
        {
            return "long";
        }

        return "nint";
    }

    static string SanitizeParamName(string name, int index)
    {
        if (string.IsNullOrWhiteSpace(name) || name.StartsWith('*'))
        {
            return $"param{index}";
        }

        if (name.Length > 1 && name[0] == 'p' && char.IsUpper(name[1]))
        {
            name = char.ToLower(name[1]) + name[2..];
        }

        name = TypeMapper.ToCamelCase(name);
        return TypeMapper.EscapeReservedWord(name);
    }

    #endregion

    #region Enum Parsing

    void ParseEnums(string content)
    {
        List<(string Ns, int Pos)> nsPositions = [];
        foreach (Match nm in NamespacePatternRegex().Matches(content))
        {
            nsPositions.Add((nm.Groups[1].Value, nm.Index));
        }

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
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            Match memberMatch = EnumMemberRegex().Match(line);
            if (!memberMatch.Success)
            {
                continue;
            }

            string cppMemberName = memberMatch.Groups[1].Value;
            string csValue;

            if (memberMatch.Groups[2].Success)
            {
                string value = memberMatch.Groups[2].Value.Trim();
                csValue = EvaluateEnumValue(value, cppNameToValue);
                if (long.TryParse(csValue, out long parsed))
                {
                    nextImplicitValue = (int)(parsed + 1);
                }
            }
            else
            {
                csValue = nextImplicitValue.ToString();
                nextImplicitValue++;
            }

            cppNameToValue[cppMemberName] = csValue;
            rawMembers.Add((cppMemberName, csValue));
        }

        string stripPrefix = ComputeEnumStripPrefix(cppEnumName, [.. rawMembers.Select(m => m.CppName)]);

        List<EnumMember> members = [];
        foreach ((string cppName, string value) in rawMembers)
        {
            string csName = cppName.StartsWith(stripPrefix)
                ? cppName[stripPrefix.Length..]
                : cppName;

            if (csName.Length > 0 && char.IsDigit(csName[0]))
            {
                csName = nsPrefix + csName;
            }

            if (string.IsNullOrEmpty(csName))
            {
                csName = cppName;
            }

            members.Add(new EnumMember(csName, value));
        }

        return members;
    }

    static string ComputeEnumStripPrefix(string cppEnumName, List<string> memberNames)
    {
        if (memberNames.Count == 0)
        {
            return cppEnumName;
        }

        if (memberNames.All(m => m.StartsWith(cppEnumName)))
        {
            return cppEnumName;
        }

        string lcp = memberNames[0];
        foreach (string name in memberNames.Skip(1))
        {
            int i = 0;
            while (i < lcp.Length && i < name.Length && lcp[i] == name[i])
            {
                i++;
            }

            lcp = lcp[..i];

            if (lcp.Length == 0)
            {
                break;
            }
        }

        if (lcp.Length == 0)
        {
            return cppEnumName;
        }

        bool atWordBoundary = memberNames.All(m =>
            m.Length <= lcp.Length || char.IsUpper(m[lcp.Length]) || char.IsDigit(m[lcp.Length]));

        if (atWordBoundary)
        {
            return lcp;
        }

        for (int i = lcp.Length - 1; i > 0; i--)
        {
            if (char.IsUpper(lcp[i]))
            {
                return lcp[..i];
            }
        }

        return lcp;
    }

    static string EvaluateEnumValue(string value, Dictionary<string, string> cppNameToValue)
    {
        try
        {
            string resolved = value;

            foreach ((string cppName, string memberValue) in cppNameToValue)
            {
                if (resolved.Contains(cppName))
                {
                    resolved = resolved.Replace(cppName, memberValue);
                }
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
            {
                resolved = resolved[1..^1].Trim();
            }

            Match shiftMatch = ShiftPatternRegex().Match(resolved);
            if (shiftMatch.Success)
            {
                return (1L << int.Parse(shiftMatch.Groups[1].Value)).ToString();
            }

            if (resolved.StartsWith("0x", StringComparison.OrdinalIgnoreCase) &&
                ulong.TryParse(resolved[2..], System.Globalization.NumberStyles.HexNumber, null, out ulong hexVal))
            {
                return hexVal.ToString();
            }

            if (long.TryParse(resolved, out long signedVal))
            {
                return signedVal.ToString();
            }

            if (ulong.TryParse(resolved, out ulong numVal))
            {
                return numVal.ToString();
            }

            ulong? evalResult = TryEvaluateExpression(resolved);
            if (evalResult.HasValue)
            {
                return evalResult.Value.ToString();
            }

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
                    {
                        result |= v;
                    }
                    else
                    {
                        return null;
                    }
                }
                return result;
            }

            Match andNotMatch = AndNotPatternRegex().Match(expr);
            if (andNotMatch.Success)
            {
                return ulong.Parse(andNotMatch.Groups[1].Value) & ~ulong.Parse(andNotMatch.Groups[2].Value);
            }

            if (TryParseSimpleValue(expr, out ulong val))
            {
                return val;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    static bool TryParseSimpleValue(string s, out ulong value)
    {
        s = s.Trim();
        if (s.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
        {
            return ulong.TryParse(s[2..], System.Globalization.NumberStyles.HexNumber, null, out value);
        }

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

            if (TypeMapper.IsUnmappableCppType(returnType))
            {
                continue;
            }

            List<ParamDef> parameters = ParseParameters(paramsStr);

            if (parameters.Any(p => TypeMapper.IsUnmappableCppType(p.CppType) || p.CppType == "ARRAY_PARAM"))
            {
                continue;
            }

            if (parameters.Any(p => p.CppType.Contains("Handler") || p.CppType.Contains("Block") ||
                p.CppType.Contains("function") || p.CppType.Contains("Function")))
            {
                continue;
            }

            string prefix = TypeMapper.GetPrefix(cppNamespace);
            string cppName = cFuncName.StartsWith(prefix) ? cFuncName[prefix.Length..] : cFuncName;

            context.FreeFunctions.Add(new FreeFunctionDef(
                cFuncName, returnType, cppName, parameters,
                libraryPath, cppNamespace, targetClassName));
        }
    }

    #endregion

    #region Struct Parsing

    /// <summary>Structs to skip during parsing (not relevant for C# interop).</summary>
    static readonly HashSet<string> SkipStructs = ["FastEnumerationState"];

    void ParseStructs(string content)
    {
        List<(string Ns, int Pos)> nsPositions = [];
        foreach (Match nm in NamespacePatternRegex().Matches(content))
        {
            nsPositions.Add((nm.Groups[1].Value, nm.Index));
        }

        // Find struct declarations followed by _*_PACKED using brace matching
        foreach (Match m in StructDeclRegex().Matches(content))
        {
            string structName = m.Groups[1].Value;
            if (SkipStructs.Contains(structName))
            {
                continue;
            }

            int braceStart = content.IndexOf('{', m.Index);
            if (braceStart < 0)
            {
                continue;
            }

            int braceEnd = FindMatchingBrace(content, braceStart);
            if (braceEnd < 0)
            {
                continue;
            }

            // Check for _*_PACKED marker after the closing brace
            string afterBrace = content[(braceEnd + 1)..Math.Min(braceEnd + 30, content.Length)].TrimStart();
            if (!PackedMarkerRegex().IsMatch(afterBrace))
            {
                continue;
            }

            // Avoid duplicates
            string ns = "MTL";
            for (int i = nsPositions.Count - 1; i >= 0; i--)
            {
                if (nsPositions[i].Pos < m.Index)
                {
                    ns = nsPositions[i].Ns;
                    break;
                }
            }

            string prefix = TypeMapper.GetPrefix(ns);
            if (context.Structs.Any(s => TypeMapper.GetPrefix(s.CppNamespace) + s.Name == prefix + structName))
            {
                continue;
            }

            string body = content[(braceStart + 1)..braceEnd];
            List<StructFieldDef> fields = ParseStructFields(body, ns);

            if (fields.Count > 0)
            {
                context.Structs.Add(new StructDef(ns, structName, fields));
            }
        }
    }

    /// <summary>
    /// Parses fields from a struct body, handling union/struct nesting and array fields.
    /// </summary>
    static List<StructFieldDef> ParseStructFields(string body, string defaultNs)
    {
        // First, flatten any union { struct { fields } ... } patterns
        // by extracting the fields from the inner struct
        string flattened = FlattenUnions(body);

        List<StructFieldDef> fields = [];
        foreach (string rawLine in flattened.Split('\n'))
        {
            string line = rawLine.Trim().TrimEnd(';');
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            // Skip constructor declarations, default constructors, static methods,
            // operator overloads, preprocessor directives, and access specifiers.
            if (line.Contains('(') || line.Contains(')') || line.Contains('=') ||
                line.StartsWith('#') || line.StartsWith("//") ||
                line is "public:" or "private:" or "protected:" ||
                line.StartsWith("static ") || line.StartsWith("union") ||
                line.StartsWith("struct") || line is "{" or "}")
            {
                continue;
            }

            // Handle array fields: "Type name[N]" → expand to N individual fields
            Match arrayMatch = StructArrayFieldRegex().Match(line);
            if (arrayMatch.Success)
            {
                string cppType = arrayMatch.Groups[1].Value.Trim();
                string baseName = arrayMatch.Groups[2].Value.Trim();
                if (int.TryParse(arrayMatch.Groups[3].Value, out int count))
                {
                    for (int i = 0; i < count; i++)
                    {
                        fields.Add(new StructFieldDef(cppType, $"{baseName}{i}"));
                    }
                }
                continue;
            }

            Match fieldMatch = StructFieldRegex().Match(line);
            if (!fieldMatch.Success)
            {
                continue;
            }

            string fieldType = fieldMatch.Groups[1].Value.Trim();
            string fieldName = fieldMatch.Groups[2].Value.Trim();

            // Strip leading underscores from field names (e.g., _impl → impl)
            fieldName = fieldName.TrimStart('_');
            if (string.IsNullOrEmpty(fieldName))
            {
                continue;
            }

            fields.Add(new StructFieldDef(fieldType, fieldName));
        }

        return fields;
    }

    /// <summary>
    /// Replaces union { struct { fields } ... } blocks with just the inner struct fields.
    /// This handles the PackedFloat3/PackedFloatQuaternion pattern in metal-cpp.
    /// </summary>
    static string FlattenUnions(string body)
    {
        StringBuilder result = new();
        int i = 0;

        while (i < body.Length)
        {
            // Look for "union" keyword at a word boundary
            int unionIdx = body.IndexOf("union", i, StringComparison.Ordinal);
            if (unionIdx < 0)
            {
                result.Append(body[i..]);
                break;
            }

            // Add everything before the union
            result.Append(body[i..unionIdx]);

            // Find the union's opening brace
            int unionBraceStart = body.IndexOf('{', unionIdx);
            if (unionBraceStart < 0)
            {
                result.Append(body[unionIdx..]);
                break;
            }

            int unionBraceEnd = FindMatchingBrace(body, unionBraceStart);
            if (unionBraceEnd < 0)
            {
                result.Append(body[unionIdx..]);
                break;
            }

            string unionBody = body[(unionBraceStart + 1)..unionBraceEnd];

            // Look for "struct {" inside the union body and extract its fields
            int structIdx = unionBody.IndexOf("struct", StringComparison.Ordinal);
            if (structIdx >= 0)
            {
                int structBraceStart = unionBody.IndexOf('{', structIdx);
                if (structBraceStart >= 0)
                {
                    int structBraceEnd = FindMatchingBrace(unionBody, structBraceStart);
                    if (structBraceEnd >= 0)
                    {
                        // Extract the inner struct fields
                        string innerFields = unionBody[(structBraceStart + 1)..structBraceEnd];
                        result.Append(innerFields);
                    }
                }
            }

            // Skip past the union closing brace and any trailing semicolons
            i = unionBraceEnd + 1;
            while (i < body.Length && (body[i] == ';' || body[i] == '\n' || body[i] == '\r' || body[i] == ' '))
            {
                i++;
            }
        }

        return result.ToString();
    }

    #endregion

    #region Class Parsing

    void ParseClasses(string content)
    {
        List<(string Ns, int Pos)> namespacePositions = [];
        foreach (Match m in NamespacePatternRegex().Matches(content))
        {
            namespacePositions.Add((m.Groups[1].Value, m.Index));
        }

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
            if (braceStart < 0)
            {
                continue;
            }

            int braceEnd = FindMatchingBrace(content, braceStart);
            if (braceEnd < 0)
            {
                continue;
            }

            string classBody = content[(braceStart + 1)..braceEnd];
            List<(string ReturnType, string Name, bool IsStatic, bool IsConst, List<ParamDef> Params, string? DeprecationMessage)> rawMethods =
                ParseMethodDeclarations(classBody);

            Dictionary<(string MethodName, int ParamCount, int OverloadIndex), ImplInfo> implInfo =
                ParseInlineImplementations(content, ns, className);

            List<MethodInfo> methods = [];
            Dictionary<(string, int), int> overloadCounter = [];
            foreach ((string retType, string name, bool isStatic, bool isConst, List<ParamDef> parameters, string? deprecationMessage) in rawMethods)
            {
                if (SkipMethods.Contains(name))
                {
                    continue;
                }

                (string, int) countKey = (name, parameters.Count);
                if (!overloadCounter.TryGetValue(countKey, out int idx))
                {
                    idx = 0;
                }
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
                    SelectorAccessor = selAccessor,
                    DeprecationMessage = deprecationMessage
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
            if (content[i] == '{')
            {
                depth++;
            }
            else if (content[i] == '}')
            {
                depth--;
                if (depth == 0)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    static List<(string ReturnType, string Name, bool IsStatic, bool IsConst, List<ParamDef> Params, string? DeprecationMessage)>
        ParseMethodDeclarations(string classBody)
    {
        List<(string, string, bool, bool, List<ParamDef>, string?)> result = [];

        string cleaned = SingleLineCommentRegex().Replace(classBody, "");
        cleaned = MultiLineCommentRegex().Replace(cleaned, "");

        string? pendingDeprecation = null;

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
            {
                continue;
            }

            Match deprecatedMatch = DeprecatedAttrRegex().Match(line);
            if (deprecatedMatch.Success)
            {
                pendingDeprecation = deprecatedMatch.Groups[1].Value;
                continue;
            }

            line = PreprocessInlineBlocks(line);

            Match methodMatch = MethodDeclRegex().Match(line);
            if (!methodMatch.Success)
            {
                pendingDeprecation = null;
                continue;
            }

            bool isStatic = methodMatch.Groups[1].Success;
            string returnType = methodMatch.Groups[2].Value.Trim();
            string name = methodMatch.Groups[3].Value.Trim();
            string paramsStr = methodMatch.Groups[4].Value.Trim();
            bool isConst = methodMatch.Groups[5].Success;

            if (returnType is "class" or "struct")
            {
                pendingDeprecation = null;
                continue;
            }

            List<ParamDef> parameters = ParseParameters(paramsStr);
            result.Add((returnType, name, isStatic, isConst, parameters, pendingDeprecation));
            pendingDeprecation = null;
        }

        return result;
    }

    /// <summary>
    /// Replaces inline block parameters like <c>void (^deallocator)(void*, NS::UInteger)</c> with a
    /// synthetic type marker <c>INLINE_BLOCK:delegateName deallocator</c> so the standard
    /// parameter parser can handle them.
    /// </summary>
    static string PreprocessInlineBlocks(string line)
    {
        while (true)
        {
            int idx = line.IndexOf("void (^");
            if (idx < 0)
            {
                idx = line.IndexOf("void(^");
            }

            if (idx < 0)
            {
                break;
            }

            int firstParen = line.IndexOf('(', idx + 4);
            if (firstParen < 0)
            {
                break;
            }

            int firstClose = line.IndexOf(')', firstParen);
            if (firstClose < 0)
            {
                break;
            }

            string blockSection = line[(firstParen + 1)..firstClose];
            string blockName = blockSection.TrimStart('^').Trim();
            if (string.IsNullOrWhiteSpace(blockName))
            {
                blockName = "handler";
            }

            int secondParen = line.IndexOf('(', firstClose + 1);
            if (secondParen < 0)
            {
                break;
            }

            int secondClose = FindMatchingParen(line, secondParen);
            if (secondClose < 0)
            {
                break;
            }

            string paramTypes = line[(secondParen + 1)..secondClose];

            string normalized = Regex.Replace(paramTypes.Replace("const ", ""), @"\s+", " ").Trim();
            string typesOnly = ExtractTypesFromInlineBlock(normalized);

            string delegateName;
            if (!InlineBlockDelegateNames.TryGetValue(typesOnly, out delegateName!))
            {
                delegateName = "UNKNOWN_BLOCK";
            }

            string replacement = $"INLINE_BLOCK:{delegateName} {blockName}";
            line = line[..idx] + replacement + line[(secondClose + 1)..];
        }

        return line;
    }

    static int FindMatchingParen(string s, int openPos)
    {
        int depth = 0;
        for (int i = openPos; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                depth++;
            }
            else if (s[i] == ')')
            {
                depth--;
                if (depth == 0)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    static Dictionary<(string MethodName, int ParamCount, int OverloadIndex), ImplInfo>
        ParseInlineImplementations(string content, string ns, string className)
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
            {
                idx = 0;
            }
            countTracker[key] = idx + 1;

            result[(methodName, paramCount, idx)] = new ImplInfo(accessor, usesClassTarget);
        }

        return result;
    }

    #endregion

    #region Parameter Parsing

    static List<ParamDef> ParseParameters(string paramsStr)
    {
        if (string.IsNullOrWhiteSpace(paramsStr))
        {
            return [];
        }

        List<ParamDef> parameters = [];
        foreach (string part in SplitParams(paramsStr))
        {
            string p = part.Trim();
            if (string.IsNullOrWhiteSpace(p))
            {
                continue;
            }

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
                {
                    parameters.Add(new ParamDef($"OBJ_ARRAY:{elemType}", name));
                }
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
                {
                    parameters.Add(new ParamDef("ARRAY_PARAM", name));
                }
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

            if (param.CppType.EndsWith('*') && next.CppType is "NS::UInteger" && next.Name is "count")
            {
                string baseType = param.CppType[..^1].Trim();

                string resolved = baseType;
                Match nsMatch = NamespaceTypeRegex().Match(baseType);
                if (nsMatch.Success)
                {
                    resolved = TypeMapper.GetPrefix(nsMatch.Groups[1].Value) + nsMatch.Groups[2].Value.Trim();
                }

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

    [GeneratedRegex(@"\[\[deprecated\(""(.+?)""\)\]\]")]
    private static partial Regex DeprecatedAttrRegex();

    [GeneratedRegex(@"_\w+_PRIVATE_CLS\(")]
    private static partial Regex ClsCheckRegex();

    [GeneratedRegex(@"_\w+_PRIVATE_SEL\(\s*(\w+)\s*\)")]
    private static partial Regex SelMatchRegex();

    [GeneratedRegex(@"^(MTL4FX|MTL4|MTLFX|MTL|NS|CA|CG)\s*::\s*(.+)$")]
    private static partial Regex NamespaceTypeRegex();

    [GeneratedRegex(@"using\s+(\w+)\s*=\s*void\s*\(\^\)\s*\(([^)]*)\)\s*;")]
    private static partial Regex BlockTypeAliasRegex();

    [GeneratedRegex(@"void\s+\(\^(\w*)\)\s*\(([^)]+)\)")]
    private static partial Regex InlineBlockMethodRegex();

    [GeneratedRegex(@"struct\s+(\w+)\s*\{([^}]*)\}\s*_MTL_PACKED\s*;", RegexOptions.Singleline)]
    private static partial Regex PackedStructRegex();

    [GeneratedRegex(@"(?:^|\n)\s*struct\s+(\w+)\s*\{", RegexOptions.Multiline)]
    private static partial Regex StructDeclRegex();

    [GeneratedRegex(@"^_\w+_PACKED\b")]
    private static partial Regex PackedMarkerRegex();

    [GeneratedRegex(@"^(.+?)\s+(\w+)\[(\d+)\]$")]
    private static partial Regex StructArrayFieldRegex();

    [GeneratedRegex(@"^(.+?)\s+(\w+)$")]
    private static partial Regex StructFieldRegex();

    #endregion
}
