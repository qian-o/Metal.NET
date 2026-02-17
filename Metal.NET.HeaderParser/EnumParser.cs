using System.Text.RegularExpressions;

namespace Metal.NET.HeaderParser;

/// <summary>
/// Parses metal-cpp header files (.hpp) to extract enum definitions.
/// 
/// metal-cpp enums follow these patterns:
///   _MTL_ENUM(NS::UInteger, PixelFormat) { ... };
///   _MTL_OPTIONS(NS::UInteger, TextureUsage) { ... };
///   _NS_ENUM(NS::UInteger, ...) { ... };
/// </summary>
public static partial class EnumParser
{
    // Matches: _MTL_ENUM(NS::UInteger, PixelFormat) {
    //      or: _MTL_OPTIONS(NS::UInteger, TextureUsage) {
    //      or: _NS_ENUM / _NS_OPTIONS variants
    [GeneratedRegex(
        @"_(MTL|NS)_(ENUM|OPTIONS)\s*\(\s*(\w[\w:]*)\s*,\s*(\w+)\s*\)\s*\{",
        RegexOptions.Compiled)]
    private static partial Regex EnumHeadRegex();

    // Matches enum members like: PixelFormatInvalid = 0,
    [GeneratedRegex(
        @"^\s*(\w+)\s*=\s*(.+?)\s*,?\s*$",
        RegexOptions.Compiled)]
    private static partial Regex EnumMemberRegex();

    /// <summary>
    /// Parse all enums from a single .hpp file content.
    /// </summary>
    public static List<EnumDef> Parse(string content, string prefix = "MTL")
    {
        var results = new List<EnumDef>();
        var headRegex = EnumHeadRegex();
        var memberRegex = EnumMemberRegex();

        var matches = headRegex.Matches(content);
        foreach (Match m in matches)
        {
            var ns = m.Groups[1].Value;         // "MTL" or "NS"
            var kind = m.Groups[2].Value;        // "ENUM" or "OPTIONS"
            var underlyingCpp = m.Groups[3].Value; // e.g. "NS::UInteger"
            var rawName = m.Groups[4].Value;     // e.g. "PixelFormat"

            var csName = ns == "MTL" ? $"MTL{rawName}" : rawName;
            var isFlags = kind == "OPTIONS";
            var underlyingCs = MapUnderlyingType(underlyingCpp);

            // Find the body between { and };
            int braceStart = m.Index + m.Length;
            int braceEnd = content.IndexOf("};", braceStart, StringComparison.Ordinal);
            if (braceEnd < 0) continue;

            var body = content[braceStart..braceEnd];
            var enumDef = new EnumDef
            {
                Name = csName,
                UnderlyingType = underlyingCs,
                IsFlags = isFlags,
                Members = [],
            };

            // Strip the enum-name prefix from member names
            // e.g. "PixelFormatInvalid" -> "Invalid"
            foreach (var line in body.Split('\n'))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("//") || trimmed.StartsWith("/*"))
                    continue;

                var mm = memberRegex.Match(trimmed);
                if (!mm.Success) continue;

                var memberFullName = mm.Groups[1].Value;   // e.g. "PixelFormatRGBA8Unorm"
                var valueExpr = mm.Groups[2].Value.Trim();

                // Strip the raw enum name prefix
                var memberName = memberFullName;
                if (memberName.StartsWith(rawName))
                    memberName = memberName[rawName.Length..];
                if (string.IsNullOrEmpty(memberName))
                    memberName = memberFullName;

                // Normalize the value expression for C#
                var csValue = NormalizeValueExpr(valueExpr, rawName);

                enumDef.Members.Add(new EnumMemberDef
                {
                    Name = memberName,
                    Value = csValue,
                });
            }

            if (enumDef.Members.Count > 0)
                results.Add(enumDef);
        }

        return results;
    }

    private static string MapUnderlyingType(string cppType)
    {
        var t = cppType.Replace(" ", "");
        return t switch
        {
            "NS::UInteger" or "NSUInteger" => "uint",
            "NS::Integer" or "NSInteger" => "int",
            "uint8_t" => "byte",
            "uint16_t" => "ushort",
            "uint32_t" => "uint",
            "uint64_t" => "ulong",
            "int32_t" => "int",
            _ => "uint",
        };
    }

    private static string NormalizeValueExpr(string expr, string enumPrefix)
    {
        // Replace references to other enum members:
        // e.g. "PixelFormatRGBA8Unorm" in value -> strip prefix
        // Also handle C++ hex/shift expressions — they're valid C# too.

        var result = expr;

        // Remove UL/ULL suffixes
        result = Regex.Replace(result, @"(\d+)[uU]?[lL]{0,2}\b", "$1");

        // Strip enum prefix from cross-references in value expressions
        if (!string.IsNullOrEmpty(enumPrefix))
        {
            result = result.Replace(enumPrefix, "");
        }

        return result.Trim();
    }
}
