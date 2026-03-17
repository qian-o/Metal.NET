namespace Metal.NET.Generator;

/// <summary>Parsed enum definition.</summary>
record EnumDef(string Namespace, string Name, string BackingType, bool IsFlags, List<EnumMember> Members, bool Deprecated = false, string? DeprecationMessage = null);

/// <summary>A single enum member with its resolved C# name and numeric value.</summary>
record EnumMember(string Name, string Value);

/// <summary>A free C function declared with <c>extern "C"</c>.</summary>
record FreeFunctionDef(string CEntryPoint, string ReturnType, string Name, List<ParamDef> Parameters, string LibraryPath, string Namespace, string TargetClassName);

/// <summary>
/// A method or function parameter.
/// <c>Type</c> may contain special prefixes like <c>OBJ_ARRAY:</c>, <c>STRUCT_ARRAY:</c>, or <c>PRIM_ARRAY:</c>.
/// </summary>
record ParamDef(string Type, string Name);

/// <summary>A property defined by a getter and optional setter method pair.</summary>
record PropertyDef(MethodInfo Getter, MethodInfo? Setter);

/// <summary>Parsed class/protocol definition with its namespace, inheritance, and method declarations.</summary>
class ClassDef
{
    public string Namespace { get; set; } = "";

    public string Name { get; set; } = "";

    public string? BaseClassName { get; set; }

    public List<MethodInfo> Methods { get; set; } = [];

    /// <summary>Whether this class supports AllocInit (has a registered ObjC class).</summary>
    public bool HasAllocInit { get; set; }
}

/// <summary>A parsed method declaration with its return type, parameters, and metadata.</summary>
class MethodInfo
{
    public string Name { get; set; } = "";

    public string ReturnType { get; set; } = "void";

    public bool IsStatic { get; set; }

    public bool IsConst { get; set; }

    public List<ParamDef> Parameters { get; set; } = [];

    public bool UsesClassTarget { get; set; }

    /// <summary>The ObjC selector string, provided directly from metal-ast.json.</summary>
    public string? Selector { get; set; }

    public string? DeprecationMessage { get; set; }
}

/// <summary>A parsed ObjC block type alias (e.g., <c>typedef void (^MTLCommandBufferHandler)(id&lt;MTLCommandBuffer&gt;)</c>).</summary>
record BlockTypeAlias(string Namespace, string ObjCName, string CsDelegateName, List<BlockParam> Parameters);

/// <summary>A parameter in a block type alias signature.</summary>
record BlockParam(string ObjCType, string CsType, string Name);

/// <summary>Parsed packed struct definition.</summary>
record StructDef(string Namespace, string Name, List<StructFieldDef> Fields);

/// <summary>A single field in a packed struct definition.</summary>
record StructFieldDef(string Type, string Name);
