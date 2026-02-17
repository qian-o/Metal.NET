using System.Text.Json;

namespace Metal.NET.HeaderParser;

/// <summary>
/// metal-cpp Header Parser for Metal.NET
/// 
/// Usage:
///   Metal.NET.HeaderParser &lt;metal-cpp-dir&gt; &lt;output-dir&gt;
///
/// Where:
///   metal-cpp-dir = path to extracted metal-cpp headers (contains Metal/, Foundation/ etc.)
///   output-dir    = path to write JSON definition files (e.g. Metal.NET/Definitions/)
///
/// How to get metal-cpp:
///   1. Go to https://developer.apple.com/metal/cpp/
///   2. Download the latest "metal-cpp" archive
///   3. Extract it — you'll get a folder with Metal/, Foundation/, QuartzCore/ subdirectories
///   4. Point this tool at that folder
/// </summary>
public static class Program
{
    private static readonly JsonSerializerOptions s_jsonOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
    };

    public static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Metal.NET.HeaderParser <metal-cpp-dir> <output-dir>");
            Console.WriteLine();
            Console.WriteLine("  metal-cpp-dir  Path to extracted metal-cpp headers");
            Console.WriteLine("                 (download from https://developer.apple.com/metal/cpp/)");
            Console.WriteLine("  output-dir     Path to write JSON definitions");
            Console.WriteLine("                 (e.g. Metal.NET/Definitions/)");
            return 1;
        }

        var metalCppDir = args[0];
        var outputDir = args[1];

        if (!Directory.Exists(metalCppDir))
        {
            Console.Error.WriteLine($"Error: Directory not found: {metalCppDir}");
            return 1;
        }

        Directory.CreateDirectory(outputDir);

        // ── Step 1: Parse selector definitions from Private.hpp files ──
        Console.WriteLine("Parsing selector definitions...");
        var selectorMap = new Dictionary<string, string>();

        var privateFiles = FindFiles(metalCppDir, "*Private.hpp");
        foreach (var file in privateFiles)
        {
            Console.WriteLine($"  {Path.GetRelativePath(metalCppDir, file)}");
            var content = File.ReadAllText(file);
            var sels = ClassParser.ParseSelectorDefs(content);
            foreach (var kv in sels)
            {
                selectorMap.TryAdd(kv.Key, kv.Value);
            }
        }
        Console.WriteLine($"  Found {selectorMap.Count} selector definitions.");

        // ── Step 2: Parse enums ──
        Console.WriteLine("Parsing enums...");
        var allEnums = new List<EnumDef>();

        var metalHeaders = FindFiles(metalCppDir, "MTL*.hpp");
        foreach (var file in metalHeaders)
        {
            var content = File.ReadAllText(file);
            var enums = EnumParser.Parse(content);
            if (enums.Count > 0)
            {
                Console.WriteLine($"  {Path.GetRelativePath(metalCppDir, file)}: {enums.Count} enums");
                allEnums.AddRange(enums);
            }
        }

        // Deduplicate enums by name (same enum can appear in multiple headers)
        allEnums = allEnums
            .GroupBy(e => e.Name)
            .Select(g => g.First())
            .OrderBy(e => e.Name)
            .ToList();

        if (allEnums.Count > 0)
        {
            var enumsFile = new EnumsFile { Enums = allEnums };
            var enumsPath = Path.Combine(outputDir, "enums.json");
            File.WriteAllText(enumsPath, JsonSerializer.Serialize(enumsFile, s_jsonOptions));
            Console.WriteLine($"  Wrote {allEnums.Count} enums to enums.json");
        }

        // ── Step 3: Parse classes/protocols ──
        Console.WriteLine("Parsing classes and protocols...");

        foreach (var file in metalHeaders)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);

            // Skip Private, Types, Defines files
            if (fileName.EndsWith("Private") || fileName == "MTLDefines" ||
                fileName == "MTLHeaderBridge")
                continue;

            var content = File.ReadAllText(file);
            var classes = ClassParser.Parse(content, fileName, selectorMap);

            foreach (var cls in classes)
            {
                var jsonPath = Path.Combine(outputDir, $"{cls.Name}.json");
                File.WriteAllText(jsonPath, JsonSerializer.Serialize(cls, s_jsonOptions));
                Console.WriteLine($"  {cls.Name}: {cls.Properties.Count} props, " +
                    $"{cls.Methods.Count} methods -> {cls.Name}.json");
            }
        }

        // ── Step 4: Also parse QuartzCore for CAMetalDrawable/CAMetalLayer ──
        var quartzHeaders = FindFiles(metalCppDir, "CA*.hpp");
        foreach (var file in quartzHeaders)
        {
            var content = File.ReadAllText(file);
            var classes = ClassParser.Parse(content, Path.GetFileNameWithoutExtension(file), selectorMap);
            foreach (var cls in classes)
            {
                // These use CA prefix, not MTL
                if (!cls.Name.StartsWith("CA"))
                    cls.Name = $"CA{cls.Name.TrimStart('M', 'T', 'L')}";

                var jsonPath = Path.Combine(outputDir, $"{cls.Name}.json");
                File.WriteAllText(jsonPath, JsonSerializer.Serialize(cls, s_jsonOptions));
                Console.WriteLine($"  {cls.Name}: {cls.Properties.Count} props, " +
                    $"{cls.Methods.Count} methods -> {cls.Name}.json");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Done! JSON definitions written to: " + Path.GetFullPath(outputDir));
        Console.WriteLine();
        Console.WriteLine("Next steps:");
        Console.WriteLine("  1. Review the generated JSON files for correctness");
        Console.WriteLine("  2. Build Metal.NET — the Source Generator will produce C# bindings");
        Console.WriteLine("  3. Fix any type mapping issues in the JSON if needed");

        return 0;
    }

    private static List<string> FindFiles(string dir, string pattern)
    {
        var results = new List<string>();
        try
        {
            results.AddRange(Directory.GetFiles(dir, pattern, SearchOption.AllDirectories));
        }
        catch (DirectoryNotFoundException) { }
        return results.OrderBy(f => f).ToList();
    }
}
