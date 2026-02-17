using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Parses metal-cpp header files (.hpp) to extract enum definitions.
/// Ported from Metal.NET.HeaderParser for direct use in the source generator.
///
/// metal-cpp enums follow these patterns:
///   _MTL_ENUM(NS::UInteger, PixelFormat) { ... };
///   _MTL_OPTIONS(NS::UInteger, TextureUsage) { ... };
///   _NS_ENUM(NS::UInteger, ...) { ... };
/// </summary>
internal static class HeaderEnumParser
{
    // Matches: _MTL_ENUM(NS::UInteger, PixelFormat) {
    //      or: _MTL_OPTIONS(NS::UInteger, TextureUsage) {
    //      or: _NS_ENUM / _NS_OPTIONS variants
    private static readonly Regex s_enumHeadRegex = new Regex(
        @"_(MTL|NS)_(ENUM|OPTIONS)\s*\(\s*(\w[\w:]*)\s*,\s*(\w+)\s*\)\s*\{",
        RegexOptions.Compiled);

    // Matches enum members like: PixelFormatInvalid = 0,
    private static readonly Regex s_enumMemberRegex = new Regex(
        @"^\s*(\w+)\s*=\s*(.+?)\s*,?\s*$",
        RegexOptions.Compiled);

    /// <summary>
    /// Parse all enums from a single .hpp file content.
    /// </summary>
    public static List<EnumDef> Parse(string content, string prefix = "MTL")
    {
        var results = new List<EnumDef>();

        var matches = s_enumHeadRegex.Matches(content);
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
            int braceEnd = content.IndexOf("};", braceStart);
            if (braceEnd < 0) continue;

            var body = content.Substring(braceStart, braceEnd - braceStart);
            var enumDef = new EnumDef
            {
                Name = csName,
                UnderlyingType = underlyingCs,
                IsFlags = isFlags,
                Members = new List<EnumMemberDef>(),
            };

            // Strip the enum-name prefix from member names
            // e.g. "PixelFormatInvalid" -> "Invalid"
            foreach (var line in body.Split('\n'))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("//") || trimmed.StartsWith("/*"))
                    continue;

                var mm = s_enumMemberRegex.Match(trimmed);
                if (!mm.Success) continue;

                var memberFullName = mm.Groups[1].Value;   // e.g. "PixelFormatRGBA8Unorm"
                var valueExpr = mm.Groups[2].Value.Trim();

                // Strip the raw enum name prefix
                var memberName = memberFullName;
                if (memberName.StartsWith(rawName))
                    memberName = memberName.Substring(rawName.Length);
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
        switch (t)
        {
            case "NS::UInteger":
            case "NSUInteger":
                return "uint";
            case "NS::Integer":
            case "NSInteger":
                return "int";
            case "uint8_t": return "byte";
            case "uint16_t": return "ushort";
            case "uint32_t": return "uint";
            case "uint64_t": return "ulong";
            case "int32_t": return "int";
            default: return "uint";
        }
    }

    private static readonly Regex s_ulSuffixRegex = new Regex(@"(\d+)[uU]?[lL]{0,2}\b", RegexOptions.Compiled);

    private static string NormalizeValueExpr(string expr, string enumPrefix)
    {
        var result = expr;

        // Remove UL/ULL suffixes
        result = s_ulSuffixRegex.Replace(result, "$1");

        // Strip enum prefix from cross-references in value expressions
        if (!string.IsNullOrEmpty(enumPrefix))
        {
            result = result.Replace(enumPrefix, "");
        }

        return result.Trim();
    }
}
