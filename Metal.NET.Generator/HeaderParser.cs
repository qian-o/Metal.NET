using System.Runtime.InteropServices;
using System.Text;
using ClangSharp;
using ClangSharp.Interop;

namespace Metal.NET.Generator;

public static class HeaderParser
{
    private static readonly string[] BindableNamespaces = ["MTL", "MTL4", "MTLFX", "MTL4FX", "CA"];
    private const string NsNamespace = "NS";
    private static readonly string[] HandWrittenTypes = ["NSString", "NSError", "NSArray"];
    private static readonly string[] GeneratableNsClasses = ["NSURL"];

    private static readonly HashSet<string> ValueStructs =
    [
        "MTLOrigin", "MTLSize", "MTLRegion", "MTLViewport", "MTLScissorRect",
        "MTLClearColor", "MTLSamplePosition", "CGSize", "MTLSizeAndAlign",
        "MTLRange", "MTLResourceID", "MTLVertexAmplificationViewMapping",
        "MTL4Origin", "MTL4Size", "MTL4Range", "MTL4BufferRange",
        "MTL4CopySparseBufferMappingOperation", "MTL4CopySparseTextureMappingOperation",
        "MTL4UpdateSparseBufferMappingOperation", "MTL4UpdateSparseTextureMappingOperation",
        "NSRange"
    ];

    private static readonly HashSet<string> CSharpKeywords =
    [
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char",
        "checked", "class", "const", "continue", "decimal", "default", "delegate", "do",
        "double", "else", "enum", "event", "explicit", "extern", "false", "finally",
        "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int",
        "interface", "internal", "is", "lock", "long", "namespace", "new", "null",
        "object", "operator", "out", "override", "params", "private", "protected",
        "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof",
        "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true",
        "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using",
        "virtual", "void", "volatile", "while"
    ];

    private static readonly HashSet<string> KnownWrapperTypes =
    [
        "MTLFunction", "MTLCompileOptions", "MTLComputePipelineState",
        "MTLRenderPipelineState", "MTLDepthStencilState", "MTLSamplerState",
        "MTLFence", "MTLRenderPassDescriptor", "MTLVertexDescriptor",
        "MTLBuffer", "MTLTexture", "MTLLibrary", "MTLCommandQueue",
        "MTLCommandBuffer", "MTLRenderCommandEncoder", "MTLComputeCommandEncoder",
        "MTLBlitCommandEncoder", "MTLDevice", "MTLHeap", "MTLEvent",
        "MTLSharedEvent", "MTLSharedEventHandle", "MTLSharedTextureHandle",
        "MTLIOCommandQueue", "MTLIOCommandBuffer", "MTLIOFileHandle",
        "MTLDynamicLibrary", "MTLBinaryArchive", "MTLCaptureManager",
        "MTLCaptureScope", "MTLCounterSampleBuffer", "MTLIndirectCommandBuffer",
        "MTLAccelerationStructure", "MTLVisibleFunctionTable",
        "MTLIntersectionFunctionTable", "MTLFunctionHandle",
        "MTLAccelerationStructureCommandEncoder", "MTLResourceStateCommandEncoder",
        "MTLArgumentEncoder", "MTLParallelRenderCommandEncoder",
        "MTLRasterizationRateMap", "MTLResidencySet", "MTLDrawable",
        "MTLComputePipelineDescriptor", "MTLRenderPipelineDescriptor",
        "MTLTileRenderPipelineDescriptor", "MTLMeshRenderPipelineDescriptor",
        "MTLDepthStencilDescriptor", "MTLSamplerDescriptor", "MTLTextureDescriptor",
        "MTLHeapDescriptor", "MTLCommandQueueDescriptor", "MTLIOCommandQueueDescriptor",
        "MTLBinaryArchiveDescriptor", "MTLStitchedLibraryDescriptor",
        "MTLCounterSampleBufferDescriptor", "MTLIndirectCommandBufferDescriptor",
        "MTLAccelerationStructureDescriptor", "MTLFunctionDescriptor",
        "MTLLinkedFunctions", "MTLRenderPassAttachmentDescriptor",
        "MTLRenderPassColorAttachmentDescriptor", "MTLRenderPassDepthAttachmentDescriptor",
        "MTLRenderPassStencilAttachmentDescriptor", "MTLRenderPassColorAttachmentDescriptorArray",
        "MTLBlitPassDescriptor", "MTLComputePassDescriptor", "MTLResourceStatePassDescriptor",
        "MTLAccelerationStructurePassDescriptor", "MTLVertexBufferLayoutDescriptor",
        "MTLVertexBufferLayoutDescriptorArray", "MTLVertexAttributeDescriptor",
        "MTLVertexAttributeDescriptorArray", "MTLBufferLayoutDescriptor",
        "MTLBufferLayoutDescriptorArray", "MTLAttributeDescriptor",
        "MTLAttributeDescriptorArray", "MTLStageInputOutputDescriptor",
        "MTLPipelineBufferDescriptor", "MTLPipelineBufferDescriptorArray",
        "MTLRenderPipelineColorAttachmentDescriptor",
        "MTLRenderPipelineColorAttachmentDescriptorArray",
        "MTLTileRenderPipelineColorAttachmentDescriptor",
        "MTLTileRenderPipelineColorAttachmentDescriptorArray",
        "MTLArgumentDescriptor", "MTLArchitecture", "MTLFunctionConstantValues",
        "MTLRasterizationRateMapDescriptor", "MTLRasterizationRateLayerDescriptor",
        "MTLRasterizationRateLayerArray", "MTLRasterizationRateSampleArray",
        "MTLResidencySetDescriptor", "MTLLogState", "MTLLogStateDescriptor",
        "MTLTensor", "MTLTensorDescriptor", "MTLTextureViewPool",
        "MTLResourceViewPoolDescriptor",
        "CAMetalDrawable", "CAMetalLayer",
        "MTLFXSpatialScaler", "MTLFXTemporalScaler", "MTLFXTemporalDenoisedScaler",
        "MTLFXFrameInterpolator", "NSURL",
        "MTL4Archive", "MTL4ArgumentTable", "MTL4ArgumentTableDescriptor",
        "MTL4BinaryFunction", "MTL4BinaryFunctionDescriptor",
        "MTL4CommandAllocator", "MTL4CommandAllocatorDescriptor",
        "MTL4CommandBuffer", "MTL4CommandEncoder", "MTL4CommandQueue",
        "MTL4CommandQueueDescriptor", "MTL4Compiler", "MTL4CompilerDescriptor",
        "MTL4CompilerTask", "MTL4ComputeCommandEncoder", "MTL4ComputePipeline",
        "MTL4CounterHeap", "MTL4CounterHeapDescriptor",
        "MTL4FunctionDescriptor", "MTL4LibraryDescriptor",
        "MTL4LibraryFunctionDescriptor", "MTL4LinkingDescriptor",
        "MTL4MachineLearningCommandEncoder", "MTL4MachineLearningPipeline",
        "MTL4MeshRenderPipeline", "MTL4PipelineDataSetSerializer",
        "MTL4PipelineState", "MTL4RenderCommandEncoder",
        "MTL4RenderPass", "MTL4RenderPipeline",
        "MTL4SpecializedFunctionDescriptor", "MTL4StitchedFunctionDescriptor",
        "MTL4TileRenderPipeline"
    ];

