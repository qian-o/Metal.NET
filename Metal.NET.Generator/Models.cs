namespace Metal.NET.Generator;

record EnumDef(string CppNamespace, string Name, string BackingType, bool IsFlags, List<EnumMember> Members);

record EnumMember(string Name, string Value);

record FreeFunctionDef(string CEntryPoint, string ReturnType, string CppName, List<ParamDef> Parameters, string LibraryPath, string CppNamespace, string TargetClassName);

record ParamDef(string CppType, string Name);

record PropertyDef(MethodInfo Getter, MethodInfo? Setter);

record ImplInfo(string? Accessor, bool UsesClassTarget);

class ClassDef
{
    public string CppNamespace { get; set; } = "";

    public string Name { get; set; } = "";

    public bool IsCopying { get; set; }

    public string? BaseClassName { get; set; }

    public List<MethodInfo> Methods { get; set; } = [];
}

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
