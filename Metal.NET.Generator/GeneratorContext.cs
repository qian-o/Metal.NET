namespace Metal.NET.Generator;

/// <summary>
/// Shared mutable state that flows from <see cref="CppParser"/> to <see cref="CSharpEmitter"/>.
/// </summary>
class GeneratorContext
{
    /// <summary>
    /// Accessor name → ObjC selector string (from bridge files).
    /// </summary>
    public Dictionary<string, string> SelectorMap { get; } = [];

    /// <summary>
    /// ObjC class names that have _DEF_CLS entries.
    /// </summary>
    public HashSet<string> RegisteredClasses { get; } = [];

    /// <summary>
    /// All parsed enums.
    /// </summary>
    public List<EnumDef> Enums { get; } = [];

    /// <summary>
    /// All parsed classes.
    /// </summary>
    public List<ClassDef> Classes { get; } = [];

    /// <summary>
    /// All parsed free functions (extern "C").
    /// </summary>
    public List<FreeFunctionDef> FreeFunctions { get; } = [];

    /// <summary>
    /// Enum C# name → backing type (e.g., "MTLPixelFormat" → "ulong").
    /// </summary>
    public Dictionary<string, string> EnumBackingTypes { get; } = [];

    /// <summary>
    /// All known generated class names (for validating base class references).
    /// </summary>
    public HashSet<string> KnownClassNames { get; } = [];
}
