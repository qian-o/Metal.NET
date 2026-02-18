namespace Metal.NET.Generator;

public class EnumDef
{
    public string Name { get; set; } = "";

    public string UnderlyingType { get; set; } = "uint";

    public bool IsFlags { get; set; }

    public List<EnumMemberDef> Members { get; set; } = [];

    public string Folder { get; set; } = "Metal";
}

public class EnumMemberDef
{
    public string Name { get; set; } = "";

    public string Value { get; set; } = "0";
}

public class ObjCClassDef
{
    public string Name { get; set; } = "";

    public bool IsClass { get; set; }

    public string? ObjCClass { get; set; }

    public List<PropertyDef> Properties { get; set; } = [];

    public List<MethodDef> Methods { get; set; } = [];

    public List<MethodDef> StaticMethods { get; set; } = [];

    public string Folder { get; set; } = "Metal";
}

public class PropertyDef
{
    public string Name { get; set; } = "";

    public string Type { get; set; } = "";

    public bool Readonly { get; set; }

    public string? GetSelector { get; set; }

    public string? SetSelector { get; set; }
}

public class MethodDef
{
    public string Name { get; set; } = "";

    public string Selector { get; set; } = "";

    public string ReturnType { get; set; } = "void";

    public List<ParamDef> Parameters { get; set; } = [];

    public bool HasErrorOut { get; set; }
}

public class ParamDef
{
    public string Name { get; set; } = "";

    public string Type { get; set; } = "";
}

public class FreeFunctionDef
{
    public string NativeName { get; set; } = "";

    public string Name { get; set; } = "";

    public string ReturnType { get; set; } = "void";

    public List<ParamDef> Parameters { get; set; } = [];

    public string TargetClass { get; set; } = "";

    public string FrameworkLibrary { get; set; } = "/System/Library/Frameworks/Metal.framework/Metal";
}

/// <summary>Result of parsing all metal-cpp headers.</summary>
public class ParseResult
{
    public List<EnumDef> Enums { get; } = [];

    public List<ObjCClassDef> Classes { get; } = [];

    public List<FreeFunctionDef> FreeFunctions { get; } = [];

    public void Deduplicate()
    {
        Dictionary<string, EnumDef> seenEnums = [];

        foreach (EnumDef e in Enums)
        {
            if (!seenEnums.ContainsKey(e.Name))
            {
                seenEnums[e.Name] = e;
            }
        }

        Enums.Clear();
        Enums.AddRange(seenEnums.Values);

        Dictionary<string, ObjCClassDef> seenClasses = [];

        foreach (ObjCClassDef c in Classes)
        {
            if (!seenClasses.ContainsKey(c.Name))
            {
                seenClasses[c.Name] = c;
            }
        }

        Classes.Clear();
        Classes.AddRange(seenClasses.Values);

        Dictionary<string, FreeFunctionDef> seenFuncs = [];

        foreach (FreeFunctionDef f in FreeFunctions)
        {
            if (!seenFuncs.ContainsKey(f.NativeName))
            {
                seenFuncs[f.NativeName] = f;
            }
        }

        FreeFunctions.Clear();
        FreeFunctions.AddRange(seenFuncs.Values);
    }
}
