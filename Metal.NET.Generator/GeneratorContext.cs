namespace Metal.NET.Generator;

/// <summary>
/// Shared mutable state that flows through the generation pipeline:
/// populated by <see cref="AstJsonParser"/>, consumed by <see cref="CSharpEmitter"/>.
/// </summary>
class GeneratorContext
{
    /// <summary>All parsed enum definitions, grouped by namespace.</summary>
    public List<EnumDef> Enums { get; } = [];

    /// <summary>All parsed class and protocol definitions.</summary>
    public List<ClassDef> Classes { get; } = [];

    /// <summary>All parsed packed struct definitions.</summary>
    public List<StructDef> Structs { get; } = [];

    /// <summary>All parsed free (non-member) C functions.</summary>
    public List<FreeFunctionDef> FreeFunctions { get; } = [];

    /// <summary>
    /// Maps each generated enum's C# name to its backing type
    /// (e.g., <c>"MTLPixelFormat"</c> → <c>"ulong"</c>).
    /// </summary>
    public Dictionary<string, string> EnumBackingTypes { get; } = [];

    /// <summary>
    /// All known generated class names, including hand-written Foundation types.
    /// Used for validating base-class references during emission.
    /// </summary>
    public HashSet<string> KnownClassNames { get; } = [];

    /// <summary>All parsed ObjC block type aliases (e.g., <c>MTLCommandBufferHandler</c>).</summary>
    public List<BlockTypeAlias> BlockTypeAliases { get; } = [];

    /// <summary>
    /// Collected <c>MsgSend</c> overload signatures, populated during emission.
    /// <para>Key: method group (e.g., <c>"MsgSend"</c>, <c>"MsgSendNInt"</c>).</para>
    /// <para>Value: sorted set of parameter type signatures
    /// (e.g., <c>"nint, nuint, MTLRegion"</c>).</para>
    /// </summary>
    public Dictionary<string, SortedSet<string>> MsgSendSignatures { get; } = [];
}
