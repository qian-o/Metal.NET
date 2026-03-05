using Metal.NET.Generator;

// Resolve the solution root from the build output directory.
string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

// Run the generator: parse metal-cpp headers and emit C# bindings into the Metal.NET project.
new Generator(Path.Combine(projectDir, "Metal.NET.Generator", "metal-cpp"), Path.Combine(projectDir, "Metal.NET")).Run();

return 0;