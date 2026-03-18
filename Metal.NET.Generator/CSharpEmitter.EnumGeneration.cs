namespace Metal.NET.Generator;

partial class CSharpEmitter
{
    #region Enum Generation

    /// <summary>
    /// Generates a consolidated enum file (e.g., <c>Metal/MTLEnums.cs</c>) containing
    /// all enums for the given output subdirectory.
    /// </summary>
    void GenerateEnumFile(string subdir, List<EnumDef> enums)
    {
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        string fileName = GetConsolidatedFileName(subdir, "Enums");

        StringBuilder sb = new();
        sb.AppendLine("namespace Metal.NET;");

        for (int ei = 0; ei < enums.Count; ei++)
        {
            EnumDef enumDef = enums[ei];
            string prefix = TypeMapper.GetPrefix(enumDef.Namespace);
            string csEnumName = prefix + enumDef.Name;

            sb.AppendLine();

            // Enum-level [Obsolete] from AST
            if (enumDef.Deprecated)
            {
                sb.AppendLine(enumDef.DeprecationMessage is { } dm
                    ? $"[Obsolete(\"{dm}\")]"
                    : "[Obsolete]");
            }

            if (enumDef.IsFlags)
            {
                sb.AppendLine("[Flags]");
            }

            sb.AppendLine($"public enum {csEnumName} : {enumDef.BackingType}");
            sb.AppendLine("{");

            for (int i = 0; i < enumDef.Members.Count; i++)
            {
                EnumMember member = enumDef.Members[i];
                string comma = i < enumDef.Members.Count - 1 ? "," : "";
                if (i > 0)
                {
                    sb.AppendLine();
                }

                if (member.Deprecated)
                {
                    sb.AppendLine(member.DeprecationMessage is { } mdm
                        ? $"    [Obsolete(\"{mdm}\")]"
                        : "    [Obsolete]");
                }

                sb.AppendLine($"    {member.Name} = {member.Value}{comma}");
            }

            sb.AppendLine("}");
        }

        File.WriteAllText(Path.Combine(dir, fileName), sb.ToString(), Utf8Bom);
        Console.WriteLine($"  Generated: {subdir}/{fileName} ({enums.Count} enums)");
    }

    #endregion
}
