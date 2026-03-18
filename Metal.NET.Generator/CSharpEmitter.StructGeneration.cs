namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
partial class CSharpEmitter
{
    #region Struct Generation

    /// <summary>
    /// Generates a consolidated struct file (e.g., <c>Metal/MTLStructs.cs</c>) containing
    /// all packed structs for the given output subdirectory, with primary constructors.
    /// </summary>
    void GenerateStructFile(string subdir, List<StructDef> structs)
    {
        static string GetCsStructName(StructDef s) => TypeMapper.GetPrefix(s.Namespace) + s.Name;

        // Filter out hand-written structs
        List<StructDef> generatable = [.. structs
            .Where(s => !SkipStructs.Contains(GetCsStructName(s)))];

        if (generatable.Count == 0)
        {
            return;
        }

        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        string fileName = subdir switch
        {
            "Metal" => "MTLStructs.cs",
            "Foundation" => "NSStructs.cs",
            "MetalFX" => "MTLFXStructs.cs",
            _ => $"{subdir}Structs.cs"
        };

        StringBuilder sb = new();
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");

        foreach (StructDef structDef in generatable)
        {
            string csStructName = GetCsStructName(structDef);

            sb.AppendLine();
            sb.AppendLine("[StructLayout(LayoutKind.Sequential)]");

            List<string> ctorParams = [];
            List<string> fieldLines = [];
            foreach (StructFieldDef field in structDef.Fields)
            {
                string csType = TypeMapper.MapType(field.Type);
                string csFieldName = TypeMapper.ToPascalCase(field.Name);
                string csParamName = TypeMapper.ToCamelCase(field.Name);

                ctorParams.Add($"{csType} {csParamName}");
                fieldLines.Add($"    public {csType} {csFieldName} = {csParamName};");
            }

            sb.AppendLine($"public struct {csStructName}({string.Join(", ", ctorParams)})");
            sb.AppendLine("{");

            for (int i = 0; i < fieldLines.Count; i++)
            {
                if (i > 0)
                {
                    sb.AppendLine();
                }
                sb.AppendLine(fieldLines[i]);
            }

            sb.AppendLine("}");
        }

        File.WriteAllText(Path.Combine(dir, fileName), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: {subdir}/{fileName} ({generatable.Count} structs)");
    }

    #endregion
}
