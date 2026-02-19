using Metal.NET.Generator;

string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
string metalCppDir = Path.Combine(projectDir, "Metal.NET.Generator", "metal-cpp");
string outputDir = Path.Combine(projectDir, "Metal.NET");

var generator = new Generator(metalCppDir, outputDir);
generator.Run();
return 0;