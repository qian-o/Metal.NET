using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Parses metal-cpp header files (.hpp) to extract class/protocol definitions.
/// Ported from Metal.NET.HeaderParser for direct use in the source generator.
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
internal static class HeaderClassParser
{
    // ── Regex patterns ──

    // Class declaration: "class Device : public NS::Referencing<Device>"
    // Also matches NS::Copying, NS::SecureCoding, and unqualified Copying/Referencing
    private static readonly Regex s_classDeclRegex = new Regex(
        @"class\s+(\w+)\s*:\s*public\s+(?:NS::)?(Referencing|CopiedBy|Copying|SecureCoding)\s*<",
        RegexOptions.Compiled);

    // Method declaration in the public section:
    // "ReturnType*  methodName(ParamType p1, ParamType2 p2) const;"
    // or "ReturnType   methodName();" (value return)
    // Also handles forward-declared return types: "class MetalDrawable*  nextDrawable();"
    // Also handles multi-word return types: "unsigned int  intValue() const;"
    private static readonly Regex s_methodDeclRegex = new Regex(
        @"^\s+(?:class\s+)?((?:unsigned\s+|signed\s+|long\s+)?[\w:]+\s*\*?)\s+(\w+)\s*\(([^)]*)\)\s*(const)?\s*;",
        RegexOptions.Compiled);

    // Static method: "static Device* alloc();" or "static class MetalLayer* layer();"
    // Also handles multi-word return types.
    private static readonly Regex s_staticMethodDeclRegex = new Regex(
        @"^\s+static\s+(?:class\s+)?((?:unsigned\s+|signed\s+|long\s+)?[\w:]+\s*\*?)\s+(\w+)\s*\(([^)]*)\)\s*;",
        RegexOptions.Compiled);

    // Selector definition: _MTL_PRIVATE_DEF_SEL(methodCppName_, "selector:name:")
    // Also handles _MTLFX_PRIVATE_DEF_SEL, _CA_PRIVATE_DEF_SEL
    private static readonly Regex s_selectorDefRegex = new Regex(
        @"_(?:MTL|NS|MTLFX|CA)_PRIVATE_DEF_SEL\s*\(\s*(\w+)\s*,\s*""([^""]+)""\s*\)",
        RegexOptions.Compiled);

    // Inline implementation with selector:
    // Object::sendMessage<...>(this, _MTL_PRIVATE_SEL(selectorField)) or _CA_PRIVATE_SEL
    private static readonly Regex s_inlineSelectorRegex = new Regex(
        @"(\w+)::(\w+)\s*\([^)]*\)[^{]*\{[^}]*_(?:MTL|CA|NS|MTLFX)_PRIVATE_SEL\s*\(\s*(\w+)\s*\)",
        RegexOptions.Compiled);

