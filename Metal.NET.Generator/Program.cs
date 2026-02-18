using Metal.NET.Generator;

string generatorDir = AppContext.BaseDirectory;

string projectDir = Path.GetFullPath(Path.Combine(generatorDir, "..", "..", ".."));
string metalCppDir = Path.Combine(projectDir, "metal-cpp");
string outputDir = Path.GetFullPath(Path.Combine(projectDir, "..", "Metal.NET"));

if (args.Length >= 1)
{
    metalCppDir = Path.GetFullPath(args[0]);
}

if (args.Length >= 2)
{
    outputDir = Path.GetFullPath(args[1]);
}

if (!Directory.Exists(metalCppDir))
{
    Console.Error.WriteLine($"metal-cpp directory not found: {metalCppDir}");

    return 1;
}

Console.WriteLine($"metal-cpp : {metalCppDir}");
Console.WriteLine($"Output    : {outputDir}");

Console.WriteLine("Parsing C++ headers...");

ParseResult parsed = HeaderParser.Parse(metalCppDir);

Console.WriteLine($"Parsed: {parsed.Enums.Count} enums, {parsed.Classes.Count} classes, {parsed.FreeFunctions.Count} free functions");

MetalBindingsGenerator generator = new(outputDir);
generator.Execute(parsed);

int generatedCount = new[] { "Metal", "Foundation", "QuartzCore", "MetalFX", "Common" }
    .Select(sub => Path.Combine(outputDir, sub))
    .Where(Directory.Exists)
    .SelectMany(dir => Directory.GetFiles(dir, "*.cs"))
    .Count();

Console.WriteLine($"Generated {generatedCount} files in {outputDir}");

return 0;
