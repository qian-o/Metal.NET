// -----------------------------------------------------------------------
// Metal.NET Generator — Main Entry Point
//
// Parses the Metal AST (Abstract Syntax Tree) from "metal-ast.json" and
// generates C# bindings for the Metal.NET project.
//
// The solution root is resolved relative to the build output directory
// (bin/Debug|Release/net10.0), allowing the generator to locate both the
// input JSON and the output project regardless of build configuration.
// -----------------------------------------------------------------------

using Metal.NET.Generator;

string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
string astJsonPath = Path.Combine(projectDir, "Metal.NET.Generator", "metal-ast.json");
string outputDir = Path.Combine(projectDir, "Metal.NET");

new Generator(astJsonPath, outputDir).Run();

return 0;