    private static readonly Dictionary<string, (string Prefix, string Folder)> NamespaceMap = new()
    {
        ["MTL"] = ("MTL", "Metal"),
        ["MTL4"] = ("MTL4", "Metal"),
        ["CA"] = ("CA", "QuartzCore"),
        ["NS"] = ("NS", "Foundation"),
        ["MTLFX"] = ("MTLFX", "MetalFX"),
        ["MTL4FX"] = ("MTL4FX", "MetalFX"),
    };

    public static bool IsKnownValueStruct(string type) => ValueStructs.Contains(type);

    public static bool IsObjCWrapper(string type) => KnownWrapperTypes.Contains(type);

    public static bool IsLikelyEnum(string type) =>
        !IsObjCWrapper(type) && !IsKnownValueStruct(type) &&
        !type.StartsWith("ns", StringComparison.OrdinalIgnoreCase) &&
        type != "void" && type != "bool" && type != "nint" && type != "nuint" &&
        type != "int" && type != "uint" && type != "float" && type != "double" &&
        type != "byte" && type != "sbyte" && type != "short" && type != "ushort" &&
        type != "long" && type != "ulong";

    public static bool IsCSharpKeyword(string name) => CSharpKeywords.Contains(name);

    public static ParseResult Parse(string metalCppDir)
    {
        var result = new ParseResult();
        string stubDir = Directory.CreateTempSubdirectory("metal_net_stubs_").FullName;

        try
        {
            CreateStubHeaders(stubDir);

            string mainHeader = CreateMainHeader(metalCppDir, stubDir);

            var selectorMap = new Dictionary<string, string>();
            var clsRegistrations = new HashSet<string>();
            var flagsEnums = new HashSet<string>();

            using var index = CXIndex.Create(excludeDeclarationsFromPch: false, displayDiagnostics: false);

            string[] clangArgs = BuildClangArgs(metalCppDir, stubDir);

            CXErrorCode err = CXTranslationUnit.TryParse(
                index,
                mainHeader,
                clangArgs.AsSpan(),
                ReadOnlySpan<CXUnsavedFile>.Empty,
                CXTranslationUnit_Flags.CXTranslationUnit_DetailedPreprocessingRecord |
                CXTranslationUnit_Flags.CXTranslationUnit_KeepGoing |
                CXTranslationUnit_Flags.CXTranslationUnit_RetainExcludedConditionalBlocks,
                out CXTranslationUnit cxtu);

            if (err != CXErrorCode.CXError_Success)
                throw new InvalidOperationException($"ClangSharp failed to parse: {err}");

            using var tu = TranslationUnit.GetOrCreate(cxtu);
            var tuDecl = tu.TranslationUnitDecl;

            // First pass: collect type aliases (for flags detection), selectors, and CLS registrations
            CollectMetadata(tuDecl, selectorMap, clsRegistrations, flagsEnums);

            // Second pass: extract enums, classes, and free functions
            ExtractDeclarations(tuDecl, result, selectorMap, clsRegistrations, flagsEnums);

            result.Deduplicate();
        }
        finally
        {
            if (Directory.Exists(stubDir))
                Directory.Delete(stubDir, recursive: true);
        }

        return result;
    }

    private static string[] BuildClangArgs(string metalCppDir, string stubDir)
    {
        var args = new List<string>
        {
            "-x", "c++",
            "-std=c++17",
            "-DMTL_PRIVATE_IMPLEMENTATION",
            "-DNS_PRIVATE_IMPLEMENTATION",
            "-DCA_PRIVATE_IMPLEMENTATION",
            "-DMTLFX_PRIVATE_IMPLEMENTATION",
            "-I" + metalCppDir,
            "-I" + stubDir,
            "-Wno-everything",
            "-ferror-limit=0",
            "-fsyntax-only",
            "-fno-blocks",
        };

        string? gccInclude = FindGccIncludePath();
        if (gccInclude != null)
        {
            args.Add("-isystem");
            args.Add(gccInclude);
        }

        return args.ToArray();
    }

