using CppAst;

namespace Metal.NET.Generator;

/// <summary>
/// Parses metal-cpp C++ headers using CppAst (libclang) to produce binding definitions.
/// Replaces the old regex-based HeaderClassParser, HeaderEnumParser, and HeaderTypeMapper.
/// </summary>
public static class CppAstParser
{
    /// <summary>C++ system include directories for the current platform.</summary>
    private static readonly string[] s_systemIncludes =
    [
        "/usr/include/c++/14",
        "/usr/include/x86_64-linux-gnu/c++/14",
        "/usr/lib/gcc/x86_64-linux-gnu/14/include",
        "/usr/include",
        "/usr/include/x86_64-linux-gnu",
    ];

    // ── Namespaces we care about ──
    private static readonly HashSet<string> s_bindableNamespaces = ["MTL", "MTL4", "MTLFX", "CA"];
    private static readonly HashSet<string> s_nsNamespace = ["NS"];

    // ── Foundation types with hand-written implementations ──
    private static readonly HashSet<string> s_handWrittenTypes = ["NSString", "NSError", "NSArray"];

    // ── Foundation classes we generate bindings for ──
    private static readonly HashSet<string> s_generatableNsClasses = ["NSURL"];

    // ── Value struct types (passed by value, not by NativePtr) ──
    private static readonly HashSet<string> s_valueStructs =
    [
        "MTLOrigin", "MTLSize", "MTLRegion", "MTLViewport",
        "MTLScissorRect", "MTLClearColor", "MTLSamplePosition", "CGSize",
        "MTLSizeAndAlign", "MTLRange", "MTLResourceID",
        "MTLVertexAmplificationViewMapping",
        "MTL4Origin", "MTL4Size", "MTL4Range", "MTL4BufferRange",
        "MTL4CopySparseBufferMappingOperation", "MTL4CopySparseTextureMappingOperation",
        "MTL4UpdateSparseBufferMappingOperation", "MTL4UpdateSparseTextureMappingOperation",
        "NSRange",
    ];

    // ── Types that are always ObjC wrappers even though names look like enums ──
    private static readonly HashSet<string> s_knownWrapperTypes =
    [
        "MTLFunction", "MTLCompileOptions", "MTLComputePipelineState",
        "MTLRenderPipelineState", "MTLDepthStencilState", "MTLSamplerState",
        "MTLFence", "MTLRenderPassDescriptor", "MTLVertexDescriptor",
        "MTLRenderPipelineColorAttachmentDescriptor",
        "MTLRenderPipelineColorAttachmentDescriptorArray",
        "MTLRenderPassColorAttachmentDescriptor",
        "MTLRenderPassColorAttachmentDescriptorArray",
        "MTLRenderPassDepthAttachmentDescriptor",
        "MTLRenderPassStencilAttachmentDescriptor",
        "MTLVertexBufferLayoutDescriptor",
        "MTLVertexBufferLayoutDescriptorArray",
        "MTLVertexAttributeDescriptor",
        "MTLVertexAttributeDescriptorArray",
        "MTLStencilDescriptor",
        "MTL4PipelineState", "MTL4CommandBufferOptions", "MTL4CompilerTaskOptions",
        "MTL4CommitOptions",
        "MTLLogState", "MTLLogContainer",
        "MTLLinkedFunctions",
        "MTLArrayType", "MTLStructType", "MTLPointerType", "MTLType",
        "MTLTextureReferenceType", "MTLTensorReferenceType",
        "MTLCaptureScope", "MTLCounterSet", "MTLResidencySet",
        "MTLComputePipelineReflection", "MTLRenderPipelineReflection",
        "MTLFunctionReflection",
        "MTL4BinaryFunction", "MTL4MachineLearningPipelineState",
        "MTL4MachineLearningPipelineReflection", "MTL4PipelineOptions",
        "MTLFunctionLogDebugLocation",
    ];

