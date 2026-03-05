namespace Metal.NET.Generator;

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

        Console.WriteLine($"Found {context.Enums.Count} enums, {context.Classes.Count} classes, {context.FreeFunctions.Count} free functions");

        Console.WriteLine("Generating C# files...");
        new CSharpEmitter(outputDir, context, typeMapper).GenerateAll();

        Console.WriteLine("Done!");
    }
}
