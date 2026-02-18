using ClangSharp;
using ClangSharp.Interop;

namespace Metal.NET.Generator;

/// <summary>
/// Parses metal-cpp C++ headers using ClangSharp AST traversal only (no regex).
/// Uses -DMTL_PRIVATE_IMPLEMENTATION to make private selector/class registration
/// definitions visible in the AST.
/// </summary>
public static class HeaderParser
{
    private static readonly HashSet<string> BindableNamespaces = ["MTL", "MTL4", "MTLFX", "MTL4FX", "CA"];

    private static readonly HashSet<string> NsNamespace = ["NS"];

    private static readonly HashSet<string> HandWrittenTypes = ["NSString", "NSError", "NSArray"];

    private static readonly HashSet<string> GeneratableNsClasses = ["NSURL"];

    private static readonly HashSet<string> ValueStructs =
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

    private static readonly HashSet<string> KnownWrapperTypes =
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

    private static readonly HashSet<string> CSharpKeywords =
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
    public static ParseResult Parse(string metalCppDir)
    {
        ParseResult result = new();

        string? stubsDir = null;

        try
        {
            stubsDir = CreateStubHeaders();
            using TranslationUnit tu = ParseWithClangSharp(metalCppDir, stubsDir);

            // Phase 1: Build accessor → selector map from Private::Selector namespaces in AST
            Dictionary<string, string> selectorMap = BuildSelectorMapFromAst(tu);

            // Phase 2: Build set of ObjC-registered class names from Private::Class namespaces in AST
            HashSet<string> clsRegistrations = BuildClsRegistrationsFromAst(tu);

            // Phase 3: Build type alias map for enum metadata (flags vs regular, underlying type)
            Dictionary<string, (string Prefix, bool IsFlags, string UnderlyingType)> enumMetadata =
                BuildEnumMetadataFromAst(tu, metalCppDir);

            // Phase 4: Extract enums from AST
            ExtractEnumsFromAst(tu, enumMetadata, metalCppDir, result);

            // Phase 5: Extract classes from AST (with inline body analysis for selectors)
            ExtractClassesFromAst(tu, clsRegistrations, selectorMap, metalCppDir, result);

            // Phase 6: Extract free functions from AST (LinkageSpecDecl nodes)
            ExtractFreeFunctionsFromAst(tu, metalCppDir, result);
        }
        finally
        {
            if (stubsDir is not null && Directory.Exists(stubsDir))
            {
                try { Directory.Delete(stubsDir, true); } catch { /* best effort */ }
            }
        }

        result.Deduplicate();

        return result;
    }

    // ──────────────────────────────────────────────────────────────────────
    //  ClangSharp AST setup
    // ──────────────────────────────────────────────────────────────────────

    private static string CreateStubHeaders()
    {
        string stubsDir = Path.Combine(Path.GetTempPath(), $"metal_net_stubs_{Guid.NewGuid():N}");

        WriteStub(stubsDir, "objc/runtime.h", """
            #pragma once
            #ifndef _SIZE_T
            #define _SIZE_T
            typedef __SIZE_TYPE__ size_t;
            #endif
            typedef struct objc_object { void *isa; } *id;
            typedef struct objc_selector *SEL;
            typedef id (*IMP)(id, SEL, ...);
            typedef struct objc_class *Class;
            typedef int BOOL;
            extern SEL sel_registerName(const char *str);
            extern Class objc_lookUpClass(const char *name);
            extern void *objc_getProtocol(const char *name);
            """);

        WriteStub(stubsDir, "objc/message.h", """
            #pragma once
            #include <objc/runtime.h>
            extern id objc_msgSend(id self, SEL op, ...);
            extern double objc_msgSend_fpret(id self, SEL op, ...);
            extern void objc_msgSend_stret(void *stretAddr, id self, SEL op, ...);
            """);

        WriteStub(stubsDir, "CoreFoundation/CoreFoundation.h", """
            #pragma once
            typedef double CFTimeInterval;
            typedef const void *IOSurfaceRef;
            typedef const void *CGColorSpaceRef;
            """);

        WriteStub(stubsDir, "IOSurface/IOSurfaceRef.h", """
            #pragma once
            typedef const void *IOSurfaceRef;
            """);

        WriteStub(stubsDir, "dispatch/dispatch.h", """
            #pragma once
            typedef void *dispatch_queue_t;
            typedef void *dispatch_data_t;
            """);

        WriteStub(stubsDir, "CoreGraphics/CGGeometry.h", """
            #pragma once
            typedef struct CGPoint { double x; double y; } CGPoint;
            typedef struct CGSize { double width; double height; } CGSize;
            typedef struct CGRect { CGPoint origin; CGSize size; } CGRect;
            """);

        WriteStub(stubsDir, "CoreGraphics/CGColorSpace.h", """
            #pragma once
            typedef const void *CGColorSpaceRef;
            """);

        WriteStub(stubsDir, "mach/mach.h", """
            #pragma once
            typedef unsigned int task_id_token_t;
            typedef int kern_return_t;
            """);

        WriteStub(stubsDir, "simd/simd.h", """
            #pragma once
            namespace simd {
                struct float4 { float x,y,z,w; };
                struct float4x4 { float4 columns[4]; };
                struct float3x3 { float columns[9]; };
            }
            """);

        WriteStub(stubsDir, "TargetConditionals.h", """
            #pragma once
            #define TARGET_OS_MAC 1
            """);

        WriteStub(stubsDir, "dlfcn.h", """
            #pragma once
            #define RTLD_DEFAULT ((void*)0)
            extern void *dlopen(const char *path, int mode);
            extern void *dlsym(void *handle, const char *symbol);
            extern int dlclose(void *handle);
            extern char *dlerror(void);
            """);

        return stubsDir;
    }

    private static void WriteStub(string baseDir, string relativePath, string content)
    {
        string fullPath = Path.Combine(baseDir, relativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, content);
    }