    /// <summary>
    /// Concrete ObjC classes that can be alloc/init'd (not protocols).
    /// Names without prefix — matched against CppAst class names.
    /// </summary>
    private static readonly HashSet<string> s_concreteClasses =
    [
        "TextureDescriptor", "SamplerDescriptor", "RenderPassDescriptor",
        "RenderPipelineDescriptor", "DepthStencilDescriptor", "StencilDescriptor",
        "VertexDescriptor", "CompileOptions", "RenderPassColorAttachmentDescriptor",
        "RenderPassDepthAttachmentDescriptor", "RenderPassStencilAttachmentDescriptor",
        "RenderPipelineColorAttachmentDescriptor", "VertexBufferLayoutDescriptor",
        "VertexAttributeDescriptor", "TileRenderPipelineDescriptor",
        "TileRenderPipelineColorAttachmentDescriptor",
        "RasterizationRateMapDescriptor", "RasterizationRateLayerDescriptor",
        "StageInputOutputDescriptor", "AttributeDescriptor", "BufferLayoutDescriptor",
        "IndirectCommandBufferDescriptor", "LinkedFunctions",
        "ComputePassDescriptor", "BlitPassDescriptor", "AccelerationStructureDescriptor",
        "PrimitiveAccelerationStructureDescriptor", "InstanceAccelerationStructureDescriptor",
        "HeapDescriptor", "SharedEventHandle", "CaptureDescriptor",
        "BinaryArchiveDescriptor", "StitchedLibraryDescriptor",
        "FunctionStitchingGraph", "FunctionStitchingInputNode",
        "FunctionStitchingFunctionNode",
        "ResidencySetDescriptor", "IOCommandQueueDescriptor",
        "TextureViewDescriptor", "TextureViewPool",
        "MetalLayer", // CA::MetalLayer
    ];

    // ── C# keywords that must be escaped ──
    private static readonly HashSet<string> s_csharpKeywords =
    [
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
        "char", "checked", "class", "const", "continue", "decimal", "default",
        "delegate", "do", "double", "else", "enum", "event", "explicit",
        "extern", "false", "finally", "fixed", "float", "for", "foreach",
        "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
        "lock", "long", "namespace", "new", "null", "object", "operator",
        "out", "override", "params", "private", "protected", "public",
        "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof",
        "stackalloc", "static", "string", "struct", "switch", "this", "throw",
        "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe",
        "ushort", "using", "virtual", "void", "volatile", "while",
    ];

    /// <summary>
    /// Parse all metal-cpp headers from the given directory and produce
    /// enums, classes, and free function definitions.
    /// </summary>
    public static ParseResult Parse(string metalCppDir, string stubsDir)
    {
        var result = new ParseResult();

        // Find system C++ include dirs
        var systemIncludes = new List<string>();
        foreach (var dir in s_systemIncludes)
        {
            if (Directory.Exists(dir))
                systemIncludes.Add(dir);
        }

        // If the default paths don't exist, try to discover them
        if (systemIncludes.Count == 0)
        {
            // Try common GCC versions
            foreach (var ver in new[] { "14", "13", "12", "11" })
            {
                var dir = $"/usr/include/c++/{ver}";
                if (Directory.Exists(dir))
                {
                    systemIncludes.Add(dir);
                    var archDir = $"/usr/include/x86_64-linux-gnu/c++/{ver}";
                    if (Directory.Exists(archDir)) systemIncludes.Add(archDir);
                    var gccDir = $"/usr/lib/gcc/x86_64-linux-gnu/{ver}/include";
                    if (Directory.Exists(gccDir)) systemIncludes.Add(gccDir);
                    break;
                }
            }
            if (Directory.Exists("/usr/include")) systemIncludes.Add("/usr/include");
            var xDir = "/usr/include/x86_64-linux-gnu";
            if (Directory.Exists(xDir)) systemIncludes.Add(xDir);
        }

        // Parse via umbrella headers which set up the full include chain.
        // This ensures all types are properly resolved across namespaces.
        var umbrellaHeaders = new List<string>();

        var metalHpp = Path.Combine(metalCppDir, "Metal", "Metal.hpp");
        if (File.Exists(metalHpp)) umbrellaHeaders.Add(metalHpp);

        var foundationHpp = Path.Combine(metalCppDir, "Foundation", "Foundation.hpp");
        if (File.Exists(foundationHpp)) umbrellaHeaders.Add(foundationHpp);

        var quartzHpp = Path.Combine(metalCppDir, "QuartzCore", "QuartzCore.hpp");
        if (File.Exists(quartzHpp)) umbrellaHeaders.Add(quartzHpp);

        // Also look for MTLFX headers
        var mtlfxDir = Path.Combine(metalCppDir, "MetalFX");
        if (Directory.Exists(mtlfxDir))
        {
            var mtlfxHpp = Path.Combine(mtlfxDir, "MetalFX.hpp");
            if (File.Exists(mtlfxHpp))
                umbrellaHeaders.Add(mtlfxHpp);
            else
            {
                foreach (var f in Directory.GetFiles(mtlfxDir, "*.hpp"))
                    umbrellaHeaders.Add(f);
            }
        }

        foreach (var hppPath in umbrellaHeaders)
        {
            var options = new CppParserOptions();
            options.ParseSystemIncludes = false;
            options.ParseMacros = true;
            options.IncludeFolders.Add(metalCppDir);
            options.IncludeFolders.Add(stubsDir);
            foreach (var inc in systemIncludes)
                options.SystemIncludeFolders.Add(inc);
            options.AdditionalArguments.Add("-xc++");
            options.AdditionalArguments.Add("-std=c++17");
            options.AdditionalArguments.Add("-fblocks");
            options.AdditionalArguments.Add("-Wno-everything");

            var compilation = CppParser.ParseFile(hppPath, options);

            if (compilation.HasErrors)
            {
                foreach (var msg in compilation.Diagnostics.Messages)
                {
                    if (msg.Type == CppLogMessageType.Error)
                        Console.Error.WriteLine($"  CppAst error in {Path.GetFileName(hppPath)}: {msg}");
                }
                continue;
            }

            // Walk all namespaces in this compilation
            foreach (var ns in compilation.Namespaces)
            {
                WalkNamespace(ns, result, hppPath);
            }
        }

        // Deduplicate
        result.Deduplicate();

        return result;
    }