    private static string? FindGccIncludePath()
    {
        string gccBase = "/usr/lib/gcc";
        if (!Directory.Exists(gccBase))
            return null;

        try
        {
            foreach (string arch in Directory.GetDirectories(gccBase))
            {
                foreach (string ver in Directory.GetDirectories(arch).OrderByDescending(d => d))
                {
                    string include = Path.Combine(ver, "include");
                    if (Directory.Exists(include))
                        return include;
                }
            }
        }
        catch
        {
            // Ignore filesystem errors
        }

        return null;
    }

    private static string CreateMainHeader(string metalCppDir, string stubDir)
    {
        string mainHeader = Path.Combine(stubDir, "_metal_all.hpp");
        var sb = new StringBuilder();

        sb.AppendLine("#pragma once");
        sb.AppendLine("#define MTL_PRIVATE_IMPLEMENTATION");
        sb.AppendLine("#define NS_PRIVATE_IMPLEMENTATION");
        sb.AppendLine("#define CA_PRIVATE_IMPLEMENTATION");
        sb.AppendLine("#define MTLFX_PRIVATE_IMPLEMENTATION");

        string[] subDirs = ["Foundation", "Metal", "QuartzCore", "MetalFX"];
        foreach (string sub in subDirs)
        {
            string dir = Path.Combine(metalCppDir, sub);
            if (!Directory.Exists(dir))
                continue;

            foreach (string file in Directory.GetFiles(dir, "*.hpp").OrderBy(f => f))
            {
                string relative = Path.GetRelativePath(stubDir, file);
                sb.AppendLine($"#include \"{relative}\"");
            }
        }

        File.WriteAllText(mainHeader, sb.ToString());
        return mainHeader;
    }

    private static void CreateStubHeaders(string stubDir)
    {
        CreateFile(stubDir, "objc/runtime.h",
            """
            #pragma once
            #ifndef __SIZE_TYPE__
            #define __SIZE_TYPE__ unsigned long
            #endif
            #ifndef _SIZE_T
            #define _SIZE_T
            typedef __SIZE_TYPE__ size_t;
            #endif
            typedef struct objc_object* id;
            typedef struct objc_selector* SEL;
            typedef id (*IMP)(id, SEL, ...);
            typedef struct objc_class* Class;
            typedef signed char BOOL;
            typedef struct objc_object Protocol;
            #ifdef __cplusplus
            extern "C" {
            #endif
            SEL sel_registerName(const char *str);
            Class objc_lookUpClass(const char *name);
            Protocol *objc_getProtocol(const char *name);
            #ifdef __cplusplus
            }
            #endif
            """);

        CreateFile(stubDir, "objc/message.h",
            """
            #pragma once
            #include "runtime.h"
            #ifdef __cplusplus
            extern "C" {
            #endif
            id objc_msgSend(id self, SEL op, ...);
            #ifdef __cplusplus
            }
            #endif
            """);

        CreateFile(stubDir, "CoreFoundation/CoreFoundation.h",
            """
            #pragma once
            typedef double CFTimeInterval;
            typedef struct __IOSurface *IOSurfaceRef;
            typedef struct CGColorSpace *CGColorSpaceRef;
            """);

        CreateFile(stubDir, "IOSurface/IOSurfaceRef.h",
            """
            #pragma once
            typedef struct __IOSurface *IOSurfaceRef;
            """);

        CreateFile(stubDir, "dispatch/dispatch.h",
            """
            #pragma once
            typedef struct dispatch_queue_s *dispatch_queue_t;
            typedef struct dispatch_data_s *dispatch_data_t;
            """);

        CreateFile(stubDir, "CoreGraphics/CGGeometry.h",
            """
            #pragma once
            struct CGPoint { double x; double y; };
            struct CGSize { double width; double height; };
            struct CGRect { struct CGPoint origin; struct CGSize size; };
            """);

        CreateFile(stubDir, "CoreGraphics/CGColorSpace.h",
            """
            #pragma once
            typedef struct CGColorSpace *CGColorSpaceRef;
            """);

        CreateFile(stubDir, "mach/mach.h",
            """
            #pragma once
            typedef unsigned int task_id_token_t;
            typedef int kern_return_t;
            """);

        CreateFile(stubDir, "simd/simd.h",
            """
            #pragma once
            namespace simd {
                struct float2 { float v[2]; };
                struct float3 { float v[3]; };
                struct float4 { float v[4]; };
                struct float3x3 { float3 columns[3]; };
                struct float4x4 { float4 columns[4]; };
            }
            """);

        CreateFile(stubDir, "TargetConditionals.h",
            """
            #pragma once
            #define TARGET_OS_MAC 1
            """);

        CreateFile(stubDir, "dlfcn.h",
            """
            #pragma once
            #define RTLD_DEFAULT ((void*)0)
            #ifdef __cplusplus
            extern "C" {
            #endif
            void *dlopen(const char *filename, int flags);
            void *dlsym(void *handle, const char *symbol);
            int dlclose(void *handle);
            char *dlerror(void);
            #ifdef __cplusplus
            }
            #endif
            """);
    }

    private static void CreateFile(string baseDir, string relativePath, string content)
    {
        string fullPath = Path.Combine(baseDir, relativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, content);
    }

    // First pass: collect metadata
    private static void CollectMetadata(
        TranslationUnitDecl tuDecl,
        Dictionary<string, string> selectorMap,
        HashSet<string> clsRegistrations,
        HashSet<string> flagsEnums)
    {
        WalkForMetadata(tuDecl.CursorChildren, selectorMap, clsRegistrations, flagsEnums, "");
    }

