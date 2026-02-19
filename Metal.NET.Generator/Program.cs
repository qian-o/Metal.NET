using System.Text;
using System.Text.RegularExpressions;

// --- Entry point ---
if (args.Length < 2)
{
    Console.Error.WriteLine("Usage: dotnet run -- <metal-cpp-dir> <output-dir>");
    return 1;
}

string metalCppDir = Path.GetFullPath(args[0]);
string outputDir = Path.GetFullPath(args[1]);

if (!Directory.Exists(metalCppDir))
{
    Console.Error.WriteLine($"metal-cpp directory not found: {metalCppDir}");
    return 1;
}

var generator = new Generator(metalCppDir, outputDir);
generator.Run();
return 0;

// =============================================================================
// Data models
// =============================================================================

record EnumDef(string CppNamespace, string Name, string BackingType, bool IsFlags, List<EnumMember> Members);
record EnumMember(string Name, string Value);

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

    // Hand-written classes to skip
    static readonly HashSet<string> SkipClasses = ["NSString", "NSError", "NSArray", "NSURL",
        "NSDictionary", "NSNotification", "NSNotificationCenter", "NSSet", "NSEnumerator",
        "NSObject", "NSProcessInfo", "NSBundle", "NSAutoreleasePool", "NSNumber", "NSValue",
        "NSDate"];

    // Methods to skip
    static readonly HashSet<string> SkipMethods = ["alloc", "init", "retain", "release", "autorelease", "copy", "retainCount"];

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

        Console.WriteLine($"Found {_enums.Count} enums, {_classes.Count} classes");

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

            var members = ParseEnumMembers(body, prefix);
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

    static List<EnumMember> ParseEnumMembers(string body, string prefix)
    {
        var members = new List<EnumMember>();
        int nextImplicitValue = 0;

        foreach (var rawLine in body.Split('\n'))
        {
            var line = rawLine.Trim().TrimEnd(',');
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Parse: MemberName = value  OR  MemberName (implicit value)
            var memberMatch = Regex.Match(line, @"^(\w+)\s*(?:=\s*(.+))?$");
            if (!memberMatch.Success) continue;

            string memberName = memberMatch.Groups[1].Value;
            string csValue;

            if (memberMatch.Groups[2].Success)
            {
                string value = memberMatch.Groups[2].Value.Trim();
                csValue = EvaluateEnumValue(value, prefix, members);
                // Update implicit counter
                if (long.TryParse(csValue, out long parsed))
                    nextImplicitValue = (int)(parsed + 1);
            }
            else
            {
                csValue = nextImplicitValue.ToString();
                nextImplicitValue++;
            }

            members.Add(new EnumMember(prefix + memberName, csValue));
        }

        return members;
    }

    static string EvaluateEnumValue(string value, string prefix, List<EnumMember> existingMembers)
    {
        try
        {
            string resolved = value;

            foreach (var existing in existingMembers)
            {
                string shortName = existing.Name[prefix.Length..];
                if (resolved.Contains(shortName))
                    resolved = resolved.Replace(shortName, existing.Value);
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
        foreach (var classDef in _classes)
            GenerateClass(classDef);
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

    void GenerateClass(ClassDef classDef)
    {
        string prefix = GetPrefix(classDef.CppNamespace);
        string csClassName = prefix + classDef.Name;

        if (SkipClasses.Contains(csClassName)) return;

        string subdir = GetOutputSubdir(classDef.CppNamespace);
        string dir = Path.Combine(_outputDir, subdir);
        Directory.CreateDirectory(dir);

        bool hasClassField = _registeredClasses.Contains(csClassName);

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
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        // Value type struct with primary constructor
        sb.AppendLine($"public readonly struct {csClassName}(nint nativePtr)");
        sb.AppendLine("{");
        sb.AppendLine("    public readonly nint NativePtr = nativePtr;");

        // For creatable objects, add parameterless constructor
        if (hasClassField)
        {
            sb.AppendLine();
            sb.AppendLine($"    public {csClassName}() : this(ObjectiveCRuntime.AllocInit({csClassName}Bindings.Class))");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
        }

        // Properties (sorted alphabetically)
        foreach (var prop in properties)
        {
            sb.AppendLine();
            EmitProperty(sb, prop, csClassName, classDef.CppNamespace, selectors);
        }

        // Methods
        foreach (var method in methods)
        {
            sb.AppendLine();
            EmitMethod(sb, method, csClassName, classDef.CppNamespace, selectors, hasClassField, hasZeroParamVersion);
        }

        sb.AppendLine("}");
        sb.AppendLine();

        // Bindings class (renamed from Selector)
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
            sb.AppendLine($"    public static readonly Selector {name} = Selector.Register(\"{objc}\");");
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
        // Timestamp types that are special
        if (t.Contains("Timestamp")) return true;
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
            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3]) &&
                m.ReturnType == "void" && m.Parameters.Count == 1)
                continue; // skip orphan setters
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
        string ns, SortedDictionary<string, string> selectors)
    {
        var getter = prop.Getter;
        string csPropName = ToPascalCase(getter.CppName);
        string csType = MapCppType(getter.ReturnType, ns);
        bool nullable = IsNullableType(csType);
        bool isEnum = IsEnumType(csType);
        bool isStruct = StructTypes.Contains(csType);
        bool isBool = csType == "bool";

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

        if (nullable)
        {
            // Value type nullable: return new T?(new T(ptr)) if ptr != 0, else null
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine("        get");
            sb.AppendLine("        {");
            sb.AppendLine($"            nint ptr = ObjectiveCRuntime.MsgSendPtr({target}, {selectorRef});");
            sb.AppendLine($"            return ptr is not 0 ? new {csType}(ptr) : default;");
            sb.AppendLine("        }");

            if (prop.Setter != null)
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value?.NativePtr ?? 0);");
            sb.AppendLine("    }");
        }
        else if (isEnum)
        {
            string msgSend = GetMsgSendForEnumGet(csType);

            sb.AppendLine($"    public {typeStr} {csPropName}");
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
            sb.AppendLine($"    public bool {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.MsgSendBool({target}, {selectorRef});");

            if (prop.Setter != null)
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, (Bool8)value);");
            sb.AppendLine("    }");
        }
        else if (isStruct)
        {
            string msgSend = GetMsgSendForStruct(csType);

            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.{msgSend}({target}, {selectorRef});");

            if (prop.Setter != null)
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            sb.AppendLine("    }");
        }
        else
        {
            string msgSend = GetMsgSendMethod(csType);

            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.{msgSend}({target}, {selectorRef});");

            if (prop.Setter != null)
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
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
                sb.AppendLine("        error = errorPtr is not 0 ? new NSError(errorPtr) : default;");
        }
        else if (nullable)
        {
            if (hasOutError)
            {
                sb.AppendLine($"        nint ptr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new NSError(errorPtr) : default;");
                sb.AppendLine($"        return ptr is not 0 ? new {returnType}(ptr) : default;");
            }
            else
            {
                sb.AppendLine($"        nint ptr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                sb.AppendLine($"        return ptr is not 0 ? new {returnType}(ptr) : default;");
            }
        }
        else if (isEnum)
        {
            string msgSend = GetMsgSendForEnumGet(returnType);
            if (hasOutError)
            {
                sb.AppendLine($"        var result = ({returnType}){msgSend}({argsStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new NSError(errorPtr) : default;");
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
                sb.AppendLine("        error = errorPtr is not 0 ? new NSError(errorPtr) : default;");
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
                sb.AppendLine("        error = errorPtr is not 0 ? new NSError(errorPtr) : default;");
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
            if (hasOutError)
            {
                sb.AppendLine($"        var result = ObjectiveCRuntime.{msgSend}({argsStr});");
                sb.AppendLine("        error = errorPtr is not 0 ? new NSError(errorPtr) : default;");
                sb.AppendLine("        return result;");
            }
            else
            {
                sb.AppendLine($"        return ObjectiveCRuntime.{msgSend}({argsStr});");
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
            "uint64_t" or "std::uint64_t" => "nuint",
            "int64_t" or "std::int64_t" => "nint",
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
        if (csType is "void" or "bool" or "nint" or "nuint" or "uint" or "ulong" or "long" or "int" or "float" or "double"
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
        "ulong" => "MsgSendNUInt",
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
                "ulong" => "ObjectiveCRuntime.MsgSendNUInt",
                "long" => "ObjectiveCRuntime.MsgSendPtr",
                "uint" => "ObjectiveCRuntime.MsgSendUInt",
                "int" => "ObjectiveCRuntime.MsgSendPtr",
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
                "ulong" => "(nuint)",
                "long" => "(nint)",
                "uint" => "(uint)",
                "int" => "(int)",
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
        if (name.Length == 1) return char.ToLower(name[0]).ToString();
        return char.ToLower(name[0]) + name[1..];
    }

    static string EscapeReservedWord(string name) =>
        CSharpReservedWords.Contains(name) ? "@" + name : name;
}