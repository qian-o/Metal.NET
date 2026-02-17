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
    //      or: _MTLFX_ENUM / _MTLFX_OPTIONS variants
    // Note: MTLFX must come before MTL in the alternation to prevent partial matches
    private static readonly Regex s_enumHeadRegex = new Regex(
        @"_(MTLFX|MTL|NS)_(ENUM|OPTIONS)\s*\(\s*(\w[\w:]*)\s*,\s*(\w+)\s*\)",
        RegexOptions.Compiled);

    // Matches enum members like: PixelFormatInvalid = 0,
    // Also matches members without explicit values: CounterHeapTypeInvalid,
    private static readonly Regex s_enumMemberRegex = new Regex(
        @"^\s*(\w+)\s*(?:=\s*(.+?))?\s*,?\s*$",
        RegexOptions.Compiled);

    /// <summary>
    /// Parse all enums from a single .hpp file content.
    /// </summary>
    public static List<EnumDef> Parse(string content, string prefix = "MTL")
    {
        var results = new List<EnumDef>();

        // Detect namespace blocks for proper prefixing
        var nsRegex = new Regex(@"^namespace\s+(\w+)\s*$", RegexOptions.Multiline);
        var namespacePrefixes = new List<(int start, string prefix)>();
        foreach (Match nsm in nsRegex.Matches(content))
        {
            var nsName = nsm.Groups[1].Value;
            switch (nsName)
            {
                case "MTL4": namespacePrefixes.Add((nsm.Index, "MTL4")); break;
                case "MTLFX": namespacePrefixes.Add((nsm.Index, "MTLFX")); break;
                case "MTL4FX": namespacePrefixes.Add((nsm.Index, "MTL4FX")); break;
                default: namespacePrefixes.Add((nsm.Index, "MTL")); break;
            }
        }

        var matches = s_enumHeadRegex.Matches(content);
        foreach (Match m in matches)
        {
            var ns = m.Groups[1].Value;         // "MTL", "NS", or "MTLFX"
            var kind = m.Groups[2].Value;        // "ENUM" or "OPTIONS"
            var underlyingCpp = m.Groups[3].Value; // e.g. "NS::UInteger"
            var rawName = m.Groups[4].Value;     // e.g. "PixelFormat"

            // Determine namespace prefix based on position in file
            var enumPrefix = "MTL";
            if (ns == "MTL" || ns == "MTLFX")
            {
                enumPrefix = (ns == "MTLFX") ? "MTLFX" : "MTL";
                foreach (var (start, p) in namespacePrefixes)
                {
                    if (start < m.Index) enumPrefix = p;
                    else break;
                }
                // For MTLFX macro enums, ensure we keep at least MTLFX prefix
                if (ns == "MTLFX" && !enumPrefix.Contains("FX"))
                    enumPrefix = "MTLFX";
            }

            var csName = (ns == "MTL" || ns == "MTLFX") ? $"{enumPrefix}{rawName}" : rawName;
            var isFlags = kind == "OPTIONS";
            var underlyingCs = MapUnderlyingType(underlyingCpp);

            // Find the body between { and };
            int openBrace = content.IndexOf('{', m.Index + m.Length);
            if (openBrace < 0) continue;
            int braceEnd = content.IndexOf("};", openBrace);
            if (braceEnd < 0) continue;

            var body = content.Substring(openBrace + 1, braceEnd - openBrace - 1);
            var enumDef = new EnumDef
            {
                Name = csName,
                UnderlyingType = underlyingCs,
                IsFlags = isFlags,
                Members = new List<EnumMemberDef>(),
            };

            // Strip the enum-name prefix from member names
            // e.g. "PixelFormatInvalid" -> "Invalid"
            var seenMembers = new HashSet<string>();
            foreach (var line in body.Split('\n'))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("//") || trimmed.StartsWith("/*"))
                    continue;

                var mm = s_enumMemberRegex.Match(trimmed);
                if (!mm.Success) continue;

                var memberFullName = mm.Groups[1].Value;   // e.g. "PixelFormatRGBA8Unorm"
                var hasExplicitValue = mm.Groups[2].Success && mm.Groups[2].Length > 0;
                var valueExpr = hasExplicitValue ? mm.Groups[2].Value.Trim() : "";

                // Strip the raw enum name prefix
                var memberName = memberFullName;
                if (memberName.StartsWith(rawName))
                    memberName = memberName.Substring(rawName.Length);
                if (string.IsNullOrEmpty(memberName))
                    memberName = memberFullName;
                // Prefix with _ if member name starts with a digit (invalid C# identifier)
                if (memberName.Length > 0 && char.IsDigit(memberName[0]))
                    memberName = "_" + memberName;

                // Skip duplicate members (can happen with Metal 4 headers)
                if (!seenMembers.Add(memberName))
                    continue;

                // Normalize the value expression for C#
                string csValue;
                if (hasExplicitValue)
                {
                    csValue = NormalizeValueExpr(valueExpr, rawName);
                }
                else
                {
                    // Auto-increment: use the member's ordinal position
                    csValue = enumDef.Members.Count.ToString();
                }

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

        // Replace well-known C++ constants
        result = result.Replace("NS::UIntegerMax", "uint.MaxValue");
        result = result.Replace("NS::IntegerMax", "int.MaxValue");

        // Remove UL/ULL suffixes
        result = s_ulSuffixRegex.Replace(result, "$1");

        // Handle values too large for uint — clamp to uint.MaxValue
        if (long.TryParse(result, out var longVal) && longVal > uint.MaxValue)
        {
            result = "uint.MaxValue";
        }

        // Strip enum prefix from cross-references in value expressions
        if (!string.IsNullOrEmpty(enumPrefix))
        {
            result = result.Replace(enumPrefix, "");
        }

        return result.Trim();
    }
}