    private static void WalkForMetadata(
        IReadOnlyList<Cursor> children,
        Dictionary<string, string> selectorMap,
        HashSet<string> clsRegistrations,
        HashSet<string> flagsEnums,
        string currentNamespace)
    {
        foreach (var cursor in children)
        {
            if (cursor is NamespaceDecl ns)
            {
                string nsName = BuildNamespacePath(currentNamespace, ns.Name);

                // Check for Private::Selector or Private::Class namespaces
                if (nsName.EndsWith("::Private::Selector"))
                {
                    CollectSelectors(ns.CursorChildren, selectorMap);
                }
                else if (nsName.EndsWith("::Private::Class"))
                {
                    CollectClsRegistrations(ns.CursorChildren, clsRegistrations);
                }
                else
                {
                    WalkForMetadata(ns.CursorChildren, selectorMap, clsRegistrations, flagsEnums, nsName);
                }
            }
            else if (cursor is TypeAliasDecl typeAlias)
            {
                // _NS_OPTIONS creates a type alias: using Name = type;
                // followed by an anonymous enum. The type alias name is the flags enum name.
                string aliasName = typeAlias.Name;
                if (!string.IsNullOrEmpty(aliasName) && !string.IsNullOrEmpty(currentNamespace))
                {
                    string? prefix = GetPrefixForNamespace(currentNamespace);
                    if (prefix != null)
                    {
                        flagsEnums.Add(prefix + aliasName);
                    }
                }
            }
            else if (cursor is LinkageSpecDecl linkage)
            {
                // Recurse into extern "C" blocks
                WalkForMetadata(linkage.CursorChildren, selectorMap, clsRegistrations, flagsEnums, currentNamespace);
            }
        }
    }

    private static void CollectSelectors(IReadOnlyList<Cursor> children, Dictionary<string, string> selectorMap)
    {
        foreach (var cursor in children)
        {
            if (cursor is VarDecl varDecl)
            {
                string varName = varDecl.Name;
                if (!varName.StartsWith("s_k"))
                    continue;

                string accessor = varName["s_k".Length..];
                string? selectorString = ExtractSelectorFromInit(varDecl);

                if (selectorString != null)
                {
                    selectorMap[accessor] = selectorString;
                }
            }
        }
    }

    private static string? ExtractSelectorFromInit(VarDecl varDecl)
    {
        if (!varDecl.HasInit || varDecl.Init == null)
            return null;

        return FindStringLiteralInExpr(varDecl.Init);
    }

    private static string? FindStringLiteralInExpr(Cursor expr)
    {
        if (expr is StringLiteral sl)
            return sl.String;

        foreach (var child in expr.CursorChildren)
        {
            string? found = FindStringLiteralInExpr(child);
            if (found != null)
                return found;
        }

        return null;
    }

    private static void CollectClsRegistrations(IReadOnlyList<Cursor> children, HashSet<string> clsRegistrations)
    {
        foreach (var cursor in children)
        {
            if (cursor is VarDecl varDecl)
            {
                string varName = varDecl.Name;
                if (varName.StartsWith("s_k"))
                {
                    string clsName = varName["s_k".Length..];
                    clsRegistrations.Add(clsName);
                }
            }
        }
    }

    // Second pass: extract declarations
    private static void ExtractDeclarations(
        TranslationUnitDecl tuDecl,
        ParseResult result,
        Dictionary<string, string> selectorMap,
        HashSet<string> clsRegistrations,
        HashSet<string> flagsEnums)
    {
        WalkForDeclarations(tuDecl.CursorChildren, result, selectorMap, clsRegistrations, flagsEnums, "");
    }

    private static void WalkForDeclarations(
        IReadOnlyList<Cursor> children,
        ParseResult result,
        Dictionary<string, string> selectorMap,
        HashSet<string> clsRegistrations,
        HashSet<string> flagsEnums,
        string currentNamespace)
    {
        foreach (var cursor in children)
        {
            switch (cursor)
            {
                case NamespaceDecl ns:
                {
                    string nsName = BuildNamespacePath(currentNamespace, ns.Name);
                    // Skip Private namespaces for declaration extraction
                    if (ns.Name == "Private")
                        continue;
                    WalkForDeclarations(ns.CursorChildren, result, selectorMap, clsRegistrations, flagsEnums, nsName);
                    break;
                }
                case EnumDecl enumDecl:
                {
                    ExtractEnum(enumDecl, currentNamespace, result, flagsEnums);
                    break;
                }
                case CXXRecordDecl recordDecl when recordDecl is not ClassTemplateSpecializationDecl:
                {
                    ExtractClass(recordDecl, currentNamespace, result, selectorMap, clsRegistrations);
                    break;
                }
                case LinkageSpecDecl linkageSpec:
                {
                    ExtractFreeFunctions(linkageSpec, result);
                    break;
                }
            }
        }
    }

