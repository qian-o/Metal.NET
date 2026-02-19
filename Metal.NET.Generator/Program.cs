using Metal.NET.Generator;

string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

new Generator(Path.Combine(projectDir, "Metal.NET.Generator", "metal-cpp"), Path.Combine(projectDir, "Metal.NET")).Run();

return 0;