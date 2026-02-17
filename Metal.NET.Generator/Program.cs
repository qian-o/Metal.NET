using Metal.NET.Generator;

// Resolve paths relative to the Generator project directory
var generatorDir = AppContext.BaseDirectory;

// Walk up from bin/Debug/net10.0 to the project root
var projectDir = Path.GetFullPath(Path.Combine(generatorDir, "..", "..", ".."));
var metalCppDir = Path.Combine(projectDir, "metal-cpp");
var outputDir = Path.GetFullPath(Path.Combine(projectDir, "..", "Metal.NET", "Generated"));

// Allow overriding via command-line arguments
if (args.Length >= 1) metalCppDir = Path.GetFullPath(args[0]);
if (args.Length >= 2) outputDir = Path.GetFullPath(args[1]);

if (!Directory.Exists(metalCppDir))
{
    Console.Error.WriteLine($"metal-cpp directory not found: {metalCppDir}");
    return 1;
}

Console.WriteLine($"metal-cpp : {metalCppDir}");
Console.WriteLine($"Output    : {outputDir}");

// Collect all .hpp files
var hppFiles = Directory.GetFiles(metalCppDir, "*.hpp", SearchOption.AllDirectories);
var files = new List<(string FileName, string Content)>();

foreach (var path in hppFiles.OrderBy(p => p))
{
    var fileName = Path.GetFileName(path);
    var content = File.ReadAllText(path);
    files.Add((fileName, content));
}

Console.WriteLine($"Found {files.Count} .hpp files");

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
generator.Execute(files);

var generatedCount = Directory.GetFiles(outputDir, "*.g.cs").Length;
Console.WriteLine($"Generated {generatedCount} files in {outputDir}");

return 0;
