using System.Text;
using System.Text.RegularExpressions;

// --- Entry point ---
string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
string metalCppDir = Path.Combine(projectDir, "Metal.NET.Generator", "metal-cpp");
string outputDir = Path.Combine(projectDir, "Metal.NET");

var generator = new Generator(metalCppDir, outputDir);
generator.Run();
return 0;

// =============================================================================
// Data models
// =============================================================================

record EnumDef(string CppNamespace, string Name, string BackingType, bool IsFlags, List<EnumMember> Members);
record EnumMember(string Name, string Value);
record FreeFunctionDef(string CEntryPoint, string ReturnType, string CppName, List<ParamDef> Parameters, string LibraryPath, string CppNamespace, string TargetClassName);

class ClassDef
{
    public string CppNamespace { get; set; } = "";
    public string Name { get; set; } = "";
    public bool IsCopying { get; set; }
    public string? BaseClassName { get; set; }
    public List<MethodInfo> Methods { get; set; } = [];
}

class MethodInfo
{
    public string CppName { get; set; } = "";
    public string ReturnType { get; set; } = "void";
    public bool IsStatic { get; set; }
    public bool IsConst { get; set; }
    public List<ParamDef> Parameters { get; set; } = [];
    public bool UsesClassTarget { get; set; }
    public string? SelectorAccessor { get; set; }
}

record ParamDef(string CppType, string Name);

// =============================================================================
// Generator
// =============================================================================

class Generator
{
    readonly string _metalCppDir;
    readonly string _outputDir;

    // accessor name → ObjC selector string (from bridge files)
    readonly Dictionary<string, string> _selectorMap = new();
    // ObjC class names that have _DEF_CLS entries
    readonly HashSet<string> _registeredClasses = new();
    // All parsed enums
    readonly List<EnumDef> _enums = [];
    // All parsed classes
    readonly List<ClassDef> _classes = [];
    // All parsed free functions (extern "C")
    readonly List<FreeFunctionDef> _freeFunctions = [];
    // All known generated class names (for validating base class references)
    readonly HashSet<string> _knownClassNames = new();

    // Hand-written classes to skip
    static readonly HashSet<string> SkipClasses = ["NSString", "NSError", "NSArray", "NSURL",
        "NSDictionary", "NSNotification", "NSNotificationCenter", "NSSet", "NSEnumerator",
        "NSObject", "NSProcessInfo", "NSBundle", "NSAutoreleasePool", "NSNumber", "NSValue",
        "NSDate"];

    // Methods to skip
    static readonly HashSet<string> SkipMethods = ["alloc", "init", "retain", "release", "autorelease", "copy", "retainCount"];

    // Known typos in metal-cpp headers (parameter name corrections)
    static readonly Dictionary<string, string> ParamNameCorrections = new()
    {
        ["frontFacingWindning"] = "frontFacingWinding"
    };

    // C# reserved words
    static readonly HashSet<string> CSharpReservedWords =
    [
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
        "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
        "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
        "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock",
        "long", "namespace", "new", "null", "object", "operator", "out", "override", "params",
        "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
        "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true",
        "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual",
        "void", "volatile", "while"
    ];

    // Struct types (returned by value, not nullable)
    static readonly HashSet<string> StructTypes =
    [
        "NSRange", "MTLRegion", "MTLSize", "MTLOrigin", "MTLSamplePosition", "MTLViewport",
        "MTLScissorRect", "MTLClearColor", "CGSize", "MTLResourceID", "MTLSizeAndAlign",
        "MTLAccelerationStructureSizes", "MTLTextureSwizzleChannels",
        "MTLVertexAmplificationViewMapping", "MTL4BufferRange", "MTL4Origin", "MTL4Size",
        "MTL4Range", "MTLRange",
        "MTL4CopySparseBufferMappingOperation", "MTL4CopySparseTextureMappingOperation",
        "MTL4UpdateSparseBufferMappingOperation", "MTL4UpdateSparseTextureMappingOperation"
    ];

    // Enum types we've seen (filled during parsing)
    readonly Dictionary<string, string> _enumBackingTypes = new();

    static string GetPrefix(string cppNamespace) => cppNamespace switch
    {
        "MTL" => "MTL",
        "MTL4" => "MTL4",
        "NS" => "NS",
        "CA" => "CA",
        "MTLFX" => "MTLFX",
        "MTL4FX" => "MTL4FX",
        _ => cppNamespace
    };

    static string GetOutputSubdir(string cppNamespace) => cppNamespace switch
    {
        "MTL" or "MTL4" => "Metal",
        "NS" => "Foundation",
        "CA" => "QuartzCore",
        "MTLFX" or "MTL4FX" => "MetalFX",
        _ => "Metal"
    };

    public Generator(string metalCppDir, string outputDir)
    {
        _metalCppDir = metalCppDir;
        _outputDir = outputDir;
    }

    public void Run()
    {
        Console.WriteLine("Parsing selector definitions...");
        ParseBridgeFiles();

        Console.WriteLine("Parsing header files...");
        ParseAllHeaders();

        Console.WriteLine($"Found {_enums.Count} enums, {_classes.Count} classes, {_freeFunctions.Count} free functions");

        Console.WriteLine("Generating C# files...");
        GenerateAll();

        Console.WriteLine("Done!");
    }

    // =========================================================================
    // Step 1: Parse bridge/private files
    // =========================================================================

    void ParseBridgeFiles()
    {
        string[] bridgeFiles =
        [
            Path.Combine(_metalCppDir, "Metal", "MTLHeaderBridge.hpp"),
            Path.Combine(_metalCppDir, "Foundation", "NSPrivate.hpp"),
            Path.Combine(_metalCppDir, "QuartzCore", "CAPrivate.hpp"),
            Path.Combine(_metalCppDir, "MetalFX", "MTLFXPrivate.hpp"),
        ];

        foreach (var file in bridgeFiles)
        {
            if (!File.Exists(file)) continue;
            string content = File.ReadAllText(file);

            // Parse selectors: _XXX_PRIVATE_DEF_SEL(accessor, "selectorString")
            foreach (Match m in Regex.Matches(content,
                @"_\w+_PRIVATE_DEF_SEL\(\s*(\w+)\s*,\s*""([^""]+)""\s*\)"))
            {
                _selectorMap[m.Groups[1].Value] = m.Groups[2].Value;
            }

            // Parse class registrations: _XXX_PRIVATE_DEF_CLS(ClassName)
            foreach (Match m in Regex.Matches(content, @"_\w+_PRIVATE_DEF_CLS\(\s*(\w+)\s*\)"))
            {
                _registeredClasses.Add(m.Groups[1].Value);
            }
        }

        Console.WriteLine($"  Parsed {_selectorMap.Count} selectors, {_registeredClasses.Count} class registrations");
    }

    // =========================================================================
    // Step 2: Parse all .hpp header files
    // =========================================================================