    private static string NamespaceToFolder(string ns) => ns switch
    {
        "MTL" or "MTL4" => "Metal",
        "CA" => "QuartzCore",
        "NS" => "Foundation",
        "MTLFX" => "MetalFX",
        _ => "Metal",
    };

    private static void WalkNamespace(CppNamespace ns, ParseResult result, string sourceFile)
    {
        string nsName = ns.Name;

        if (s_bindableNamespaces.Contains(nsName))
        {
            // Parse enums
            foreach (var cppEnum in ns.Enums)
            {
                var enumDef = ConvertEnum(cppEnum, nsName);
                if (enumDef != null)
                {
                    enumDef.Folder = NamespaceToFolder(nsName);
                    result.Enums.Add(enumDef);
                }
            }

            // Parse classes/protocols
            foreach (var cppClass in ns.Classes)
            {
                if (cppClass.ClassKind == CppClassKind.Struct && cppClass.Functions.Count <= 1
                    && cppClass.Fields.Count > 0 && cppClass.BaseTypes.Count == 0)
                {
                    // Skip plain structs (SamplePosition, etc. are handled manually in MTLStructs.cs)
                    continue;
                }

                // Skip types that are value structs (defined in MTLStructs.cs)
                string checkName = $"{(nsName switch { "MTL" => "MTL", "MTL4" => "MTL4", "MTLFX" => "MTLFX", "CA" => "CA", _ => nsName })}{cppClass.Name}";
                if (s_valueStructs.Contains(checkName))
                    continue;

                var classDef = ConvertClass(cppClass, nsName);
                if (classDef != null)
                {
                    classDef.Folder = NamespaceToFolder(nsName);
                    result.Classes.Add(classDef);
                }
            }

            // Parse free functions
            foreach (var cppFunc in ns.Functions)
            {
                var freeDef = ConvertFreeFunction(cppFunc, nsName);
                if (freeDef != null)
                    result.FreeFunctions.Add(freeDef);
            }
        }
        else if (s_nsNamespace.Contains(nsName))
        {
            // Foundation namespace - only generate whitelisted classes
            foreach (var cppEnum in ns.Enums)
            {
                // Skip NS enums - they're Foundation internal
            }
            foreach (var cppClass in ns.Classes)
            {
                string fullName = $"NS{cppClass.Name}";
                if (!s_generatableNsClasses.Contains(fullName))
                    continue;
                if (s_handWrittenTypes.Contains(fullName))
                    continue;

                var classDef = ConvertClass(cppClass, nsName);
                if (classDef != null)
                {
                    classDef.Folder = NamespaceToFolder(nsName);
                    result.Classes.Add(classDef);
                }
            }
        }

        // Recurse into nested namespaces (skip Private)
        foreach (var child in ns.Namespaces)
        {
            if (child.Name == "Private") continue;
            WalkNamespace(child, result, sourceFile);
        }
    }

    // ═══════════════════════════════════════════════════════
    // Enum conversion
    // ═══════════════════════════════════════════════════════

