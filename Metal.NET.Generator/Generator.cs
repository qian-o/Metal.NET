using System.Text.Json;

namespace Metal.NET.Generator;

/// <summary>
/// Orchestrates the code generation pipeline: parse metal-cpp headers, then emit C# bindings.
/// </summary>
class Generator(string metalCppDir, string outputDir)
{
    public void Run()
    {
        GeneratorContext context = new();

        TypeMapper typeMapper = new(context);

        CppParser parser = new(metalCppDir, context);

        Console.WriteLine("Parsing selector definitions...");
        parser.ParseBridgeFiles();

        Console.WriteLine("Parsing header files...");
        parser.ParseAllHeaders();

        Console.WriteLine($"Found {context.Enums.Count} enums, {context.Structs.Count} structs, {context.Classes.Count} classes, {context.FreeFunctions.Count} free functions");

        string docsPath = Path.Combine(Path.GetDirectoryName(metalCppDir)!, "metal-docs.json");
        Console.WriteLine($"Loading documentation from {docsPath}...");
        Dictionary<string, DocEntry> docDb = LoadDocDatabase(docsPath);
        Console.WriteLine($"Loaded {docDb.Count} documentation entries");

        Console.WriteLine("Generating C# files...");
        new CSharpEmitter(outputDir, context, typeMapper, docDb).GenerateAll();

        Console.WriteLine("Done!");
    }

    static Dictionary<string, DocEntry> LoadDocDatabase(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);

        // Strip UTF-8 BOM if present
        int offset = bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF ? 3 : 0;

        return JsonSerializer.Deserialize<Dictionary<string, DocEntry>>(
            bytes.AsSpan(offset)) ?? [];
    }
}
