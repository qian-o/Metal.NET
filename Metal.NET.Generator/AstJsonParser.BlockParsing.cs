namespace Metal.NET.Generator;

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

        // void * / const void * → pointer (must check before general pointer case)
        if (t.Replace("const ", "").Trim().StartsWith("void"))
        {
            return "pointer";
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

    /// <summary>
    /// Scans all method parameters in protocols and classes for inline block
    /// signatures (e.g. <c>void (^)(id&lt;MTLFunction&gt;, NSError *)</c>) and
    /// auto-registers a <see cref="BlockTypeAlias"/> for each unique signature.
    /// This must run after <see cref="ParseBlockTypedefs"/> so that already-known
    /// typedef names remain authoritative.
    /// </summary>
    static void ParseInlineBlocks(AstRoot ast, GeneratorContext context)
    {
        // Collect already-known typedef names so we don't duplicate them
        HashSet<string> knownDelegateNames = [.. context.BlockTypeAliases.Select(b => b.CsDelegateName)];

        // Track unique signatures to avoid duplicates
        Dictionary<string, string> signatureToDelegateName = [];

        // Copy existing InlineBlockDelegateNames entries
        foreach ((string sig, string name) in InlineBlockDelegateNames)
        {
            signatureToDelegateName[sig] = name;
        }

        foreach (AstClass cls in ast.Protocols.Concat(ast.Classes))
        {
            foreach (AstMethod method in cls.Methods)
            {
                foreach (AstParam param in method.Parameters)
                {
                    string t = StripNullability(param.Type).Trim();
                    if (!t.Contains("(^"))
                    {
                        continue;
                    }

                    Match inlineBlockMatch = InlineBlockTypeRegex().Match(t);
                    if (!inlineBlockMatch.Success)
                    {
                        continue;
                    }

                    string paramsStr = inlineBlockMatch.Groups[1].Value.Trim();

                    // Already mapped
                    if (signatureToDelegateName.ContainsKey(paramsStr))
                    {
                        continue;
                    }

                    // Parse the block params
                    List<BlockParam> blockParams = [new BlockParam("nint", "nint", "block")];
                    bool hasUnmappableParam = false;

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

                            string stripped = StripNullability(p).Trim();

                            // Skip signatures with generic type params or struct types
                            if (stripped is "ObjectType" or "KeyType" or "NSRange")
                            {
                                hasUnmappableParam = true;
                                break;
                            }

                            string csType = MapBlockParamType(p);
                            string paramName = InferParamNameFromObjCType(p, paramIndex);
                            // Store raw ObjC type (with nullability) to match typedef behavior
                            blockParams.Add(new BlockParam(p, csType, paramName));
                            paramIndex++;
                        }
                    }

                    if (hasUnmappableParam)
                    {
                        continue;
                    }

                    // Derive a delegate name from the class + param name (e.g. MTLLibraryNewFunctionCompletionHandler)
                    string delegateName = DeriveDelegateName(cls.Name, method, param.Name);

                    // Ensure uniqueness
                    if (knownDelegateNames.Contains(delegateName))
                    {
                        delegateName += "Block";
                    }

                    // Deduplicate param names within the block
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

                    string ns = InferNamespaceFromName(cls.Name);
                    signatureToDelegateName[paramsStr] = delegateName;
                    knownDelegateNames.Add(delegateName);
                    context.BlockTypeAliases.Add(new BlockTypeAlias(ns, delegateName, delegateName, blockParams));
                }
            }
        }

        // Update the shared lookup so MapObjCTypeForModel can resolve them
        foreach ((string sig, string name) in signatureToDelegateName)
        {
            InlineBlockDelegateNames.TryAdd(sig, name);
        }
    }

    /// <summary>
    /// Derives a delegate class name from the class, method, and parameter context.
    /// E.g. MTLLibrary + makeFunction + completionHandler → MTLNewFunctionCompletionHandler
    /// </summary>
    static string DeriveDelegateName(string className, AstMethod method, string paramName)
    {
        // For completion handlers, use the selector pattern
        string sel = method.Selector;
        string prefix = InferNamespaceFromName(className);

        // Try to build from selector: "newFunctionWithName:constantValues:completionHandler:"
        // Take the first segment as the base name
        string baseName = SelectorToMethodName(sel);

        // Capitalize the param name part for the suffix
        string suffix = TypeMapper.ToPascalCase(paramName);

        // Build: MTL + PascalCase(baseName) + PascalCase(paramName)
        return prefix + TypeMapper.ToPascalCase(baseName) + suffix;
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