    private static EnumDef? ConvertEnum(CppEnum cppEnum, string ns)
    {
        string prefix = ns switch
        {
            "MTL" => "MTL",
            "MTL4" => "MTL4",
            "MTLFX" => "MTLFX",
            "CA" => "CA",
            "NS" => "NS",
            _ => ns
        };

        string enumName;
        string underlyingType;

        if (!string.IsNullOrEmpty(cppEnum.Name))
        {
            // Named enum (from _MTL_ENUM)
            enumName = cppEnum.Name;
            underlyingType = MapEnumUnderlyingType(cppEnum.IntegerType);
        }
        else
        {
            // Anonymous enum (from _MTL_OPTIONS) — the typedef name is in IntegerType
            var intTypeName = cppEnum.IntegerType?.GetDisplayName();
            if (string.IsNullOrEmpty(intTypeName)) return null;

            enumName = intTypeName;
            underlyingType = "uint"; // _MTL_OPTIONS always uses NS::UInteger -> uint
        }

        string fullName = $"{prefix}{enumName}";
        bool isFlags = string.IsNullOrEmpty(cppEnum.Name); // Anonymous enums from _MTL_OPTIONS are always flags

        var enumDef = new EnumDef
        {
            Name = fullName,
            UnderlyingType = underlyingType,
            IsFlags = isFlags,
        };

        // Determine the prefix to strip from member names
        string memberPrefix = enumName;

        var seen = new HashSet<string>();
        foreach (var item in cppEnum.Items)
        {
            string memberName = item.Name;

            // Strip the enum type prefix from member names
            // e.g., PixelFormatRGBA8Unorm -> RGBA8Unorm
            if (memberName.StartsWith(memberPrefix))
                memberName = memberName.Substring(memberPrefix.Length);

            // Handle digit-prefixed names (e.g., "1_0" -> "_1_0")
            if (memberName.Length > 0 && char.IsDigit(memberName[0]))
                memberName = $"_{memberName}";

            if (string.IsNullOrEmpty(memberName))
                memberName = item.Name;

            if (!seen.Add(memberName))
                continue; // skip duplicates

            string value = item.Value.ToString();

            // Handle negative values for unsigned underlying types
            if (item.Value < 0 && (underlyingType == "uint" || underlyingType == "ushort" || underlyingType == "byte"))
            {
                // Convert to unsigned representation
                if (underlyingType == "uint")
                    value = unchecked((uint)item.Value).ToString();
                else if (underlyingType == "ushort")
                    value = unchecked((ushort)item.Value).ToString();
                else
                    value = unchecked((byte)item.Value).ToString();
            }

            enumDef.Members.Add(new EnumMemberDef
            {
                Name = memberName,
                Value = value,
            });
        }

        return enumDef.Members.Count > 0 ? enumDef : null;
    }

    private static string MapEnumUnderlyingType(CppType? type)
    {
        if (type == null) return "uint";

        var displayName = type.GetDisplayName();
        return displayName switch
        {
            "UInteger" or "NS::UInteger" or "unsigned long" or "unsigned long long" => "uint",
            "Integer" or "NS::Integer" or "long" or "long long" => "int",
            "unsigned int" or "uint32_t" => "uint",
            "int" or "int32_t" => "int",
            "unsigned short" or "uint16_t" => "ushort",
            "short" or "int16_t" => "short",
            "unsigned char" or "uint8_t" => "byte",
            "char" or "int8_t" => "sbyte",
            _ => "uint",
        };
    }

    // ═══════════════════════════════════════════════════════
    // Class / protocol conversion
    // ═══════════════════════════════════════════════════════