    private static TranslationUnit ParseWithClangSharp(string metalCppDir, string stubsDir)
    {
        // Build a combined header that includes all frameworks
        string combinedHeader = Path.Combine(stubsDir, "_combined.hpp");
        List<string> includes = [];

        foreach (string dir in new[] { "Metal", "MetalFX", "QuartzCore", "Foundation" })
        {
            string fullDir = Path.Combine(metalCppDir, dir);

            if (!Directory.Exists(fullDir))
            {
                continue;
            }

            foreach (string file in Directory.GetFiles(fullDir, "*.hpp").OrderBy(f => f))
            {
                string fileName = Path.GetFileName(file);

                if (fileName.EndsWith("Private.hpp") || fileName.EndsWith("Defines.hpp")
                    || fileName.EndsWith("HeaderBridge.hpp"))
                {
                    continue;
                }

                includes.Add($"#include \"{file}\"");
            }
        }

        File.WriteAllText(combinedHeader, string.Join('\n', includes));

        List<string> clangArgsList =
        [
            "-x", "c++",
            "-std=c++17",
            "-fblocks",
            "-DINFINITY=__builtin_inf()",
            "-DMTL_PRIVATE_IMPLEMENTATION",
            $"-I{metalCppDir}",
            $"-I{stubsDir}",
        ];

        // Add system include paths for Linux (detect available GCC versions)
        if (OperatingSystem.IsLinux())
        {
            string? gccInclude = FindGccIncludePath();

            if (gccInclude is not null)
            {
                clangArgsList.AddRange(["-isystem", gccInclude]);
            }

            if (Directory.Exists("/usr/include"))
            {
                clangArgsList.AddRange(["-isystem", "/usr/include"]);
            }
        }

        string[] clangArgs = [.. clangArgsList];

        CXIndex index = CXIndex.Create();
        CXTranslationUnit cxTu = CXTranslationUnit.CreateFromSourceFile(
            index,
            combinedHeader,
            clangArgs,
            ReadOnlySpan<CXUnsavedFile>.Empty);

        return TranslationUnit.GetOrCreate(cxTu);
    }

    private static string? FindGccIncludePath()
    {
        string basePath = "/usr/lib/gcc";

        if (!Directory.Exists(basePath))
        {
            return null;
        }

        // Search for the highest GCC version include directory
        foreach (string arch in Directory.GetDirectories(basePath))
        {
            string? best = Directory.GetDirectories(arch)
                .Where(d => File.Exists(Path.Combine(d, "include", "stddef.h")))
                .OrderByDescending(d => d)
                .FirstOrDefault();

            if (best is not null)
            {
                return Path.Combine(best, "include");
            }
        }

        return null;
    }

    // ──────────────────────────────────────────────────────────────────────
    //  AST-based selector map (replaces regex BuildSelectorMap)
    // ──────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Walks the AST for Private::Selector namespaces and extracts accessor → selector mappings.
    /// Each VarDecl named s_k{accessor} contains a sel_registerName("selectorString") call.
    /// </summary>
    private static Dictionary<string, string> BuildSelectorMapFromAst(TranslationUnit tu)
    {
        Dictionary<string, string> map = [];
        WalkForSelectorNamespaces(tu.TranslationUnitDecl.Decls, map, false);

        return map;
    }

    private static void WalkForSelectorNamespaces(IReadOnlyList<Decl> decls, Dictionary<string, string> map, bool inPrivate)
    {
        foreach (Decl decl in decls)
        {
            if (decl is not NamespaceDecl ns)
            {
                continue;
            }

            if (ns.Name == "Private")
            {
                WalkForSelectorNamespaces(ns.Decls, map, true);
            }
            else if (inPrivate && ns.Name == "Selector")
            {
                foreach (Decl inner in ns.Decls)
                {
                    if (inner is VarDecl vd && vd.Name.Length > 3 && vd.Name.StartsWith("s_k"))
                    {
                        string accessor = vd.Name[3..];
                        string? selectorStr = vd.Init is not null ? FindStringLiteral(vd.Init) : null;

                        if (selectorStr is not null)
                        {
                            map[accessor] = selectorStr;
                        }
                        else
                        {
                            // Fallback: derive from accessor name
                            map[accessor] = AccessorToSelector(accessor);
                        }
                    }
                }
            }
            else
            {
                WalkForSelectorNamespaces(ns.Decls, map, false);
            }
        }
    }

    // ──────────────────────────────────────────────────────────────────────
    //  AST-based CLS registration (replaces regex BuildClsRegistrations)
    // ──────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Walks the AST for Private::Class namespaces and extracts registered class names.
    /// Each VarDecl named s_k{ClassName} is a class registration.
    /// </summary>
    private static HashSet<string> BuildClsRegistrationsFromAst(TranslationUnit tu)
    {
        HashSet<string> set = [];
        WalkForClassNamespaces(tu.TranslationUnitDecl.Decls, set, false);

        return set;
    }

    private static void WalkForClassNamespaces(IReadOnlyList<Decl> decls, HashSet<string> set, bool inPrivate)
    {
        foreach (Decl decl in decls)
        {
            if (decl is not NamespaceDecl ns)
            {
                continue;
            }

            if (ns.Name == "Private")
            {
                WalkForClassNamespaces(ns.Decls, set, true);
            }
            else if (inPrivate && ns.Name == "Class")
            {
                foreach (Decl inner in ns.Decls)
                {
                    if (inner is VarDecl vd && vd.Name.Length > 3 && vd.Name.StartsWith("s_k"))
                    {
                        set.Add(vd.Name[3..]);
                    }
                }
            }
            else
            {
                WalkForClassNamespaces(ns.Decls, set, false);
            }
        }
    }

