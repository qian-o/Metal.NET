using System.Text;

namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
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

        string fileName = subdir switch
        {
            "Metal" => "MTLEnums.cs",
            "Foundation" => "NSEnums.cs",
            "MetalFX" => "MTLFXEnums.cs",
            _ => $"{subdir}Enums.cs"
        };

        foreach (EnumDef enumDef in enums)
        {
            string prefix = TypeMapper.GetPrefix(enumDef.Namespace);
            string oldFile = Path.Combine(dir, $"{prefix}{enumDef.Name}.cs");
            if (File.Exists(oldFile))
            {
                File.Delete(oldFile);
            }
        }

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

        File.WriteAllText(Path.Combine(dir, fileName), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: {subdir}/{fileName} ({enums.Count} enums)");
    }

    #endregion
}
