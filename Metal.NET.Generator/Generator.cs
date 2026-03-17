namespace Metal.NET.Generator;

/// <summary>
/// Orchestrates the code generation pipeline: parse metal-ast.json, then emit C# bindings.
/// </summary>
class Generator(string astJsonPath, string outputDir)
{
    public void Run()
    {
        Console.WriteLine($"Parsing {astJsonPath}...");

        AstJsonParser parser = new();
        GeneratorContext context = parser.Parse(astJsonPath);

        Console.WriteLine($"Found {context.Enums.Count} enums, {context.Structs.Count} structs, {context.Classes.Count} classes, {context.FreeFunctions.Count} free functions");

        TypeMapper typeMapper = new(context);

        Console.WriteLine("Generating C# files...");
        new CSharpEmitter(outputDir, context, typeMapper).GenerateAll();

        Console.WriteLine("Done!");
    }
}