    private static ObjCClassDef? ConvertClass(CppClass cppClass, string ns)
    {
        if (string.IsNullOrEmpty(cppClass.Name)) return null;

        // Skip Private classes and template instantiations
        if (cppClass.Name == "Private" || cppClass.Name.Contains('<'))
            return null;

        // Skip internal helper classes
        if (cppClass.Name.StartsWith("_"))
            return null;

        string prefix = ns switch
        {
            "MTL" => "MTL",
            "MTL4" => "MTL4",
            "MTLFX" => "MTLFX",
            "CA" => "CA",
            "NS" => "NS",
            _ => ns
        };

        string fullName = $"{prefix}{cppClass.Name}";

        // Skip if this is a known hand-written type
        if (s_handWrittenTypes.Contains(fullName))
            return null;

        // Determine if this is a concrete ObjC class (can be alloc/init'd)
        bool isClass = s_concreteClasses.Contains(cppClass.Name);
        string? objCClass = isClass ? fullName : null;

        var def = new ObjCClassDef
        {
            Name = fullName,
            IsClass = isClass,
            ObjCClass = objCClass,
        };

        // Track method signatures for deduplication
        var methodSigs = new HashSet<string>();
        // potentialPropertyNames: collision detection to prevent methods from shadowing properties
        var potentialPropertyNames = new HashSet<string>();
        // addedPropertyNames: track which properties have actually been added to def.Properties
        var addedPropertyNames = new HashSet<string>();

        // Pre-pass: identify all potential property names (0-arg, non-void, non-static, non-new methods)
        foreach (var fn in cppClass.Functions)
        {
            if (fn.Visibility != CppVisibility.Public) continue;
            if (fn.StorageQualifier == CppStorageQualifier.Static) continue;
            if (fn.Parameters.Count != 0) continue;
            if (fn.Name.StartsWith("new") || fn.Name == "init" || fn.Name == "alloc") continue;
            if (fn.Name == cppClass.Name || fn.Name.StartsWith("~") || fn.Name.StartsWith("operator")) continue;

            var retType = MapType(fn.ReturnType, ns, prefix);
            if (retType == null || retType == "void") continue;

            string pcName = char.ToUpperInvariant(fn.Name[0]) + fn.Name.Substring(1);
            potentialPropertyNames.Add(pcName);
        }

        foreach (var fn in cppClass.Functions)
        {
            // Skip constructors, destructors, operators
            if (fn.Name == cppClass.Name || fn.Name.StartsWith("~") || fn.Name.StartsWith("operator"))
                continue;

            // Skip private/protected methods
            if (fn.Visibility != CppVisibility.Public)
                continue;

            // Skip init/alloc methods (we generate our own for concrete classes)
            if (fn.Name == "init" || fn.Name == "alloc")
                continue;

            bool isStatic = fn.StorageQualifier == CppStorageQualifier.Static;

            // Try to convert this method
            var methodDef = ConvertMethod(fn, ns, prefix);
            if (methodDef == null) continue;

            // Build dedup key — use PascalCase name for C# uniqueness
            var pcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name.Substring(1);
            var sig = $"{(isStatic ? "s:" : "")}{pcName}({string.Join(",", methodDef.Parameters.Select(p => p.Type))})";
            if (!methodSigs.Add(sig)) continue;

            // Check if this looks like a property (no params, not void return)
            bool isProperty = fn.Parameters.Count == 0
                && methodDef.ReturnType != "void"
                && !fn.Name.StartsWith("new")
                && !isStatic;

            // Check for corresponding setter
            bool hasSetter = false;
            string setterName = $"set{Capitalize(fn.Name)}";
            if (isProperty)
            {
                hasSetter = cppClass.Functions.Any(f =>
                    f.Name == setterName && f.Parameters.Count == 1 && f.Visibility == CppVisibility.Public);
            }

            if (isProperty && !isStatic)
            {
                // Don't add if we already have a property with this name
                string propPcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name.Substring(1);
                if (addedPropertyNames.Add(propPcName))
                {
                    def.Properties.Add(new PropertyDef
                    {
                        Name = fn.Name, // original camelCase name
                        Type = methodDef.ReturnType,
                        Readonly = !hasSetter,
                        GetSelector = fn.Name,
                        SetSelector = hasSetter ? $"set{Capitalize(fn.Name)}:" : null,
                    });
                }
            }
            else
            {
                // Skip setter methods - they're handled by properties
                if (fn.Name.StartsWith("set") && fn.Name.Length > 3 && char.IsUpper(fn.Name[3])
                    && fn.Parameters.Count == 1)
                {
                    // Check if there's a matching getter (potential property)
                    string propPcName = fn.Name.Substring(3); // already PascalCase after "set"
                    if (potentialPropertyNames.Contains(propPcName))
                        continue;
                }

                // Skip methods whose PascalCase name collides with an existing property
                string methodPcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name.Substring(1);
                if (potentialPropertyNames.Contains(methodPcName))
                    continue;

                if (isStatic)
                    def.StaticMethods.Add(methodDef);
                else
                    def.Methods.Add(methodDef);
            }
        }

        // Generate even if there are no methods — the wrapper struct is still needed
        // for types referenced by other classes
        return def;
    }

    private static MethodDef? ConvertMethod(CppFunction fn, string ns, string prefix)
    {
        // Map return type
        var retType = MapType(fn.ReturnType, ns, prefix);
        if (retType == null) return null; // unsupported type

        // Build selector from function name and parameters
        string selector = BuildSelector(fn);

        var methodDef = new MethodDef
        {
            Name = fn.Name,
            Selector = selector,
            ReturnType = retType,
        };

        // Check for error-out pattern (last param is Error**)
        bool hasErrorOut = false;

        foreach (var param in fn.Parameters)
        {
            // Check for Error** pattern
            if (IsErrorOutParam(param))
            {
                hasErrorOut = true;
                continue; // handled separately
            }

            var paramType = MapType(param.Type, ns, prefix);
            if (paramType == null) return null; // unsupported param type

            string paramName = string.IsNullOrEmpty(param.Name) ? $"param{methodDef.Parameters.Count}" : param.Name;
            if (s_csharpKeywords.Contains(paramName))
                paramName = $"@{paramName}";

            methodDef.Parameters.Add(new ParamDef
            {
                Name = paramName,
                Type = paramType,
            });
        }

        methodDef.HasErrorOut = hasErrorOut;

        return methodDef;
    }

