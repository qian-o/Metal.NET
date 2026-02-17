using System.Text.RegularExpressions;

namespace Metal.NET.HeaderParser;

/// <summary>
/// Parses metal-cpp header files (.hpp) to extract class/protocol definitions.
///
/// metal-cpp class declarations look like:
///   class Device : public NS::Referencing&lt;Device&gt;
///   {
///   public:
///       NS::String*   name() const;
///       CommandQueue*  newCommandQueue();
///       Buffer*        newBuffer(NS::UInteger length, ResourceOptions options);
///   };
///
/// Selector mappings are in the inline implementations:
///   _MTL_INLINE MTL::CommandQueue* MTL::Device::newCommandQueue()
///   {
///       return Object::sendMessage&lt;...&gt;(this, _MTL_PRIVATE_SEL(newCommandQueue));
///   }
///
/// Or in the Private.hpp files:
///   _MTL_PRIVATE_DEF_SEL(newCommandQueue, "newCommandQueue");
///   _MTL_PRIVATE_DEF_SEL(newBufferWithLength_options_, "newBufferWithLength:options:");
/// </summary>
public static partial class ClassParser
{
    // ── Regex patterns ──

    // Class declaration: "class Device : public NS::Referencing<Device>"
    [GeneratedRegex(
        @"class\s+(\w+)\s*:\s*public\s+(NS::Referencing|NS::CopiedBy)<",
        RegexOptions.Compiled)]
    private static partial Regex ClassDeclRegex();

    // Method declaration in the public section:
    // "ReturnType*  methodName(ParamType p1, ParamType2 p2) const;"
    // or "ReturnType   methodName();" (value return)
    [GeneratedRegex(
        @"^\s+([\w:]+\s*\*?)\s+(\w+)\s*\(([^)]*)\)\s*(const)?\s*;",
        RegexOptions.Compiled)]
    private static partial Regex MethodDeclRegex();

    // Static method: "static Device* alloc();"
    [GeneratedRegex(
        @"^\s+static\s+([\w:]+\s*\*?)\s+(\w+)\s*\(([^)]*)\)\s*;",
        RegexOptions.Compiled)]
    private static partial Regex StaticMethodDeclRegex();

    // Selector definition: _MTL_PRIVATE_DEF_SEL(methodCppName_, "selector:name:")
    [GeneratedRegex(
        @"_(?:MTL|NS)_PRIVATE_DEF_SEL\s*\(\s*(\w+)\s*,\s*""([^""]+)""\s*\)",
        RegexOptions.Compiled)]
    private static partial Regex SelectorDefRegex();

    // Inline implementation with selector:
    // Object::sendMessage<...>(this, _MTL_PRIVATE_SEL(selectorField))
    [GeneratedRegex(
        @"(\w+)::(\w+)\s*\([^)]*\)[^{]*\{[^}]*_MTL_PRIVATE_SEL\s*\(\s*(\w+)\s*\)",
        RegexOptions.Compiled)]
    private static partial Regex InlineSelectorRegex();

    /// <summary>
    /// Parse all class definitions from a set of .hpp files.
    /// <paramref name="selectorMap"/> should be pre-populated from Private.hpp files.
    /// </summary>
    public static List<ObjCClassDef> Parse(string content, string fileName,
        Dictionary<string, string> selectorMap)
    {
        var results = new List<ObjCClassDef>();

        // Also extract inline selectors from this file
        foreach (Match m in InlineSelectorRegex().Matches(content))
        {
            var className = m.Groups[1].Value;
            var methodName = m.Groups[2].Value;
            var selField = m.Groups[3].Value;

            var key = $"{className}.{methodName}";
            if (!selectorMap.ContainsKey(key) && selectorMap.TryGetValue(selField, out var sel))
            {
                selectorMap[key] = sel;
            }
        }

        // Find class declarations
        foreach (Match classMatch in ClassDeclRegex().Matches(content))
        {
            var className = classMatch.Value.Contains("CopiedBy")
                ? classMatch.Groups[1].Value
                : classMatch.Groups[1].Value;
            var rawClassName = classMatch.Groups[1].Value;
            var isReferencing = classMatch.Value.Contains("Referencing");
            var isCopied = classMatch.Value.Contains("CopiedBy");

            // Determine if this is an ObjC class or protocol
            // In Metal, Descriptor types are classes; protocols are interfaces
            var csName = $"MTL{rawClassName}";
            var isClass = IsDescriptorOrConcreteClass(rawClassName);

            // Find the class body (from the match to the closing "};")
            int searchStart = classMatch.Index + classMatch.Length;
            int classBodyEnd = FindMatchingBrace(content, searchStart);
            if (classBodyEnd < 0) continue;

            var classBody = content[searchStart..classBodyEnd];

            var def = new ObjCClassDef
            {
                Name = csName,
                IsClass = isClass,
                ObjCClass = isClass ? csName : null,
            };

            // Parse methods
            ParseMethods(classBody, rawClassName, selectorMap, def);

            if (def.Properties.Count > 0 || def.Methods.Count > 0 || def.StaticMethods.Count > 0)
                results.Add(def);
        }

        return results;
    }