    /// <summary>
    /// Parse all class definitions from a set of .hpp files.
    /// <paramref name="selectorMap"/> should be pre-populated from Private.hpp files.
    /// </summary>
    public static List<ObjCClassDef> Parse(string content, string fileName,
        Dictionary<string, string> selectorMap)
    {
        var results = new List<ObjCClassDef>();

        // Detect which namespace(s) are used in this file
        var namespacePrefixes = DetectNamespacePrefixes(content);

        // Also extract inline selectors from this file
        foreach (Match m in s_inlineSelectorRegex.Matches(content))
        {
            var className = m.Groups[1].Value;
            var methodName = m.Groups[2].Value;
            var selField = m.Groups[3].Value;

            var key = $"{className}.{methodName}";
            // If we don't already have a class.method mapping, try to resolve it
            // from the selector field name extracted from the inline implementation
            if (!selectorMap.ContainsKey(key) && selectorMap.TryGetValue(selField, out var sel))
            {
                selectorMap[key] = sel;
            }
        }

        // Find class declarations
        foreach (Match classMatch in s_classDeclRegex.Matches(content))
        {
            var rawClassName = classMatch.Groups[1].Value;

            // Determine the namespace prefix for this class based on its position in the content
            var csPrefix = GetNamespacePrefix(content, classMatch.Index, namespacePrefixes);

            var csName = $"{csPrefix}{rawClassName}";
            var isClass = IsDescriptorOrConcreteClass(rawClassName);

            // Find the class body (from the match to the closing "};")
            int searchStart = classMatch.Index + classMatch.Length;
            int classBodyEnd = FindMatchingBrace(content, searchStart);
            if (classBodyEnd < 0) continue;

            var classBody = content.Substring(searchStart, classBodyEnd - searchStart);

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

    /// <summary>
    /// Detect all namespace blocks and their positions in the content.
    /// Returns list of (startIndex, prefix) tuples.
    /// </summary>
    private static List<(int start, string prefix)> DetectNamespacePrefixes(string content)
    {
        var result = new List<(int start, string prefix)>();
        var nsRegex = new Regex(@"^namespace\s+(\w+)\s*$", RegexOptions.Multiline);
        foreach (Match m in nsRegex.Matches(content))
        {
            var ns = m.Groups[1].Value;
            string prefix;
            switch (ns)
            {
                case "MTL": prefix = "MTL"; break;
                case "MTL4": prefix = "MTL4"; break;
                case "MTLFX": prefix = "MTLFX"; break;
                case "MTL4FX": prefix = "MTL4FX"; break;
                case "CA": prefix = "CA"; break;
                case "NS": prefix = "NS"; break;
                default: prefix = "MTL"; break;
            }
            result.Add((m.Index, prefix));
        }
        return result;
    }

    /// <summary>
    /// Get the namespace prefix for a class at a given position in the content.
    /// </summary>
    private static string GetNamespacePrefix(string content, int classIndex,
        List<(int start, string prefix)> namespacePrefixes)
    {
        // Find the closest namespace declaration before the class
        string prefix = "MTL"; // default
        foreach (var (start, p) in namespacePrefixes)
        {
            if (start < classIndex)
                prefix = p;
            else
                break;
        }
        return prefix;
    }

    private static void ParseMethods(string classBody, string className,
        Dictionary<string, string> selectorMap, ObjCClassDef def)
    {
        // Determine the namespace prefix of the containing class for type resolution
        var nsPrefix = "MTL";
        if (def.Name.StartsWith("MTL4FX")) nsPrefix = "MTL4FX";
        else if (def.Name.StartsWith("MTLFX")) nsPrefix = "MTLFX";
        else if (def.Name.StartsWith("MTL4")) nsPrefix = "MTL4";
        else if (def.Name.StartsWith("CA")) nsPrefix = "CA";
        else if (def.Name.StartsWith("NS")) nsPrefix = "NS";

        // Track method signatures to avoid duplicates
        var methodSignatures = new HashSet<string>();
        // Track property names
        var propertyNames = new HashSet<string>();
        // Track methods that overlap with property names (to resolve conflicts later)
        var methodNameOverlaps = new HashSet<string>();

        var lines = classBody.Split('\n');
        bool inPublic = false;

        // First pass: collect all method names that have parameterized versions
        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (trimmed == "public:") { inPublic = true; continue; }
            if (trimmed == "private:" || trimmed == "protected:") { inPublic = false; continue; }
            if (!inPublic) continue;

            var mMatch = s_methodDeclRegex.Match(line);
            if (!mMatch.Success) continue;

            var mName = mMatch.Groups[2].Value.Trim();
            var mParams = mMatch.Groups[3].Value.Trim();
            var mIsConst = mMatch.Groups[4].Success;

            // If a name appears both as no-param-const (property getter) and with params,
            // it should be a method, not a property
            if (!string.IsNullOrEmpty(mParams) && !IsPropertySetter(mName, mParams))
                methodNameOverlaps.Add(mName);
        }

        inPublic = false;

        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (trimmed == "public:") { inPublic = true; continue; }
            if (trimmed == "private:" || trimmed == "protected:") { inPublic = false; continue; }
            if (!inPublic) continue;
            if (trimmed.StartsWith("//") || trimmed.StartsWith("/*") || string.IsNullOrEmpty(trimmed))
                continue;

            // Check for static method first
            var staticMatch = s_staticMethodDeclRegex.Match(line);
            if (staticMatch.Success)
            {
                var sRetType = staticMatch.Groups[1].Value.Trim();
                var sMethodName = staticMatch.Groups[2].Value.Trim();
                var sParamStr = staticMatch.Groups[3].Value.Trim();

                // Skip alloc/init — we generate those automatically for classes
                if (sMethodName == "alloc" || sMethodName == "init")
                    continue;

                var sRetCs = MapTypeInContext(sRetType, nsPrefix);
                if (sRetCs == null) continue;

                if (HeaderTypeMapper.IsCSharpKeyword(sMethodName))
                    sMethodName = $"@{sMethodName}";

                var sSel = ResolveSelector(className, sMethodName.TrimStart('@'), sParamStr, selectorMap);

                var sMethod = new MethodDef
                {
                    Name = sMethodName,
                    Selector = sSel ?? sMethodName.TrimStart('@'),
                    ReturnType = sRetCs,
                };

                if (!string.IsNullOrEmpty(sParamStr))
                {
                    var sParsed = ParseParams(sParamStr);
                    bool sUnsupported = false;
                    var sConverted = new List<ParamDef>();
                    foreach (var p in sParsed)
                    {
                        var pType = MapTypeInContext(p.type, nsPrefix);
                        if (pType == null) { sUnsupported = true; break; }
                        var pName = p.name;
                        if (HeaderTypeMapper.IsCSharpKeyword(pName)) pName = $"@{pName}";
                        sConverted.Add(new ParamDef { Name = pName, Type = pType });
                    }
                    if (sUnsupported) continue;
                    sMethod.Parameters = sConverted;
                }

                if (!HasUnsupportedParamCombination(sMethod))
                {
                    var sSigTypes = string.Join(",", sMethod.Parameters.Select(p => p.Type));
                    var sSigKey = $"static:{sMethod.Name}({sSigTypes})";
                    if (methodSignatures.Add(sSigKey))
                        def.StaticMethods.Add(sMethod);
                }
                continue;
            }

            var methodMatch = s_methodDeclRegex.Match(line);
            if (!methodMatch.Success) continue;

            var returnTypeCpp = methodMatch.Groups[1].Value.Trim();
            var methodName = methodMatch.Groups[2].Value.Trim();
            var paramStr = methodMatch.Groups[3].Value.Trim();
            var isConst = methodMatch.Groups[4].Success;

            // Skip methods with array-of-pointer parameters (e.g. "const MTL::Buffer* const buffers[]")
            if (paramStr.Contains("[]"))
                continue;

            var returnTypeCs = MapTypeInContext(returnTypeCpp, nsPrefix);

            // Skip methods with unsupported return types
            if (returnTypeCs == null)
                continue;

            // Escape C# keywords used as method names
            if (HeaderTypeMapper.IsCSharpKeyword(methodName))
                methodName = $"@{methodName}";

            // Resolve the ObjC selector
            var selector = ResolveSelector(className, methodName.TrimStart('@'), paramStr, selectorMap);

            // Determine if this is a property getter/setter
            var rawName = methodName.TrimStart('@');
            if (IsPropertyGetter(rawName, paramStr, isConst) && !methodNameOverlaps.Contains(rawName))
            {
                var existingProp = def.Properties.FirstOrDefault(p => p.Name == methodName);
                if (existingProp == null)
                {
                    def.Properties.Add(new PropertyDef
                    {
                        Name = methodName,
                        Type = returnTypeCs,
                        Readonly = true,
                        GetSelector = selector != rawName ? selector : null,
                    });
                }
            }
            else if (IsPropertySetter(rawName, paramStr))
            {
                var getterName = char.ToLower(rawName[3]) + rawName.Substring(4);
                if (HeaderTypeMapper.IsCSharpKeyword(getterName))
                    getterName = $"@{getterName}";
                var existingProp = def.Properties.FirstOrDefault(p => p.Name == getterName);
                if (existingProp != null)
                {
                    existingProp.Readonly = false;
                    existingProp.SetSelector = selector != null ? selector : $"set{rawName.Substring(3)}:";
                }
                // If no getter exists, still create a write-only property
                else
                {
                    var paramType = ParseSingleParamInContext(paramStr, nsPrefix);
                    if (paramType == null) continue; // unsupported param type
                    def.Properties.Add(new PropertyDef
                    {
                        Name = getterName,
                        Type = paramType,
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
                    Selector = selector ?? rawName,
                    ReturnType = returnTypeCs,
                };

                if (!string.IsNullOrEmpty(paramStr))
                {
                    var parsedParams = ParseParams(paramStr);

                    // Check if any parameter has an unsupported type
                    bool hasUnsupported = false;

                    // Check if last param is "NS::Error**" — that's an error-out param
                    if (parsedParams.Count > 0 &&
                        parsedParams[parsedParams.Count - 1].type.Contains("Error") &&
                        parsedParams[parsedParams.Count - 1].type.Contains("**"))
                    {
                        method.HasErrorOut = true;
                        parsedParams.RemoveAt(parsedParams.Count - 1);
                    }

                    if (parsedParams.Count > 0)
                    {
                        var convertedParams = new List<ParamDef>();
                        foreach (var p in parsedParams)
                        {
                            var csType = MapTypeInContext(p.type, nsPrefix);
                            if (csType == null) { hasUnsupported = true; break; }

                            var paramName = p.name;
                            if (HeaderTypeMapper.IsCSharpKeyword(paramName))
                                paramName = $"@{paramName}";

                            convertedParams.Add(new ParamDef
                            {
                                Name = paramName,
                                Type = csType,
                            });
                        }
                        if (hasUnsupported) continue; // skip entire method
                        method.Parameters = convertedParams;
                    }
                }

                // Build a signature key for dedup: "methodName(type1,type2,...)"
                var sigTypes = string.Join(",", method.Parameters.Select(p => p.Type));
                var sigKey = $"{method.Name}({sigTypes})";
                if (method.HasErrorOut) sigKey += "+err";

                if (!methodSignatures.Add(sigKey))
                    continue; // skip duplicate method signature

                // Skip methods with parameter type combinations that the runtime can't handle
                // (e.g., mixed float/value-struct params with other types)
                if (HasUnsupportedParamCombination(method))
                    continue;

                def.Methods.Add(method);
            }
        }
    }

    /// <summary>
    /// Check if a method has parameter type combinations that the ObjC runtime
    /// can't handle (e.g., float/double mixed with other param types, or value
    /// struct params that need special handling).
    /// </summary>
    private static bool HasUnsupportedParamCombination(MethodDef method)
    {
        if (method.Parameters.Count == 0) return false;

        foreach (var p in method.Parameters)
        {
            // Value structs need special objc_msgSend overloads that may not exist
            if (HeaderTypeMapper.IsValueStruct(p.Type))
                return true;
            // Float/double with other params need special overloads
            if (p.Type is "float" or "double" && method.Parameters.Count > 1)
                return true;
        }

        return false;
    }

    /// <summary>
    /// Maps a C++ type to C#, using the containing class's namespace prefix
    /// for types without an explicit namespace qualifier.
    /// </summary>
    private static string? MapTypeInContext(string cppType, string nsPrefix)
    {
        // If the type has an explicit namespace qualifier (e.g. "MTL4::Foo", "MTL::Bar"),
        // let the standard mapper handle it.
        if (cppType.Contains("::"))
            return HeaderTypeMapper.ToCSharpType(cppType);

        var mapped = HeaderTypeMapper.ToCSharpType(cppType);
        if (mapped == null) return null;

        // If the containing class is in a non-MTL namespace, and the type was mapped with
        // default MTL prefix, re-prefix it to match the containing namespace.
        // This handles unqualified forward declarations like "MetalDrawable*" inside a CA class
        // or "BinaryFunction*" inside an MTL4 class.
        if (nsPrefix != "MTL" && !HeaderTypeMapper.IsPrimitive(mapped)
            && mapped.StartsWith("MTL") && !mapped.StartsWith("MTL4") && !mapped.StartsWith("MTLFX")
            && !HeaderTypeMapper.IsValueStruct(mapped))
        {
            // For CA/NS namespace: only re-prefix types that don't exist as MTL types
            // (e.g. MetalDrawable → CAMetalDrawable, but Device → MTLDevice stays)
            if (nsPrefix == "CA" || nsPrefix == "NS")
            {
                var baseName = mapped.Substring(3);
                // If the base name starts with Metal (CA-specific types), re-prefix to CA
                if (nsPrefix == "CA" && baseName.StartsWith("Metal"))
                    mapped = $"CA{baseName}";
                // NS types use standard mapping (String→NSString etc.), no re-prefix needed
            }
            else
            {
                mapped = nsPrefix + mapped.Substring(3);
            }
        }

        return mapped;
    }

    private static string? ParseSingleParamInContext(string paramStr, string nsPrefix)
    {
        // Skip if it contains array syntax
        if (paramStr.Contains("[]")) return null;

        var parts = paramStr.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 2)
        {
            var typeParts = new string[parts.Length - 1];
            Array.Copy(parts, typeParts, parts.Length - 1);
            return MapTypeInContext(string.Join(" ", typeParts), nsPrefix);
        }
        return null;
    }

    private static bool IsPropertyGetter(string name, string paramStr, bool isConst)
    {
        if (!string.IsNullOrEmpty(paramStr)) return false;
        return isConst || name.StartsWith("is") || name.EndsWith("Enabled");
    }

    private static bool IsPropertySetter(string name, string paramStr)
    {
        if (!name.StartsWith("set") || name.Length < 4 || !char.IsUpper(name[3]))
            return false;
        return !string.IsNullOrEmpty(paramStr) && !paramStr.Contains(',');
    }

    private static string? ParseSingleParam(string paramStr)
    {
        // Skip if it contains array syntax
        if (paramStr.Contains("[]")) return null;

        var parts = paramStr.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 2)
        {
            var typeParts = new string[parts.Length - 1];
            Array.Copy(parts, typeParts, parts.Length - 1);
            return HeaderTypeMapper.ToCSharpType(string.Join(" ", typeParts));
        }
        return null;
    }