    /// <summary>Build an Objective-C selector string from a C++ method.</summary>
    private static string BuildSelector(CppFunction fn)
    {
        if (fn.Parameters.Count == 0)
            return fn.Name;

        // metal-cpp method names typically encode the selector in the method name
        // e.g., "newBufferWithLength" with params (length, options) -> "newBufferWithLength:options:"
        // We use the function name as the first selector part, then parameter names
        var parts = new List<string> { fn.Name };
        for (int i = 1; i < fn.Parameters.Count; i++)
        {
            var pName = fn.Parameters[i].Name;
            if (string.IsNullOrEmpty(pName))
                pName = $"param{i}";
            parts.Add(pName);
        }
        return string.Join(":", parts) + ":";
    }

    /// <summary>Check if a parameter is an Error** (out NSError pattern).</summary>
    private static bool IsErrorOutParam(CppParameter param)
    {
        // Look for Error** or Error* const* patterns
        var type = param.Type;
        if (type is CppPointerType ptr1 && ptr1.ElementType is CppPointerType ptr2)
        {
            var innerType = UnwrapType(ptr2.ElementType);
            if (innerType is CppClass cls && cls.Name == "Error")
                return true;
        }
        return false;
    }

    // ═══════════════════════════════════════════════════════
    // Free function conversion
    // ═══════════════════════════════════════════════════════

    private static FreeFunctionDef? ConvertFreeFunction(CppFunction fn, string ns)
    {
        string prefix = ns switch
        {
            "MTL" => "MTL",
            "MTL4" => "MTL4",
            "MTLFX" => "MTLFX",
            _ => ns
        };

        // Map return type
        var retType = MapType(fn.ReturnType, ns, prefix);
        if (retType == null) return null;

        // Map target class and method name
        string nativeName = $"{prefix}{fn.Name}";
        string? targetClass = MapFreeFunctionTarget(fn.Name, prefix);
        if (targetClass == null) return null;

        string methodName = fn.Name;

        var def = new FreeFunctionDef
        {
            NativeName = nativeName,
            Name = methodName,
            ReturnType = retType,
            TargetClass = targetClass,
            FrameworkLibrary = "/System/Library/Frameworks/Metal.framework/Metal",
        };

        foreach (var param in fn.Parameters)
        {
            var paramType = MapType(param.Type, ns, prefix);
            if (paramType == null) return null;

            string paramName = string.IsNullOrEmpty(param.Name) ? $"param{def.Parameters.Count}" : param.Name;
            if (s_csharpKeywords.Contains(paramName))
                paramName = $"@{paramName}";

            def.Parameters.Add(new ParamDef
            {
                Name = paramName,
                Type = paramType,
            });
        }

        return def;
    }

    private static string? MapFreeFunctionTarget(string funcName, string prefix)
    {
        // Map free functions to their target classes
        if (funcName.Contains("Device")) return $"{prefix}Device";
        if (funcName.Contains("Counter")) return $"{prefix}Device";

        // If we can't determine the target, skip
        return null;
    }

    // ═══════════════════════════════════════════════════════
    // Type mapping (C++ -> C#)
    // ═══════════════════════════════════════════════════════