    // ──────────────────────────────────────────────────────────────────────
    //  AST-based enum metadata (replaces regex BuildOptionsEnumNames)
    // ──────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Builds enum metadata from TypeAliasDecl nodes in the AST.
    /// Named enums (from _*_ENUM) are NOT flags. Unnamed enums (from _*_OPTIONS) ARE flags.
    /// TypeAliasDecl nodes created by _*_OPTIONS alias integer types (the enum name comes
    /// from the typedef, and the enum itself is unnamed).
    /// </summary>
    private static Dictionary<string, (string Prefix, bool IsFlags, string UnderlyingType)> BuildEnumMetadataFromAst(
        TranslationUnit tu,
        string metalCppDir)
    {
        Dictionary<string, (string, bool, string)> map = [];
        HashSet<string> typeAliasNames = [];

        // First pass: collect all TypeAliasDecl names in bindable namespaces
        // These come from both _*_ENUM and _*_OPTIONS macros
        foreach (Decl decl in tu.TranslationUnitDecl.Decls)
        {
            if (decl is NamespaceDecl nsDecl)
            {
                string nsName = nsDecl.Name;

                if (!BindableNamespaces.Contains(nsName) && !NsNamespace.Contains(nsName))
                {
                    continue;
                }

                if (!IsDeclFromMetalCpp(decl, metalCppDir))
                {
                    continue;
                }

                string prefix = NamespaceToPrefix(nsName);
                CollectTypeAliases(nsDecl.Decls, prefix, metalCppDir, typeAliasNames, map);
            }
        }

        // Second pass: for unnamed enums, determine if they are flags
        // Unnamed enums are from _*_OPTIONS → flags = true
        // Named enums are from _*_ENUM → flags = false (already in map from type alias)
        foreach (Decl decl in tu.TranslationUnitDecl.Decls)
        {
            if (decl is NamespaceDecl nsDecl)
            {
                string nsName = nsDecl.Name;

                if (!BindableNamespaces.Contains(nsName) && !NsNamespace.Contains(nsName))
                {
                    continue;
                }

                if (!IsDeclFromMetalCpp(decl, metalCppDir))
                {
                    continue;
                }

                string prefix = NamespaceToPrefix(nsName);

                foreach (Decl innerDecl in nsDecl.Decls)
                {
                    if (innerDecl is not EnumDecl enumDecl || !IsDeclFromMetalCpp(enumDecl, metalCppDir))
                    {
                        continue;
                    }

                    string enumName = enumDecl.Name;

                    if (string.IsNullOrEmpty(enumName) || enumName.StartsWith("(unnamed"))
                    {
                        // Unnamed enum → from _*_OPTIONS → flags
                        string underlyingTypeStr = enumDecl.IntegerType.AsString;
                        string simpleName = underlyingTypeStr;

                        if (simpleName.Contains("::"))
                        {
                            simpleName = simpleName[(simpleName.LastIndexOf("::") + 2)..];
                        }

                        if (typeAliasNames.Contains(simpleName) && !map.ContainsKey(simpleName))
                        {
                            string underlyingType = ResolveTypeAliasUnderlyingType(nsDecl, simpleName, metalCppDir);
                            map[simpleName] = (prefix, true, underlyingType);
                        }
                        else if (!map.ContainsKey(simpleName))
                        {
                            string underlyingType = MapEnumUnderlyingType(underlyingTypeStr);
                            map[simpleName] = (prefix, true, underlyingType);
                        }
                        else
                        {
                            // Already in map but ensure isFlags = true for unnamed
                            var existing = map[simpleName];
                            map[simpleName] = (existing.Item1, true, existing.Item3);
                        }
                    }
                    else
                    {
                        // Named enum → from _*_ENUM → not flags (unless already set)
                        if (!map.ContainsKey(enumName))
                        {
                            string underlyingType = MapEnumUnderlyingType(enumDecl.IntegerType.AsString);
                            map[enumName] = (prefix, false, underlyingType);
                        }
                    }
                }
            }
        }

        return map;
    }

    private static void CollectTypeAliases(
        IReadOnlyList<Decl> decls,
        string prefix,
        string metalCppDir,
        HashSet<string> typeAliasNames,
        Dictionary<string, (string, bool, string)> map)
    {
        foreach (Decl decl in decls)
        {
            if (decl is TypeAliasDecl tad && IsDeclFromMetalCpp(tad, metalCppDir))
            {
                string aliasName = tad.Name;
                string underlyingStr = tad.UnderlyingType.AsString;

                // Check if this aliases an integer type (from _*_ENUM or _*_OPTIONS)
                string mappedType = MapEnumUnderlyingType(underlyingStr);

                if (mappedType != "uint" || underlyingStr is "unsigned int" or "uint32_t")
                {
                    typeAliasNames.Add(aliasName);
                    // Default to not-flags; will be updated for unnamed enums
                    map.TryAdd(aliasName, (prefix, false, mappedType));
                }
            }
            else if (decl is TypedefDecl td && IsDeclFromMetalCpp(td, metalCppDir))
            {
                string aliasName = td.Name;
                string underlyingStr = td.UnderlyingType.AsString;

                string mappedType = MapEnumUnderlyingType(underlyingStr);

                if (mappedType != "uint" || underlyingStr is "unsigned int" or "uint32_t")
                {
                    typeAliasNames.Add(aliasName);
                    map.TryAdd(aliasName, (prefix, false, mappedType));
                }
            }
        }
    }

    private static string ResolveTypeAliasUnderlyingType(NamespaceDecl nsDecl, string aliasName, string metalCppDir)
    {
        foreach (Decl decl in nsDecl.Decls)
        {
            if (decl is TypeAliasDecl tad && tad.Name == aliasName && IsDeclFromMetalCpp(tad, metalCppDir))
            {
                return MapEnumUnderlyingType(tad.UnderlyingType.AsString);
            }

            if (decl is TypedefDecl td && td.Name == aliasName && IsDeclFromMetalCpp(td, metalCppDir))
            {
                return MapEnumUnderlyingType(td.UnderlyingType.AsString);
            }
        }

        return "uint";
    }

    // ──────────────────────────────────────────────────────────────────────
    //  AST helpers: find string literals and DeclRefExpr in statement trees
    // ──────────────────────────────────────────────────────────────────────

