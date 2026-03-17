namespace Metal.NET.Generator;

/// <summary>
/// Orchestrates the full code-generation pipeline.
/// <list type="number">
///   <item>Parses <c>metal-ast.json</c> into a <see cref="GeneratorContext"/>.</item>
///   <item>Initialises a <see cref="TypeMapper"/> from the context.</item>
///   <item>Emits all C# binding files via <see cref="CSharpEmitter"/>.</item>
/// </list>
/// </summary>
/// <param name="astJsonPath">Absolute path to <c>metal-ast.json</c>.</param>
/// <param name="outputDir">Root directory of the <c>Metal.NET</c> project.</param>
class Generator(string astJsonPath, string outputDir)
{
    /// <summary>Runs the parse → emit pipeline and prints diagnostic counts.</summary>
    public void Run()
    {
        Console.WriteLine($"Parsing {astJsonPath}...");

        GeneratorContext context = AstJsonParser.Parse(astJsonPath);

        Console.WriteLine($"Found {context.Enums.Count} enums, {context.Structs.Count} structs, {context.Classes.Count} classes, {context.FreeFunctions.Count} free functions");

        Console.WriteLine("Generating C# files...");
        new CSharpEmitter(outputDir, context, new TypeMapper(context)).GenerateAll();

        Console.WriteLine("Done!");
    }
}
