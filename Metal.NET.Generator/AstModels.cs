namespace Metal.NET.Generator;

class AstRoot
{
    [JsonPropertyName("sdkVersion")]
    public string? SdkVersion { get; set; }

    [JsonPropertyName("enums")]
    public List<AstEnum> Enums { get; set; } = [];

    [JsonPropertyName("protocols")]
    public List<AstClass> Protocols { get; set; } = [];

    [JsonPropertyName("classes")]
    public List<AstClass> Classes { get; set; } = [];

    [JsonPropertyName("typedefs")]
    public List<AstTypedef> Typedefs { get; set; } = [];

    [JsonPropertyName("functions")]
    public List<AstFunction> Functions { get; set; } = [];

    [JsonPropertyName("structs")]
    public List<AstStruct> Structs { get; set; } = [];
}

class AstEnum
{
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "";

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("underlyingType")]
    public string UnderlyingType { get; set; } = "";

    [JsonPropertyName("isOptions")]
    public bool IsOptions { get; set; }

    [JsonPropertyName("members")]
    public List<AstEnumMember> Members { get; set; } = [];

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstEnumMember
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("value")]
    public string Value { get; set; } = "";

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstClass
{
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "";

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("methods")]
    public List<AstMethod> Methods { get; set; } = [];

    [JsonPropertyName("properties")]
    public List<AstProperty> Properties { get; set; } = [];

    [JsonPropertyName("protocols")]
    public List<string> Protocols { get; set; } = [];

    [JsonPropertyName("super")]
    public string? Super { get; set; }

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstMethod
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("selector")]
    public string Selector { get; set; } = "";

    [JsonPropertyName("isClassMethod")]
    public bool IsClassMethod { get; set; }

    [JsonPropertyName("returnType")]
    public string ReturnType { get; set; } = "";

    [JsonPropertyName("returnNullability")]
    public string? ReturnNullability { get; set; }

    [JsonPropertyName("parameters")]
    public List<AstParam> Parameters { get; set; } = [];

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstParam
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";

    [JsonPropertyName("nullability")]
    public string? Nullability { get; set; }
}

class AstProperty
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";

    [JsonPropertyName("nullability")]
    public string? Nullability { get; set; }

    [JsonPropertyName("readonly")]
    public bool Readonly { get; set; }

    [JsonPropertyName("getter")]
    public string? Getter { get; set; }

    [JsonPropertyName("setter")]
    public string? Setter { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstTypedef
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("underlyingType")]
    public string UnderlyingType { get; set; } = "";

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }
}

class AstFunction
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("returnType")]
    public string ReturnType { get; set; } = "";

    [JsonPropertyName("parameters")]
    public List<AstParam> Parameters { get; set; } = [];

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }
}

class AstStruct
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("fields")]
    public List<AstStructField> Fields { get; set; } = [];

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }
}

class AstStructField
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
}
