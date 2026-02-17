using System.Collections.Generic;

namespace Metal.NET.Generator;

// ── Enum definitions ──

public class EnumDef
{
    public string Name { get; set; } = "";
    public string UnderlyingType { get; set; } = "uint";
    public bool IsFlags { get; set; }
    public List<EnumMemberDef> Members { get; set; } = new();
}

public class EnumMemberDef
{
    public string Name { get; set; } = "";
    public string Value { get; set; } = "0";
}

// ── Objective-C protocol / class bindings ──

public class ObjCClassDef
{
    /// <summary>The C# struct name, e.g. "MTLDevice".</summary>
    public string Name { get; set; } = "";

    /// <summary>Whether this wraps an Objective-C class (true) or protocol (false).</summary>
    public bool IsClass { get; set; }

    /// <summary>The Objective-C class name (only for classes), e.g. "MTLTextureDescriptor".</summary>
    public string? ObjCClass { get; set; }

    /// <summary>Properties exposed on the object.</summary>
    public List<PropertyDef> Properties { get; set; } = new();

    /// <summary>Instance methods.</summary>
    public List<MethodDef> Methods { get; set; } = new();

    /// <summary>Static / class methods.</summary>
    public List<MethodDef> StaticMethods { get; set; } = new();
}

public class PropertyDef
{
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public bool Readonly { get; set; }

    /// <summary>Override the getter selector (default: Name).</summary>
    public string? GetSelector { get; set; }

    /// <summary>Override the setter selector (default: "set" + PascalCase(Name) + ":").</summary>
    public string? SetSelector { get; set; }
}

public class MethodDef
{
    /// <summary>C# method name.</summary>
    public string Name { get; set; } = "";

    /// <summary>Objective-C selector, e.g. "newBufferWithLength:options:".</summary>
    public string Selector { get; set; } = "";

    /// <summary>Return type (C# type name). Use "void" for no return.</summary>
    public string ReturnType { get; set; } = "void";

    /// <summary>Method parameters.</summary>
    public List<ParamDef> Parameters { get; set; } = new();

    /// <summary>If true, the last parameter is "out NSError".</summary>
    public bool HasErrorOut { get; set; }
}

public class ParamDef
{
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
}

// ── Free C function declarations (extern "C") ──

public class FreeFunctionDef
{
    /// <summary>The C function name, e.g. "MTLCreateSystemDefaultDevice".</summary>
    public string NativeName { get; set; } = "";

    /// <summary>The C# method name, e.g. "CreateSystemDefaultDevice".</summary>
    public string Name { get; set; } = "";

    /// <summary>Return type (C# type name).</summary>
    public string ReturnType { get; set; } = "void";

    /// <summary>Parameters.</summary>
    public List<ParamDef> Parameters { get; set; } = new();

    /// <summary>The target class to inject this into, e.g. "MTLDevice".</summary>
    public string TargetClass { get; set; } = "";

    /// <summary>The native framework library path for [LibraryImport].</summary>
    public string FrameworkLibrary { get; set; } = "/System/Library/Frameworks/Metal.framework/Metal";
}
