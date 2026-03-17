using System.Text.Json.Serialization;

namespace Metal.NET.Generator;

/// <summary>A single member entry within a documentation group.</summary>
class DocMember
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecatedMessage")]
    public string? DeprecatedMessage { get; set; }
}

/// <summary>A named group of members in the documentation (e.g., "Creating Command Buffers").</summary>
class DocGroup
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = "";

    [JsonPropertyName("members")]
    public List<DocMember> Members { get; set; } = [];
}

/// <summary>A top-level documentation entry for a class or enum, keyed by slug.</summary>
class DocEntry
{
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecatedMessage")]
    public string? DeprecatedMessage { get; set; }

    [JsonPropertyName("groups")]
    public List<DocGroup>? Groups { get; set; }
}