    private static string? FindStringLiteral(Stmt stmt)
    {
        if (stmt is StringLiteral sl)
        {
            return sl.String;
        }

        foreach (Cursor child in stmt.CursorChildren)
        {
            if (child is Stmt cs)
            {
                string? found = FindStringLiteral(cs);

                if (found is not null)
                {
                    return found;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Finds the first DeclRefExpr in a method body whose referenced variable starts with "s_k"
    /// and lives in the <c>Private::Selector</c> namespace (not <c>Private::Class</c>).
    /// Returns the accessor name (with "s_k" prefix stripped).
    /// </summary>
    private static string? FindSelectorAccessorInBody(Stmt stmt)
    {
        if (stmt is DeclRefExpr dre
            && dre.Decl.Name.Length > 3
            && dre.Decl.Name.StartsWith("s_k")
            && dre.Decl.DeclContext is NamespaceDecl ns
            && ns.Name == "Selector")
        {
            return dre.Decl.Name[3..];
        }

        foreach (Cursor child in stmt.CursorChildren)
        {
            if (child is Stmt cs)
            {
                string? found = FindSelectorAccessorInBody(cs);

                if (found is not null)
                {
                    return found;
                }
            }
        }

        return null;
    }

    // ──────────────────────────────────────────────────────────────────────
    //  AST-based enum extraction
    // ──────────────────────────────────────────────────────────────────────

    private static void ExtractEnumsFromAst(
        TranslationUnit tu,
        Dictionary<string, (string Prefix, bool IsFlags, string UnderlyingType)> enumMetadata,
        string metalCppDir,
        ParseResult result)
    {
        foreach (Decl decl in tu.TranslationUnitDecl.Decls)
        {
            if (decl is NamespaceDecl nsDecl)
            {
                string nsName = nsDecl.Name;

                if (!BindableNamespaces.Contains(nsName) && !NsNamespace.Contains(nsName))
                {
                    continue;
                }

                // Check that this decl comes from our metal-cpp headers
                if (!IsDeclFromMetalCpp(decl, metalCppDir))
                {
                    continue;
                }

                string prefix = NamespaceToPrefix(nsName);

                foreach (Decl innerDecl in nsDecl.Decls)
                {
                    if (innerDecl is EnumDecl enumDecl)
                    {
                        ProcessEnumDecl(enumDecl, prefix, nsName, enumMetadata, metalCppDir, result);
                    }
                }
            }
        }
    }

    private static void ProcessEnumDecl(
        EnumDecl enumDecl,
        string prefix,
        string nsName,
        Dictionary<string, (string Prefix, bool IsFlags, string UnderlyingType)> enumMetadata,
        string metalCppDir,
        ParseResult result)
    {
        if (!IsDeclFromMetalCpp(enumDecl, metalCppDir))
        {
            return;
        }

        string enumName = enumDecl.Name;
        bool isFlags = false;
        string? overrideUnderlyingType = null;

        // Handle unnamed enums: ClangSharp gives them names like "(unnamed enum at ...)"
        // The underlying type name IS the real enum name for _*_OPTIONS macros
        if (string.IsNullOrEmpty(enumName) || enumName.StartsWith("(unnamed"))
        {
            string underlyingTypeStr = enumDecl.IntegerType.AsString;

            // Extract the simple name from the underlying type (e.g., "NS::TextureUsage" -> "TextureUsage")
            string simpleName = underlyingTypeStr;

            if (simpleName.Contains("::"))
            {
                simpleName = simpleName[(simpleName.LastIndexOf("::") + 2)..];
            }

            // Look up in our enum metadata
            if (enumMetadata.TryGetValue(simpleName, out var info))
            {
                prefix = info.Prefix;
                isFlags = info.IsFlags;
                overrideUnderlyingType = info.UnderlyingType;
                enumName = simpleName;
            }
            else
            {
                return;
            }
        }
        else
        {
            // Named enum: check if it's a flags enum via our enum metadata
            if (enumMetadata.TryGetValue(enumName, out var info))
            {
                prefix = info.Prefix;
                isFlags = info.IsFlags;
                overrideUnderlyingType = info.UnderlyingType;
            }
        }

        string fullName = $"{prefix}{enumName}";
        string underlyingType = overrideUnderlyingType ?? MapEnumUnderlyingType(enumDecl.IntegerType.AsString);

        EnumDef enumDef = new()
        {
            Name = fullName,
            UnderlyingType = underlyingType,
            IsFlags = isFlags,
            Folder = NamespaceToFolder(prefix),
        };

        HashSet<string> seen = [];

        foreach (EnumConstantDecl enumerator in enumDecl.Enumerators)
        {
            string memberName = enumerator.Name;
            long initVal = enumerator.InitVal;

            string resolvedValue;

            if (underlyingType is "ulong" or "nuint")
            {
                resolvedValue = unchecked((ulong)initVal).ToString();
            }
            else if (underlyingType is "uint")
            {
                // Handle negative values that should be interpreted as unsigned
                if (initVal < 0)
                {
                    resolvedValue = unchecked((uint)initVal).ToString();
                }
                else if (initVal > uint.MaxValue)
                {
                    resolvedValue = unchecked((uint)initVal).ToString();
                }
                else
                {
                    resolvedValue = initVal.ToString();
                }
            }
            else
            {
                resolvedValue = initVal.ToString();
            }

            if (memberName.Length > 0 && char.IsDigit(memberName[0]))
            {
                memberName = $"_{memberName}";
            }

            if (!seen.Add(memberName))
            {
                continue;
            }

            enumDef.Members.Add(new EnumMemberDef
            {
                Name = memberName,
                Value = resolvedValue,
            });
        }

        if (enumDef.Members.Count > 0)
        {
            result.Enums.Add(enumDef);
        }
    }

    // ──────────────────────────────────────────────────────────────────────
    //  AST-based class extraction
    // ──────────────────────────────────────────────────────────────────────

    private static void ExtractClassesFromAst(
        TranslationUnit tu,
        HashSet<string> clsRegistrations,
        Dictionary<string, string> selectorMap,
        string metalCppDir,
        ParseResult result)
    {
        foreach (Decl decl in tu.TranslationUnitDecl.Decls)
        {
            if (decl is NamespaceDecl nsDecl)
            {
                string nsName = nsDecl.Name;

                if (!BindableNamespaces.Contains(nsName) && !NsNamespace.Contains(nsName))
                {
                    continue;
                }

                if (!IsDeclFromMetalCpp(decl, metalCppDir))
                {
                    continue;
                }

                string prefix = NamespaceToPrefix(nsName);

                foreach (Decl innerDecl in nsDecl.Decls)
                {
                    if (innerDecl is CXXRecordDecl rec && rec.IsThisDeclarationADefinition)
                    {
                        ProcessClassDecl(rec, nsName, prefix, clsRegistrations, selectorMap, metalCppDir, result);
                    }
                }
            }
        }
    }

    private static void ProcessClassDecl(
        CXXRecordDecl rec,
        string nsName,
        string prefix,
        HashSet<string> clsRegistrations,
        Dictionary<string, string> selectorMap,
        string metalCppDir,
        ParseResult result)
    {
        if (!IsDeclFromMetalCpp(rec, metalCppDir))
        {
            return;
        }

        string className = rec.Name;

        if (string.IsNullOrEmpty(className) || className == "Private"
            || className.Contains('<') || className.StartsWith('_'))
        {
            return;
        }

        string fullName = $"{prefix}{className}";

        if (HandWrittenTypes.Contains(fullName))
        {
            return;
        }

        if (NsNamespace.Contains(nsName) && !GeneratableNsClasses.Contains(fullName))
        {
            return;
        }

        if (ValueStructs.Contains(fullName))
        {
            return;
        }

        // Extract methods from ClangSharp AST
        List<RawMethodDecl> rawMethods = [];

        foreach (CXXMethodDecl method in rec.Methods)
        {
            if (method.Handle.IsImplicit)
            {
                continue;
            }

            string methodName = method.Name;

            if (string.IsNullOrEmpty(methodName))
            {
                continue;
            }

            // Skip destructors, constructors, operators
            if (methodName.StartsWith('~') || methodName.StartsWith("operator") || methodName == className)
            {
                continue;
            }

            // Get return type as string
            string returnTypeStr = method.ReturnType.AsString;

            // Get parameters
            List<RawParamInfo> paramList = [];

            foreach (ParmVarDecl param in method.Parameters)
            {
                string paramTypeStr = param.Type.AsString;
                string paramName = param.Name;

                paramList.Add(new RawParamInfo(paramTypeStr, paramName));
            }

            // Include method body reference for selector resolution
            Stmt? body = method.HasBody ? method.Body : null;

            rawMethods.Add(new RawMethodDecl(methodName, returnTypeStr, method.IsStatic, paramList, body));
        }

        // Determine if this is a class (has alloc or registered via CLS macro)
        bool isClass = rawMethods.Any(m => m.IsStatic && m.Name == "alloc" && m.Params.Count == 0)
            || clsRegistrations.Contains(className);

        string? objCClass = isClass ? fullName : null;

        // Extract parent class from base classes (NS::Referencing<Self, Parent> template)
        string? parentClass = null;

        foreach (CXXBaseSpecifier baseSpec in rec.Bases)
        {
            ClangSharp.Type baseType = baseSpec.Type;

            // Try to get the ClassTemplateSpecializationDecl
            if (baseType.AsCXXRecordDecl is ClassTemplateSpecializationDecl cts)
            {
                string templateName = cts.Name;

                if (templateName is "Referencing" or "Copying")
                {
                    if (cts.TemplateArgs.Count >= 2)
                    {
                        ClangSharp.Type? parentType = cts.TemplateArgs[1].AsType;
                        CXXRecordDecl? parentRec = parentType?.AsCXXRecordDecl;

                        if (parentRec is not null)
                        {
                            string parentSimpleName = parentRec.Name;

                            // Determine parent namespace
                            if (parentRec.DeclContext is NamespaceDecl parentNsDecl)
                            {
                                string parentNs = parentNsDecl.Name;
                                string parentPrefix = NamespaceToPrefix(parentNs);
                                parentClass = $"{parentPrefix}{parentSimpleName}";
                            }
                            else
                            {
                                parentClass = $"{prefix}{parentSimpleName}";
                            }
                        }
                    }
                }
            }
        }

        if (parentClass is "NSFastEnumeration" or "NSObject" or "objc_object")
        {
            parentClass = null;
        }

        ObjCClassDef def = new()
        {
            Name = fullName,
            IsClass = isClass,
            ObjCClass = objCClass,
            ParentClass = parentClass,
            Folder = NamespaceToFolder(nsName),
        };

        HashSet<string> methodSigs = [];
        HashSet<string> potentialPropertyNames = [];
        HashSet<string> addedPropertyNames = [];

        // First pass: identify potential properties (non-static, 0-param, non-void return)
        foreach (RawMethodDecl m in rawMethods)
        {
            if (m.IsStatic || m.Params.Count != 0)
            {
                continue;
            }

            if (m.Name.StartsWith("new") || m.Name == "init" || m.Name == "alloc")
            {
                continue;
            }

            if (m.Name == className || m.Name.StartsWith('~') || m.Name.StartsWith("operator"))
            {
                continue;
            }

            string? retType = MapType(m.ReturnType, nsName, prefix);

            if (retType is null || retType == "void")
            {
                continue;
            }

            string pcName = char.ToUpperInvariant(m.Name[0]) + m.Name[1..];
            potentialPropertyNames.Add(pcName);
        }

        // Second pass: convert methods
        foreach (RawMethodDecl m in rawMethods)
        {
            if (m.Name == className || m.Name.StartsWith('~') || m.Name.StartsWith("operator"))
            {
                continue;
            }

            if (m.Name == "init" || m.Name == "alloc")
            {
                continue;
            }

            string? retType = MapType(m.ReturnType, nsName, prefix);

            if (retType is null)
            {
                continue;
            }

            // Resolve selector using AST body analysis + selector map
            string selector = ResolveSelector(nsName, className, m.Name, m.Params, selectorMap, m.Body);

            MethodDef methodDef = new()
            {
                Name = m.Name,
                Selector = selector,
                ReturnType = retType,
            };

            bool hasErrorOut = false;
            bool paramFailed = false;

            foreach (RawParamInfo p in m.Params)
            {
                if (IsErrorOutParam(p.Type))
                {
                    hasErrorOut = true;

                    continue;
                }

                string? paramType = MapType(p.Type, nsName, prefix);

                if (paramType is null)
                {
                    paramFailed = true;

                    break;
                }

                string paramName = string.IsNullOrEmpty(p.Name) ? $"param{methodDef.Parameters.Count}" : p.Name;

                // Strip Hungarian notation 'p' prefix for pointer params (e.g., pDevice -> device)
                if (paramName.Length > 1 && paramName[0] == 'p' && char.IsUpper(paramName[1]))
                {
                    paramName = char.ToLowerInvariant(paramName[1]) + paramName[2..];
                }

                if (CSharpKeywords.Contains(paramName))
                {
                    paramName = $"@{paramName}";
                }

                methodDef.Parameters.Add(new ParamDef
                {
                    Name = paramName,
                    Type = paramType,
                });
            }

            if (paramFailed)
            {
                continue;
            }

            methodDef.HasErrorOut = hasErrorOut;

            string pcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name[1..];
            string sig = $"{(m.IsStatic ? "s:" : "")}{pcName}({string.Join(",", methodDef.Parameters.Select(p => p.Type))})";

            if (!methodSigs.Add(sig))
            {
                continue;
            }

            bool isProperty = m.Params.Count == 0
                && methodDef.ReturnType != "void"
                && !m.Name.StartsWith("new")
                && !m.IsStatic;

            bool hasSetter = false;
            string setterName = $"set{Capitalize(m.Name)}";

            if (isProperty)
            {
                hasSetter = rawMethods.Any(f =>
                    f.Name == setterName && f.Params.Count == 1 && !f.IsStatic);
            }

            if (isProperty && !m.IsStatic)
            {
                string propPcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name[1..];

                if (addedPropertyNames.Add(propPcName))
                {
                    string? setSelector = null;

                    if (hasSetter)
                    {
                        // Find the setter method's body for selector resolution
                        Stmt? setterBody = rawMethods
                            .FirstOrDefault(f => f.Name == setterName && f.Params.Count == 1 && !f.IsStatic)
                            ?.Body;

                        setSelector = ResolveSelector(nsName, className, setterName, [new RawParamInfo("", "")], selectorMap, setterBody);
                    }

                    def.Properties.Add(new PropertyDef
                    {
                        Name = m.Name,
                        Type = methodDef.ReturnType,
                        Readonly = !hasSetter,
                        GetSelector = selector,
                        SetSelector = setSelector,
                    });
                }
            }
            else
            {
                if (m.Name.StartsWith("set") && m.Name.Length > 3 && char.IsUpper(m.Name[3])
                    && m.Params.Count == 1)
                {
                    string propPcName = m.Name[3..];

                    if (potentialPropertyNames.Contains(propPcName))
                    {
                        continue;
                    }
                }

                string methodPcName = char.ToUpperInvariant(methodDef.Name[0]) + methodDef.Name[1..];

                if (potentialPropertyNames.Contains(methodPcName))
                {
                    continue;
                }

                if (m.IsStatic)
                {
                    def.StaticMethods.Add(methodDef);
                }
                else
                {
                    def.Methods.Add(methodDef);
                }
            }
        }

        result.Classes.Add(def);
    }

    // ──────────────────────────────────────────────────────────────────────
    //  AST-based free function extraction (replaces regex ParseFreeFunctions)
    // ──────────────────────────────────────────────────────────────────────

    private static void ExtractFreeFunctionsFromAst(
        TranslationUnit tu,
        string metalCppDir,
        ParseResult result)
    {
        VisitForExternC(tu.TranslationUnitDecl.Decls, metalCppDir, result);
    }

    private static void VisitForExternC(IReadOnlyList<Decl> decls, string metalCppDir, ParseResult result)
    {
        foreach (Decl decl in decls)
        {
            if (decl is LinkageSpecDecl linkSpec)
            {
                foreach (Decl ld in linkSpec.Decls)
                {
                    if (ld is FunctionDecl fd && IsDeclFromMetalCpp(fd, metalCppDir))
                    {
                        ProcessFreeFunctionDecl(fd, result);
                    }
                }
            }
            else if (decl is NamespaceDecl ns)
            {
                VisitForExternC(ns.Decls, metalCppDir, result);
            }
        }
    }

    private static void ProcessFreeFunctionDecl(FunctionDecl fd, ParseResult result)
    {
        string funcName = fd.Name;

        string prefix;

        if (funcName.StartsWith("MTL"))
        {
            prefix = "MTL";
        }
        else if (funcName.StartsWith("CA"))
        {
            prefix = "CA";
        }
        else
        {
            return;
        }

        string ns = prefix;
        string returnTypeStr = fd.ReturnType.AsString;
        string? retType = MapType(returnTypeStr, ns, prefix);

        if (retType is null)
        {
            return;
        }

        string? targetClass = MapFreeFunctionTarget(funcName, prefix);

        if (targetClass is null)
        {
            return;
        }

        FreeFunctionDef def = new()
        {
            NativeName = funcName,
            Name = funcName,
            ReturnType = retType,
            TargetClass = targetClass,
            FrameworkLibrary = "/System/Library/Frameworks/Metal.framework/Metal",
        };

        bool paramFailed = false;

        foreach (ParmVarDecl param in fd.Parameters)
        {
            string paramTypeStr = param.Type.AsString;
            string? paramType = MapType(paramTypeStr, ns, prefix);

            if (paramType is null)
            {
                paramFailed = true;

                break;
            }

            string paramName = string.IsNullOrEmpty(param.Name) ? $"param{def.Parameters.Count}" : param.Name;

            // Strip Hungarian notation 'p' prefix for pointer params (e.g., pDevice -> device)
            if (paramName.Length > 1 && paramName[0] == 'p' && char.IsUpper(paramName[1]))
            {
                paramName = char.ToLowerInvariant(paramName[1]) + paramName[2..];
            }

            if (CSharpKeywords.Contains(paramName))
            {
                paramName = $"@{paramName}";
            }

            def.Parameters.Add(new ParamDef
            {
                Name = paramName,
                Type = paramType,
            });
        }

        if (paramFailed)
        {
            return;
        }

        result.FreeFunctions.Add(def);
    }

    // ──────────────────────────────────────────────────────────────────────
    //  Helpers: check if a Decl comes from the metal-cpp directory
    // ──────────────────────────────────────────────────────────────────────

    private static bool IsDeclFromMetalCpp(Decl decl, string metalCppDir)
    {
        CXSourceLocation loc = decl.Location;
        loc.GetFileLocation(out CXFile file, out _, out _, out _);
        string filePath = file.Name.CString;

        if (string.IsNullOrEmpty(filePath))
        {
            return false;
        }

        return filePath.StartsWith(metalCppDir, StringComparison.OrdinalIgnoreCase);
    }

    // ──────────────────────────────────────────────────────────────────────
    //  Selector resolution (uses AST body analysis + selector map)
    // ──────────────────────────────────────────────────────────────────────

    private static string ResolveSelector(
        string ns,
        string className,
        string methodName,
        List<RawParamInfo> methodParams,
        Dictionary<string, string> selectorMap,
        Stmt? body)
    {
        // Try to find selector accessor in method body via AST traversal
        if (body is not null)
        {
            string? accessor = FindSelectorAccessorInBody(body);

            if (accessor is not null)
            {
                if (selectorMap.TryGetValue(accessor, out string? selector))
                {
                    return selector;
                }

                return AccessorToSelector(accessor);
            }
        }

        // Fallback: construct selector from method name and params
        if (methodParams.Count == 0)
        {
            return methodName;
        }

        // For setter with 1 param, the selector is methodName:
        if (methodParams.Count == 1)
        {
            return $"{methodName}:";
        }

        // Multi-param: methodName:paramName2:paramName3:...
        List<string> parts = [methodName];

        for (int i = 1; i < methodParams.Count; i++)
        {
            string pName = methodParams[i].Name;

            if (string.IsNullOrEmpty(pName))
            {
                pName = $"param{i}";
            }

            parts.Add(pName);
        }

        return string.Join(":", parts) + ":";
    }

    private static string AccessorToSelector(string accessor)
    {
        // Convert accessor like "addDebugMarker_range_" to "addDebugMarker:range:"
        if (!accessor.Contains('_'))
        {
            return accessor;
        }

        // Split by underscores and rejoin with colons
        // Trailing underscore means trailing colon
        bool trailingUnderscore = accessor.EndsWith('_');
        string[] parts = accessor.Split('_', StringSplitOptions.RemoveEmptyEntries);

        string result = string.Join(":", parts);

        if (trailingUnderscore)
        {
            result += ":";
        }

        return result;
    }

    private static bool IsErrorOutParam(string typeStr)
    {
        // Detect NS::Error** pattern
        string cleaned = typeStr.Replace(" ", "");

        return cleaned.Contains("Error**");
    }

    private static string? MapFreeFunctionTarget(string funcName, string prefix)
    {
        if (funcName.Contains("Device"))
        {
            return $"{prefix}Device";
        }

        if (funcName.Contains("Counter"))
        {
            return $"{prefix}Device";
        }

        return null;
    }

    // ──────────────────────────────────────────────────────────────────────
    //  Namespace / type mapping (kept from original)
    // ──────────────────────────────────────────────────────────────────────

    private static string NamespaceToPrefix(string ns) => ns switch
    {
        "MTL" => "MTL",
        "MTL4" => "MTL4",
        "MTLFX" => "MTLFX",
        "MTL4FX" => "MTL4FX",
        "CA" => "CA",
        "NS" => "NS",
        _ => ns,
    };

    private static string NamespaceToFolder(string ns) => ns switch
    {
        "MTL" or "MTL4" => "Metal",
        "CA" => "QuartzCore",
        "NS" => "Foundation",
        "MTLFX" or "MTL4FX" => "MetalFX",
        _ => "Metal",
    };

    private static string MapEnumUnderlyingType(string typeStr)
    {
        return typeStr switch
        {
            "NS::UInteger" or "UInteger" or "unsigned long" or "unsigned long long" => "ulong",
            "NS::Integer" or "Integer" or "long" or "long long" => "long",
            "unsigned int" or "uint32_t" => "uint",
            "int" or "int32_t" => "int",
            "unsigned short" or "uint16_t" => "ushort",
            "short" or "int16_t" => "short",
            "unsigned char" or "uint8_t" => "byte",
            "char" or "int8_t" => "sbyte",
            "std::uint64_t" or "uint64_t" => "ulong",
            _ => "uint",
        };
    }

    private static string? MapType(string typeStr, string ns, string prefix)
    {
        if (string.IsNullOrWhiteSpace(typeStr))
        {
            return null;
        }

        string t = typeStr.Trim();

        // Reject array types
        if (t.Contains("[]"))
        {
            return null;
        }

        // Strip leading const
        if (t.StartsWith("const "))
        {
            t = t[6..].Trim();
        }

        // Check for function pointers, blocks, std::function, handler types
        // Normalize spaces for consistent checking (ClangSharp may add spaces before & and *)
        string tNorm = t.Replace(" &", "&").Replace(" *", "*");
        if (tNorm.Contains("function<") || tNorm.Contains("block") || tNorm.Contains("Block")
            || tNorm.Contains("(*)") || tNorm.Contains("(^")
            || tNorm.Contains("Handler")
            || tNorm.EndsWith("Function") || tNorm.EndsWith("Function&"))
        {
            return null;
        }

        // Handle class prefix like "class "
        if (t.StartsWith("class "))
        {
            t = t[6..].Trim();
        }

        // Handle pointer types
        if (t.EndsWith('*'))
        {
            string inner = t[..^1].Trim();

            // Strip trailing const
            if (inner.EndsWith("const"))
            {
                inner = inner[..^5].Trim();
            }

            // Strip leading const again
            if (inner.StartsWith("const "))
            {
                inner = inner[6..].Trim();
            }

            // void*
            if (inner == "void")
            {
                return "nint";
            }

            // char* / const char*
            if (inner == "char" || inner == "unsigned char")
            {
                return "nint";
            }

            // Primitive pointer types (e.g., float*, int*)
            if (inner is "float" or "double" or "int" or "uint" or "long"
                or "short" or "uint8_t" or "uint16_t" or "uint32_t" or "uint64_t"
                or "int8_t" or "int16_t" or "int32_t" or "int64_t" or "size_t")
            {
                return "nint";
            }

            // Double pointer (e.g., NS::Object**)
            if (inner.EndsWith('*'))
            {
                return "nint";
            }

            // Qualified class pointer: NS::ClassName*
            return MapClassPointer(inner, ns, prefix);
        }

        // Handle reference types
        if (t.EndsWith('&'))
        {
            string inner = t[..^1].Trim();

            if (inner.StartsWith("const "))
            {
                inner = inner[6..].Trim();
            }

            if (inner == "char")
            {
                return "nint";
            }

            // Treat as pointer
            return MapClassPointer(inner, ns, prefix);
        }

        // Primitive types
        return t switch
        {
            "void" => "void",
            "bool" => "Bool8",
            "char" or "unsigned char" => "byte",
            "short" => "short",
            "unsigned short" => "ushort",
            "int" => "int",
            "unsigned int" => "uint",
            "long" or "long long" => "nint",
            "unsigned long" or "unsigned long long" => "nuint",
            "float" => "float",
            "double" => "double",
            "int8_t" => "sbyte",
            "uint8_t" => "byte",
            "int16_t" => "short",
            "uint16_t" => "ushort",
            "int32_t" => "int",
            "uint32_t" => "uint",
            "int64_t" => "nint",
            "uint64_t" => "nuint",
            "size_t" => "nuint",
            _ => MapQualifiedType(t, ns, prefix),
        };
    }

    private static string? MapQualifiedType(string t, string ns, string prefix)
    {
        // Handle NS:: qualified types
        if (t.StartsWith("NS::"))
        {
            string nsType = t[4..];

            return nsType switch
            {
                "UInteger" => "nuint",
                "Integer" => "nint",
                "String" => "NSString",
                "Error" => "NSError",
                "Array" => "NSArray",
                "URL" => "NSURL",
                "Range" => "NSRange",
                "Number" or "Data" or "Dictionary" or "Object" or "Bundle"
                    or "Notification" or "ProcessInfo" or "Set" => "nint",
                _ => MapGenericClassName(nsType, "NS"),
            };
        }

        // Handle MTL:: qualified types
        if (t.StartsWith("MTL::"))
        {
            string mtlType = t[5..];

            return MapGenericClassName(mtlType, "MTL");
        }

        // Handle MTL4:: qualified types
        if (t.StartsWith("MTL4::"))
        {
            string mtl4Type = t[6..];

            return MapGenericClassName(mtl4Type, "MTL4");
        }

        // Handle CA:: qualified types
        if (t.StartsWith("CA::"))
        {
            string caType = t[4..];

            if (caType == "Texture")
            {
                return "nint";
            }

            return MapGenericClassName(caType, "CA");
        }

        // Handle MTLFX:: qualified types
        if (t.StartsWith("MTLFX::"))
        {
            string mtlfxType = t[7..];

            return MapGenericClassName(mtlfxType, "MTLFX");
        }

        // Handle MTL4FX:: qualified types
        if (t.StartsWith("MTL4FX::"))
        {
            string mtl4fxType = t[8..];

            return MapGenericClassName(mtl4fxType, "MTL4FX");
        }

        // Handle simd:: qualified types (e.g., simd::float4x4)
        if (t.StartsWith("simd::"))
        {
            return "nint";
        }

        // Typedefs not namespace-qualified
        return t switch
        {
            "UInteger" => "nuint",
            "Integer" => "nint",
            "CFTimeInterval" => "double",
            "IOSurfaceRef" => "nint",
            "CGColorSpaceRef" => "nint",
            "dispatch_queue_t" => "nint",
            "dispatch_data_t" => "nint",
            "task_id_token_t" => "nint",
            "kern_return_t" => "uint",
            "CGSize" => "CGSize",
            "GPUAddress" => "nuint",
            _ => MapGenericClassName(t, prefix),
        };
    }

    private static string? MapClassPointer(string className, string ns, string prefix)
    {
        // Strip const
        if (className.StartsWith("const "))
        {
            className = className[6..].Trim();
        }

        // Handle class prefix
        if (className.StartsWith("class "))
        {
            className = className[6..].Trim();
        }

        // Void pointer already handled
        if (className == "void")
        {
            return "nint";
        }

        if (className == "char" || className == "unsigned char")
        {
            return "nint";
        }

        // Handle qualified names with ::
        if (className.Contains("::"))
        {
            return MapQualifiedType(className, ns, prefix);
        }

        return MapGenericClassName(className, prefix);
    }

    private static string? MapGenericClassName(string name, string prefix)
    {
        // Skip handler/callback types (std::function wrappers and block types)
        if (name.Contains("Handler"))
        {
            return null;
        }

        // Special class name mappings
        string? mapped = name switch
        {
            "String" => "NSString",
            "Error" => "NSError",
            "Array" => "NSArray",
            "URL" => "NSURL",
            "Number" or "Data" or "Dictionary" or "Object" or "Bundle"
                or "Notification" or "ProcessInfo" or "Set" or "float4x4" => "nint",
            "Referencing" or "Copying" or "SecureCoding" or "_Base" => null,
            "Architecture" or "AccelerationStructureSizes" => "nint",
            // C++ typedef aliases that resolve to existing types or primitives
            "Coordinate2D" or "SamplePosition" => "MTLSamplePosition",
            "AutoreleasedArgument" => "MTLArgument",
            "AutoreleasedComputePipelineReflection" => "MTLComputePipelineReflection",
            "AutoreleasedRenderPipelineReflection" => "MTLRenderPipelineReflection",
            "Timestamp" or "GPUAddress" => "nuint",
            _ => "!UNMAPPED!",
        };

        if (mapped != "!UNMAPPED!")
        {
            return mapped;
        }

        // If name already has a known prefix, use it directly
        if (name.StartsWith("MTL") || name.StartsWith("CA") || name.StartsWith("NS") || name.StartsWith("MTLFX"))
        {
            return name;
        }

        string fullName = $"{prefix}{name}";

        if (ValueStructs.Contains(fullName))
        {
            return fullName;
        }

        return fullName;
    }

    private static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        return char.ToUpperInvariant(s[0]) + s[1..];
    }

    /// <summary>Returns true if the given type name is a known value struct.</summary>
    public static bool IsKnownValueStruct(string type) => ValueStructs.Contains(type);

    /// <summary>Returns true if the given type name represents an Objective-C wrapper.</summary>
    public static bool IsObjCWrapper(string type)
    {
        if (ValueStructs.Contains(type) || IsLikelyEnum(type))
        {
            return false;
        }

        return type.StartsWith("MTL") || type.StartsWith("NS") || type.StartsWith("CA");
    }

    /// <summary>Returns true if the given type name is likely an enum based on naming conventions.</summary>
    public static bool IsLikelyEnum(string type)
    {
        if (KnownWrapperTypes.Contains(type))
        {
            return false;
        }

        if (ValueStructs.Contains(type))
        {
            return false;
        }

        if (!type.StartsWith("MTL"))
        {
            return false;
        }

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

    /// <summary>Returns true if the given name is a C# keyword.</summary>
    public static bool IsCSharpKeyword(string name) => CSharpKeywords.Contains(name);

    private sealed class RawMethodDecl(string name, string returnType, bool isStatic, List<RawParamInfo> @params, Stmt? body = null)
    {
        public string Name { get; } = name;

        public string ReturnType { get; } = returnType;

        public bool IsStatic { get; } = isStatic;

        public List<RawParamInfo> Params { get; } = @params;

        public Stmt? Body { get; } = body;
    }

    private sealed class RawParamInfo(string type, string name)
    {
        public string Type { get; } = type;

        public string Name { get; } = name;
    }
}