    private static void ParseMethods(string classBody, string className,
        Dictionary<string, string> selectorMap, ObjCClassDef def)
    {
        var lines = classBody.Split('\n');
        bool inPublic = false;

        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (trimmed == "public:") { inPublic = true; continue; }
            if (trimmed is "private:" or "protected:") { inPublic = false; continue; }
            if (!inPublic) continue;
            if (trimmed.StartsWith("//") || trimmed.StartsWith("/*") || string.IsNullOrEmpty(trimmed))
                continue;

            // Skip static alloc/init — we generate those automatically for classes
            var staticMatch = StaticMethodDeclRegex().Match(line);
            if (staticMatch.Success)
            {
                // We could add static methods here if needed
                continue;
            }

            var methodMatch = MethodDeclRegex().Match(line);
            if (!methodMatch.Success) continue;

            var returnTypeCpp = methodMatch.Groups[1].Value.Trim();
            var methodName = methodMatch.Groups[2].Value.Trim();
            var paramStr = methodMatch.Groups[3].Value.Trim();
            var isConst = methodMatch.Groups[4].Success;

            var returnTypeCs = TypeMapper.ToCSharpType(returnTypeCpp);

            // Resolve the ObjC selector
            var selector = ResolveSelector(className, methodName, paramStr, selectorMap);

            // Determine if this is a property getter/setter
            if (IsPropertyGetter(methodName, paramStr, isConst))
            {
                var existingProp = def.Properties.FirstOrDefault(p => p.Name == methodName);
                if (existingProp == null)
                {
                    def.Properties.Add(new PropertyDef
                    {
                        Name = methodName,
                        Type = returnTypeCs,
                        Readonly = true, // will be set to false if setter found
                        GetSelector = selector != methodName ? selector : null,
                    });
                }
            }
            else if (IsPropertySetter(methodName, paramStr))
            {
                var getterName = char.ToLower(methodName[3]) + methodName[4..];
                var existingProp = def.Properties.FirstOrDefault(p => p.Name == getterName);
                if (existingProp != null)
                {
                    existingProp.Readonly = false;
                    existingProp.SetSelector = selector != null ? selector : $"set{methodName[3..]}:";
                }
                // If no getter exists, still create a write-only property
                else
                {
                    var paramType = ParseSingleParam(paramStr);
                    def.Properties.Add(new PropertyDef
                    {
                        Name = getterName,
                        Type = paramType ?? returnTypeCs,
                        Readonly = false,
                        SetSelector = selector,
                    });
                }
            }
            else
            {
                // Regular method
                var method = new MethodDef
                {
                    Name = methodName,
                    Selector = selector ?? methodName,
                    ReturnType = returnTypeCs,
                };

                if (!string.IsNullOrEmpty(paramStr))
                {
                    var parsedParams = ParseParams(paramStr);

                    // Check if last param is "NS::Error**" — that's an error-out param
                    if (parsedParams.Count > 0 &&
                        parsedParams[^1].type.Contains("Error") &&
                        parsedParams[^1].type.Contains("**"))
                    {
                        method.HasErrorOut = true;
                        parsedParams.RemoveAt(parsedParams.Count - 1);
                    }

                    if (parsedParams.Count > 0)
                    {
                        method.Parameters = parsedParams.Select(p => new ParamDef
                        {
                            Name = p.name,
                            Type = TypeMapper.ToCSharpType(p.type),
                        }).ToList();
                    }
                }

                def.Methods.Add(method);
            }
        }
    }

    private static bool IsPropertyGetter(string name, string paramStr, bool isConst)
    {
        // No parameters, returns a value — likely a property getter
        if (!string.IsNullOrEmpty(paramStr)) return false;

        // Common patterns: name(), isXxx(), xxxEnabled()
        return isConst || name.StartsWith("is") || name.EndsWith("Enabled");
    }

    private static bool IsPropertySetter(string name, string paramStr)
    {
        // "setXxx(value)" — single parameter, starts with "set", and name[3] is uppercase
        if (!name.StartsWith("set") || name.Length < 4 || !char.IsUpper(name[3]))
            return false;
        // Should have exactly one parameter
        return !string.IsNullOrEmpty(paramStr) && !paramStr.Contains(',');
    }

    private static string? ParseSingleParam(string paramStr)
    {
        var parts = paramStr.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 1)
            return TypeMapper.ToCSharpType(string.Join(" ", parts[..^1]));
        return null;
    }

    private static List<(string type, string name)> ParseParams(string paramStr)
    {
        var result = new List<(string type, string name)>();
        var parts = paramStr.Split(',', StringSplitOptions.TrimEntries);
        foreach (var part in parts)
        {
            if (string.IsNullOrEmpty(part)) continue;

            // "const NS::String* source" -> type="const NS::String*", name="source"
            var tokens = part.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (tokens.Count == 0) continue;

            var name = tokens[^1].TrimStart('*').TrimEnd('*');
            var type = string.Join(" ", tokens[..^1]);

            // Handle cases like "ResourceOptions options" (no pointer)
            // or "NS::UInteger length"
            if (string.IsNullOrEmpty(type) && tokens.Count == 1)
            {
                type = tokens[0];
                name = "param";
            }

            // If the last token has * but no space, e.g. "MTLDevice*"
            if (type.EndsWith("*") || part.TrimEnd().EndsWith("*"))
            {
                // type already includes *
            }

            result.Add((type, name));
        }
        return result;
    }

    private static string? ResolveSelector(string className, string methodName,
        string paramStr, Dictionary<string, string> selectorMap)
    {
        // Try class.method key first
        var key = $"{className}.{methodName}";
        if (selectorMap.TryGetValue(key, out var sel)) return sel;

        // Try the C++ mangled selector field name
        // metal-cpp uses: newBufferWithLength_options_ for "newBufferWithLength:options:"
        // The field name is the method name + underscore-separated param labels + trailing underscore
        var fieldVariants = new[]
        {
            methodName,
            $"{methodName}_",
        };
        foreach (var f in fieldVariants)
        {
            if (selectorMap.TryGetValue(f, out sel)) return sel;
        }

        // Fallback: construct the selector from the method name
        // For zero-param methods: selector = methodName
        if (string.IsNullOrEmpty(paramStr)) return methodName;

        // For methods with params, we can't reliably guess the selector
        // Return the method name — the user may need to fix this
        return null;
    }

    /// <summary>
    /// Parse all _MTL_PRIVATE_DEF_SEL entries from Private.hpp files.
    /// Returns a map of fieldName -> "objc:selector:string:".
    /// </summary>
    public static Dictionary<string, string> ParseSelectorDefs(string content)
    {
        var map = new Dictionary<string, string>();
        foreach (Match m in SelectorDefRegex().Matches(content))
        {
            var fieldName = m.Groups[1].Value;  // e.g. "newBufferWithLength_options_"
            var selector = m.Groups[2].Value;   // e.g. "newBufferWithLength:options:"
            map[fieldName] = selector;
        }
        return map;
    }

    private static int FindMatchingBrace(string content, int startAfterOpenBrace)
    {
        // We need to find the opening '{' first
        int braceStart = content.IndexOf('{', startAfterOpenBrace);
        if (braceStart < 0) return -1;

        int depth = 1;
        for (int i = braceStart + 1; i < content.Length; i++)
        {
            if (content[i] == '{') depth++;
            else if (content[i] == '}')
            {
                depth--;
                if (depth == 0) return i;
            }
        }
        return -1;
    }

    private static bool IsDescriptorOrConcreteClass(string rawName)
    {
        // In Metal, types ending in "Descriptor" are concrete ObjC classes
        // that can be alloc/init'd. Others are protocols.
        return rawName.EndsWith("Descriptor")
            || rawName == "CompileOptions"
            || rawName == "VertexDescriptor"
            || rawName == "StencilDescriptor"
            || rawName == "RenderPassDescriptor"
            || rawName == "ComputePassDescriptor"
            || rawName == "BlitPassDescriptor";
    }
}
