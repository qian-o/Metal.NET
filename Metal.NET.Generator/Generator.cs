namespace Metal.NET.Generator;

class Generator(string metalCppDir, string outputDir)
{
    public void Run()
    {
        var context = new GeneratorContext();
        var typeMapper = new TypeMapper(context);

        Console.WriteLine("Parsing selector definitions...");
        var parser = new CppParser(metalCppDir, context);
        parser.ParseBridgeFiles();

        Console.WriteLine("Parsing header files...");
        parser.ParseAllHeaders();

        Console.WriteLine($"Found {context.Enums.Count} enums, {context.Classes.Count} classes, {context.FreeFunctions.Count} free functions");

        Console.WriteLine("Generating C# files...");
        var emitter = new CSharpEmitter(outputDir, context, typeMapper);
        emitter.GenerateAll();

        Console.WriteLine("Done!");
    }
}
