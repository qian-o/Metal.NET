using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Deserializes metal-ast.json and populates a <see cref="GeneratorContext"/>
/// with enum, class, struct, free function, and block type alias definitions.
/// </summary>
partial class AstJsonParser
{
    #region Block Typedef Parsing

    static void ParseBlockTypedefs(AstRoot ast, GeneratorContext context)
    {
        foreach (AstTypedef td in ast.Typedefs)
        {
            if (!td.UnderlyingType.Contains("(^)"))
            {
                continue;
            }

            string ns = InferNamespaceFromName(td.Name);

            // Parse the block signature: "void (^)(ParamType1 name1, ParamType2 name2)"
            Match blockMatch = BlockSignatureRegex().Match(td.UnderlyingType);
            if (!blockMatch.Success)
            {
                continue;
            }

            string paramsStr = blockMatch.Groups[1].Value.Trim();
            List<BlockParam> blockParams = [new BlockParam("nint", "nint", "block")]; // ObjC block pointer is always first

            if (!string.IsNullOrWhiteSpace(paramsStr))
            {
                int paramIndex = 0;
                foreach (string part in SplitBlockParams(paramsStr))
                {
                    string p = part.Trim();
                    if (string.IsNullOrWhiteSpace(p))
                    {
                        continue;
                    }

                    // Parse ObjC type and infer param name
                    string objcType = p;
                    string paramName = InferParamNameFromObjCType(objcType, paramIndex);
                    string csType = MapBlockParamType(objcType);

                    blockParams.Add(new BlockParam(objcType, csType, paramName));
                    paramIndex++;
                }
            }

            // Deduplicate param names
            HashSet<string> usedNames = [];
            for (int i = 0; i < blockParams.Count; i++)
            {
                string name = blockParams[i].Name;
                if (!usedNames.Add(name))
                {
                    int suffix = 2;
                    while (!usedNames.Add($"{name}{suffix}"))
                    {
                        suffix++;
                    }
                    blockParams[i] = blockParams[i] with { Name = $"{name}{suffix}" };
                }
            }

            context.BlockTypeAliases.Add(new BlockTypeAlias(ns, td.Name, td.Name, blockParams));
        }
    }

    /// <summary>Infers a meaningful parameter name from an ObjC type string.</summary>
    static string InferParamNameFromObjCType(string objcType, int index)
    {
        // Strip nullability annotations
        string t = StripNullability(objcType);

        // id<MTLFoo> → foo
        Match idMatch = IdProtocolRegex().Match(t);
        if (idMatch.Success)
        {
            string typeName = idMatch.Groups[1].Value;
            return char.ToLower(typeName[0]) + typeName[1..];
        }

        // MTLFoo * → foo
        if (t.EndsWith('*'))
        {
            string baseName = t.TrimEnd('*').Trim();
            if (baseName.Length > 0)
            {
                // Get last component
                string[] parts = baseName.Split(' ');
                string last = parts[^1];
                return char.ToLower(last[0]) + last[1..];
            }
        }

        // void * → pointer
        if (t.StartsWith("void"))
        {
            return "pointer";
        }

        // Primitive types
        return t switch
        {
            "NSUInteger" or "uint64_t" => "value",
            _ => $"param{index}"
        };
    }

    /// <summary>Maps an ObjC block parameter type to its C# equivalent.</summary>
    static string MapBlockParamType(string objcType)
    {
        string t = StripNullability(objcType).Trim();

        // id<Protocol> → nint (pointer to ObjC object)
        if (t.StartsWith("id<") || t.StartsWith("id "))
        {
            return "nint";
        }

        // Any pointer type → nint
        if (t.EndsWith('*'))
        {
            return "nint";
        }

        return t switch
        {
            "NSUInteger" => "nuint",
            "NSInteger" => "nint",
            "uint64_t" => "ulong",
            "int64_t" => "long",
            "uint32_t" => "uint",
            "int32_t" => "int",
            "float" => "float",
            "double" => "double",
            "BOOL" => "bool",
            _ when t.Contains("MTL") || t.Contains("NS") || t.Contains("CA") => "long",
            _ => "nint"
        };
    }

    /// <summary>Splits a block signature parameter list respecting nested angle brackets and parens.</summary>
    static List<string> SplitBlockParams(string paramsStr)
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
}
