namespace Metal.NET.Generator;

class GeneratorContext
{
    public Dictionary<string, string> SelectorMap { get; } = [];

    public HashSet<string> RegisteredClasses { get; } = [];

    public List<EnumDef> Enums { get; } = [];

    public List<ClassDef> Classes { get; } = [];

    public List<FreeFunctionDef> FreeFunctions { get; } = [];

    public Dictionary<string, string> EnumBackingTypes { get; } = [];

    public HashSet<string> KnownClassNames { get; } = [];

    public List<BlockTypeAlias> BlockTypeAliases { get; } = [];

    public Dictionary<string, SortedSet<string>> MsgSendSignatures { get; } = [];
}