    private static void ExtractEnum(
        EnumDecl enumDecl,
        string currentNamespace,
        ParseResult result,
        HashSet<string> flagsEnums)
    {
        string? prefix = GetPrefixForNamespace(currentNamespace);
        string? folder = GetFolderForNamespace(currentNamespace);
        if (prefix == null || folder == null)
            return;

        string enumName = enumDecl.Name;
        bool isAnonymous = string.IsNullOrEmpty(enumName);

        // Get underlying type string
        string underlyingTypeStr = enumDecl.IntegerType?.AsString ?? "unsigned int";

        string? resolvedEnumName = null;
        bool isFlags = false;

        if (isAnonymous)
        {
            // For _NS_OPTIONS: the enum is anonymous but has a using declaration preceding it
            // The underlying type string contains the alias name (e.g. "ResourceOptions")
            // Check if the underlying type string refers to a type alias
            string desugaredType = enumDecl.IntegerType?.CanonicalType?.AsString ?? underlyingTypeStr;

            // For anonymous enums from _NS_OPTIONS, the type string IS the alias name
            // We need to look through the type alias. The canonical underlying type is the real type.
            // The name in underlyingTypeStr should match a known flags enum.
            resolvedEnumName = underlyingTypeStr;

            // Clean up any namespace qualifiers
            if (resolvedEnumName.Contains("::"))
                resolvedEnumName = resolvedEnumName[(resolvedEnumName.LastIndexOf("::") + 2)..];

            // Remove any leading namespace prefix that matches our known namespaces
            resolvedEnumName = resolvedEnumName.Trim();

            string fullName = prefix + resolvedEnumName;
            if (flagsEnums.Contains(fullName))
            {
                isFlags = true;
                enumName = resolvedEnumName;
                underlyingTypeStr = desugaredType;
            }
            else
            {
                // Unknown anonymous enum, skip
                return;
            }
        }

        string csharpName = prefix + enumName;
        string csharpUnderlyingType = MapUnderlyingType(underlyingTypeStr);

        var def = new EnumDef
        {
            Name = csharpName,
            UnderlyingType = csharpUnderlyingType,
            IsFlags = isFlags,
            Folder = folder
        };

        foreach (var enumerator in enumDecl.Enumerators)
        {
            string memberName = prefix + enumerator.Name;
            string value = enumerator.IsUnsigned
                ? enumerator.UnsignedInitVal.ToString()
                : enumerator.InitVal.ToString();

            def.Members.Add(new EnumMemberDef { Name = memberName, Value = value });
        }

        if (def.Members.Count > 0)
            result.Enums.Add(def);
    }

    private static string MapUnderlyingType(string cppType)
    {
        string cleaned = cppType.Trim();

        // Strip namespace qualifiers
        if (cleaned.Contains("::"))
            cleaned = cleaned[(cleaned.LastIndexOf("::") + 2)..];

        return cleaned switch
        {
            "UInteger" or "unsigned long" or "unsigned long long" or "size_t" => "nuint",
            "Integer" or "long" or "long long" => "nint",
            "unsigned int" or "uint32_t" => "uint",
            "int" or "int32_t" => "int",
            "unsigned short" or "uint16_t" => "ushort",
            "short" or "int16_t" => "short",
            "unsigned char" or "uint8_t" => "byte",
            "char" or "int8_t" or "signed char" => "sbyte",
            _ => "uint"
        };
    }

    private static void ExtractClass(
        CXXRecordDecl recordDecl,
        string currentNamespace,
        ParseResult result,
        Dictionary<string, string> selectorMap,
        HashSet<string> clsRegistrations)
    {
        if (!recordDecl.HasDefinition)
            return;

        string className = recordDecl.Name;
        if (string.IsNullOrEmpty(className))
            return;

        string? prefix = GetPrefixForNamespace(currentNamespace);
        string? folder = GetFolderForNamespace(currentNamespace);
        if (prefix == null || folder == null)
            return;

        // Check namespace eligibility
        string topNs = currentNamespace.Contains("::") ? currentNamespace[..currentNamespace.IndexOf("::")] : currentNamespace;

        bool isBindable = BindableNamespaces.Contains(topNs);
        bool isNs = topNs == NsNamespace;

        if (!isBindable && !isNs)
            return;

        string csharpName = prefix + className;

        // NS namespace filtering
        if (isNs)
        {
            if (!GeneratableNsClasses.Contains(csharpName))
                return;
        }

        // Skip value structs - they're handled differently
        if (ValueStructs.Contains(csharpName))
            return;

        // Determine parent class from template bases
        string? parentClass = null;
        string? objcClass = null;

        if (recordDecl.NumBases > 0)
        {
            foreach (var baseSpec in recordDecl.Bases)
            {
                var baseType = baseSpec.Type;
                parentClass = ExtractParentFromBase(baseType, prefix);
                if (parentClass != null)
                    break;
            }
        }

        // Determine if this is a class (has alloc or CLS registration)
        bool hasAlloc = false;
        foreach (var method in recordDecl.Methods)
        {
            if (method.Name == "alloc" && method.IsStatic)
            {
                hasAlloc = true;
                break;
            }
        }

        bool hasCls = clsRegistrations.Contains(csharpName);
        bool isClass = hasAlloc || hasCls;

        if (hasCls)
            objcClass = csharpName;

        var classDef = new ObjCClassDef
        {
            Name = csharpName,
            IsClass = isClass,
            ObjCClass = objcClass,
            ParentClass = parentClass,
            Folder = folder
        };

        // Extract methods
        var getters = new Dictionary<string, (MethodDef Method, string ReturnType)>();
        var setterNames = new HashSet<string>();

        foreach (var method in recordDecl.Methods)
        {
            if (ShouldSkipMethod(method))
                continue;

            string? returnType = MapType(method.ReturnType);
            if (returnType == null)
                continue;

            var parameters = new List<ParamDef>();
            bool hasErrorOut = false;
            bool skipMethod = false;

            foreach (var param in method.Parameters)
            {
                string paramTypeStr = param.Type?.AsString ?? "";

                // Check for NS::Error** (error out parameter)
                if (paramTypeStr.Contains("Error") && paramTypeStr.Contains("**"))
                {
                    hasErrorOut = true;
                    continue;
                }

                string? paramType = MapType(param.Type);
                if (paramType == null)
                {
                    skipMethod = true;
                    break;
                }

                string paramName = param.Name;
                if (string.IsNullOrEmpty(paramName))
                    paramName = "arg" + parameters.Count;
                if (IsCSharpKeyword(paramName))
                    paramName = "@" + paramName;

                parameters.Add(new ParamDef { Name = paramName, Type = paramType });
            }

            if (skipMethod)
                continue;

            // Find selector
            string selector = ResolveSelector(method, selectorMap);

            string methodName = method.Name;
            if (IsCSharpKeyword(methodName))
                methodName = "@" + methodName;

            var methodDef = new MethodDef
            {
                Name = methodName,
                Selector = selector,
                ReturnType = returnType,
                Parameters = parameters,
                HasErrorOut = hasErrorOut
            };

            if (method.IsStatic)
            {
                classDef.StaticMethods.Add(methodDef);
            }
            else
            {
                classDef.Methods.Add(methodDef);

                // Track potential property getters (non-static, 0 params, non-void return)
                if (parameters.Count == 0 && returnType != "void")
                {
                    getters[method.Name] = (methodDef, returnType);
                }

                // Track potential property setters
                if (parameters.Count == 1 && returnType == "void" && method.Name.StartsWith("set") && method.Name.Length > 3)
                {
                    setterNames.Add(method.Name);
                }
            }
        }

        // Build properties from getter/setter pairs
        foreach (var (getterName, (getterMethod, retType)) in getters)
        {
            string pascalName = char.ToUpperInvariant(getterName[0]) + getterName[1..];
            string expectedSetter = "set" + pascalName;

            bool hasSetter = setterNames.Contains(expectedSetter);

            // Find setter selector
            string? setSelector = null;
            if (hasSetter)
            {
                foreach (var m in classDef.Methods)
                {
                    string rawName = m.Name.StartsWith("@") ? m.Name[1..] : m.Name;
                    if (rawName == expectedSetter)
                    {
                        setSelector = m.Selector;
                        break;
                    }
                }
            }

            string propName = pascalName;
            if (IsCSharpKeyword(propName.ToLowerInvariant()))
                propName = pascalName; // keep PascalCase

            classDef.Properties.Add(new PropertyDef
            {
                Name = propName,
                Type = retType,
                Readonly = !hasSetter,
                GetSelector = getterMethod.Selector,
                SetSelector = setSelector
            });
        }

        if (classDef.Methods.Count > 0 || classDef.StaticMethods.Count > 0 || classDef.Properties.Count > 0)
            result.Classes.Add(classDef);
    }