    /// <summary>
    /// Map a CppAst type to a C# type string.
    /// Returns null if the type is unsupported (blocks, std::function, etc.).
    /// </summary>
    private static string? MapType(CppType? type, string ns, string prefix)
    {
        if (type == null) return null;

        type = UnwrapType(type);

        // Primitive types
        if (type is CppPrimitiveType prim)
        {
            return prim.Kind switch
            {
                CppPrimitiveKind.Void => "void",
                CppPrimitiveKind.Bool => "Bool8",
                CppPrimitiveKind.Char => "byte",
                CppPrimitiveKind.Short => "short",
                CppPrimitiveKind.Int => "int",
                CppPrimitiveKind.LongLong => "long",
                CppPrimitiveKind.UnsignedChar => "byte",
                CppPrimitiveKind.UnsignedShort => "ushort",
                CppPrimitiveKind.UnsignedInt => "uint",
                CppPrimitiveKind.UnsignedLongLong => "ulong",
                CppPrimitiveKind.Float => "float",
                CppPrimitiveKind.Double => "double",
                CppPrimitiveKind.Long => "nint",
                CppPrimitiveKind.UnsignedLong => "nuint",
                _ => null,
            };
        }

        // Pointer types
        if (type is CppPointerType ptr)
        {
            var elem = UnwrapType(ptr.ElementType);

            // void* -> nint
            if (elem is CppPrimitiveType { Kind: CppPrimitiveKind.Void })
                return "nint";

            // char const* -> nint (C string)
            if (elem is CppPrimitiveType { Kind: CppPrimitiveKind.Char })
                return "nint";

            // ObjC class pointers -> our wrapper struct
            if (elem is CppClass cls)
                return MapClassName(cls.Name, cls, ns, prefix);

            // Enum pointer -> nint
            if (elem is CppEnum)
                return "nint";

            // Function pointer -> nint (opaque)
            if (elem is CppFunctionType)
                return null; // skip methods with function pointer params

            return "nint"; // fallback for other pointers
        }

        // Reference types (treated like pointers)
        if (type is CppReferenceType refType)
        {
            var elem = UnwrapType(refType.ElementType);
            if (elem is CppPrimitiveType { Kind: CppPrimitiveKind.Char })
                return "nint";
            return MapType(new CppPointerType(refType.ElementType), ns, prefix);
        }

        // Class/struct types (by value)
        if (type is CppClass classType)
        {
            return MapClassName(classType.Name, classType, ns, prefix);
        }

        // Enum types
        if (type is CppEnum enumType)
        {
            return MapEnumName(enumType.Name, enumType, ns, prefix);
        }

        // Typedef
        if (type is CppTypedef td)
        {
            var tdName = td.Name;
            if (tdName == "UInteger") return "nuint";
            if (tdName == "Integer") return "nint";
            if (tdName == "CFTimeInterval") return "double";
            if (tdName == "IOSurfaceRef") return "nint";
            if (tdName == "CGColorSpaceRef") return "nint";
            if (tdName == "dispatch_queue_t") return "nint";
            if (tdName == "dispatch_data_t") return "nint";
            if (tdName == "task_id_token_t") return "nint";
            if (tdName == "kern_return_t") return "uint";
            if (tdName == "CGSize") return "CGSize";
            // Recurse into the underlying type
            return MapType(td.ElementType, ns, prefix);
        }

        // Block function types (Objective-C blocks) -> unsupported
        if (type is CppBlockFunctionType)
            return null;

        // std::function -> unsupported
        if (type is CppUnexposedType unexposed)
        {
            var name = unexposed.GetDisplayName();
            if (name.Contains("function") || name.Contains("block") || name.Contains("Block"))
                return null;
            return "nint"; // generic fallback
        }

        // Array types -> unsupported for direct binding
        if (type is CppArrayType)
            return null;

        return null;
    }

    /// <summary>Unwrap const/qualified types to get the underlying type.</summary>
    private static CppType UnwrapType(CppType type)
    {
        while (type is CppQualifiedType qualified)
            type = qualified.ElementType;
        return type;
    }

    /// <summary>Map a C++ class name to a C# type name.</summary>
    private static string? MapClassName(string name, CppClass cls, string ns, string prefix)
    {
        // Foundation types
        if (name == "String") return "NSString";
        if (name == "Error") return "NSError";
        if (name == "Array") return "NSArray";
        if (name == "URL") return "NSURL";
        if (name == "Number") return "nint"; // NSNumber -> opaque
        if (name == "Data") return "nint"; // NSData -> opaque
        if (name == "Dictionary") return "nint"; // NSDictionary -> opaque
        if (name == "Object") return "nint"; // NS::Object -> opaque handle
        if (name == "Bundle") return "nint"; // NSBundle -> opaque handle
        if (name == "Notification") return "nint"; // NSNotification -> opaque
        if (name == "ProcessInfo") return "nint";
        if (name == "Set") return "nint";

        // CGSize in any namespace is still CGSize
        if (name == "CGSize") return "CGSize";

        // Opaque Apple framework types
        if (name == "float4x4") return "nint"; // simd type
        if (name == "Texture") // CA::Texture could be MTLTexture
        {
            string? parentNs = cls.FullParentName;
            if (parentNs == "CA") return "nint"; // CA texture wrapper
        }

        // Determine the correct prefix from the class's actual parent namespace
        string actualPrefix = prefix;
        string? classParentNs = cls.FullParentName;
        if (!string.IsNullOrEmpty(classParentNs))
        {
            actualPrefix = classParentNs switch
            {
                "MTL" => "MTL",
                "MTL4" => "MTL4",
                "MTLFX" => "MTLFX",
                "CA" => "CA",
                "NS" => "NS",
                _ => prefix,
            };
        }

        string fullName = $"{actualPrefix}{name}";

        // Already has prefix (e.g., from typedef)
        if (name.StartsWith("MTL") || name.StartsWith("CA") || name.StartsWith("NS") || name.StartsWith("MTLFX"))
            fullName = name;

        // Value structs
        if (s_valueStructs.Contains(fullName))
            return fullName;

        // Referencing<T> base class -> skip
        if (name == "Referencing" || name == "Copying" || name == "SecureCoding" || name == "_Base")
            return null;

        // Architecture and similar opaque types
        if (name == "Architecture" || name == "AccelerationStructureSizes")
            return "nint";

        return fullName;
    }

