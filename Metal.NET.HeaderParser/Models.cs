using System.Text.Json.Serialization;

namespace Metal.NET.HeaderParser;

// ── Output models (matches Metal.NET.Generator's JSON schema) ──

public class EnumDef
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("underlyingType")]
    public string UnderlyingType { get; set; } = "uint";

    [JsonPropertyName("isFlags")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool IsFlags { get; set; }

    [JsonPropertyName("members")]
    public List<EnumMemberDef> Members { get; set; } = [];
}

public class EnumMemberDef
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("value")]
    public string Value { get; set; } = "0";
}

public class ObjCClassDef
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("isClass")]
    public bool IsClass { get; set; }

    [JsonPropertyName("objCClass")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ObjCClass { get; set; }

    [JsonPropertyName("properties")]
    public List<PropertyDef> Properties { get; set; } = [];

    [JsonPropertyName("methods")]
    public List<MethodDef> Methods { get; set; } = [];

    [JsonPropertyName("staticMethods")]
    public List<MethodDef> StaticMethods { get; set; } = [];
}

public class PropertyDef
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";

    [JsonPropertyName("readonly")]
    public bool Readonly { get; set; }

    [JsonPropertyName("getSelector")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GetSelector { get; set; }

    [JsonPropertyName("setSelector")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SetSelector { get; set; }
}

public class MethodDef
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("selector")]
    public string Selector { get; set; } = "";

    [JsonPropertyName("returnType")]
    public string ReturnType { get; set; } = "void";

    [JsonPropertyName("parameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ParamDef>? Parameters { get; set; }

    [JsonPropertyName("hasErrorOut")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool HasErrorOut { get; set; }
}

public class ParamDef
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
}

public class EnumsFile
{
    [JsonPropertyName("enums")]
    public List<EnumDef> Enums { get; set; } = [];
}