    private static string? ExtractParentFromBase(ClangSharp.Type baseType, string currentPrefix)
    {
        // Desugar to find template specialization
        var type = baseType;
        while (type.IsSugared)
        {
            var desugared = type.Desugar;
            if (desugared == type)
                break;
            type = desugared;
        }

        string typeStr = baseType.AsString;

        // Look for NS::Referencing<Self, Parent> or NS::Copying<Self, Parent>
        if (typeStr.Contains("Referencing") || typeStr.Contains("Copying") || typeStr.Contains("SecureCoding"))
        {
            // Try to extract parent from template args via the AST
            if (type is TemplateSpecializationType tst)
            {
                // Second template arg is the parent
                if (tst.Handle.NumTemplateArguments >= 2)
                {
                    var parentArg = tst.Handle.GetTemplateArgument(1);
                    string parentStr = parentArg.AsType.ToString();
                    if (!string.IsNullOrEmpty(parentStr) && parentStr != "class NS::Object" && parentStr != "NS::Object")
                    {
                        return MapQualifiedTypeName(parentStr);
                    }
                }
            }

            // Fallback: parse from string representation
            int angleStart = typeStr.IndexOf('<');
            if (angleStart >= 0)
            {
                string argsStr = typeStr[(angleStart + 1)..];
                int angleEnd = argsStr.LastIndexOf('>');
                if (angleEnd >= 0)
                    argsStr = argsStr[..angleEnd];

                string[] args = SplitTemplateArgs(argsStr);
                if (args.Length >= 2)
                {
                    string parent = args[1].Trim();
                    string mapped = MapQualifiedTypeName(parent);
                    if (mapped != "NSObject")
                        return mapped;
                }
            }
        }

        return null;
    }

