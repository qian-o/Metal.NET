namespace Metal.NET.Generator;

/// <summary>Parsed enum definition with its namespace, backing type, members, and deprecation info.</summary>
record EnumDef(string Namespace, string Name, string BackingType, bool IsFlags, List<EnumMember> Members, bool Deprecated = false, string? DeprecationMessage = null);

/// <summary>A single enum member with its resolved C# name, numeric value, and deprecation info.</summary>
record EnumMember(string Name, string Value, bool Deprecated = false, string? DeprecationMessage = null);

/// <summary>A free C function declared with <c>extern "C"</c> in the Metal framework headers.</summary>
record FreeFunctionDef(string CEntryPoint, string ReturnType, string Name, List<ParamDef> Parameters, string LibraryPath, string Namespace, string TargetClassName);

/// <summary>
/// A method or function parameter.
/// <para><c>Type</c> may contain special prefixes:
/// <c>OBJ_ARRAY:</c>, <c>STRUCT_ARRAY:</c>, <c>PRIM_ARRAY:</c>, or <c>INLINE_BLOCK:</c>.</para>
/// </summary>
record ParamDef(string Type, string Name);

/// <summary>A property defined by a getter and optional setter method pair.</summary>
record PropertyDef(MethodInfo Getter, MethodInfo? Setter);

/// <summary>
/// Parsed class or protocol definition with its namespace, inheritance chain,
/// method declarations, and whether it supports <c>AllocInit</c>.
/// </summary>
class ClassDef
{
    /// <summary>Logical namespace prefix (e.g., "MTL", "MTL4", "NS").</summary>
    public required string Namespace { get; set; }

    /// <summary>Bare class name without prefix (e.g., "Device", "Buffer").</summary>
    public required string Name { get; set; }

    /// <summary>Optional C# base class name, or <c>null</c> if it inherits <c>NSObject</c>.</summary>
    public string? BaseClassName { get; set; }

    /// <summary>All parsed methods (both property-derived and explicit).</summary>
    public List<MethodInfo> Methods { get; set; } = [];

    /// <summary>Whether this class supports <c>AllocInit</c> (has a registered ObjC class).</summary>
    public bool HasAllocInit { get; set; }

    /// <summary>Whether this class/protocol is deprecated in the Apple SDK.</summary>
    public bool Deprecated { get; set; }

    /// <summary>Deprecation message if the class/protocol is deprecated, otherwise <c>null</c>.</summary>
    public string? DeprecationMessage { get; set; }

    /// <summary>Full C# class name including prefix (e.g., "MTLDevice", "MTL4CommandBuffer").</summary>
    public string FullCsName => TypeMapper.GetPrefix(Namespace) + Name;
}

/// <summary>A parsed method declaration with its return type, parameters, and ObjC metadata.</summary>
class MethodInfo
{
    /// <summary>Base method name derived from the ObjC selector.</summary>
    public required string Name { get; set; }

    /// <summary>Return type in the internal model representation.</summary>
    public string ReturnType { get; set; } = "void";

    /// <summary>Whether this is a class-level (static) method.</summary>
    public bool IsStatic { get; set; }

    /// <summary>Whether the method is read-only (const in ObjC).</summary>
    public bool IsConst { get; set; }

    /// <summary>Method parameters.</summary>
    public List<ParamDef> Parameters { get; set; } = [];

    /// <summary>Whether the method targets the ObjC class object rather than an instance.</summary>
    public bool UsesClassTarget { get; set; }

    /// <summary>The ObjC selector string, provided directly from <c>metal-ast.json</c>.</summary>
    public string? Selector { get; set; }

    /// <summary>Whether this method was parsed from the JSON <c>properties</c> array (as a getter or setter).</summary>
    public bool IsPropertyAccessor { get; set; }

    /// <summary>Deprecation message if the method is deprecated, otherwise <c>null</c>.</summary>
    public string? DeprecationMessage { get; set; }
}

/// <summary>
/// A parsed ObjC block type alias
/// (e.g., <c>typedef void (^MTLCommandBufferHandler)(id&lt;MTLCommandBuffer&gt;)</c>).
/// </summary>
record BlockTypeAlias(string Namespace, string ObjCName, string CsDelegateName, List<BlockParam> Parameters);

/// <summary>A parameter in a block type alias signature.</summary>
record BlockParam(string ObjCType, string CsType, string Name);

/// <summary>Parsed packed struct definition.</summary>
record StructDef(string Namespace, string Name, List<StructFieldDef> Fields);

/// <summary>A single field in a packed struct definition.</summary>
record StructFieldDef(string Type, string Name);