    void ParseAllHeaders()
    {
        string[] subdirs = ["Metal", "Foundation", "QuartzCore", "MetalFX"];

        foreach (var subdir in subdirs)
        {
            string dir = Path.Combine(_metalCppDir, subdir);
            if (!Directory.Exists(dir)) continue;

            foreach (var file in Directory.GetFiles(dir, "*.hpp"))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.Contains("Private") || fileName.Contains("HeaderBridge") ||
                    fileName.Contains("Defines") || fileName.Contains("Types") ||
                    fileName.Contains("Version") || fileName.Contains("GPUAddress") ||
                    fileName.Contains("IOCompressor") || fileName.Contains("AccelerationStructureTypes"))
                    continue;
                if (fileName is "Metal.hpp" or "Foundation.hpp" or "QuartzCore.hpp" or "MetalFX.hpp")
                    continue;

                string content = File.ReadAllText(file);
                ParseEnums(content);
                ParseClasses(content, file);
                ParseFreeFunctions(content, subdir, file);
            }
        }
    }

    // =========================================================================
    // Enum parsing
    // =========================================================================

    void ParseEnums(string content)
    {
        var enumRegex = new Regex(
            @"_(\w+)_(ENUM|OPTIONS)\s*\(\s*([^,]+?)\s*,\s*(\w+)\s*\)\s*\{([^}]*)\}",
            RegexOptions.Singleline);

        // Find namespace context positions
        var namespaceRegex = new Regex(@"namespace\s+(MTL4FX|MTL4|MTLFX|MTL|NS|CA)\s*\{", RegexOptions.Multiline);
        var nsPositions = new List<(string Ns, int Pos)>();
        foreach (Match nm in namespaceRegex.Matches(content))
            nsPositions.Add((nm.Groups[1].Value, nm.Index));

        foreach (Match m in enumRegex.Matches(content))
        {
            string nsPrefix = m.Groups[1].Value;
            bool isFlags = m.Groups[2].Value == "OPTIONS";
            string cppType = m.Groups[3].Value.Trim();
            string name = m.Groups[4].Value.Trim();
            string body = m.Groups[5].Value;

            string backingType = MapEnumBackingType(cppType);

            // Determine namespace from enclosing namespace block, not macro prefix
            string cppNamespace = nsPrefix switch
            {
                "NS" => "NS",
                "CA" => "CA",
                "MTLFX" => "MTLFX",
                _ => "MTL"
            };
            for (int i = nsPositions.Count - 1; i >= 0; i--)
            {
                if (nsPositions[i].Pos < m.Index)
                {
                    cppNamespace = nsPositions[i].Ns;
                    break;
                }
            }

            string prefix = GetPrefix(cppNamespace);
            string csEnumName = prefix + name;
            _enumBackingTypes[csEnumName] = backingType;

            var members = ParseEnumMembers(body, name, prefix);
            _enums.Add(new EnumDef(cppNamespace, name, backingType, isFlags, members));
        }
    }

    static string MapEnumBackingType(string cppType) => cppType.Trim() switch
    {
        "NS::UInteger" or "UInteger" => "ulong",
        "NS::Integer" or "Integer" => "long",
        "uint32_t" => "uint",
        "int32_t" => "int",
        "uint8_t" => "byte",
        "std::uint64_t" or "uint64_t" => "ulong",
        "std::int64_t" or "int64_t" => "long",
        _ => "ulong"
    };

    static List<EnumMember> ParseEnumMembers(string body, string cppEnumName, string nsPrefix)
    {
        // First pass: collect all C++ member names and their values
        var rawMembers = new List<(string CppName, string Value)>();
        var cppNameToValue = new Dictionary<string, string>();
        int nextImplicitValue = 0;

        foreach (var rawLine in body.Split('\n'))
        {
            var line = rawLine.Trim().TrimEnd(',');
            if (string.IsNullOrWhiteSpace(line)) continue;

            var memberMatch = Regex.Match(line, @"^(\w+)\s*(?:=\s*(.+))?$");
            if (!memberMatch.Success) continue;

            string cppMemberName = memberMatch.Groups[1].Value;
            string csValue;

            if (memberMatch.Groups[2].Success)
            {
                string value = memberMatch.Groups[2].Value.Trim();
                csValue = EvaluateEnumValue(value, cppNameToValue);
                if (long.TryParse(csValue, out long parsed))
                    nextImplicitValue = (int)(parsed + 1);
            }
            else
            {
                csValue = nextImplicitValue.ToString();
                nextImplicitValue++;
            }

            cppNameToValue[cppMemberName] = csValue;
            rawMembers.Add((cppMemberName, csValue));
        }

        // Compute the common prefix to strip from all member names
        string stripPrefix = ComputeEnumStripPrefix(cppEnumName, rawMembers.Select(m => m.CppName).ToList());

        // Second pass: build C# enum members with stripped names
        var members = new List<EnumMember>();
        foreach (var (cppName, value) in rawMembers)
        {
            string csName = cppName.StartsWith(stripPrefix)
                ? cppName[stripPrefix.Length..]
                : cppName;

            // If the stripped name starts with a digit, prefix with the namespace prefix (e.g., MTL)
            if (csName.Length > 0 && char.IsDigit(csName[0]))
                csName = nsPrefix + csName;

            // If empty after stripping, keep original
            if (string.IsNullOrEmpty(csName))
                csName = cppName;

            members.Add(new EnumMember(csName, value));
        }

        return members;
    }

    static string ComputeEnumStripPrefix(string cppEnumName, List<string> memberNames)
    {
        if (memberNames.Count == 0) return cppEnumName;

        // If all members start with the full enum name, use it directly
        if (memberNames.All(m => m.StartsWith(cppEnumName)))
            return cppEnumName;

        // Compute the longest common prefix of all member names
        string lcp = memberNames[0];
        foreach (var name in memberNames.Skip(1))
        {
            int i = 0;
            while (i < lcp.Length && i < name.Length && lcp[i] == name[i])
                i++;
            lcp = lcp[..i];
            if (lcp.Length == 0) break;
        }

        if (lcp.Length == 0) return cppEnumName;

        // Check if the LCP ends at a word boundary (next char in members is uppercase or digit)
        bool atWordBoundary = memberNames.All(m =>
            m.Length <= lcp.Length || char.IsUpper(m[lcp.Length]) || char.IsDigit(m[lcp.Length]));

        if (atWordBoundary)
            return lcp;

        // Trim LCP to end at the last uppercase boundary
        for (int i = lcp.Length - 1; i > 0; i--)
        {
            if (char.IsUpper(lcp[i]))
                return lcp[..i];
        }

        return lcp;
    }

    static string EvaluateEnumValue(string value, Dictionary<string, string> cppNameToValue)
    {
        try
        {
            string resolved = value;

            foreach (var (cppName, memberValue) in cppNameToValue)
            {
                if (resolved.Contains(cppName))
                    resolved = resolved.Replace(cppName, memberValue);
            }

            resolved = Regex.Replace(resolved, @"(0x[\da-fA-F]+)ULL", "$1");
            resolved = Regex.Replace(resolved, @"(\d+)ULL", "$1");
            resolved = Regex.Replace(resolved, @"(0x[\da-fA-F]+)UL", "$1");
            resolved = Regex.Replace(resolved, @"(\d+)UL", "$1");
            // Handle known constants
            resolved = resolved.Replace("NS::UIntegerMax", "18446744073709551615");
            resolved = resolved.Replace("NS::IntegerMax", "9223372036854775807");
            // Handle L suffix
            resolved = Regex.Replace(resolved, @"(-?\d+)L\b", "$1");
            // Strip parentheses
            resolved = resolved.Trim();
            while (resolved.StartsWith('(') && resolved.EndsWith(')'))
                resolved = resolved[1..^1].Trim();

            var shiftMatch = Regex.Match(resolved, @"^1\s*<<\s*(\d+)$");
            if (shiftMatch.Success)
                return (1L << int.Parse(shiftMatch.Groups[1].Value)).ToString();

            if (resolved.StartsWith("0x", StringComparison.OrdinalIgnoreCase) &&
                ulong.TryParse(resolved[2..], System.Globalization.NumberStyles.HexNumber, null, out ulong hexVal))
                return hexVal.ToString();

            // Try signed parse first for negative values
            if (long.TryParse(resolved, out long signedVal))
                return signedVal.ToString();

            if (ulong.TryParse(resolved, out ulong numVal))
                return numVal.ToString();

            ulong? evalResult = TryEvaluateExpression(resolved);
            if (evalResult.HasValue)
                return evalResult.Value.ToString();

            return value.Trim().Replace("ULL", "").Replace("UL", "");
        }
        catch
        {
            return value.Trim();
        }
    }

    static ulong? TryEvaluateExpression(string expr)
    {
        try
        {
            expr = expr.Replace(" ", "");

            if (expr.Contains('|') && !expr.Contains('~'))
            {
                ulong result = 0;
                foreach (var part in expr.Split('|'))
                {
                    if (TryParseSimpleValue(part.Trim(), out ulong v))
                        result |= v;
                    else
                        return null;
                }
                return result;
            }

            var andNotMatch = Regex.Match(expr, @"^(\d+)&~(\d+)$");
            if (andNotMatch.Success)
                return ulong.Parse(andNotMatch.Groups[1].Value) & ~ulong.Parse(andNotMatch.Groups[2].Value);

            if (TryParseSimpleValue(expr, out ulong val))
                return val;

            return null;
        }
        catch { return null; }
    }

    static bool TryParseSimpleValue(string s, out ulong value)
    {
        s = s.Trim();
        if (s.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            return ulong.TryParse(s[2..], System.Globalization.NumberStyles.HexNumber, null, out value);

        var shiftMatch = Regex.Match(s, @"^(\d+)<<(\d+)$");
        if (shiftMatch.Success)
        {
            value = ulong.Parse(shiftMatch.Groups[1].Value) << int.Parse(shiftMatch.Groups[2].Value);
            return true;
        }

        return ulong.TryParse(s, out value);
    }

    // =========================================================================
    // Free function parsing (extern "C" declarations)
    // =========================================================================

    void ParseFreeFunctions(string content, string subdir, string filePath)
    {
        string libraryPath = subdir switch
        {
            "Metal" => "/System/Library/Frameworks/Metal.framework/Metal",
            "MetalFX" => "/System/Library/Frameworks/MetalFX.framework/MetalFX",
            "Foundation" => "/System/Library/Frameworks/Foundation.framework/Foundation",
            "QuartzCore" => "/System/Library/Frameworks/QuartzCore.framework/QuartzCore",
            _ => "/System/Library/Frameworks/Metal.framework/Metal"
        };

        string cppNamespace = subdir switch
        {
            "Metal" => "MTL",
            "MetalFX" => "MTLFX",
            "Foundation" => "NS",
            "QuartzCore" => "CA",
            _ => "MTL"
        };

        // Derive target class name from the header file name (e.g., MTLDevice.hpp → MTLDevice)
        string targetClassName = Path.GetFileNameWithoutExtension(filePath);

        // Match: extern "C" ReturnType FuncName(params);
        var externRegex = new Regex(
            @"extern\s+""C""\s+(.+?)\s+(\w+)\s*\(([^)]*)\)\s*;",
            RegexOptions.Multiline);

        foreach (Match m in externRegex.Matches(content))
        {
            string returnType = m.Groups[1].Value.Trim();
            string cFuncName = m.Groups[2].Value.Trim();
            string paramsStr = m.Groups[3].Value.Trim();

            // Skip functions with unmappable types
            if (IsUnmappableCppType(returnType)) continue;

            var parameters = ParseParameters(paramsStr);
            if (parameters.Any(p => IsUnmappableCppType(p.CppType) || p.CppType == "ARRAY_PARAM")) continue;
            if (parameters.Any(p => p.CppType.Contains("Handler") || p.CppType.Contains("Block") ||
                p.CppType.Contains("function") || p.CppType.Contains("Function"))) continue;

            // Derive C++ wrapper name from the _NS_EXPORT pattern (e.g., MTLCreateSystemDefaultDevice → CreateSystemDefaultDevice)
            string prefix = GetPrefix(cppNamespace);
            string cppName = cFuncName.StartsWith(prefix) ? cFuncName[prefix.Length..] : cFuncName;

            _freeFunctions.Add(new FreeFunctionDef(cFuncName, returnType, cppName, parameters, libraryPath, cppNamespace, targetClassName));
        }
    }

    // =========================================================================
    // Class parsing
    // =========================================================================

    void ParseClasses(string content, string filePath)
    {
        var classRegex = new Regex(
            @"class\s+(\w+)\s*:\s*public\s+NS::(Referencing|Copying)\s*<\s*(\w+)(?:\s*,\s*((?:[\w:]+::)?)(\w+))?\s*>",
            RegexOptions.Multiline);

        var namespaceRegex = new Regex(@"namespace\s+(MTL4FX|MTL4|MTLFX|MTL|NS|CA)\s*\{", RegexOptions.Multiline);

        var namespacePositions = new List<(string Ns, int Pos)>();
        foreach (Match m in namespaceRegex.Matches(content))
            namespacePositions.Add((m.Groups[1].Value, m.Index));

        foreach (Match cm in classRegex.Matches(content))
        {
            string className = cm.Groups[1].Value;
            bool isCopying = cm.Groups[2].Value == "Copying";
            // Groups 4 = namespace prefix (e.g., "MTL::"), 5 = base class name
            string? baseNsPrefix = cm.Groups[4].Success && cm.Groups[4].Value.Length > 0 ? cm.Groups[4].Value : null;
            string? baseClassName = cm.Groups[5].Success && cm.Groups[5].Value.Length > 0 ? cm.Groups[5].Value : null;

            // Determine namespace
            string ns = "MTL";
            for (int i = namespacePositions.Count - 1; i >= 0; i--)
            {
                if (namespacePositions[i].Pos < cm.Index)
                {
                    ns = namespacePositions[i].Ns;
                    break;
                }
            }

            // Extract class body
            int braceStart = content.IndexOf('{', cm.Index + cm.Length);
            if (braceStart < 0) continue;
            int braceEnd = FindMatchingBrace(content, braceStart);
            if (braceEnd < 0) continue;

            string classBody = content[(braceStart + 1)..braceEnd];
            var rawMethods = ParseMethodDeclarations(classBody);

            // Parse inline implementations to find selector accessors and class targets
            var implInfo = ParseInlineImplementations(content, ns, className);

            // Build method list
            var methods = new List<MethodInfo>();
            var overloadCounter = new Dictionary<(string, int), int>();
            foreach (var (retType, name, isStatic, isConst, parameters) in rawMethods)
            {
                if (SkipMethods.Contains(name)) continue;

                var countKey = (name, parameters.Count);
                if (!overloadCounter.TryGetValue(countKey, out int idx))
                    idx = 0;
                overloadCounter[countKey] = idx + 1;

                var key = (name, parameters.Count, idx);
                bool usesClassTarget = implInfo.TryGetValue(key, out var info) && info.UsesClassTarget;
                string? selAccessor = info?.Accessor;

                methods.Add(new MethodInfo
                {
                    CppName = name,
                    ReturnType = retType,
                    IsStatic = isStatic,
                    IsConst = isConst,
                    Parameters = parameters,
                    UsesClassTarget = usesClassTarget,
                    SelectorAccessor = selAccessor
                });
            }

            // Resolve base class name with correct namespace prefix
            string? csBaseClassName = null;
            if (baseClassName != null)
            {
                if (!string.IsNullOrEmpty(baseNsPrefix))
                {
                    // Extract namespace from prefix like "MTL::" → "MTL"
                    string baseNs = baseNsPrefix.TrimEnd(':', ' ');
                    csBaseClassName = GetPrefix(baseNs) + baseClassName;
                }
                else
                {
                    // Same namespace as the class
                    csBaseClassName = GetPrefix(ns) + baseClassName;
                }
            }

            _classes.Add(new ClassDef
            {
                CppNamespace = ns,
                Name = className,
                IsCopying = isCopying,
                BaseClassName = csBaseClassName,
                Methods = methods
            });
        }
    }

    static int FindMatchingBrace(string content, int openPos)
    {
        int depth = 0;
        for (int i = openPos; i < content.Length; i++)
        {
            if (content[i] == '{') depth++;
            else if (content[i] == '}') { depth--; if (depth == 0) return i; }
        }
        return -1;
    }

    List<(string ReturnType, string Name, bool IsStatic, bool IsConst, List<ParamDef> Params)> ParseMethodDeclarations(string classBody)
    {
        var result = new List<(string, string, bool, bool, List<ParamDef>)>();

        var cleaned = Regex.Replace(classBody, @"//[^\n]*", "");
        cleaned = Regex.Replace(cleaned, @"/\*.*?\*/", "", RegexOptions.Singleline);

        foreach (var rawLine in cleaned.Split('\n'))
        {
            var line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("public:") ||
                line.StartsWith("private:") || line.StartsWith("protected:") ||
                line.StartsWith("//") ||
                (line.StartsWith("class ") && !line.Contains('(')) ||
                (line.StartsWith("struct ") && !line.Contains('(')) ||
                line.StartsWith("using ") ||
                line.StartsWith("typedef ") || line.StartsWith("friend "))
                continue;

            var methodMatch = Regex.Match(line,
                @"^(static\s+)?(.+?)\s+(\w+)\s*\(([^)]*)\)\s*(const)?\s*;?\s*$");
            if (!methodMatch.Success) continue;

            bool isStatic = methodMatch.Groups[1].Success;
            string returnType = methodMatch.Groups[2].Value.Trim();
            string name = methodMatch.Groups[3].Value.Trim();
            string paramsStr = methodMatch.Groups[4].Value.Trim();
            bool isConst = methodMatch.Groups[5].Success;

            if (returnType is "class" or "struct") continue;

            var parameters = ParseParameters(paramsStr);
            result.Add((returnType, name, isStatic, isConst, parameters));
        }

        return result;
    }

    record ImplInfo(string? Accessor, bool UsesClassTarget);

    Dictionary<(string MethodName, int ParamCount, int OverloadIndex), ImplInfo> ParseInlineImplementations(
        string content, string ns, string className)
    {
        var result = new Dictionary<(string, int, int), ImplInfo>();
        var countTracker = new Dictionary<(string, int), int>();
        string nsPattern = Regex.Escape(ns);

        var implRegex = new Regex(
            $@"_\w+_INLINE\s+.+?\s+{nsPattern}::{Regex.Escape(className)}::(\w+)\s*\(([^)]*)\)\s*(?:const\s*)?\{{(.*?)\}}",
            RegexOptions.Singleline);

        foreach (Match m in implRegex.Matches(content))
        {
            string methodName = m.Groups[1].Value;
            string paramsStr = m.Groups[2].Value;
            string body = m.Groups[3].Value;

            int paramCount = string.IsNullOrWhiteSpace(paramsStr) ? 0 : SplitParams(paramsStr).Count;

            bool usesClassTarget = Regex.IsMatch(body, @"_\w+_PRIVATE_CLS\(");

            var selMatch = Regex.Match(body, @"_\w+_PRIVATE_SEL\(\s*(\w+)\s*\)");
            string? accessor = selMatch.Success ? selMatch.Groups[1].Value : null;

            var key = (methodName, paramCount);
            if (!countTracker.TryGetValue(key, out int idx))
                idx = 0;
            countTracker[key] = idx + 1;

            result[(methodName, paramCount, idx)] = new ImplInfo(accessor, usesClassTarget);
        }

        return result;
    }

    static List<ParamDef> ParseParameters(string paramsStr)
    {
        if (string.IsNullOrWhiteSpace(paramsStr)) return [];

        var parameters = new List<ParamDef>();
        foreach (var part in SplitParams(paramsStr))
        {
            var p = part.Trim();
            if (string.IsNullOrWhiteSpace(p)) continue;

            if (p.Contains("[]"))
            {
                parameters.Add(new ParamDef("ARRAY_PARAM", "array"));
                continue;
            }

            // Remove const
            var cleaned = p.Replace("const ", "").Trim();

            var lastSpace = cleaned.LastIndexOf(' ');
            if (lastSpace < 0)
            {
                parameters.Add(new ParamDef(cleaned, "param"));
                continue;
            }

            string type = cleaned[..lastSpace].Trim();
            string name = cleaned[(lastSpace + 1)..].Trim();

            if (name.StartsWith('*'))
            {
                type += "*";
                name = name[1..];
            }

            parameters.Add(new ParamDef(type.Trim(), name));
        }

        return parameters;
    }

    static List<string> SplitParams(string paramsStr)
    {
        var result = new List<string>();
        int depth = 0;
        int start = 0;

        for (int i = 0; i < paramsStr.Length; i++)
        {
            char c = paramsStr[i];
            if (c == '<' || c == '(') depth++;
            else if (c == '>' || c == ')') depth--;
            else if (c == ',' && depth == 0)
            {
                result.Add(paramsStr[start..i]);
                start = i + 1;
            }
        }

        result.Add(paramsStr[start..]);
        return result;
    }

    // =========================================================================
    // Step 3: Generate C# files
    // =========================================================================

    void GenerateAll()
    {
        foreach (var enumDef in _enums)
            GenerateEnum(enumDef);

        // Build known class names (both generated and hand-written)
        foreach (var classDef in _classes)
        {
            string prefix = GetPrefix(classDef.CppNamespace);
            _knownClassNames.Add(prefix + classDef.Name);
        }
        // Also include hand-written classes that are valid base classes
        _knownClassNames.UnionWith(["NSString", "NSError", "NSArray", "NSURL", "NativeObject"]);

        // Build a map of class name -> property names for "new" keyword detection
        var classPropertyMap = new Dictionary<string, HashSet<string>>();
        foreach (var classDef in _classes)
        {
            string prefix = GetPrefix(classDef.CppNamespace);
            string csClassName = prefix + classDef.Name;
            var propNames = classDef.Methods
                .Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget)
                .Select(m => ToPascalCase(m.CppName))
                .ToHashSet();
            classPropertyMap[csClassName] = propNames;
        }

        // Build inherited property names by walking the inheritance chain
        HashSet<string> GetInheritedProperties(string csClassName)
        {
            var result = new HashSet<string>();
            if (!classPropertyMap.ContainsKey(csClassName)) return result;
            var classDef = _classes.First(c => GetPrefix(c.CppNamespace) + c.Name == csClassName);
            var current = classDef.BaseClassName;
            while (current != null && _knownClassNames.Contains(current) && classPropertyMap.TryGetValue(current, out var parentProps))
            {
                result.UnionWith(parentProps);
                var parentDef = _classes.FirstOrDefault(c => GetPrefix(c.CppNamespace) + c.Name == current);
                current = parentDef?.BaseClassName;
            }
            return result;
        }

        // Build lookup of free functions per target class
        var freeFuncsByClass = _freeFunctions
            .GroupBy(f => f.TargetClassName)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var classDef in _classes)
        {
            string prefix = GetPrefix(classDef.CppNamespace);
            string csClassName = prefix + classDef.Name;
            var inheritedProps = GetInheritedProperties(csClassName);
            freeFuncsByClass.TryGetValue(csClassName, out var classFuncs);
            GenerateClass(classDef, inheritedProps, classFuncs ?? []);
        }
    }

    void GenerateEnum(EnumDef enumDef)
    {
        string prefix = GetPrefix(enumDef.CppNamespace);
        string csEnumName = prefix + enumDef.Name;
        string subdir = GetOutputSubdir(enumDef.CppNamespace);
        string dir = Path.Combine(_outputDir, subdir);
        Directory.CreateDirectory(dir);

        var sb = new StringBuilder();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        if (enumDef.IsFlags)
            sb.AppendLine("[Flags]");

        sb.AppendLine($"public enum {csEnumName} : {enumDef.BackingType}");
        sb.AppendLine("{");

        for (int i = 0; i < enumDef.Members.Count; i++)
        {
            var member = enumDef.Members[i];
            string comma = i < enumDef.Members.Count - 1 ? "," : "";
            // Issue 7: Add blank lines between enum members
            if (i > 0) sb.AppendLine();
            sb.AppendLine($"    {member.Name} = {member.Value}{comma}");
        }

        sb.AppendLine("}");
        File.WriteAllText(Path.Combine(dir, $"{csEnumName}.cs"), sb.ToString());
        Console.WriteLine($"  Generated: {subdir}/{csEnumName}.cs");
    }

    void EmitFreeFunction(StringBuilder sb, FreeFunctionDef func, string cppNamespace)
    {
        string csReturnType = MapCppType(func.ReturnType, cppNamespace);
        bool nullable = IsNullableType(csReturnType);

        // Build P/Invoke parameter list
        var pinvokeParams = new List<string>();
        foreach (var p in func.Parameters)
        {
            string csType = MapCppType(p.CppType, cppNamespace);
            if (IsNullableType(csType))
                pinvokeParams.Add($"nint {EscapeReservedWord(ToCamelCase(p.Name))}");
            else
                pinvokeParams.Add($"{csType} {EscapeReservedWord(ToCamelCase(p.Name))}");
        }

        string pinvokeReturnType = nullable ? "nint" : csReturnType;

        // P/Invoke declaration
        sb.AppendLine($"    [LibraryImport(\"{func.LibraryPath}\", EntryPoint = \"{func.CEntryPoint}\")]");
        sb.AppendLine($"    private static partial {pinvokeReturnType} {func.CEntryPoint}({string.Join(", ", pinvokeParams)});");
        sb.AppendLine();

        // Public wrapper method
        var wrapperParams = new List<string>();
        var callArgs = new List<string>();
        foreach (var p in func.Parameters)
        {
            string csType = MapCppType(p.CppType, cppNamespace);
            string csName = EscapeReservedWord(ToCamelCase(p.Name));
            if (IsNullableType(csType))
            {
                wrapperParams.Add($"{csType} {csName}");
                callArgs.Add($"{csName}.NativePtr");
            }
            else
            {
                wrapperParams.Add($"{csType} {csName}");
                callArgs.Add(csName);
            }
        }

        string csFullReturnType = nullable ? $"{csReturnType}?" : csReturnType;
        string wrapperParamStr = string.Join(", ", wrapperParams);
        string callArgStr = string.Join(", ", callArgs);

        if (nullable)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.CppName}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine($"        return nativePtr is not 0 ? new(nativePtr) : null;");
            sb.AppendLine("    }");
        }
        else if (csReturnType == "void")
        {
            sb.AppendLine($"    public static void {func.CppName}({wrapperParamStr}) => {func.CEntryPoint}({callArgStr});");
        }
        else
        {
            sb.AppendLine($"    public static {csReturnType} {func.CppName}({wrapperParamStr}) => {func.CEntryPoint}({callArgStr});");
        }
    }

    void GenerateClass(ClassDef classDef, HashSet<string> inheritedProperties, List<FreeFunctionDef> freeFunctions)
    {
        string prefix = GetPrefix(classDef.CppNamespace);
        string csClassName = prefix + classDef.Name;

        if (SkipClasses.Contains(csClassName)) return;

        string subdir = GetOutputSubdir(classDef.CppNamespace);
        string dir = Path.Combine(_outputDir, subdir);
        Directory.CreateDirectory(dir);

        bool hasClassField = _registeredClasses.Contains(csClassName);
        bool hasFreeFunctions = freeFunctions.Count > 0;

        // Filter out methods with array params, function pointer params, or unmappable types
        var validMethods = classDef.Methods
            .Where(m => !m.Parameters.Any(p => p.CppType == "ARRAY_PARAM"))
            .Where(m => !HasFunctionPointerParam(m))
            .Where(m => !HasUnmappableParam(m))
            .ToList();

        // Categorize into properties and methods
        // Identify methods whose C++ name has a zero-param sibling that became a property
        var nameCounts = validMethods.GroupBy(m => m.CppName).Where(g => g.Count() > 1)
            .Select(g => g.Key).ToHashSet();
        var hasZeroParamVersion = validMethods
            .Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget)
            .Select(m => m.CppName).ToHashSet();

        var (properties, methods) = CategorizeMembers(validMethods, classDef.CppNamespace);

        var selectors = new SortedDictionary<string, string>();
        var sb = new StringBuilder();

        if (hasFreeFunctions)
        {
            sb.AppendLine("using System.Runtime.InteropServices;");
            sb.AppendLine();
        }

        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        // Reference type class with primary constructor inheriting base class or NativeObject
        // Use 'partial' when we have free functions that need LibraryImport
        string baseClass = classDef.BaseClassName != null && _knownClassNames.Contains(classDef.BaseClassName)
            ? classDef.BaseClassName
            : "NativeObject";
        string partialKeyword = hasFreeFunctions ? "partial " : "";
        sb.AppendLine($"public {partialKeyword}class {csClassName}(nint nativePtr) : {baseClass}(nativePtr)");
        sb.AppendLine("{");

        // For creatable objects, add parameterless constructor
        bool hasPrecedingMember = false;
        if (hasClassField)
        {
            sb.AppendLine($"    public {csClassName}() : this(ObjectiveCRuntime.AllocInit({csClassName}Bindings.Class))");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        // Properties (sorted alphabetically)
        foreach (var prop in properties)
        {
            if (hasPrecedingMember) sb.AppendLine();
            EmitProperty(sb, prop, csClassName, classDef.CppNamespace, selectors, inheritedProperties);
            hasPrecedingMember = true;
        }

        // Methods
        foreach (var method in methods)
        {
            if (hasPrecedingMember) sb.AppendLine();
            EmitMethod(sb, method, csClassName, classDef.CppNamespace, selectors, hasClassField, hasZeroParamVersion);
            hasPrecedingMember = true;
        }

        // Static free functions (e.g., MTLCreateSystemDefaultDevice → MTLDevice.CreateSystemDefaultDevice)
        foreach (var func in freeFunctions)
        {
            if (hasPrecedingMember) sb.AppendLine();
            EmitFreeFunction(sb, func, classDef.CppNamespace);
            hasPrecedingMember = true;
        }

        sb.AppendLine("}");
        sb.AppendLine();

        // Bindings class
        sb.AppendLine($"file static class {csClassName}Bindings");
        sb.AppendLine("{");

        bool first = true;
        if (hasClassField)
        {
            sb.AppendLine($"    public static readonly nint Class = ObjectiveCRuntime.GetClass(\"{csClassName}\");");
            first = false;
        }

        foreach (var (name, objc) in selectors)
        {
            if (!first) sb.AppendLine();
            sb.AppendLine($"    public static readonly Selector {name} = \"{objc}\";");
            first = false;
        }
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(dir, $"{csClassName}.cs"), sb.ToString());
        Console.WriteLine($"  Generated: {subdir}/{csClassName}.cs");
    }

    static bool HasFunctionPointerParam(MethodInfo method)
    {
        return method.Parameters.Any(p =>
            p.CppType.Contains("Handler") || p.CppType.Contains("Block") ||
            p.CppType.Contains("function") || p.CppType.Contains("std::function") ||
            p.CppType.Contains("void(") || p.CppType.Contains("Function&") ||
            p.CppType.Contains("Function &"));
    }

    static bool HasUnmappableParam(MethodInfo method)
    {
        foreach (var p in method.Parameters)
        {
            if (IsUnmappableCppType(p.CppType)) return true;
        }
        // Also check return type
        if (IsUnmappableCppType(method.ReturnType)) return true;
        return false;
    }

    static bool IsUnmappableCppType(string cppType)
    {
        string t = cppType;
        // Template types
        if (t.Contains('<') || t.Contains('>')) return true;
        // C++ references (not pointers)
        if (t.Contains('&')) return true;
        // Raw pointer array patterns
        if (t.Contains("* const") && !t.Contains("**")) return true;
        // MTL::Timestamp is a typedef for uint64_t used as pointer (sampleTimestamps takes Timestamp*)
        // But MTL4::TimestampGranularity is a valid enum - don't block it
        if (t.Contains("Timestamp") && !t.Contains("TimestampGranularity")) return true;
        // Autoreleased types (special out-pointer pattern)
        if (t.Contains("Autoreleased")) return true;
        // Unsupported Foundation types
        if (t.Contains("NS::Bundle") || t.Contains("NS::Process") ||
            t.Contains("NS::Notification") || t.Contains("NS::Observer") ||
            t.Contains("NS::Dictionary") || t.Contains("NS::Object") ||
            t.Contains("NS::Data") || t.Contains("NS::Number") ||
            t.Contains("NS::Set") || t.Contains("NS::Enumerator") ||
            t.Contains("NS::Value") || t.Contains("NS::Date")) return true;
        // MTLCoordinate2D (typedef, not in structs set)
        if (t.Contains("Coordinate2D")) return true;
        // Kernel/system types
        if (t.Contains("kern_return_t") || t.Contains("task_id_token_t")) return true;
        return false;
    }

    // =========================================================================
    // Categorize methods into properties and methods
    // =========================================================================

    record PropertyDef(MethodInfo Getter, MethodInfo? Setter);

    (List<PropertyDef> Properties, List<MethodInfo> Methods) CategorizeMembers(
        List<MethodInfo> allMethods, string ns)
    {
        var properties = new List<PropertyDef>();
        var methods = new List<MethodInfo>();
        var used = new HashSet<MethodInfo>(ReferenceEqualityComparer.Instance);

        // Build setter map
        var setterMap = new Dictionary<string, MethodInfo>(StringComparer.Ordinal);
        foreach (var m in allMethods)
        {
            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3]) &&
                m.ReturnType == "void" && m.Parameters.Count == 1)
            {
                string propName = char.ToLower(m.CppName[3]) + (m.CppName.Length > 4 ? m.CppName[4..] : "");
                setterMap[propName] = m;
            }
        }

        // Find getters: no params, returns value, not using class target (static factory methods → methods)
        foreach (var m in allMethods)
        {
            if (m.ReturnType == "void") continue;
            if (m.Parameters.Count > 0) continue;
            if (m.UsesClassTarget) continue; // static methods using Class → remain methods
            if (used.Contains(m)) continue;
            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3])) continue;

            MethodInfo? setter = null;
            if (setterMap.TryGetValue(m.CppName, out var s))
            {
                setter = s;
                used.Add(s);
            }

            properties.Add(new PropertyDef(m, setter));
            used.Add(m);
        }

        // Remaining become methods
        foreach (var m in allMethods)
        {
            if (used.Contains(m)) continue;
            // Note: orphan setters (set methods without a matching getter) are kept as methods
            methods.Add(m);
        }

        // Sort properties alphabetically by PascalCase name
        properties.Sort((a, b) => string.Compare(
            ToPascalCase(a.Getter.CppName), ToPascalCase(b.Getter.CppName), StringComparison.Ordinal));

        return (properties, methods);
    }

    // =========================================================================
    // Property emission
    // =========================================================================

    void EmitProperty(StringBuilder sb, PropertyDef prop, string csClassName,
        string ns, SortedDictionary<string, string> selectors, HashSet<string> inheritedProperties)
    {
        var getter = prop.Getter;
        string csPropName = ToPascalCase(getter.CppName);
        string csType = MapCppType(getter.ReturnType, ns);
        bool nullable = IsNullableType(csType);
        bool isEnum = IsEnumType(csType);
        bool isStruct = StructTypes.Contains(csType);
        bool isBool = csType == "bool";
        bool isNew = inheritedProperties.Contains(csPropName);

        // Register getter selector
        string selectorName = csPropName;
        string selectorObjC;
        if (getter.SelectorAccessor != null && _selectorMap.TryGetValue(getter.SelectorAccessor, out string? objcSel))
            selectorObjC = objcSel;
        else
            selectorObjC = getter.CppName;
        selectors.TryAdd(selectorName, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorName}";
        string target = "NativePtr";

        string typeStr = nullable ? $"{csType}?" : csType;

        // Resolve setter selector
        string? setSelName = null;
        string? setSelObjC = null;
        if (prop.Setter != null)
        {
            setSelName = "Set" + csPropName;
            if (prop.Setter.SelectorAccessor != null && _selectorMap.TryGetValue(prop.Setter.SelectorAccessor, out string? setObjC))
                setSelObjC = setObjC;
            else
                setSelObjC = "set" + csPropName + ":";
            selectors.TryAdd(setSelName, setSelObjC);
        }

        string newMod = isNew ? "new " : "";

        if (nullable)
        {
            // Use NativeObject.GetProperty/SetProperty helpers for cached nullable reference type properties
            sb.AppendLine($"    public {newMod}{typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => GetProperty(ref field, {selectorRef});");

            if (prop.Setter != null)
                sb.AppendLine($"        set => SetProperty(ref field, {csClassName}Bindings.{setSelName}, value);");
            sb.AppendLine("    }");
        }
        else if (isEnum)
        {
            string msgSend = GetMsgSendForEnumGet(csType);

            sb.AppendLine($"    public {newMod}{typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ({csType}){msgSend}({target}, {selectorRef});");

            if (prop.Setter != null)
            {
                string setCast = GetEnumSetCast(csType);
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, {setCast}value);");
            }
            sb.AppendLine("    }");
        }
        else if (isBool)
        {
            sb.AppendLine($"    public {newMod}bool {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.MsgSendBool({target}, {selectorRef});");

            if (prop.Setter != null)
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, (Bool8)value);");
            sb.AppendLine("    }");
        }
        else if (isStruct)
        {
            string msgSend = GetMsgSendForStruct(csType);

            sb.AppendLine($"    public {newMod}{typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.{msgSend}({target}, {selectorRef});");

            if (prop.Setter != null)
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            sb.AppendLine("    }");
        }
        else
        {
            string msgSend = GetMsgSendMethod(csType);
            string getCast = csType is "int" or "long" ? $"({csType})" : "";

            sb.AppendLine($"    public {newMod}{typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => {getCast}ObjectiveCRuntime.{msgSend}({target}, {selectorRef});");

            if (prop.Setter != null)
            {
                string setCast = csType switch { "int" => "(nint)", "long" => "(nint)", _ => "" };
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, {setCast}value);");
            }
            sb.AppendLine("    }");
        }
    }

    // =========================================================================
    // Method emission
    // =========================================================================

    void EmitMethod(StringBuilder sb, MethodInfo method, string csClassName,
        string ns, SortedDictionary<string, string> selectors, bool hasClassField,
        HashSet<string> methodsWithZeroParamProperty)
    {
        // Derive the C# method name and ObjC selector from the accessor
        string csMethodName;
        string selectorObjC;
        string cppName = method.CppName;

        if (method.SelectorAccessor != null)
        {
            // Look up the ObjC selector string from the bridge files
            if (_selectorMap.TryGetValue(method.SelectorAccessor, out string? objcSel))
                selectorObjC = objcSel;
            else
                selectorObjC = method.SelectorAccessor.Replace('_', ':');

            // Derive method name from the ObjC selector
            // Take everything before the first ':' and PascalCase it
            string selectorBaseName = selectorObjC.Contains(':')
                ? selectorObjC[..selectorObjC.IndexOf(':')]
                : selectorObjC;

            // If this C++ method name has a zero-param sibling that became a property,
            // use the selector-based name to differentiate
            if (methodsWithZeroParamProperty.Contains(cppName) && method.Parameters.Count > 0)
                csMethodName = ToPascalCase(selectorBaseName);
            else
                csMethodName = ToPascalCase(cppName);
        }
        else
        {
            csMethodName = ToPascalCase(cppName);
            // Fallback: construct selector from method name + colons
            int colonCount = method.Parameters.Count;
            selectorObjC = method.CppName + (colonCount > 0 ? new string(':', colonCount) : "");
        }

        bool isStaticClassMethod = method.IsStatic && method.UsesClassTarget;
        string target = isStaticClassMethod ? $"{csClassName}Bindings.Class" : "NativePtr";

        string selectorKey = ToPascalCase(method.CppName);
        // If a selector key already exists with a different ObjC selector, make the key unique
        if (selectors.TryGetValue(selectorKey, out string? existingSelector) && existingSelector != selectorObjC)
        {
            // Use the full selector-based name to disambiguate
            selectorKey = ToPascalCase(selectorObjC.Replace(":", " ").Trim()).Replace(" ", "");
        }
        selectors.TryAdd(selectorKey, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        string returnType = MapCppType(method.ReturnType, ns);
        bool nullable = IsNullableType(returnType);
        bool isEnum = IsEnumType(returnType);
        bool isStruct = StructTypes.Contains(returnType);
        bool isBool = returnType == "bool";
        bool isVoid = returnType == "void";

        bool hasOutError = method.Parameters.Any(p => p.CppType.Contains("Error**"));

        // Build C# parameter list and call arguments
        var csParams = new List<string>();
        var callArgs = new List<string> { target, selectorRef };

        foreach (var param in method.Parameters)
        {
            if (param.CppType == "ARRAY_PARAM") continue;

            string csParamType = MapCppType(param.CppType, ns);
            string csParamName = EscapeReservedWord(ToCamelCase(param.Name));

            if (param.CppType.Contains("Error**"))
            {
                csParams.Add("out NSError? error");
                callArgs.Add("out nint errorPtr");
                continue;
            }

            csParams.Add($"{csParamType} {csParamName}");

            if (IsNullableType(csParamType))
                callArgs.Add($"{csParamName}.NativePtr");
            else if (IsEnumType(csParamType))
                callArgs.Add($"{GetEnumSetCast(csParamType)}{csParamName}");
            else if (csParamType == "bool")
                callArgs.Add($"(Bool8){csParamName}");
            else if (csParamType is "uint" or "ulong")
                callArgs.Add($"(nuint){csParamName}");
            else if (csParamType is "int" or "long")
                callArgs.Add($"(nint){csParamName}");
            else
                callArgs.Add(csParamName);
        }

        string paramStr = string.Join(", ", csParams);
        string argsStr = string.Join(", ", callArgs);
        string staticKw = isStaticClassMethod ? "static " : "";
        string csReturnType = isVoid ? "void" : nullable ? $"{returnType}?" : returnType;

        sb.AppendLine($"    public {staticKw}{csReturnType} {csMethodName}({paramStr})");
        sb.AppendLine("    {");

        if (isVoid)
        {
            sb.AppendLine($"        ObjectiveCRuntime.MsgSend({argsStr});");
            if (hasOutError)
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
        }
        else if (nullable)
        {
            if (hasOutError)
            {
                sb.AppendLine($"        nint nativePtr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
                sb.AppendLine();
                sb.AppendLine($"        return nativePtr is not 0 ? new(nativePtr) : null;");
            }
            else
            {
                sb.AppendLine($"        nint nativePtr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"        return nativePtr is not 0 ? new(nativePtr) : null;");
            }
        }
        else if (isEnum)
        {
            string msgSend = GetMsgSendForEnumGet(returnType);
            if (hasOutError)
            {
                sb.AppendLine($"        var result = ({returnType}){msgSend}({argsStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
                sb.AppendLine("        return result;");
            }
            else
            {
                sb.AppendLine($"        return ({returnType}){msgSend}({argsStr});");
            }
        }
        else if (isBool)
        {
            if (hasOutError)
            {
                sb.AppendLine($"        var result = ObjectiveCRuntime.MsgSendBool({argsStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
                sb.AppendLine("        return result;");
            }
            else
            {
                sb.AppendLine($"        return ObjectiveCRuntime.MsgSendBool({argsStr});");
            }
        }
        else if (isStruct)
        {
            string msgSend = GetMsgSendForStruct(returnType);
            if (hasOutError)
            {
                sb.AppendLine($"        var result = ObjectiveCRuntime.{msgSend}({argsStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
                sb.AppendLine("        return result;");
            }
            else
            {
                sb.AppendLine($"        return ObjectiveCRuntime.{msgSend}({argsStr});");
            }
        }
        else
        {
            string msgSend = GetMsgSendMethod(returnType);
            string retCast = returnType is "uint" or "ulong" or "int" or "long" ? $"({returnType})" : "";
            if (hasOutError)
            {
                sb.AppendLine($"        var result = {retCast}ObjectiveCRuntime.{msgSend}({argsStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new(errorPtr) : null;");
                sb.AppendLine("        return result;");
            }
            else
            {
                sb.AppendLine($"        return {retCast}ObjectiveCRuntime.{msgSend}({argsStr});");
            }
        }

        sb.AppendLine("    }");
    }

    // =========================================================================
    // Type mapping
    // =========================================================================

    string MapCppType(string cppType, string defaultNs)
    {
        string t = cppType.Trim();

        // Remove const and class keywords
        t = t.Replace("const ", "").Replace("class ", "").Trim();

        bool isPointer = t.EndsWith('*');
        bool isDoublePointer = t.EndsWith("**");

        if (isDoublePointer) t = t[..^2].Trim();
        else if (isPointer) t = t[..^1].Trim();

        if (t == "void" && isPointer) return "nint";
        if (t == "void") return "void";

        string? simple = t switch
        {
            "NS::UInteger" when isPointer => "nint",
            "NS::Integer" when isPointer => "nint",
            "NS::UInteger" => "nuint",
            "NS::Integer" => "nint",
            "uint32_t" => "uint",
            "int32_t" => "int",
            "uint8_t" => "byte",
            "int8_t" => "sbyte",
            "uint16_t" => "ushort",
            "int16_t" => "short",
            "uint64_t" or "std::uint64_t" => "ulong",
            "int64_t" or "std::int64_t" => "long",
            "float" => "float",
            "double" => "double",
            "bool" => "bool",
            "char" when isPointer => "nint",
            "IOSurfaceRef" => "nint",
            "dispatch_queue_t" => "nint",
            "dispatch_data_t" => "nint",
            "CGColorSpaceRef" => "nint",
            "CFTimeInterval" => "double",
            "CGSize" => "CGSize",
            _ => null
        };
        if (simple != null) return simple;

        // Namespaced types
        var nsMatch = Regex.Match(t, @"^(MTL4FX|MTL4|MTLFX|MTL|NS|CA|CG)\s*::\s*(.+)$");
        if (nsMatch.Success)
        {
            string typeNs = nsMatch.Groups[1].Value;
            string typeName = nsMatch.Groups[2].Value.Trim();

            if (typeName == "GPUAddress") return "nuint";

            string prefix = GetPrefix(typeNs);
            string csName = prefix + typeName;

            if (StructTypes.Contains(csName)) return csName;
            if (_enumBackingTypes.ContainsKey(csName)) return csName;
            return csName;
        }

        // Unqualified type in same namespace
        if (!t.Contains("::"))
        {
            // Special typedefs
            if (t == "GPUAddress") return "nuint";

            string prefix = GetPrefix(defaultNs);
            string csName = prefix + t;

            if (StructTypes.Contains(csName)) return csName;
            if (_enumBackingTypes.ContainsKey(csName)) return csName;
            return csName;
        }

        return "nint";
    }

    bool IsNullableType(string csType)
    {
        if (csType is "void" or "bool" or "nint" or "nuint" or "uint" or "int" or "ulong" or "long" or "float" or "double"
            or "byte" or "sbyte" or "short" or "ushort")
            return false;
        if (StructTypes.Contains(csType)) return false;
        if (_enumBackingTypes.ContainsKey(csType)) return false;
        return true;
    }

    bool IsEnumType(string csType) => _enumBackingTypes.ContainsKey(csType);

    string GetMsgSendMethod(string csType) => csType switch
    {
        "nint" => "MsgSendPtr",
        "nuint" => "MsgSendNUInt",
        "uint" => "MsgSendUInt",
        "int" => "MsgSendPtr",
        "ulong" => "MsgSendULong",
        "long" => "MsgSendPtr",
        "float" => "MsgSendFloat",
        "double" => "MsgSendDouble",
        _ => "MsgSendPtr"
    };

    string GetMsgSendForEnumGet(string csEnumType)
    {
        if (_enumBackingTypes.TryGetValue(csEnumType, out string? backing))
        {
            return backing switch
            {
                "int" => "ObjectiveCRuntime.MsgSendInt",
                "uint" => "ObjectiveCRuntime.MsgSendUInt",
                "long" => "ObjectiveCRuntime.MsgSendPtr",
                "ulong" => "ObjectiveCRuntime.MsgSendNUInt",
                _ => "ObjectiveCRuntime.MsgSendNUInt"
            };
        }
        return "ObjectiveCRuntime.MsgSendNUInt";
    }

    string GetEnumSetCast(string csEnumType)
    {
        if (_enumBackingTypes.TryGetValue(csEnumType, out string? backing))
        {
            return backing switch
            {
                "int" => "(int)",
                "uint" => "(uint)",
                "long" => "(nint)",
                "ulong" => "(nuint)",
                _ => "(nuint)"
            };
        }
        return "(nuint)";
    }

    static string GetMsgSendForStruct(string csType) => csType switch
    {
        "MTLSize" => "MsgSendMTLSize",
        "MTLSizeAndAlign" => "MsgSendMTLSizeAndAlign",
        "MTLResourceID" => "MsgSendMTLResourceID",
        "MTLClearColor" => "MsgSendMTLClearColor",
        "MTLAccelerationStructureSizes" => "MsgSendMTLAccelerationStructureSizes",
        "MTLTextureSwizzleChannels" => "MsgSendMTLTextureSwizzleChannels",
        "MTLSamplePosition" => "MsgSendMTLSamplePosition",
        "MTL4BufferRange" => "MsgSendMTL4BufferRange",
        "NSRange" => "MsgSendNSRange",
        "CGSize" => "MsgSendCGSize",
        _ => "MsgSendPtr"
    };

    // =========================================================================
    // Naming helpers
    // =========================================================================

    static string ToPascalCase(string name)
    {
        if (string.IsNullOrEmpty(name)) return name;
        if (name.Length == 1) return char.ToUpper(name[0]).ToString();
        return char.ToUpper(name[0]) + name[1..];
    }

    static string ToCamelCase(string name)
    {
        if (string.IsNullOrEmpty(name)) return name;
        // Apply known typo corrections
        if (ParamNameCorrections.TryGetValue(name, out string? corrected))
            name = corrected;
        if (name.Length == 1) return char.ToLower(name[0]).ToString();
        return char.ToLower(name[0]) + name[1..];
    }

    static string EscapeReservedWord(string name) =>
        CSharpReservedWords.Contains(name) ? "@" + name : name;
}