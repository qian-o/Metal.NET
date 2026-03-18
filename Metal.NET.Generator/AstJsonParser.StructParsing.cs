namespace Metal.NET.Generator;

partial class AstJsonParser
{
    #region Struct Parsing

    static void ParseStructs(AstRoot ast, GeneratorContext context)
    {
        foreach (AstStruct astStruct in ast.Structs)
        {
            if (SkipStructParseNames.Contains(astStruct.Name))
            {
                continue;
            }

            string ns = InferNamespaceFromName(astStruct.Name);
            if (ns.Length == 0)
            {
                // Structs without a known prefix (like CGSize) are skipped
                continue;
            }

            string prefix = TypeMapper.GetPrefix(ns);
            string bareName = astStruct.Name.StartsWith(prefix)
                ? astStruct.Name[prefix.Length..]
                : astStruct.Name;

            // Special handling for MTLPackedFloat3 which has a union in the AST
            if (astStruct.Name == "MTLPackedFloat3")
            {
                context.Structs.Add(new StructDef(ns, bareName, [
                    new StructFieldDef("float", "x"),
                    new StructFieldDef("float", "y"),
                    new StructFieldDef("float", "z"),
                ]));
                continue;
            }

            List<StructFieldDef> fields = [];
            foreach (AstStructField f in astStruct.Fields)
            {
                string fieldType = f.Type;

                // Handle array fields: "Type[N]" → expand to N individual fields
                Match arrayMatch = ArrayFieldRegex().Match(fieldType);
                if (arrayMatch.Success)
                {
                    string elemType = arrayMatch.Groups[1].Value;
                    if (int.TryParse(arrayMatch.Groups[2].Value, out int count))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            fields.Add(new StructFieldDef(elemType, $"{f.Name}{i}"));
                        }
                        continue;
                    }
                }

                // Skip union/nested struct types
                if (fieldType.Contains("union") || fieldType.Contains("anonymous"))
                {
                    continue;
                }

                fields.Add(new StructFieldDef(fieldType, f.Name));
            }

            if (fields.Count > 0)
            {
                context.Structs.Add(new StructDef(ns, bareName, fields));
            }
        }
    }

    #endregion
}
