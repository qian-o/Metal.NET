using Metal.NET.Generator;

// Resolve the solution root from the build output directory.
string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

// Run the generator: parse metal-ast.json and emit C# bindings into the Metal.NET project.
new Generator(Path.Combine(projectDir, "Metal.NET.Generator", "metal-ast.json"), Path.Combine(projectDir, "Metal.NET")).Run();

return 0;