    private static string[] SplitTemplateArgs(string args)
    {
        var result = new List<string>();
        int depth = 0;
        int start = 0;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case '<':
                    depth++;
                    break;
                case '>':
                    depth--;
                    break;
                case ',' when depth == 0:
                    result.Add(args[start..i]);
                    start = i + 1;
                    break;
            }
        }

        result.Add(args[start..]);
        return result.ToArray();
    }

    private static string MapQualifiedTypeName(string qualifiedName)
    {
        string name = qualifiedName.Trim();
        // Remove pointer
        name = name.TrimEnd('*').Trim();
        // Remove "class " prefix
        if (name.StartsWith("class "))
            name = name["class ".Length..];
        // Remove namespace
        if (name.Contains("::"))
        {
            string ns = name[..name.LastIndexOf("::")];
            string typeName = name[(name.LastIndexOf("::") + 2)..];

            // Get the innermost namespace for prefix
            string innerNs = ns.Contains("::") ? ns[(ns.LastIndexOf("::") + 2)..] : ns;
            // But also check the top-level namespace
            string topNs = ns.Contains("::") ? ns[..ns.IndexOf("::")] : ns;

            if (NamespaceMap.TryGetValue(innerNs, out var map))
                return map.Prefix + typeName;
            if (NamespaceMap.TryGetValue(topNs, out map))
                return map.Prefix + typeName;

            // Check for multi-level namespace like MTL4
            if (NamespaceMap.TryGetValue(ns.Replace("::", ""), out map))
                return map.Prefix + typeName;

            return typeName;
        }

        return name;
    }

    private static bool ShouldSkipMethod(CXXMethodDecl method)
    {
        string name = method.Name;

        // Skip constructors, destructors, operators
        if (method is CXXConstructorDecl || method is CXXDestructorDecl || method is CXXConversionDecl)
            return true;

        if (name.StartsWith("operator"))
            return true;

        // Skip init and alloc
        if (name == "init" || name == "alloc")
            return true;

        // Skip if name is empty
        if (string.IsNullOrEmpty(name))
            return true;

        return false;
    }

    private static string ResolveSelector(CXXMethodDecl method, Dictionary<string, string> selectorMap)
    {
        // Try to find selector accessor from method body
        string? accessor = FindSelectorAccessorInBody(method);

        if (accessor != null && selectorMap.TryGetValue(accessor, out string? sel))
            return sel;

        // If accessor found but not in map, convert underscores to colons
        if (accessor != null)
        {
            return ConvertAccessorToSelector(accessor);
        }

        // Fallback: construct selector from method name and parameter count
        return ConstructSelectorFromMethod(method);
    }

    private static string? FindSelectorAccessorInBody(CXXMethodDecl method)
    {
        if (!method.HasBody || method.Body == null)
            return null;

        return FindDeclRefInCursor(method.Body);
    }

    private static string? FindDeclRefInCursor(Cursor cursor)
    {
        if (cursor is DeclRefExpr declRef)
        {
            string refName = declRef.Decl?.Name ?? declRef.Name;
            if (refName.StartsWith("s_k"))
            {
                return refName["s_k".Length..];
            }
        }

        foreach (var child in cursor.CursorChildren)
        {
            string? found = FindDeclRefInCursor(child);
            if (found != null)
                return found;
        }

        return null;
    }

    private static string ConvertAccessorToSelector(string accessor)
    {
        // Trailing underscores become colons
        if (accessor.EndsWith("_"))
        {
            return accessor.Replace('_', ':');
        }

        return accessor;
    }

    private static string ConstructSelectorFromMethod(CXXMethodDecl method)
    {
        string name = method.Name;
        int paramCount = (int)method.NumParams;

        // Check for error out parameter
        foreach (var param in method.Parameters)
        {
            string paramTypeStr = param.Type?.AsString ?? "";
            if (paramTypeStr.Contains("Error") && paramTypeStr.Contains("**"))
                paramCount++; // error param counts in selector
        }

        if (paramCount == 0)
            return name;

        // Simple heuristic: name + colons for params
        var sb = new StringBuilder(name);
        if (!name.EndsWith(":"))
        {
            sb.Append(':');
            for (int i = 1; i < paramCount; i++)
                sb.Append(':');
        }

        return sb.ToString();
    }

    private static void ExtractFreeFunctions(LinkageSpecDecl linkageSpec, ParseResult result)
    {
        foreach (var cursor in linkageSpec.CursorChildren)
        {
            if (cursor is not FunctionDecl funcDecl)
                continue;

            string nativeName = funcDecl.Name;
            if (string.IsNullOrEmpty(nativeName))
                continue;

            if (!nativeName.StartsWith("MTL") && !nativeName.StartsWith("CA"))
                continue;

            string? returnType = MapType(funcDecl.ReturnType);
            if (returnType == null)
                continue;

            var parameters = new List<ParamDef>();
            bool skip = false;

            foreach (var param in funcDecl.Parameters)
            {
                string? paramType = MapType(param.Type);
                if (paramType == null)
                {
                    skip = true;
                    break;
                }

                string paramName = param.Name;
                if (string.IsNullOrEmpty(paramName))
                    paramName = "arg" + parameters.Count;
                if (IsCSharpKeyword(paramName))
                    paramName = "@" + paramName;

                parameters.Add(new ParamDef { Name = paramName, Type = paramType });
            }

            if (skip)
                continue;

            string targetClass = DetermineTargetClass(nativeName);
            string frameworkLibrary = DetermineFrameworkLibrary(nativeName);

            // Generate a friendly name by removing prefix
            string friendlyName = nativeName;
            if (nativeName.StartsWith("MTL"))
                friendlyName = nativeName["MTL".Length..];
            else if (nativeName.StartsWith("CA"))
                friendlyName = nativeName["CA".Length..];

            result.FreeFunctions.Add(new FreeFunctionDef
            {
                NativeName = nativeName,
                Name = friendlyName,
                ReturnType = returnType,
                Parameters = parameters,
                TargetClass = targetClass,
                FrameworkLibrary = frameworkLibrary
            });
        }
    }

    private static string DetermineTargetClass(string funcName)
    {
        if (funcName.Contains("Device"))
            return "MTLDevice";
        if (funcName.Contains("CommandBuffer"))
            return "MTLCommandBuffer";
        if (funcName.Contains("IOCompression"))
            return "MTLIOCompressor";
        if (funcName.StartsWith("CA"))
            return "CAMetalLayer";

        return "MTLDevice";
    }

    private static string DetermineFrameworkLibrary(string funcName)
    {
        if (funcName.StartsWith("CA"))
            return "/System/Library/Frameworks/QuartzCore.framework/QuartzCore";

        return "/System/Library/Frameworks/Metal.framework/Metal";
    }

    public static string? MapType(ClangSharp.Type? type)
    {
        if (type == null)
            return null;

        string typeStr = type.AsString;
        if (string.IsNullOrEmpty(typeStr))
            return null;

        return MapTypeString(typeStr, type);
    }

    private static string? MapTypeString(string typeStr, ClangSharp.Type? clangType)
    {
        string trimmed = typeStr.Trim();

        // Remove const qualifiers for matching
        string cleaned = trimmed
            .Replace("const ", "")
            .Replace(" const", "")
            .Trim();

        // Function pointers, blocks, handlers, std::function → skip
        if (cleaned.Contains("(*)") || cleaned.Contains("(^)") ||
            cleaned.Contains("Block") || cleaned.Contains("block") ||
            cleaned.Contains("Handler") || cleaned.Contains("handler") ||
            cleaned.Contains("std::function") || cleaned.Contains("Function&") ||
            cleaned.Contains("HandlerFunction"))
            return null;

        // Direct primitive type mappings
        switch (cleaned)
        {
            case "void": return "void";
            case "bool": return "bool";
            case "char": return "byte";
            case "unsigned char": return "byte";
            case "signed char": return "sbyte";
            case "short": return "short";
            case "unsigned short": return "ushort";
            case "int": return "int";
            case "unsigned int": return "uint";
            case "long": return "nint";
            case "unsigned long": return "nuint";
            case "long long": return "nint";
            case "unsigned long long": return "nuint";
            case "float": return "float";
            case "double": return "double";
            case "int8_t": return "sbyte";
            case "uint8_t": return "byte";
            case "int16_t": return "short";
            case "uint16_t": return "ushort";
            case "int32_t": return "int";
            case "uint32_t": return "uint";
            case "int64_t": return "nint";
            case "uint64_t": return "nuint";
            case "size_t": return "nuint";
            case "CFTimeInterval": return "double";
            case "IOSurfaceRef": return "nint";
            case "CGColorSpaceRef": return "nint";
            case "dispatch_queue_t": return "nint";
            case "dispatch_data_t": return "nint";
        }

        // NS:: types
        if (cleaned == "NS::UInteger") return "nuint";
        if (cleaned == "NS::Integer") return "nint";

        if (cleaned == "NS::String *" || cleaned == "NS::String*") return "NSString";
        if (cleaned == "NS::Error *" || cleaned == "NS::Error*") return "NSError";
        if (cleaned == "NS::Array *" || cleaned == "NS::Array*") return "NSArray";
        if (cleaned == "NS::URL *" || cleaned == "NS::URL*") return "NSURL";
        if (cleaned == "NS::Range") return "NSRange";

        // NS:: types that map to nint
        if (cleaned.StartsWith("NS::") && cleaned.EndsWith("*"))
        {
            string nsType = cleaned["NS::".Length..].TrimEnd('*').Trim();
            if (nsType is "Number" or "Data" or "Dictionary" or "Object" or
                "Bundle" or "Notification" or "ProcessInfo" or "Set")
                return "nint";
        }

        // void* and char* → nint
        if (cleaned == "void *" || cleaned == "void*") return "nint";
        if (cleaned == "char *" || cleaned == "char*") return "nint";

        // Double pointers → nint
        if (cleaned.Contains("**")) return "nint";

        // GPUAddress, Timestamp
        if (cleaned.EndsWith("GPUAddress") || cleaned == "GPUAddress") return "nuint";
        if (cleaned.EndsWith("Timestamp") || cleaned == "Timestamp") return "nuint";

        // simd types → nint
        if (cleaned.StartsWith("simd::")) return "nint";

        // Qualified pointer: Namespace::Type *
        if (cleaned.EndsWith("*") && cleaned.Contains("::"))
        {
            string withoutPtr = cleaned.TrimEnd('*').Trim();
            string mapped = MapQualifiedTypeName(withoutPtr);

            // Primitive pointer → nint
            if (mapped is "void" or "char" or "byte" or "int" or "uint" or "float" or "double"
                or "nint" or "nuint" or "short" or "ushort" or "sbyte" or "bool")
                return "nint";

            return mapped;
        }

        // Non-pointer qualified type (enum values): Namespace::Type
        if (cleaned.Contains("::") && !cleaned.EndsWith("*"))
        {
            return MapQualifiedTypeName(cleaned);
        }

        // Pointer to a simple type (primitive* → nint)
        if (cleaned.EndsWith("*"))
        {
            string inner = cleaned.TrimEnd('*').Trim();
            if (inner is "void" or "char" or "int" or "unsigned int" or "float" or "double"
                or "long" or "unsigned long" or "short" or "unsigned short"
                or "uint8_t" or "int8_t" or "uint16_t" or "int16_t"
                or "uint32_t" or "int32_t" or "uint64_t" or "int64_t")
                return "nint";
        }

        // Struct types we know about
        if (ValueStructs.Contains(cleaned))
            return cleaned;

        // Fallback: check if canonical type reveals something useful
        if (clangType != null)
        {
            var canonical = clangType.CanonicalType;
            if (canonical != clangType)
            {
                string canonicalStr = canonical.AsString;
                if (canonicalStr != typeStr && !string.IsNullOrEmpty(canonicalStr))
                    return MapTypeString(canonicalStr, null);
            }
        }

        return null;
    }

    private static string BuildNamespacePath(string current, string name)
    {
        if (string.IsNullOrEmpty(current))
            return name;
        return current + "::" + name;
    }

    private static string? GetPrefixForNamespace(string namespacePath)
    {
        if (string.IsNullOrEmpty(namespacePath))
            return null;

        // Get the top-level namespace
        string topNs = namespacePath.Contains("::") ? namespacePath[..namespacePath.IndexOf("::")] : namespacePath;

        if (NamespaceMap.TryGetValue(topNs, out var map))
            return map.Prefix;

        return null;
    }

    private static string? GetFolderForNamespace(string namespacePath)
    {
        if (string.IsNullOrEmpty(namespacePath))
            return null;

        string topNs = namespacePath.Contains("::") ? namespacePath[..namespacePath.IndexOf("::")] : namespacePath;

        if (NamespaceMap.TryGetValue(topNs, out var map))
            return map.Folder;

        return null;
    }
}