    /// <summary>Map a C++ enum name to a C# enum type name.</summary>
    private static string MapEnumName(string name, CppEnum cppEnum, string ns, string prefix)
    {
        if (name.StartsWith("MTL") || name.StartsWith("CA") || name.StartsWith("NS"))
            return name; // already prefixed

        // Determine actual prefix from enum's parent namespace
        string actualPrefix = prefix;
        string? parentNs = cppEnum.FullParentName;
        if (!string.IsNullOrEmpty(parentNs))
        {
            actualPrefix = parentNs switch
            {
                "MTL" => "MTL",
                "MTL4" => "MTL4",
                "MTLFX" => "MTLFX",
                "CA" => "CA",
                "NS" => "NS",
                _ => prefix,
            };
        }
        return $"{actualPrefix}{name}";
    }

    private static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return char.ToUpperInvariant(s[0]) + s.Substring(1);
    }

    // ═══════════════════════════════════════════════════════
    // Public helper methods used by MetalBindingsGenerator
    // ═══════════════════════════════════════════════════════

    public static bool IsKnownValueStruct(string type) => s_valueStructs.Contains(type);
    public static bool IsObjCWrapper(string type)
    {
        if (s_valueStructs.Contains(type) || IsLikelyEnum(type)) return false;
        return type.StartsWith("MTL") || type.StartsWith("NS") || type.StartsWith("CA");
    }
    public static bool IsLikelyEnum(string type)
    {
        if (s_knownWrapperTypes.Contains(type)) return false;
        if (!type.StartsWith("MTL")) return false;
        return type.Contains("Format")
            || type.EndsWith("Action") || type.EndsWith("Mode") || type.EndsWith("Type")
            || type.EndsWith("Function") || type.EndsWith("Operation") || type.EndsWith("Factor")
            || type.EndsWith("Mask") || type.EndsWith("Options") || type.EndsWith("Filter")
            || type.EndsWith("Usage") || type.EndsWith("Version") || type.EndsWith("Status")
            || type.EndsWith("Set") || type.EndsWith("Winding") || type.EndsWith("Granularity")
            || type.EndsWith("Stages") || type.EndsWith("State") || type.EndsWith("Tier")
            || type.EndsWith("Scope") || type.EndsWith("Access") || type.EndsWith("Level")
            || type.EndsWith("Layout") || type.EndsWith("Destination") || type.EndsWith("Point")
            || type.EndsWith("Basis") || type.EndsWith("Caps") || type.EndsWith("Visibility")
            || type.EndsWith("Family") || type.EndsWith("Priority") || type.EndsWith("Method")
            || type.EndsWith("Mutability") || type.EndsWith("Class") || type.EndsWith("Color")
            || type.EndsWith("Option") || type.EndsWith("Validation") || type.EndsWith("Signature")
            || type.EndsWith("Functions") || type.EndsWith("Configuration") || type.EndsWith("Reflection")
            || type.EndsWith("Location") || type.EndsWith("PageSize");
    }
    public static bool IsCSharpKeyword(string name) => s_csharpKeywords.Contains(name);
}

/// <summary>Result of parsing all metal-cpp headers.</summary>
public class ParseResult
{
    public List<EnumDef> Enums { get; } = new();
    public List<ObjCClassDef> Classes { get; } = new();
    public List<FreeFunctionDef> FreeFunctions { get; } = new();

    public void Deduplicate()
    {
        // Deduplicate enums by name
        var seenEnums = new Dictionary<string, EnumDef>();
        foreach (var e in Enums)
        {
            if (!seenEnums.ContainsKey(e.Name))
                seenEnums[e.Name] = e;
        }
        Enums.Clear();
        Enums.AddRange(seenEnums.Values);

        // Deduplicate classes by name
        var seenClasses = new Dictionary<string, ObjCClassDef>();
        foreach (var c in Classes)
        {
            if (!seenClasses.ContainsKey(c.Name))
                seenClasses[c.Name] = c;
        }
        Classes.Clear();
        Classes.AddRange(seenClasses.Values);

        // Deduplicate free functions by native name
        var seenFuncs = new Dictionary<string, FreeFunctionDef>();
        foreach (var f in FreeFunctions)
        {
            if (!seenFuncs.ContainsKey(f.NativeName))
                seenFuncs[f.NativeName] = f;
        }
        FreeFunctions.Clear();
        FreeFunctions.AddRange(seenFuncs.Values);
    }
}
