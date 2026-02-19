namespace Metal.NET.Generator;

/// <summary>
/// Parsed C++ enum definition.
/// </summary>
record EnumDef(string CppNamespace, string Name, string BackingType, bool IsFlags, List<EnumMember> Members);

/// <summary>
/// A single enum member with its resolved C# name and numeric value.
/// </summary>
record EnumMember(string Name, string Value);

/// <summary>
/// A free C function declared with <c>extern "C"</c>.
/// </summary>
record FreeFunctionDef(string CEntryPoint, string ReturnType, string CppName, List<ParamDef> Parameters, string LibraryPath, string CppNamespace, string TargetClassName);

/// <summary>
/// A method or function parameter.
/// <c>CppType</c> may contain special prefixes like <c>OBJ_ARRAY:</c>, <c>STRUCT_ARRAY:</c>, or <c>PRIM_ARRAY:</c>.
/// </summary>
record ParamDef(string CppType, string Name);

/// <summary>
/// A property defined by a getter and optional setter method pair.
/// </summary>
record PropertyDef(MethodInfo Getter, MethodInfo? Setter);

/// <summary>
/// Implementation info extracted from inline method bodies in the header.
/// </summary>
record ImplInfo(string? Accessor, bool UsesClassTarget);

/// <summary>
/// Parsed C++ class definition with its namespace, inheritance, and method declarations.
/// </summary>
class ClassDef
{
    public string CppNamespace { get; set; } = "";

    public string Name { get; set; } = "";

    public bool IsCopying { get; set; }

    public string? BaseClassName { get; set; }

    public List<MethodInfo> Methods { get; set; } = [];
}

/// <summary>
/// A parsed C++ method declaration with its return type, parameters, and implementation metadata.
/// </summary>
class MethodInfo
{
    public string CppName { get; set; } = "";

    public string ReturnType { get; set; } = "void";

    public bool IsStatic { get; set; }

    public bool IsConst { get; set; }

    public List<ParamDef> Parameters { get; set; } = [];

    public bool UsesClassTarget { get; set; }

    public string? SelectorAccessor { get; set; }
}
