using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Metal.NET.Generator;

[Generator(LanguageNames.CSharp)]
public class MetalBindingsGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Collect all .hpp files marked as AdditionalFiles (metal-cpp headers)
        var hppFiles = context.AdditionalTextsProvider
            .Where(static f => f.Path.EndsWith(".hpp"))
            .Select(static (text, ct) => (
                FileName: Path.GetFileName(text.Path),
                Content: text.GetText(ct)?.ToString() ?? ""));

        context.RegisterSourceOutput(hppFiles.Collect(), ExecuteHpp);
    }

    // ──────────────────── Direct .hpp processing ────────────────────

    private void ExecuteHpp(SourceProductionContext ctx,
        ImmutableArray<(string FileName, string Content)> files)
    {
        if (files.Length == 0) return;

        // Step 1: Parse selector definitions from *Private.hpp files
        var selectorMap = new Dictionary<string, string>();
        foreach (var (fileName, content) in files)
        {
            if (fileName.EndsWith("Private.hpp"))
            {
                var sels = HeaderClassParser.ParseSelectorDefs(content);
                foreach (var kv in sels)
                {
                    if (!selectorMap.ContainsKey(kv.Key))
                        selectorMap[kv.Key] = kv.Value;
                }
            }
        }

        // Step 2: Parse enums from MTL*.hpp and MTLFX*.hpp files
        var allEnums = new List<EnumDef>();
        foreach (var (fileName, content) in files)
        {
            if (!fileName.StartsWith("MTL")) continue;

            var enums = HeaderEnumParser.Parse(content);
            allEnums.AddRange(enums);
        }

        // Deduplicate enums by name
        var seenEnums = new Dictionary<string, EnumDef>();
        foreach (var e in allEnums)
        {
            if (!seenEnums.ContainsKey(e.Name))
                seenEnums[e.Name] = e;
        }

        foreach (var e in seenEnums.Values.OrderBy(e => e.Name))
        {
            GenerateEnumDef(ctx, e);
        }

        // Step 3: Parse extern "C" free functions from header files
        var freeFunctionsByClass = new Dictionary<string, List<FreeFunctionDef>>();
        foreach (var (fileName, content) in files)
        {
            var freeFuncs = HeaderClassParser.ParseFreeFunctions(content);
            foreach (var f in freeFuncs)
            {
                if (!freeFunctionsByClass.TryGetValue(f.TargetClass, out var list))
                {
                    list = new List<FreeFunctionDef>();
                    freeFunctionsByClass[f.TargetClass] = list;
                }
                list.Add(f);
            }
        }

        // Step 4: Parse classes/protocols from MTL*.hpp files (including MTL4*.hpp)
        var generatedClasses = new HashSet<string>();
        foreach (var (fileName, content) in files)
        {
            var baseName = Path.GetFileNameWithoutExtension(fileName);
            if (!baseName.StartsWith("MTL")) continue;

            // Skip Private, Defines, HeaderBridge files
            if (baseName.EndsWith("Private") || baseName == "MTLDefines" ||
                baseName == "MTLHeaderBridge" || baseName == "MTLFXDefines")
                continue;

            var classes = HeaderClassParser.Parse(content, baseName, selectorMap);
            foreach (var cls in classes)
            {
                if (generatedClasses.Add(cls.Name))
                {
                    freeFunctionsByClass.TryGetValue(cls.Name, out var freeFuncs);
                    GenerateObjCClassDef(ctx, cls, freeFuncs);
                }
            }
        }

        // Step 5: Parse QuartzCore CA*.hpp files
        foreach (var (fileName, content) in files)
        {
            var baseName = Path.GetFileNameWithoutExtension(fileName);
            if (!baseName.StartsWith("CA")) continue;

            var classes = HeaderClassParser.Parse(content, baseName, selectorMap);
            foreach (var cls in classes)
            {
                if (!cls.Name.StartsWith("CA"))
                    cls.Name = $"CA{cls.Name.TrimStart('M', 'T', 'L')}";

                if (generatedClasses.Add(cls.Name))
                {
                    freeFunctionsByClass.TryGetValue(cls.Name, out var freeFuncs);
                    GenerateObjCClassDef(ctx, cls, freeFuncs);
                }
            }
        }

        // Step 6: Parse Foundation NS*.hpp files
        foreach (var (fileName, content) in files)
        {
            var baseName = Path.GetFileNameWithoutExtension(fileName);
            if (!baseName.StartsWith("NS")) continue;

            // Only generate a whitelist of Foundation classes that are commonly
            // used in Metal code and have straightforward bindings
            if (!s_generatableNsFiles.Contains(baseName))
                continue;

            var classes = HeaderClassParser.Parse(content, baseName, selectorMap);
            foreach (var cls in classes)
            {
                if (!cls.Name.StartsWith("NS"))
                    cls.Name = $"NS{cls.Name}";

                // Skip NS types that have hand-written Runtime implementations
                // with special C# convenience methods
                if (s_handWrittenNsTypes.Contains(cls.Name))
                    continue;

                if (generatedClasses.Add(cls.Name))
                {
                    freeFunctionsByClass.TryGetValue(cls.Name, out var freeFuncs);
                    GenerateObjCClassDef(ctx, cls, freeFuncs);
                }
            }
        }

        // Step 7: Generate stub structs for referenced but undefined types
        var referencedTypes = CollectReferencedTypes(generatedClasses);
        var missingTypes = new HashSet<string>();
        foreach (var t in referencedTypes)
        {
            if (!generatedClasses.Contains(t) && !seenEnums.ContainsKey(t))
                missingTypes.Add(t);
        }
        foreach (var missingType in missingTypes.OrderBy(t => t))
        {
            GenerateStubStruct(ctx, missingType);
            generatedClasses.Add(missingType);
        }
    }

    /// <summary>
    /// Collects all ObjC wrapper types referenced by generated classes
    /// (from properties and method parameters/return types).
    /// </summary>
    private HashSet<string> CollectReferencedTypes(HashSet<string> generatedClasses)
    {
        // We can't easily introspect the already-generated code, so we maintain a static list
        // of known referenced-but-empty types that commonly appear in Metal headers.
        return new HashSet<string>
        {
            "MTLLogState", "MTLLogContainer",
            "MTLFXFrameInterpolatableScaler",
            "MTL4FunctionDescriptor",
            "MTLIntersectionFunctionDescriptor",
        };
    }

    private void GenerateStubStruct(SourceProductionContext ctx, string typeName)
    {
        var sb = new StringBuilder();
        sb.AppendLine("// <auto-generated />");
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();
        sb.AppendLine($"/// <summary>Stub wrapper for {typeName} (methods not yet bound).</summary>");
        sb.AppendLine("[StructLayout(LayoutKind.Sequential)]");
        sb.AppendLine($"public readonly struct {typeName}");
        sb.AppendLine("{");
        sb.AppendLine("    public readonly nint NativePtr;");
        sb.AppendLine();
        sb.AppendLine($"    public {typeName}(nint ptr) => NativePtr = ptr;");
        sb.AppendLine();
        sb.AppendLine("    public bool IsNull => NativePtr == 0;");
        sb.AppendLine();
        sb.AppendLine($"    public static implicit operator nint({typeName} o) => o.NativePtr;");
        sb.AppendLine($"    public static implicit operator {typeName}(nint ptr) => new {typeName}(ptr);");
        sb.AppendLine("}");

        ctx.AddSource($"{typeName}.g.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
    }

    // ──────────────────── Enum generation ────────────────────

    private void GenerateEnumDef(SourceProductionContext ctx, EnumDef e)
    {
        var sb = new StringBuilder();
        sb.AppendLine("// <auto-generated />");
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        if (e.IsFlags) sb.AppendLine("[System.Flags]");
        sb.AppendLine($"public enum {e.Name} : {e.UnderlyingType}");
        sb.AppendLine("{");
        for (int i = 0; i < e.Members.Count; i++)
        {
            var m = e.Members[i];
            var comma = i < e.Members.Count - 1 ? "," : "";
            sb.AppendLine($"    {m.Name} = {m.Value}{comma}");
        }
        sb.AppendLine("}");

        ctx.AddSource($"{e.Name}.g.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
    }

    // ──────────────────── ObjC class / protocol generation ────────────────────

    private void GenerateObjCClassDef(SourceProductionContext ctx, ObjCClassDef def,
        List<FreeFunctionDef>? freeFunctions = null)
    {
        // Collect all unique selectors we need
        var selectors = new Dictionary<string, string>(); // selectorString -> fieldName

        foreach (var p in def.Properties)
        {
            var getSel = p.GetSelector ?? p.Name;
            AddSelector(selectors, getSel);
            if (!p.Readonly)
            {
                var setSel = p.SetSelector ?? $"set{Capitalize(p.Name)}:";
                AddSelector(selectors, setSel);
            }
        }
        foreach (var m in def.Methods) AddSelector(selectors, m.Selector);
        foreach (var m in def.StaticMethods) AddSelector(selectors, m.Selector);

        var sb = new StringBuilder();
        sb.AppendLine("// <auto-generated />");
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        // ── Selector cache ──
        sb.AppendLine($"internal static class {def.Name}_Selectors");
        sb.AppendLine("{");
        foreach (var kv in selectors)
        {
            sb.AppendLine($"    internal static readonly Selector {kv.Value} = Selector.Register(\"{kv.Key}\");");
        }
        sb.AppendLine("}");
        sb.AppendLine();

        // ── Struct wrapper ──
        sb.AppendLine("[StructLayout(LayoutKind.Sequential)]");
        sb.AppendLine($"public readonly struct {def.Name}");
        sb.AppendLine("{");
        sb.AppendLine("    public readonly nint NativePtr;");
        sb.AppendLine();
        sb.AppendLine($"    public {def.Name}(nint ptr) => NativePtr = ptr;");
        sb.AppendLine();
        sb.AppendLine("    public bool IsNull => NativePtr == 0;");
        sb.AppendLine();
        sb.AppendLine($"    public static implicit operator nint({def.Name} o) => o.NativePtr;");
        sb.AppendLine($"    public static implicit operator {def.Name}(nint ptr) => new {def.Name}(ptr);");
        sb.AppendLine();

        // ── Alloc (for classes) ──
        bool hasStaticMethods = def.StaticMethods.Count > 0;
        if (def.IsClass && def.ObjCClass != null)
        {
            sb.AppendLine($"    private static readonly nint s_class = ObjectiveCRuntime.GetClass(\"{def.ObjCClass}\");");
            sb.AppendLine();
            sb.AppendLine($"    public static {def.Name} Alloc()");
            sb.AppendLine("    {");
            sb.AppendLine("        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register(\"alloc\"));");
            sb.AppendLine($"        return new {def.Name}(ptr);");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine($"    public {def.Name} Init()");
            sb.AppendLine("    {");
            sb.AppendLine("        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register(\"init\"));");
            sb.AppendLine($"        return new {def.Name}(ptr);");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine($"    public static {def.Name} New()");
            sb.AppendLine("    {");
            sb.AppendLine("        return Alloc().Init();");
            sb.AppendLine("    }");
            sb.AppendLine();
        }
        else if (hasStaticMethods)
        {
            // Types with static factory methods need s_class even if not a "descriptor" class
            sb.AppendLine($"    private static readonly nint s_class = ObjectiveCRuntime.GetClass(\"{def.Name}\");");
            sb.AppendLine();
        }

        // ── Properties ──
        foreach (var p in def.Properties)
        {
            var getSel = SelectorFieldName(p.GetSelector ?? p.Name);
            var retCSharp = MapReturnCall(p.Type);
            var propName = ToPascalCase(p.Name);

            // Skip properties whose getter returns a value struct (needs objc_msgSend_stret)
            if (retCSharp.Invoke.Contains("TODO"))
            {
                sb.AppendLine($"    // TODO: {propName} (value-struct return type {p.Type} requires objc_msgSend_stret)");
                sb.AppendLine();
                continue;
            }

            sb.AppendLine($"    public {p.Type} {propName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => {WrapReturn(p.Type, $"{retCSharp.Invoke}(NativePtr, {def.Name}_Selectors.{getSel})")};");

            if (!p.Readonly)
            {
                var setSel = SelectorFieldName(p.SetSelector ?? $"set{Capitalize(p.Name)}:");
                var setCall = MapSetCall(p.Type);
                sb.AppendLine($"        set => ObjectiveCRuntime.{setCall}(NativePtr, {def.Name}_Selectors.{setSel}, {UnwrapParam(p.Type, "value")});");
            }
            sb.AppendLine("    }");
            sb.AppendLine();
        }

        // ── Instance methods ──
        foreach (var m in def.Methods)
        {
            EmitMethod(sb, def.Name, m, isStatic: false);
        }

        // ── Static methods ──
        foreach (var m in def.StaticMethods)
        {
            EmitMethod(sb, def.Name, m, isStatic: true);
        }

        // ── Free C functions (DllImport) ──
        if (freeFunctions != null && freeFunctions.Count > 0)
        {
            foreach (var f in freeFunctions)
            {
                EmitFreeFunction(sb, f);
            }
        }

        // Retain / Release helpers
        sb.AppendLine("    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);");
        sb.AppendLine("    public void Release() => ObjectiveCRuntime.Release(NativePtr);");

        sb.AppendLine("}");

        ctx.AddSource($"{def.Name}.g.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
    }

    // ── Helpers ──

    private void EmitMethod(StringBuilder sb, string typeName, MethodDef m, bool isStatic)
    {
        var selField = $"{typeName}_Selectors.{SelectorFieldName(m.Selector)}";
        var retType = m.ReturnType;
        var methodName = ToPascalCase(m.Name);

        // Build parameter list
        var paramList = new List<string>();
        foreach (var p in m.Parameters)
        {
            paramList.Add($"{p.Type} {p.Name}");
        }
        if (m.HasErrorOut) paramList.Add("out NSError error");

        var paramsStr = string.Join(", ", paramList);
        var staticMod = isStatic ? "static " : "";
        var receiver = isStatic ? "s_class" : "NativePtr";

        // Determine which objc_msgSend variant to use
        var retCall = MapReturnCall(retType);

        // Skip methods whose return type requires stret (value struct return)
        if (retCall.Invoke.Contains("TODO"))
        {
            sb.AppendLine($"    // TODO: {methodName} (value-struct return type {retType} requires objc_msgSend_stret)");
            sb.AppendLine();
            return;
        }

        sb.AppendLine($"    public {staticMod}{retType} {methodName}({paramsStr})");
        sb.AppendLine("    {");

        // Build args for objc_msgSend
        var argParts = new List<string> { receiver, selField };
        foreach (var p in m.Parameters)
        {
            argParts.Add(UnwrapParam(p.Type, p.Name));
        }
        if (m.HasErrorOut) argParts.Add("out error");

        var argsStr = string.Join(", ", argParts);
        var hasParams = m.Parameters.Count > 0 || m.HasErrorOut;

        // Special case: Bool8/bool return with params — bool8_objc_msgSend has no param overloads
        if (retType == "Bool8" && hasParams)
        {
            sb.AppendLine($"        return (byte)ObjectiveCRuntime.intptr_objc_msgSend({argsStr}) != 0;");
        }
        else if (retType == "bool" && hasParams)
        {
            sb.AppendLine($"        return (byte)ObjectiveCRuntime.intptr_objc_msgSend({argsStr}) != 0;");
        }
        // Special case: nuint return with params — nuint_objc_msgSend has no param overloads
        else if (retType == "nuint" && hasParams)
        {
            sb.AppendLine($"        return (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend({argsStr});");
        }
        // Special case: float return with params — float_objc_msgSend has no param overloads
        else if (retType == "float" && hasParams)
        {
            sb.AppendLine($"        return BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend({argsStr}));");
        }
        // Special case: double return with params — double_objc_msgSend has no param overloads
        else if (retType == "double" && hasParams)
        {
            sb.AppendLine($"        return BitConverter.Int64BitsToDouble((long)ObjectiveCRuntime.intptr_objc_msgSend({argsStr}));");
        }
        // Special case: uint/enum return with params — uint_objc_msgSend has no param overloads
        else if (retType == "uint" && hasParams)
        {
            sb.AppendLine($"        return (uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend({argsStr});");
        }
        // Enum return with params — use intptr and cast
        else if (IsLikelyEnum(retType) && hasParams)
        {
            sb.AppendLine($"        return ({retType})(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend({argsStr});");
        }
        // Special case: ulong return with params — ulong_objc_msgSend may not have param overloads
        else if (retType == "ulong" && hasParams)
        {
            sb.AppendLine($"        return (ulong)ObjectiveCRuntime.intptr_objc_msgSend({argsStr});");
        }
        else if (retType == "void")
        {
            sb.AppendLine($"        ObjectiveCRuntime.objc_msgSend({argsStr});");
        }
        else
        {
            sb.AppendLine($"        var __result = {retCall.Invoke}({argsStr});");
            sb.AppendLine($"        return {WrapReturnVar(retType, "__result")};");
        }

        sb.AppendLine("    }");
        sb.AppendLine();
    }

    /// <summary>
    /// Emits a static P/Invoke wrapper for a free C function (e.g., MTLCreateSystemDefaultDevice).
    /// </summary>
    private void EmitFreeFunction(StringBuilder sb, FreeFunctionDef f)
    {
        // Build public parameter list
        var publicParams = new List<string>();
        // Build private extern parameter list (all ObjC wrappers become nint)
        var externParams = new List<string>();
        // Build argument forwarding list (unwrap wrappers)
        var forwardArgs = new List<string>();

        foreach (var p in f.Parameters)
        {
            publicParams.Add($"{p.Type} {p.Name}");

            if (IsObjCWrapper(p.Type))
            {
                externParams.Add($"nint {p.Name}");
                forwardArgs.Add($"{p.Name}.NativePtr");
            }
            else
            {
                externParams.Add($"{p.Type} {p.Name}");
                forwardArgs.Add(p.Name);
            }
        }

        var externParamsStr = string.Join(", ", externParams);
        var publicParamsStr = string.Join(", ", publicParams);
        var forwardArgsStr = string.Join(", ", forwardArgs);

        // Determine the extern return type (ObjC wrappers → nint)
        bool wrapReturn = f.ReturnType != "void" && f.ReturnType != "nint"
            && IsObjCWrapper(f.ReturnType);
        var externReturnType = wrapReturn ? "nint" : f.ReturnType;

        // Emit the DllImport declaration as a private static extern
        sb.AppendLine($"    [DllImport(\"{f.FrameworkLibrary}\")]");
        sb.AppendLine($"    private static extern {externReturnType} {f.NativeName}({externParamsStr});");
        sb.AppendLine();

        // Emit the public static wrapper method
        sb.AppendLine($"    public static {f.ReturnType} {ToPascalCase(f.Name)}({publicParamsStr})");
        sb.AppendLine("    {");
        if (f.ReturnType == "void")
        {
            sb.AppendLine($"        {f.NativeName}({forwardArgsStr});");
        }
        else if (wrapReturn)
        {
            sb.AppendLine($"        return new {f.ReturnType}({f.NativeName}({forwardArgsStr}));");
        }
        else
        {
            sb.AppendLine($"        return {f.NativeName}({forwardArgsStr});");
        }
        sb.AppendLine("    }");
        sb.AppendLine();
    }
    private static (string Invoke, bool NeedsWrap) MapReturnCall(string type)
    {
        return type switch
        {
            "void" => ("ObjectiveCRuntime.objc_msgSend", false),
            "Bool8" or "bool" => ("ObjectiveCRuntime.bool8_objc_msgSend", false),
            "uint" => ("ObjectiveCRuntime.uint_objc_msgSend", false),
            "ulong" => ("ObjectiveCRuntime.ulong_objc_msgSend", false),
            "float" => ("ObjectiveCRuntime.float_objc_msgSend", false),
            "double" => ("ObjectiveCRuntime.double_objc_msgSend", false),
            "nuint" => ("ObjectiveCRuntime.nuint_objc_msgSend", false),
            "nint" => ("ObjectiveCRuntime.intptr_objc_msgSend", false),
            // Value structs cannot be returned via intptr_objc_msgSend; skip generation.
            _ when IsKnownValueStruct(type) => ("/* TODO: stret */", false),
            // Enum types: return as uint and cast to enum
            _ when IsLikelyEnum(type) => ("ObjectiveCRuntime.uint_objc_msgSend", false),
            // Anything else (struct wrappers like MTLCommandQueue, NSString, etc.)
            // is returned as nint and wrapped in the struct constructor.
            _ => ("ObjectiveCRuntime.intptr_objc_msgSend", true),
        };
    }

    /// <summary>Wraps a return expression for enum types that need casting.</summary>
    private static string WrapReturnEnum(string type, string expr)
    {
        if (IsLikelyEnum(type))
            return $"({type}){expr}";
        return expr;
    }

    private static string WrapReturn(string type, string expr)
    {
        if (IsLikelyEnum(type))
            return $"({type})({expr})";
        var call = MapReturnCall(type);
        if (!call.NeedsWrap) return expr;
        return $"new {type}({expr})";
    }

    private static string WrapReturnVar(string type, string varName)
    {
        if (IsLikelyEnum(type))
            return $"({type}){varName}";
        var call = MapReturnCall(type);
        if (!call.NeedsWrap) return varName;
        return $"new {type}({varName})";
    }

    private static string MapSetCall(string type)
    {
        // All setters go through objc_msgSend; the difference is in how we unwrap the value.
        return "objc_msgSend";
    }

    /// <summary>
    /// Convert a parameter to the form needed for objc_msgSend.
    /// All register-sized values are cast to IntPtr to match uniform overloads.
    /// Value structs and float/double are passed as-is.
    /// </summary>
    private static string UnwrapParam(string type, string name)
    {
        // Value structs are passed by value directly
        if (IsKnownValueStruct(type)) return name;

        // Float/double have dedicated overloads
        if (type is "float" or "double") return name;

        // nint is already the target type
        if (type is "nint") return name;

        // nuint → nint (same register size)
        if (type is "nuint") return $"(nint){name}";

        // Enum types → cast to uint then to nint
        if (IsLikelyEnum(type)) return $"(nint)(uint){name}";

        // ObjC wrappers → .NativePtr (which is nint)
        if (IsObjCWrapper(type)) return $"{name}.NativePtr";

        // Bool8 → nint
        if (type is "Bool8") return $"(nint){name}.Value";
        if (type is "bool") return $"(nint)({name} ? 1 : 0)";

        // Numeric primitives → nint
        if (type is "uint" or "int" or "byte" or "sbyte" or "short" or "ushort")
            return $"(nint){name}";
        if (type is "ulong" or "long")
            return $"(nint){name}";

        // Fallback — assume ObjC wrapper
        return $"(nint){name}";
    }

    private static bool IsObjCWrapper(string type)
    {
        // ObjC wrapper types: start with MTL/NS/CA, not value structs, not enums, not primitives
        if (IsKnownValueStruct(type) || IsLikelyEnum(type)) return false;
        return type.StartsWith("MTL") || type.StartsWith("NS") || type.StartsWith("CA");
    }

    private static bool IsKnownValueStruct(string type)
    {
        return type is "MTLOrigin" or "MTLSize" or "MTLRegion" or "MTLViewport"
            or "MTLScissorRect" or "MTLClearColor" or "MTLSamplePosition" or "CGSize"
            or "MTLSizeAndAlign";
    }

    // Known ObjC wrapper class/protocol types that should NOT be treated as enums
    // even though their names end with enum-like suffixes.
    private static readonly System.Collections.Generic.HashSet<string> s_knownWrapperTypes = new()
    {
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
        // Types ending with common enum suffixes but actually ObjC classes/protocols
        "MTLArrayType", "MTLStructType", "MTLPointerType", "MTLType",
        "MTLTextureReferenceType", "MTLTensorReferenceType",
        "MTLCaptureScope", "MTLCounterSet", "MTLResidencySet",
        "MTLComputePipelineReflection", "MTLRenderPipelineReflection",
        "MTLFunctionReflection",
        "MTL4BinaryFunction", "MTL4MachineLearningPipelineState",
        "MTL4MachineLearningPipelineReflection", "MTL4PipelineOptions",
        "MTLFunctionLogDebugLocation",
    };

    // NS types that have hand-written Runtime implementations with special C# methods
    private static readonly System.Collections.Generic.HashSet<string> s_handWrittenNsTypes = new()
    {
        "NSString", "NSError", "NSArray",
    };

    // Foundation files that are safe to generate (simple bindings, no complex C++ templates)
    private static readonly System.Collections.Generic.HashSet<string> s_generatableNsFiles = new()
    {
        "NSURL",
    };

    private static bool IsLikelyEnum(string type)
    {
        // Exclude known wrapper types first
        if (s_knownWrapperTypes.Contains(type)) return false;

        // Enum types in Metal follow a naming convention
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

    private static void AddSelector(Dictionary<string, string> dict, string selector)
    {
        if (!dict.ContainsKey(selector))
        {
            dict[selector] = SelectorFieldName(selector);
        }
    }

    private static string SelectorFieldName(string selector)
    {
        // "newBufferWithLength:options:" -> "newBufferWithLength_options_"
        var name = selector.Replace(":", "_");
        // Escape C# keywords
        if (HeaderTypeMapper.IsCSharpKeyword(name))
            name = $"@{name}";
        return name;
    }

    private static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return char.ToUpperInvariant(s[0]) + s.Substring(1);
    }

    /// <summary>
    /// Converts a camelCase method/property name to PascalCase.
    /// Preserves well-known prefixes like MTL, CA, NS, GPU, CPU, MTLFX, etc.
    /// Handles @-prefixed keywords by stripping @ and capitalizing.
    /// </summary>
    private static string ToPascalCase(string name)
    {
        if (string.IsNullOrEmpty(name)) return name;

        // Strip @ prefix (C# keyword escape)
        if (name.StartsWith("@"))
            name = name.Substring(1);

        // Already PascalCase (starts with uppercase or well-known prefix)
        if (char.IsUpper(name[0]))
            return name;

        // Simple capitalize first letter
        return char.ToUpperInvariant(name[0]) + name.Substring(1);
    }
}
