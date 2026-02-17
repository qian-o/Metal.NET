using Metal.NET.Generator;

// Resolve paths relative to the Generator project directory
var generatorDir = AppContext.BaseDirectory;

// Walk up from bin/Debug/net10.0 to the project root
var projectDir = Path.GetFullPath(Path.Combine(generatorDir, "..", "..", ".."));
var metalCppDir = Path.Combine(projectDir, "metal-cpp");
var stubsDir = Path.Combine(projectDir, "stubs");
var outputDir = Path.GetFullPath(Path.Combine(projectDir, "..", "Metal.NET", "Generated"));

// Allow overriding via command-line arguments
if (args.Length >= 1) metalCppDir = Path.GetFullPath(args[0]);
if (args.Length >= 2) outputDir = Path.GetFullPath(args[1]);
if (args.Length >= 3) stubsDir = Path.GetFullPath(args[2]);

if (!Directory.Exists(metalCppDir))
{
    Console.Error.WriteLine($"metal-cpp directory not found: {metalCppDir}");
    return 1;
}

if (!Directory.Exists(stubsDir))
{
    Console.Error.WriteLine($"stubs directory not found: {stubsDir}");
    return 1;
}

Console.WriteLine($"metal-cpp : {metalCppDir}");
Console.WriteLine($"stubs     : {stubsDir}");
Console.WriteLine($"Output    : {outputDir}");

// Parse all headers using CppAst (libclang)
Console.WriteLine("Parsing C++ headers with CppAst...");
var parsed = CppAstParser.Parse(metalCppDir, stubsDir);

Console.WriteLine($"Parsed: {parsed.Enums.Count} enums, {parsed.Classes.Count} classes, {parsed.FreeFunctions.Count} free functions");

// Clean the output directory
if (Directory.Exists(outputDir))
{
    foreach (var file in Directory.GetFiles(outputDir, "*.g.cs"))
    {
        File.Delete(file);
    }
}

// Run the generator
var generator = new MetalBindingsGenerator(outputDir);
generator.Execute(parsed);

var generatedCount = Directory.GetFiles(outputDir, "*.g.cs").Length;
Console.WriteLine($"Generated {generatedCount} files in {outputDir}");

return 0;