    private static List<(string type, string name)> ParseParams(string paramStr)
    {
        var result = new List<(string type, string name)>();
        var parts = paramStr.Split(',');
        foreach (var rawPart in parts)
        {
            var part = rawPart.Trim();
            if (string.IsNullOrEmpty(part)) continue;

            // "const NS::String* source" -> type="const NS::String*", name="source"
            var tokens = part.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (tokens.Count == 0) continue;

            var name = tokens[tokens.Count - 1].TrimStart('*').TrimEnd('*');
            var typeParts = tokens.Take(tokens.Count - 1).ToArray();
            var type = string.Join(" ", typeParts);

            // Strip C++ forward declaration "class" keyword from type
            if (type.StartsWith("class "))
                type = type.Substring(6);

            // Handle cases like "ResourceOptions options" (no pointer)
            if (string.IsNullOrEmpty(type) && tokens.Count == 1)
            {
                type = tokens[0];
                name = "param";
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
        if (string.IsNullOrEmpty(paramStr)) return methodName;

        return null;
    }

    /// <summary>
    /// Parse all _MTL_PRIVATE_DEF_SEL entries from Private.hpp files.
    /// Returns a map of fieldName -> "objc:selector:string:".
    /// </summary>
    public static Dictionary<string, string> ParseSelectorDefs(string content)
    {
        var map = new Dictionary<string, string>();
        foreach (Match m in s_selectorDefRegex.Matches(content))
        {
            var fieldName = m.Groups[1].Value;  // e.g. "newBufferWithLength_options_"
            var selector = m.Groups[2].Value;   // e.g. "newBufferWithLength:options:"
            map[fieldName] = selector;
        }
        return map;
    }

    private static int FindMatchingBrace(string content, int startAfterOpenBrace)
    {
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
        return rawName.EndsWith("Descriptor")
            || rawName == "CompileOptions"
            || rawName == "VertexDescriptor"
            || rawName == "StencilDescriptor"
            || rawName == "RenderPassDescriptor"
            || rawName == "ComputePassDescriptor"
            || rawName == "BlitPassDescriptor"
            || rawName == "MetalLayer";
    }
}
