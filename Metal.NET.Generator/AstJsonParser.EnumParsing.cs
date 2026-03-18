namespace Metal.NET.Generator;

partial class AstJsonParser
{
    #region Enum Parsing

    static void ParseEnums(AstRoot ast, GeneratorContext context)
    {
        foreach (AstEnum astEnum in ast.Enums)
        {
            if (astEnum.Framework is null or "CoreFoundation" or "CoreGraphics")
            {
                continue;
            }

            string ns = InferNamespaceFromName(astEnum.Name);
            string prefix = TypeMapper.GetPrefix(ns);
            string backingType = MapEnumBackingType(astEnum.UnderlyingType);

            // Strip the ObjC prefix from enum name to get the bare name
            string bareName = astEnum.Name;
            if (bareName.StartsWith(prefix))
            {
                bareName = bareName[prefix.Length..];
            }

            string csEnumName = prefix + bareName;
            context.EnumBackingTypes[csEnumName] = backingType;

            // First pass: strip prefixes and collect processed names
            List<(string name, AstEnumMember src)> processed = [];
            bool anyDigitLeading = false;
            foreach (AstEnumMember m in astEnum.Members)
            {
                // Strip the enum prefix from member names
                string memberName = m.Name;
                if (memberName.StartsWith(astEnum.Name))
                {
                    memberName = memberName[astEnum.Name.Length..];
                }
                else if (memberName.StartsWith(prefix))
                {
                    memberName = memberName[prefix.Length..];
                    // If the remaining starts with the bare enum name, strip that too
                    if (memberName.StartsWith(bareName))
                    {
                        memberName = memberName[bareName.Length..];
                    }
                }

                // Handle leading underscores: strip '_' and PascalCase the first word
                // e.g. _iOS_GPUFamily1_v1 → Ios_GPUFamily1_v1
                if (memberName.Length > 0 && memberName[0] == '_')
                {
                    memberName = memberName.TrimStart('_');
                    if (memberName.Length > 0 && char.IsLower(memberName[0]))
                    {
                        int sepIdx = memberName.IndexOf('_');
                        if (sepIdx > 0)
                        {
                            memberName = char.ToUpper(memberName[0]) + memberName[1..sepIdx].ToLowerInvariant() + memberName[sepIdx..];
                        }
                        else
                        {
                            memberName = char.ToUpper(memberName[0]) + memberName[1..].ToLowerInvariant();
                        }
                    }
                }

                if (string.IsNullOrEmpty(memberName))
                {
                    memberName = m.Name;
                }

                if (memberName.Length > 0 && char.IsDigit(memberName[0]))
                {
                    anyDigitLeading = true;
                }

                processed.Add((memberName, m));
            }

            // Second pass: when any member starts with a digit, prefix ALL members for consistency
            List<EnumMember> members = [];
            foreach (var (name, src) in processed)
            {
                string finalName = name;
                if (anyDigitLeading && name.Length > 0 && !name.StartsWith(prefix))
                {
                    finalName = prefix + name;
                }

                members.Add(new EnumMember(finalName, src.Value, src.Deprecated, src.DeprecationMessage));
            }

            // Strip common PascalCase prefix shared by all enum members
            if (members.Count > 1)
            {
                string commonPrefix = FindCommonEnumPrefix(members);
                if (commonPrefix.Length > 0)
                {
                    List<EnumMember> stripped = [];
                    bool valid = true;
                    HashSet<string> uniqueCheck = [];
                    foreach (EnumMember em in members)
                    {
                        string newName = em.Name[commonPrefix.Length..];
                        if (string.IsNullOrEmpty(newName))
                        {
                            valid = false;
                            break;
                        }

                        if (char.IsDigit(newName[0]))
                        {
                            valid = false;
                            break;
                        }

                        if (!uniqueCheck.Add(newName))
                        {
                            valid = false;
                            break;
                        }

                        stripped.Add(new EnumMember(newName, em.Value, em.Deprecated, em.DeprecationMessage));
                    }

                    if (valid)
                    {
                        members = stripped;
                    }
                }
            }

            context.Enums.Add(new EnumDef(
                ns, bareName, backingType, astEnum.IsOptions, members,
                astEnum.Deprecated, astEnum.DeprecationMessage));
        }
    }

    /// <summary>Maps an ObjC enum underlying type to a C# backing type.</summary>
    static string MapEnumBackingType(string objcType) => objcType.Trim() switch
    {
        "NSUInteger" => "ulong",
        "NSInteger" => "long",
        "uint32_t" => "uint",
        "int32_t" => "int",
        "uint8_t" => "byte",
        "uint64_t" => "ulong",
        "int64_t" => "long",
        _ => "ulong"
    };

    /// <summary>
    /// Finds the longest common PascalCase prefix shared by all enum member names.
    /// Returns empty string if no common prefix exists or stripping it would be invalid.
    /// </summary>
    static string FindCommonEnumPrefix(List<EnumMember> members)
    {
        if (members.Count <= 1)
        {
            return "";
        }

        // Compute character-level longest common prefix
        string lcp = members[0].Name;
        foreach (EnumMember m in members.Skip(1))
        {
            int i = 0;
            while (i < lcp.Length && i < m.Name.Length && lcp[i] == m.Name[i])
            {
                i++;
            }

            lcp = lcp[..i];
        }

        if (lcp.Length == 0)
        {
            return "";
        }

        // Find the rightmost PascalCase word boundary where all remaining names start with uppercase.
        // The prefix must end with a lowercase letter to ensure we split at a complete word boundary
        // (avoids splitting acronyms like "MTL" into "MT" + "L...").
        for (int pos = lcp.Length; pos > 0; pos--)
        {
            // Ensure the prefix ends at a complete PascalCase word boundary
            if (!char.IsLower(lcp[pos - 1]))
            {
                continue;
            }

            bool valid = true;
            foreach (EnumMember m in members)
            {
                if (pos >= m.Name.Length || !char.IsUpper(m.Name[pos]))
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
            {
                return lcp[..pos];
            }
        }

        return "";
    }

    #endregion
}
