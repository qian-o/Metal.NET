using System.Text;

namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
class CSharpEmitter(string outputDir, GeneratorContext context, TypeMapper typeMapper)
{
    /// <summary>Hand-written classes to skip during generation.</summary>
    static readonly HashSet<string> SkipClasses =
    [
        "NSString",
        "NSError",
        "NSArray",
        "NSURL",
        "NSDictionary",
        "NSNotification",
        "NSNotificationCenter",
        "NSSet",
        "NSEnumerator",
        "NSObject",
        "NSProcessInfo",
        "NSBundle",
        "NSAutoreleasePool",
        "NSNumber",
        "NSValue",
        "NSDate"
    ];

    /// <summary>Hand-written structs to skip during generation (located in Common/Structs.cs).</summary>
    static readonly HashSet<string> SkipStructs =
    [
        "CGSize",
        "SimdFloat4",
        "SimdFloat4x4"
    ];

    /// <summary>
    /// Maps (ClassName, MemberName) → element type for NSArray properties and methods.
    /// Used to resolve typed arrays from the Objective-C Metal API.
    /// </summary>
    static readonly Dictionary<(string Class, string Member), string> NSArrayElementTypes = new()
    {
        // MTLDevice
        { ("MTLDevice", "CounterSets"), "MTLCounterSet" },
        { ("MTLDevice", "CopyAllDevices"), "MTLDevice" },
        { ("MTLDevice", "NewArgumentEncoder"), "MTLArgumentDescriptor" },
        // MTLCounterSet
        { ("MTLCounterSet", "Counters"), "MTLCounter" },
        // MTLLibrary
        { ("MTLLibrary", "FunctionNames"), "NSString" },
        // MTLFunction
        { ("MTLFunction", "StageInputAttributes"), "MTLAttribute" },
        { ("MTLFunction", "VertexAttributes"), "MTLVertexAttribute" },
        // MTLStructType
        { ("MTLStructType", "Members"), "MTLStructMember" },
        // MTLResidencySet
        { ("MTLResidencySet", "AllAllocations"), "MTLAllocation" },
        // MTLCommandBufferEncoderInfo
        { ("MTLCommandBufferEncoderInfo", "DebugSignposts"), "NSString" },
        // MTLInstanceAccelerationStructureDescriptor
        { ("MTLInstanceAccelerationStructureDescriptor", "InstancedAccelerationStructures"), "MTLAccelerationStructure" },
        // MTLFunctionStitchingGraph
        { ("MTLFunctionStitchingGraph", "Attributes"), "MTLFunctionStitchingAttribute" },
        { ("MTLFunctionStitchingGraph", "Nodes"), "MTLFunctionStitchingFunctionNode" },
        // MTLFunctionStitchingFunctionNode
        { ("MTLFunctionStitchingFunctionNode", "ControlDependencies"), "MTLFunctionStitchingFunctionNode" },
        // MTLStitchedLibraryDescriptor
        { ("MTLStitchedLibraryDescriptor", "FunctionGraphs"), "MTLFunctionStitchingGraph" },
        // MTL4CompilerTaskOptions
        { ("MTL4CompilerTaskOptions", "LookupArchives"), "MTL4Archive" },
        // MTLComputePipelineState
        { ("MTLComputePipelineState", "NewComputePipelineStateWithBinaryFunctions"), "MTL4BinaryFunction" },
        { ("MTLComputePipelineState", "NewComputePipelineState"), "MTLFunction" },
        // MTL4MachineLearningPipelineDescriptor
        { ("MTL4MachineLearningPipelineDescriptor", "SetInputDimensions"), "MTLTensorExtents" },
    };

    /// <summary>
    /// Maps a property name suffix to element type for NSArray properties.
    /// Applied when no exact (Class, Property) match is found in NSArrayElementTypes.
    /// </summary>
    static readonly (string Suffix, string ElementType)[] NSArraySuffixRules =
    [
        ("BinaryArchives", "MTLBinaryArchive"),
        ("AdditionalBinaryFunctions", "MTLFunction"),
        ("BinaryLinkedFunctions", "MTL4BinaryFunction"),
        ("BinaryFunctions", "MTLFunction"),
        ("PrivateFunctions", "MTLFunction"),
        ("Functions", "MTLFunction"),
        ("PreloadedLibraries", "MTLDynamicLibrary"),
        ("InsertLibraries", "MTLDynamicLibrary"),
        ("Libraries", "MTLDynamicLibrary"),
        ("GeometryDescriptors", "MTLAccelerationStructureGeometryDescriptor"),
        ("PrivateFunctionDescriptors", "MTL4FunctionDescriptor"),
        ("FunctionDescriptors", "MTL4FunctionDescriptor"),
        ("VertexBuffers", "MTLMotionKeyframeData"),
        ("BoundingBoxBuffers", "MTLMotionKeyframeData"),
        ("ControlPointBuffers", "MTLMotionKeyframeData"),
        ("RadiusBuffers", "MTLMotionKeyframeData"),
        ("Bindings", "MTLBinding"),
        ("Arguments", "MTLArgument"),
    ];

    /// <summary>
    /// Tries to resolve the element type for an NSArray property or method.
    /// Returns null if no mapping is found.
    /// </summary>
    static string? TryResolveNSArrayElementType(string className, string propertyName)
    {
        if (NSArrayElementTypes.TryGetValue((className, propertyName), out string? elementType))
        {
            return elementType;
        }

        foreach ((string suffix, string elemType) in NSArraySuffixRules)
        {
            if (propertyName.EndsWith(suffix, StringComparison.Ordinal))
            {
                return elemType;
            }
        }

        return null;
    }

    /// <summary>
    /// Records a MsgSend overload signature for later generation of ObjectiveC.cs.
    /// </summary>
    void RecordMsgSend(string group, params string[] argTypes)
    {
        string key = string.Join(", ", argTypes);
        if (!context.MsgSendSignatures.TryGetValue(group, out var set))
        {
#pragma warning disable IDE0028 // Collection initialization can be simplified (requires custom comparer)
            set = new SortedSet<string>(StringComparer.Ordinal);
#pragma warning restore IDE0028
            context.MsgSendSignatures[group] = set;
        }
        set.Add(key);
    }

    #region Generation Entry Point

    public void GenerateAll()
    {
        // Group enums by namespace into consolidated files (e.g., MTLEnums.cs, NSEnums.cs, MTLFXEnums.cs)
        var enumsBySubdir = context.Enums.GroupBy(e => TypeMapper.GetOutputSubdir(e.Namespace));
        foreach (var group in enumsBySubdir)
        {
            GenerateEnumFile(group.Key, [.. group]);
        }

        // Group structs by namespace into consolidated files (e.g., MTLStructs.cs)
        var structsBySubdir = context.Structs.GroupBy(s => TypeMapper.GetOutputSubdir(s.Namespace));
        foreach (var group in structsBySubdir)
        {
            GenerateStructFile(group.Key, [.. group]);
        }

        // Generate consolidated delegate file for block type aliases
        if (context.BlockTypeAliases.Count > 0)
        {
            GenerateDelegateFile();
        }

        // Build known class names (both generated and hand-written)
        foreach (ClassDef classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.Namespace);
            context.KnownClassNames.Add(prefix + classDef.Name);
        }
        context.KnownClassNames.UnionWith(["NSObject", "NSString", "NSError", "NSArray", "NSURL", "NSDictionary", "NSNumber", "NSData", "NSBundle", "NativeObject"]);

        // Build a map of class name → property names for inheritance detection
        Dictionary<string, HashSet<string>> classPropertyMap = [];
        foreach (ClassDef classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.Namespace);
            string csClassName = prefix + classDef.Name;
            classPropertyMap[csClassName] =
            [
                .. classDef.Methods.Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget && m.IsConst)
                                   .Select(m => TypeMapper.ToPascalCase(m.Name))
            ];
        }

        // Build inherited property names by walking the inheritance chain
        HashSet<string> GetInheritedProperties(string csClassName)
        {
            HashSet<string> result = [];
            if (!classPropertyMap.ContainsKey(csClassName))
            {
                return result;
            }
            ClassDef classDef = context.Classes.First(c => TypeMapper.GetPrefix(c.Namespace) + c.Name == csClassName);
            string? current = classDef.BaseClassName;
            while (current != null && context.KnownClassNames.Contains(current) && classPropertyMap.TryGetValue(current, out HashSet<string>? parentProps))
            {
                result.UnionWith(parentProps);
                ClassDef? parentDef = context.Classes.FirstOrDefault(c => TypeMapper.GetPrefix(c.Namespace) + c.Name == current);
                current = parentDef?.BaseClassName;
            }
            return result;
        }

        // Build lookup of free functions per target class
        Dictionary<string, List<FreeFunctionDef>> freeFuncsByClass = context.FreeFunctions
            .GroupBy(f => f.TargetClassName)
            .ToDictionary(g => g.Key, g => g.ToList());

        // Record MsgSend signatures used by hand-written Foundation classes
        RecordMsgSend("MsgSend", "nint");

        RecordMsgSend("MsgSendNInt");
        RecordMsgSend("MsgSendNInt", "nint");
        RecordMsgSend("MsgSendNInt", "nint", "nint");
        RecordMsgSend("MsgSendNInt", "Bool8");
        RecordMsgSend("MsgSendNInt", "float");
        RecordMsgSend("MsgSendNInt", "double");
        RecordMsgSend("MsgSendNInt", "int");
        RecordMsgSend("MsgSendNInt", "uint");
        RecordMsgSend("MsgSendNInt", "long");
        RecordMsgSend("MsgSendNInt", "ulong");
        RecordMsgSend("MsgSendNInt", "nuint");

        RecordMsgSend("MsgSendBool");
        RecordMsgSend("MsgSendFloat");
        RecordMsgSend("MsgSendDouble");
        RecordMsgSend("MsgSendInt");
        RecordMsgSend("MsgSendUInt");
        RecordMsgSend("MsgSendLong");
        RecordMsgSend("MsgSendULong");

        RecordMsgSend("MsgSendNUInt");

        // MsgSend with no args is always needed
        RecordMsgSend("MsgSend");

        foreach (ClassDef classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.Namespace);
            string csClassName = prefix + classDef.Name;
            HashSet<string> inheritedProps = GetInheritedProperties(csClassName);
            freeFuncsByClass.TryGetValue(csClassName, out List<FreeFunctionDef>? classFuncs);
            GenerateClass(classDef, inheritedProps, classFuncs ?? []);
        }

        GenerateObjectiveCFile();
    }

    #endregion

    #region Enum Generation

    /// <summary>
    /// Generates a consolidated enum file (e.g., <c>Metal/MTLEnums.cs</c>) containing
    /// all enums for the given output subdirectory.
    /// </summary>
    void GenerateEnumFile(string subdir, List<EnumDef> enums)
    {
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        string fileName = subdir switch
        {
            "Metal" => "MTLEnums.cs",
            "Foundation" => "NSEnums.cs",
            "MetalFX" => "MTLFXEnums.cs",
            _ => $"{subdir}Enums.cs"
        };

        foreach (EnumDef enumDef in enums)
        {
            string prefix = TypeMapper.GetPrefix(enumDef.Namespace);
            string oldFile = Path.Combine(dir, $"{prefix}{enumDef.Name}.cs");
            if (File.Exists(oldFile))
            {
                File.Delete(oldFile);
            }
        }

        StringBuilder sb = new();
        sb.AppendLine("namespace Metal.NET;");

        for (int ei = 0; ei < enums.Count; ei++)
        {
            EnumDef enumDef = enums[ei];
            string prefix = TypeMapper.GetPrefix(enumDef.Namespace);
            string csEnumName = prefix + enumDef.Name;

            sb.AppendLine();

            // Enum-level [Obsolete] from AST
            if (enumDef.Deprecated)
            {
                sb.AppendLine(enumDef.DeprecationMessage is { } dm
                    ? $"[Obsolete(\"{dm}\")]"
                    : "[Obsolete]");
            }

            if (enumDef.IsFlags)
            {
                sb.AppendLine("[Flags]");
            }

            sb.AppendLine($"public enum {csEnumName} : {enumDef.BackingType}");
            sb.AppendLine("{");

            for (int i = 0; i < enumDef.Members.Count; i++)
            {
                EnumMember member = enumDef.Members[i];
                string comma = i < enumDef.Members.Count - 1 ? "," : "";
                if (i > 0)
                {
                    sb.AppendLine();
                }

                sb.AppendLine($"    {member.Name} = {member.Value}{comma}");
            }

            sb.AppendLine("}");
        }

        File.WriteAllText(Path.Combine(dir, fileName), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: {subdir}/{fileName} ({enums.Count} enums)");
    }

    #endregion

    #region Struct Generation

    /// <summary>
    /// Generates a consolidated struct file (e.g., <c>Metal/MTLStructs.cs</c>) containing
    /// all packed structs for the given output subdirectory, with primary constructors.
    /// </summary>
    void GenerateStructFile(string subdir, List<StructDef> structs)
    {
        static string GetCsStructName(StructDef s) => TypeMapper.GetPrefix(s.Namespace) + s.Name;

        // Filter out hand-written structs
        List<StructDef> generatable = [.. structs
            .Where(s => !SkipStructs.Contains(GetCsStructName(s)))];

        if (generatable.Count == 0)
        {
            return;
        }

        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        string fileName = subdir switch
        {
            "Metal" => "MTLStructs.cs",
            "Foundation" => "NSStructs.cs",
            "MetalFX" => "MTLFXStructs.cs",
            _ => $"{subdir}Structs.cs"
        };

        StringBuilder sb = new();
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");

        foreach (StructDef structDef in generatable)
        {
            string csStructName = GetCsStructName(structDef);

            sb.AppendLine();
            sb.AppendLine("[StructLayout(LayoutKind.Sequential)]");

            List<string> ctorParams = [];
            List<string> fieldLines = [];
            foreach (StructFieldDef field in structDef.Fields)
            {
                string csType = TypeMapper.MapType(field.Type);
                string csFieldName = TypeMapper.ToPascalCase(field.Name);
                string csParamName = TypeMapper.ToCamelCase(field.Name);

                ctorParams.Add($"{csType} {csParamName}");
                fieldLines.Add($"    public {csType} {csFieldName} = {csParamName};");
            }

            sb.AppendLine($"public struct {csStructName}({string.Join(", ", ctorParams)})");
            sb.AppendLine("{");

            for (int i = 0; i < fieldLines.Count; i++)
            {
                if (i > 0)
                {
                    sb.AppendLine();
                }
                sb.AppendLine(fieldLines[i]);
            }

            sb.AppendLine("}");
        }

        File.WriteAllText(Path.Combine(dir, fileName), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: {subdir}/{fileName} ({generatable.Count} structs)");
    }

    #endregion

    #region Delegate Generation

    /// <summary>
    /// Generates Metal/MTLDelegates.cs containing sealed handler classes that inherit
    /// NativeBlock. Each class wraps a managed Action callback and bridges it to native
    /// code via an [UnmanagedCallersOnly] trampoline.
    /// </summary>
    void GenerateDelegateFile()
    {
        string dir = Path.Combine(outputDir, "Metal");
        Directory.CreateDirectory(dir);

        StringBuilder sb = new();
        sb.AppendLine("using System.Runtime.CompilerServices;");
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");

        foreach (BlockTypeAlias alias in context.BlockTypeAliases.OrderBy(a => a.CsDelegateName))
        {
            // Skip the first parameter (block pointer) – it's always nint block
            List<BlockParam> callbackParams = [.. alias.Parameters.Skip(1)];

            // Build the strong-typed Action<> argument types and trampoline body
            List<string> actionTypeArgs = [];
            List<string> trampolineArgs = [];
            List<string> callbackArgs = [];

            foreach (BlockParam p in callbackParams)
            {
                string strongType = ResolveStrongType(p);
                actionTypeArgs.Add(strongType);

                // Trampoline receives the low-level type
                trampolineArgs.Add($"{p.CsType} {p.Name}");

                // If the strong type is a NativeObject, wrap it; otherwise pass through
                if (strongType != p.CsType)
                {
                    callbackArgs.Add($"new {strongType}({p.Name}, NativeObjectOwnership.Borrowed)");
                }
                else
                {
                    callbackArgs.Add(p.Name);
                }
            }

            string actionType = actionTypeArgs.Count > 0
                ? $"Action<{string.Join(", ", actionTypeArgs)}>"
                : "Action";

            // Build the delegate* unmanaged type for the constructor: <nint, param types..., void>
            List<string> fPtrTypeArgs = ["nint"]; // block pointer
            foreach (BlockParam p in callbackParams)
            {
                fPtrTypeArgs.Add(p.CsType);
            }
            fPtrTypeArgs.Add("void");
            string fPtrType = $"delegate* unmanaged[Cdecl]<{string.Join(", ", fPtrTypeArgs)}>";

            // Trampoline parameter list (includes nint block as first)
            string trampolineParamStr = callbackParams.Count > 0
                ? $"nint block, {string.Join(", ", trampolineArgs)}"
                : "nint block";

            sb.AppendLine();
            sb.AppendLine($"public sealed unsafe class {alias.CsDelegateName}({actionType} callback) : NativeBlock((nint)({fPtrType})&Trampoline, callback)");
            sb.AppendLine("{");
            sb.AppendLine("    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]");
            sb.AppendLine($"    private static void Trampoline({trampolineParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        {actionType} callback = GetContext<{actionType}>(block);");
            sb.AppendLine();
            sb.AppendLine($"        callback({string.Join(", ", callbackArgs)});");
            sb.AppendLine("    }");
            sb.AppendLine("}");
        }

        File.WriteAllText(Path.Combine(dir, "MTLDelegates.cs"), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: Metal/MTLDelegates.cs ({context.BlockTypeAliases.Count} handler classes)");
    }

    /// <summary>
    /// Resolves the strong C# type for a block parameter.
    /// Pointer types that map to known NativeObject classes get their class name;
    /// value types (ulong, long, nuint, nint from void*) pass through unchanged.
    /// </summary>
    static string ResolveStrongType(BlockParam param)
    {
        // Value types pass through directly
        if (!param.ObjCType.TrimEnd().EndsWith('*'))
        {
            return param.CsType;
        }

        // void* stays as nint (e.g., MTLDeallocator's pointer param)
        string stripped = param.ObjCType.TrimEnd().TrimEnd('*').Trim();
        if (stripped is "void" or "")
        {
            return "nint";
        }

        // Use TypeMapper to resolve the strong type
        return TypeMapper.MapType(param.ObjCType);
    }

    #endregion

    #region Class Generation

    /// <summary>
    /// Generates a single C# class file: constructor, properties, methods, indexer,
    /// free-function wrappers, and the companion <c>Bindings</c> selector-lookup class.
    /// </summary>
    void GenerateClass(ClassDef classDef, HashSet<string> inheritedProperties, List<FreeFunctionDef> freeFunctions)
    {
        string prefix = TypeMapper.GetPrefix(classDef.Namespace);
        string csClassName = prefix + classDef.Name;

        if (SkipClasses.Contains(csClassName))
        {
            return;
        }

        string subdir = TypeMapper.GetOutputSubdir(classDef.Namespace);
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        bool hasClassField = classDef.HasAllocInit;
        bool hasFreeFunctions = freeFunctions.Count > 0;

        List<MethodInfo> validMethods =
        [
            .. classDef.Methods.Where(m => !m.Parameters.Any(p => p.Type == "ARRAY_PARAM")
                                            && !HasUnmergableArrayParam(m)
                                            && !HasFunctionPointerParam(m)
                                            && !HasUnmappableParam(m))
        ];

        HashSet<string> hasZeroParamVersion =
        [
            .. validMethods
                .Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget)
                .Select(m => m.Name)
        ];

        (List<PropertyDef> properties, List<MethodInfo> methods) = CategorizeMembers(validMethods);

        // Detect indexer
        MethodInfo? indexerGetter = methods.FirstOrDefault(m =>
            m.Selector is "objectAtIndexedSubscript:"
            || (m.Name == "object" && m.Parameters.Count == 1 && m.ReturnType != "void"));
        MethodInfo? indexerSetter = methods.FirstOrDefault(m =>
            m.Selector is "setObject:atIndexedSubscript:"
            || (m.Name == "setObject" && m.Parameters.Count == 2 && m.ReturnType == "void"));

        List<MethodInfo> nonIndexerMethods = [.. methods
            .Where(m => m != indexerGetter && m != indexerSetter)];

        Dictionary<MethodInfo, string> simplifiedNames = ComputeSimplifiedMethodNames(nonIndexerMethods, properties);

        SortedDictionary<string, string> selectors = [];
        StringBuilder sb = new();

        if (hasFreeFunctions)
        {
            sb.AppendLine("using System.Runtime.InteropServices;");
            sb.AppendLine();
        }

        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        string baseClass = classDef.BaseClassName != null && context.KnownClassNames.Contains(classDef.BaseClassName)
            ? classDef.BaseClassName
            : "NSObject";
        string partialKeyword = hasFreeFunctions ? "partial " : "";

        sb.AppendLine($"public {partialKeyword}class {csClassName}(nint nativePtr, NativeObjectOwnership ownership) : {baseClass}(nativePtr, ownership), INativeObject<{csClassName}>");
        sb.AppendLine("{");
        string newKeyword = baseClass is not "NativeObject" ? "new " : "";
        sb.AppendLine("    #region INativeObject");
        sb.AppendLine($"    public static {newKeyword}{csClassName} Null {{ get; }} = new(0, NativeObjectOwnership.Borrowed);");
        sb.AppendLine();
        sb.AppendLine($"    public static {newKeyword}{csClassName} New(nint nativePtr, NativeObjectOwnership ownership)");
        sb.AppendLine("    {");
        sb.AppendLine("        return new(nativePtr, ownership);");
        sb.AppendLine("    }");
        sb.AppendLine("    #endregion");

        bool hasPrecedingMember = true;

        // Constructor
        if (hasClassField)
        {
            sb.AppendLine();
            sb.AppendLine($"    public {csClassName}() : this(ObjectiveC.AllocInit({csClassName}Bindings.Class), NativeObjectOwnership.Managed)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        // === Properties (in JSON order, no grouping) ===
        foreach (PropertyDef prop in properties)
        {
            int prevLen = sb.Length;
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            if (EmitProperty(sb, prop, csClassName, selectors, inheritedProperties))
            {
                hasPrecedingMember = true;
            }
            else
            {
                sb.Length = prevLen;
            }
        }

        // === Indexer ===
        if (indexerGetter != null)
        {
            const string getterSelectorObjC = "objectAtIndexedSubscript:";
            const string setterSelectorObjC = "setObject:atIndexedSubscript:";

            selectors.TryAdd("Object", getterSelectorObjC);

            string elemType = TypeMapper.MapType(indexerGetter.ReturnType);
            string indexParam = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(indexerGetter.Parameters[0].Name));

            sb.AppendLine();
            sb.AppendLine($"    public {elemType} this[nuint {indexParam}]");
            sb.AppendLine("    {");
            sb.AppendLine("        get");
            sb.AppendLine("        {");
            sb.AppendLine($"            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, {csClassName}Bindings.Object, {indexParam});");
            sb.AppendLine();
            sb.AppendLine("            return new(nativePtr, NativeObjectOwnership.Borrowed);");
            sb.AppendLine("        }");
            RecordMsgSend("MsgSendNInt", "nuint");

            if (indexerSetter != null)
            {
                selectors.TryAdd("SetObject", setterSelectorObjC);

                sb.AppendLine("        set");
                sb.AppendLine("        {");
                sb.AppendLine($"            ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.SetObject, value.NativePtr, {indexParam});");
                sb.AppendLine("        }");
                RecordMsgSend("MsgSend", "nint", "nuint");
            }

            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        // === Methods (in JSON order, no grouping) ===
        foreach (MethodInfo method in nonIndexerMethods)
        {
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitMethod(sb, method, csClassName, selectors, hasZeroParamVersion, simplifiedNames);
            hasPrecedingMember = true;
        }

        // === Free functions ===
        foreach (FreeFunctionDef func in freeFunctions)
        {
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitFreeFunction(sb, func, csClassName);
            hasPrecedingMember = true;
        }

        sb.AppendLine("}");
        sb.AppendLine();

        sb.AppendLine($"file static class {csClassName}Bindings");
        sb.AppendLine("{");

        bool first = true;
        if (hasClassField)
        {
            sb.AppendLine($"    public static readonly nint Class = ObjectiveC.GetClass(\"{csClassName}\");");
            first = false;
        }

        foreach ((string name, string objc) in selectors)
        {
            if (!first)
            {
                sb.AppendLine();
            }
            sb.AppendLine($"    public static readonly Selector {name} = \"{objc}\";");
            first = false;
        }
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(dir, $"{csClassName}.cs"), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: {subdir}/{csClassName}.cs");
    }

    #endregion

    #region Member Categorization

    /// <summary>
    /// Derives the ObjC property name from a method's name.
    /// Strips <c>set</c> then <c>is</c> prefixes sequentially so that setters and boolean
    /// getters always resolve to the same canonical name:
    /// <list type="bullet">
    ///   <item><c>setXxx</c> → <c>xxx</c> (regular setter)</item>
    ///   <item><c>isXxx</c>  → <c>xxx</c> (boolean getter)</item>
    ///   <item><c>setIsXxx</c> → <c>isXxx</c> → <c>xxx</c> (boolean setter, chained)</item>
    ///   <item>everything else → returned as-is</item>
    /// </list>
    /// </summary>
    static string GetPropertyName(MethodInfo m)
    {
        string name = m.Name;

        // Strip trailing underscore (e.g., setFoo_ → setFoo).
        if (name.EndsWith('_'))
        {
            name = name[..^1];
        }

        // Setter: setXxx → xxx
        if (name.Length > 3 && name.StartsWith("set") && char.IsUpper(name[3]))
        {
            name = char.ToLower(name[3]) + name[4..];
        }

        // Boolean getter: isXxx → xxx
        if (name.Length > 2 && name.StartsWith("is") && char.IsUpper(name[2]))
        {
            name = char.ToLower(name[2]) + name[3..];
        }

        return name;
    }

    /// <summary>
    /// Separates methods into properties (getter/setter pairs) and remaining methods.
    /// A method is treated as a property getter if it has no parameters, returns non-void,
    /// is const, is not static, and is not an ownership-transfer method (new/alloc/copy/init).
    /// Getter-setter pairing uses <see cref="GetPropertyName"/> to derive the ObjC property
    /// name from each method's name, so all naming conventions (including
    /// boolean <c>isXxx</c> getters paired with <c>setXxx:</c> setters) are handled uniformly.
    /// </summary>
    static (List<PropertyDef> Properties, List<MethodInfo> Methods) CategorizeMembers(List<MethodInfo> allMethods)
    {
        List<PropertyDef> properties = [];
        List<MethodInfo> methods = [];
#pragma warning disable IDE0028 // Collection initialization can be simplified (requires custom comparer)
        HashSet<MethodInfo> used = new(ReferenceEqualityComparer.Instance);

        Dictionary<string, MethodInfo> setterMap = new(StringComparer.Ordinal);
#pragma warning restore IDE0028
        foreach (MethodInfo m in allMethods)
        {
            if (m.Name.StartsWith("set") && m.Name.Length > 3 && char.IsUpper(m.Name[3]) &&
                m.ReturnType == "void" && m.Parameters.Count == 1)
            {
                setterMap[GetPropertyName(m)] = m;
            }
        }

        foreach (MethodInfo m in allMethods)
        {
            if (m.ReturnType == "void")
            {
                continue;
            }

            if (m.Parameters.Count > 0)
            {
                continue;
            }

            if (m.UsesClassTarget)
            {
                continue;
            }

            if (used.Contains(m))
            {
                continue;
            }

            if (m.Name.StartsWith("set") && m.Name.Length > 3 && char.IsUpper(m.Name[3]))
            {
                continue;
            }

            if (TypeMapper.IsOwnershipTransferMethod(m.Name))
            {
                continue;
            }

            if (!m.IsConst)
            {
                continue;
            }

            MethodInfo? setter = null;
            if (setterMap.TryGetValue(GetPropertyName(m), out MethodInfo? s))
            {
                setter = s;
                used.Add(s);
            }

            properties.Add(new PropertyDef(m, setter));
            used.Add(m);
        }

        foreach (MethodInfo m in allMethods)
        {
            if (used.Contains(m))
            {
                continue;
            }

            methods.Add(m);
        }

        return (properties, methods);
    }

    #endregion

    #region Method Filtering

    /// <summary>
    /// Returns <see langword="true"/> if the method has <c>std::function</c> or unknown function
    /// pointer params. Block handler params (<c>Handler</c>/<c>Block</c> types and <c>INLINE_BLOCK:</c>
    /// markers) are <b>not</b> considered function pointers.
    /// </summary>
    bool HasFunctionPointerParam(MethodInfo method)
    {
        return method.Parameters.Any(p =>
        {
            if (p.Type.StartsWith("INLINE_BLOCK:"))
            {
                string delegateName = p.Type["INLINE_BLOCK:".Length..];
                return delegateName == "UNKNOWN_BLOCK";
            }

            if (p.Type.Contains("std::function") || p.Type.Contains("Function&") || p.Type.Contains("Function &"))
            {
                return true;
            }

            if (p.Type.Contains("Handler") || p.Type.Contains("Block"))
            {
                string csType = TypeMapper.MapType(p.Type);
                return !context.BlockTypeAliases.Any(b => b.CsDelegateName == csType);
            }

            return p.Type.Contains("function") || p.Type.Contains("void(");
        });
    }

    /// <summary>Returns <see langword="true"/> if the parameter type is a known block handler typedef.</summary>
    bool IsBlockHandlerType(string type)
    {
        if (type.Contains("Handler") || type.Contains("Block"))
        {
            string csType = TypeMapper.MapType(type);
            return context.BlockTypeAliases.Any(b => b.CsDelegateName == csType);
        }

        return false;
    }

    /// <summary>
    /// Returns <see langword="true"/> if any parameter's type is unmappable (excluding
    /// special prefixed types and block handler types which are handled separately).
    /// </summary>
    static bool HasUnmappableParam(MethodInfo method)
    {
        foreach (ParamDef p in method.Parameters)
        {
            if (p.Type.StartsWith("OBJ_ARRAY:") ||
                p.Type.StartsWith("PRIM_ARRAY:") ||
                p.Type.StartsWith("STRUCT_ARRAY:") ||
                p.Type.StartsWith("INLINE_BLOCK:") ||
                p.Type == "ARRAY_PARAM")
            {
                continue;
            }

            if (p.Type.Contains("Handler") || p.Type.Contains("Block") ||
                p.Type.Contains("Function&") || p.Type.Contains("Function &") ||
                p.Type.Contains("std::function"))
            {
                continue;
            }

            if (TypeMapper.IsUnmappableType(p.Type))
            {
                return true;
            }
        }

        return TypeMapper.IsUnmappableType(method.ReturnType);
    }

    /// <summary>
    /// Returns <see langword="true"/> if the method has an array parameter whose
    /// next parameter is <b>not</b> a matching <c>count</c> parameter.
    /// </summary>
    static bool HasUnmergableArrayParam(MethodInfo method)
    {
        List<ParamDef> p = method.Parameters;
        for (int i = 0; i < p.Count; i++)
        {
            if (p[i].Type.StartsWith("OBJ_ARRAY:") ||
                p[i].Type.StartsWith("PRIM_ARRAY:") ||
                p[i].Type.StartsWith("STRUCT_ARRAY:"))
            {
                bool nextIsCount = i + 1 < p.Count &&
                    p[i + 1].Type is "NS::UInteger" &&
                    p[i + 1].Name is "count";
                if (!nextIsCount)
                {
                    return true;
                }
            }
        }
        return false;
    }

    #endregion

    #region Property Emission

    /// <summary>
    /// Emits a single property (getter + optional setter) into <paramref name="sb"/>.
    /// Returns <see langword="false"/> if the property is inherited and should be skipped.
    /// </summary>
    bool EmitProperty(StringBuilder sb, PropertyDef prop, string csClassName, SortedDictionary<string, string> selectors, HashSet<string> inheritedProperties)
    {
        MethodInfo getter = prop.Getter;
        string csPropName = TypeMapper.ToPascalCase(getter.Name);

        if (inheritedProperties.Contains(csPropName))
        {
            return false;
        }

        string csType = TypeMapper.MapType(getter.ReturnType);

        string? nsArrayElemType = null;
        if (csType == "NSArray")
        {
            nsArrayElemType = TryResolveNSArrayElementType(csClassName, csPropName);
        }

        bool isNSArray = nsArrayElemType != null;
        bool nullable = !isNSArray && typeMapper.IsNativeObjectType(csType);
        bool isEnum = typeMapper.IsEnumType(csType);
        bool isStruct = TypeMapper.StructTypes.Contains(csType);
        bool isBool = csType == "bool";

        string selectorName = csPropName;
        string selectorObjC = getter.Selector ?? getter.Name;
        selectors.TryAdd(selectorName, selectorObjC);

        const string Target = "NativePtr";

        string selectorRef = $"{csClassName}Bindings.{selectorName}";
        string typeStr = csType;

        string? setSelName = null;
        if (prop.Setter != null)
        {
            setSelName = TypeMapper.ToPascalCase(prop.Setter.Name);
            string setSelObjC = prop.Setter.Selector ?? "set" + csPropName + ":";
            selectors.TryAdd(setSelName, setSelObjC);
        }

        if (getter.DeprecationMessage != null)
        {
            sb.AppendLine("    /// <summary>");
            sb.AppendLine($"    /// Deprecated: {getter.DeprecationMessage}");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine($"    [Obsolete(\"{getter.DeprecationMessage}\")]");
        }

        if (isNSArray)
        {
            sb.AppendLine($"    public {nsArrayElemType}[] {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => GetArrayProperty<{nsArrayElemType}>({selectorRef});");
            if (prop.Setter != null)
            {
                sb.AppendLine($"        set => SetArrayProperty({csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (nullable)
        {
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => GetProperty(ref field, {selectorRef});");
            if (prop.Setter != null)
            {
                sb.AppendLine($"        set => SetProperty(ref field, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (isEnum)
        {
            string msgSend = typeMapper.GetMsgSendForEnumGet(csType);
            string enumGetGroup = msgSend.Replace("ObjectiveC.", "");
            RecordMsgSend(enumGetGroup);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ({csType}){msgSend}({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                string setCast = typeMapper.GetEnumSetCast(csType);
                string enumSetType = setCast.TrimStart('(').TrimEnd(')');
                RecordMsgSend("MsgSend", enumSetType);
                sb.AppendLine($"        set => ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, {setCast}value);");
            }
            sb.AppendLine("    }");
        }
        else if (isBool)
        {
            RecordMsgSend("MsgSendBool");
            sb.AppendLine($"    public Bool8 {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveC.MsgSendBool({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                RecordMsgSend("MsgSend", "Bool8");
                sb.AppendLine($"        set => ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (isStruct)
        {
            string msgSend = TypeMapper.GetMsgSendForStruct(csType);
            RecordMsgSend(msgSend);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveC.{msgSend}({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                RecordMsgSend("MsgSend", csType);
                sb.AppendLine($"        set => ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else
        {
            string msgSend = TypeMapper.GetMsgSendMethod(csType);
            RecordMsgSend(msgSend);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveC.{msgSend}({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                RecordMsgSend("MsgSend", csType);
                sb.AppendLine($"        set => ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }

        return true;
    }

    #endregion

    #region Method Emission

    /// <summary>
    /// Emits a single method into <paramref name="sb"/>, handling parameter marshalling
    /// (arrays, blocks, out-params, enums) and selecting the correct <c>MsgSend</c> variant.
    /// </summary>
    void EmitMethod(StringBuilder sb, MethodInfo method, string csClassName, SortedDictionary<string, string> selectors, HashSet<string> hasZeroParamVersion, Dictionary<MethodInfo, string> simplifiedNames)
    {
        string csMethodName;
        string selectorObjC;
        string methodName = method.Name;

        if (method.Selector != null)
        {
            selectorObjC = method.Selector;

            string selectorBaseName = selectorObjC.Contains(':')
                ? selectorObjC[..selectorObjC.IndexOf(':')]
                : selectorObjC;

            // Use pre-computed simplified name (with conflict detection) for any selector method
            int colonCount = selectorObjC.Count(c => c == ':');
            if (simplifiedNames.TryGetValue(method, out string? simplified))
            {
                csMethodName = simplified;
            }
            else if (colonCount > 1)
            {
                csMethodName = BuildMethodNameFromSelector(selectorObjC);
            }
            else if (hasZeroParamVersion.Contains(methodName) && method.Parameters.Count > 0)
            {
                csMethodName = TypeMapper.ToPascalCase(selectorBaseName);
            }
            else
            {
                csMethodName = TypeMapper.ToPascalCase(methodName);
            }
        }
        else
        {
            csMethodName = TypeMapper.ToPascalCase(methodName);
            int colonCount = method.Parameters.Count;
            selectorObjC = method.Name + (colonCount > 0 ? new string(':', colonCount) : "");
        }

        bool isStaticClassMethod = method.IsStatic && method.UsesClassTarget;
        string target = isStaticClassMethod ? $"{csClassName}Bindings.Class" : "NativePtr";

        string selectorKey = hasZeroParamVersion.Contains(method.Name) && method.Parameters.Count > 0
            ? BuildMethodNameFromSelector(selectorObjC)
            : TypeMapper.ToPascalCase(method.Name);
        if (selectors.TryGetValue(selectorKey, out string? existingSelector) && existingSelector != selectorObjC)
        {
            selectorKey = BuildMethodNameFromSelector(selectorObjC);
        }
        selectors.TryAdd(selectorKey, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        string returnType = TypeMapper.MapType(method.ReturnType);

        string? returnArrayElemType = null;
        if (returnType == "NSArray")
        {
            returnArrayElemType = TryResolveNSArrayElementType(csClassName, csMethodName);
        }
        bool returnsArray = returnArrayElemType != null;

        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(returnType);
        bool isEnum = typeMapper.IsEnumType(returnType);
        bool isStruct = TypeMapper.StructTypes.Contains(returnType);
        bool isBool = returnType == "bool";
        bool isVoid = returnType == "void";

        bool hasOutError = method.Parameters.Any(p => p.Type.Contains("Error**"));

        List<string> csParams = [];
        List<string> callArgs = [target, selectorRef];
        List<string> callArgTypes = [];
        List<string> arraySetupLines = [];
        List<string> fixedStatements = [];
        List<string> nsArrayReleaseVars = [];
        List<(string CsType, string CsParamName, string PtrVarName)> autoreleasedOutParams = [];
        bool needsUnsafeContext = false;

        for (int pi = 0; pi < method.Parameters.Count; pi++)
        {
            ParamDef param = method.Parameters[pi];
            if (param.Type == "ARRAY_PARAM")
            {
                continue;
            }

            if (param.Type.StartsWith("OBJ_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemType = param.Type["OBJ_ARRAY:".Length..];
                string elemCsType = TypeMapper.MapType(elemType + "*");
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].Type is "NS::UInteger" &&
                    method.Parameters[pi + 1].Name is "count";

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                arraySetupLines.Add($"        nint* {ptrVar} = stackalloc nint[{csParamName}.Length];");
                arraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                arraySetupLines.Add("        {");
                arraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i].NativePtr;");
                arraySetupLines.Add("        }");

                callArgs.Add($"(nint){ptrVar}");
                callArgTypes.Add("nint");

                if (nextIsCount)
                {
                    callArgs.Add($"(nuint){csParamName}.Length");
                    callArgTypes.Add("nuint");
                    pi++;
                }
                continue;
            }

            if (param.Type.StartsWith("PRIM_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemType = param.Type["PRIM_ARRAY:".Length..];
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemType}[] {csParamName}");

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                arraySetupLines.Add($"        {elemType}* {ptrVar} = stackalloc {elemType}[{csParamName}.Length];");
                arraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                arraySetupLines.Add("        {");
                arraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i];");
                arraySetupLines.Add("        }");

                callArgs.Add($"(nint){ptrVar}");
                callArgTypes.Add("nint");
                continue;
            }

            if (param.Type.StartsWith("STRUCT_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemType = param.Type["STRUCT_ARRAY:".Length..];
                string elemCsType = TypeMapper.MapType(elemType);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].Type is "NS::UInteger" &&
                    method.Parameters[pi + 1].Name is "count";

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                fixedStatements.Add($"fixed ({elemCsType}* {ptrVar} = {csParamName})");

                callArgs.Add($"(nint){ptrVar}");
                callArgTypes.Add("nint");

                if (nextIsCount)
                {
                    callArgs.Add($"(nuint){csParamName}.Length");
                    callArgTypes.Add("nuint");
                    pi++;
                }
                continue;
            }

            if (param.Type.StartsWith("INLINE_BLOCK:"))
            {
                string delegateName = param.Type["INLINE_BLOCK:".Length..];
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                csParams.Add($"{delegateName} {csParamName}");
                callArgs.Add($"{csParamName}.NativePtr");
                callArgTypes.Add("nint");
                continue;
            }

            if (IsBlockHandlerType(param.Type))
            {
                string csType = TypeMapper.MapType(param.Type);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                csParams.Add($"{csType} {csParamName}");
                callArgs.Add($"{csParamName}.NativePtr");
                callArgTypes.Add("nint");
                continue;
            }

            string csParamType = TypeMapper.MapType(param.Type);
            string paramName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

            // Autoreleased* types → out parameters (strip "Autoreleased" prefix to resolve underlying type)
            if (param.Type.Contains("Autoreleased"))
            {
                string resolvedType = param.Type.Replace("Autoreleased", "");
                string csType = TypeMapper.MapType(resolvedType);
                string ptrVarName = $"{paramName}Ptr";
                csParams.Add($"out {csType} {paramName}");
                callArgs.Add($"out nint {ptrVarName}");
                callArgTypes.Add("out nint");
                autoreleasedOutParams.Add((csType, paramName, ptrVarName));
                continue;
            }

            if (param.Type.Contains("Error**"))
            {
                csParams.Add("out NSError error");
                callArgs.Add("out nint errorPtr");
                callArgTypes.Add("out nint");
                continue;
            }

            if (param.Type.Contains("Timestamp*") && !param.Type.Contains("TimestampGranularity"))
            {
                csParams.Add($"out ulong {paramName}");
                callArgs.Add($"out {paramName}");
                callArgTypes.Add("out ulong");
                continue;
            }

            csParams.Add($"{csParamType} {paramName}");

            if (csParamType == "NSArray")
            {
                string? paramArrayElemType = TryResolveNSArrayElementType(csClassName, csMethodName);
                if (paramArrayElemType != null)
                {
                    csParams[^1] = $"{paramArrayElemType}[] {paramName}";
                    string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                    arraySetupLines.Add($"        nint {ptrVar} = NSArray.FromArray({paramName});");
                    callArgs.Add(ptrVar);
                    nsArrayReleaseVars.Add(ptrVar);
                }
                else
                {
                    callArgs.Add($"{paramName}");
                }
                callArgTypes.Add("nint");
            }
            else if (typeMapper.IsNativeObjectType(csParamType))
            {
                callArgs.Add($"{paramName}.NativePtr");
                callArgTypes.Add("nint");
            }
            else if (typeMapper.IsEnumType(csParamType))
            {
                callArgs.Add($"{typeMapper.GetEnumSetCast(csParamType)}{paramName}");
                string castType = typeMapper.GetEnumSetCast(csParamType).TrimStart('(').TrimEnd(')');
                callArgTypes.Add(castType);
            }
            // For P/Invoke signature tracking: map bool → Bool8 since bool is not
            // blittable in LibraryImport; all other types pass through unchanged.
            else
            {
                callArgs.Add(paramName);
                callArgTypes.Add(csParamType == "bool" ? "Bool8" : csParamType);
            }
        }

        string paramStr = string.Join(", ", csParams);
        string argsStr = string.Join(", ", callArgs);
        string staticKw = isStaticClassMethod ? "static " : "";
        string unsafeKw = needsUnsafeContext ? "unsafe " : "";
        string csReturnType = returnsArray ? $"{returnArrayElemType}[]" : (isVoid ? "void" : returnType);

        if (method.DeprecationMessage != null)
        {
            sb.AppendLine("    /// <summary>");
            sb.AppendLine($"    /// Deprecated: {method.DeprecationMessage}");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine($"    [Obsolete(\"{method.DeprecationMessage}\")]");
        }

        sb.AppendLine($"    public {staticKw}{unsafeKw}{csReturnType} {csMethodName}({paramStr})");
        sb.AppendLine("    {");

        foreach (string line in arraySetupLines)
        {
            sb.AppendLine(line);
        }

        if (arraySetupLines.Count > 0)
        {
            sb.AppendLine();
        }

        string indent = "        ";
        foreach (string fixedStmt in fixedStatements)
        {
            sb.AppendLine($"{indent}{fixedStmt}");
            sb.AppendLine($"{indent}{{");
            indent += "    ";
        }

        string[] argTypesArray = [.. callArgTypes];
        string msgSendExpr;
        if (isVoid)
        {
            RecordMsgSend("MsgSend", argTypesArray);
            msgSendExpr = $"ObjectiveC.MsgSend({argsStr})";
        }
        else if (returnsArray || nullable)
        {
            RecordMsgSend("MsgSendNInt", argTypesArray);
            msgSendExpr = $"ObjectiveC.MsgSendNInt({argsStr})";
        }
        else if (isEnum)
        {
            string msgSend = typeMapper.GetMsgSendForEnumGet(returnType);
            string enumGroup = msgSend.Replace("ObjectiveC.", "");
            RecordMsgSend(enumGroup, argTypesArray);
            msgSendExpr = $"({returnType}){msgSend}({argsStr})";
        }
        else if (isBool)
        {
            RecordMsgSend("MsgSendBool", argTypesArray);
            msgSendExpr = $"ObjectiveC.MsgSendBool({argsStr})";
        }
        else if (isStruct)
        {
            string msgSend = TypeMapper.GetMsgSendForStruct(returnType);
            RecordMsgSend(msgSend, argTypesArray);
            msgSendExpr = $"ObjectiveC.{msgSend}({argsStr})";
        }
        else
        {
            string msgSend = TypeMapper.GetMsgSendMethod(returnType);
            RecordMsgSend(msgSend, argTypesArray);
            msgSendExpr = $"ObjectiveC.{msgSend}({argsStr})";
        }

        if (isVoid)
        {
            sb.AppendLine($"{indent}{msgSendExpr};");
            foreach ((string csType, string csParamName, string ptrVar) in autoreleasedOutParams)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}{csParamName} = new({ptrVar}, NativeObjectOwnership.Owned);");
            }
            if (hasOutError)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
            }
            foreach (string rv in nsArrayReleaseVars)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}ObjectiveC.Release({rv});");
            }
        }
        else if (returnsArray || nullable)
        {
            sb.AppendLine($"{indent}nint nativePtr = {msgSendExpr};");
            foreach ((string csType, string csParamName, string ptrVar) in autoreleasedOutParams)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}{csParamName} = new({ptrVar}, NativeObjectOwnership.Owned);");
            }
            if (hasOutError)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
            }
            foreach (string rv in nsArrayReleaseVars)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}ObjectiveC.Release({rv});");
            }
            sb.AppendLine();
            sb.AppendLine(returnsArray
                ? $"{indent}return NSArray.ToArray<{returnArrayElemType}>(nativePtr);"
                : $"{indent}return new(nativePtr, NativeObjectOwnership.Owned);");
        }
        else if (hasOutError || autoreleasedOutParams.Count > 0)
        {
            sb.AppendLine($"{indent}{csReturnType} result = {msgSendExpr};");
            foreach ((string csType, string csParamName, string ptrVar) in autoreleasedOutParams)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}{csParamName} = new({ptrVar}, NativeObjectOwnership.Owned);");
            }
            if (hasOutError)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
            }
            sb.AppendLine();
            sb.AppendLine($"{indent}return result;");
        }
        else
        {
            sb.AppendLine($"{indent}return {msgSendExpr};");
        }

        for (int fi = fixedStatements.Count - 1; fi >= 0; fi--)
        {
            indent = "        " + new string(' ', fi * 4);
            sb.AppendLine($"{indent}}}");
        }

        sb.AppendLine("    }");
    }

    /// <summary>
    /// Builds a C# method name from a multi-part ObjC selector.
    /// E.g., "presentDrawable:atTime:" → "PresentDrawableAtTime"
    /// E.g., "newBufferWithLength:options:" → "NewBufferWithLengthOptions"
    /// </summary>
    static string BuildMethodNameFromSelector(string selector)
    {
        ReadOnlySpan<char> remaining = selector.AsSpan();
        StringBuilder sb = new();

        while (!remaining.IsEmpty)
        {
            int colon = remaining.IndexOf(':');
            ReadOnlySpan<char> part = colon < 0 ? remaining : remaining[..colon];

            if (!part.IsEmpty)
            {
                sb.Append(char.ToUpper(part[0]));
                if (part.Length > 1)
                {
                    sb.Append(part[1..]);
                }
            }

            remaining = colon < 0 ? [] : remaining[(colon + 1)..];
        }

        return sb.ToString();
    }

    /// <summary>
    /// Simplifies a method name by using just the first selector part and stripping
    /// any "With..." suffix. E.g., "newBufferWithLength" → "NewBuffer",
    /// "signalEvent" → "SignalEvent", "newTensorWithDescriptor" → "NewTensor".
    /// </summary>
    static string SimplifyMethodName(string selectorFirstPart)
    {
        string pascal = TypeMapper.ToPascalCase(selectorFirstPart);

        int idx = 0;
        while (idx < pascal.Length)
        {
            idx = pascal.IndexOf("With", idx, StringComparison.Ordinal);
            if (idx <= 0)
            {
                break;
            }

            if (idx + 4 < pascal.Length && char.IsUpper(pascal[idx + 4]))
            {
                return pascal[..idx];
            }

            idx += 4;
        }

        return pascal;
    }

    /// <summary>
    /// Computes a parameter type signature key for method overload conflict detection.
    /// Handles array merging (OBJ_ARRAY + count → single array param) and error out params.
    /// </summary>
    static string ComputeParamTypesKey(MethodInfo method)
    {
        List<string> types = [];
        for (int i = 0; i < method.Parameters.Count; i++)
        {
            ParamDef p = method.Parameters[i];

            if (p.Type is "ARRAY_PARAM")
            {
                continue;
            }

            if (p.Type.StartsWith("OBJ_ARRAY:") || p.Type.StartsWith("STRUCT_ARRAY:"))
            {
                types.Add(TypeMapper.MapType(ExtractArrayElementType(p.Type) + "*") + "[]");
                i += SkipCountParam(method, i);
                continue;
            }

            if (p.Type.StartsWith("PRIM_ARRAY:"))
            {
                types.Add(ExtractArrayElementType(p.Type) + "[]");
                continue;
            }

            if (p.Type.Contains("Error**"))
            {
                types.Add("out:NSError");
                continue;
            }

            types.Add(TypeMapper.MapType(p.Type));
        }
        return string.Join(',', types);

        static string ExtractArrayElementType(string type) => type[(type.IndexOf(':') + 1)..];

        static int SkipCountParam(MethodInfo method, int currentIndex) =>
            currentIndex + 1 < method.Parameters.Count &&
            method.Parameters[currentIndex + 1].Type is "NS::UInteger" &&
            method.Parameters[currentIndex + 1].Name is "count" ? 1 : 0;
    }

    /// <summary>
    /// Pre-computes simplified C# method names for multi-part selector methods.
    /// Detects parameter type signature conflicts and falls back to full selector names
    /// when simplification would create ambiguous overloads (e.g., two methods with the same
    /// simplified name and identical parameter types like presentDrawable:atTime: and
    /// presentDrawable:afterMinimumDuration:).
    /// </summary>
    Dictionary<MethodInfo, string> ComputeSimplifiedMethodNames(List<MethodInfo> methods, List<PropertyDef> properties)
    {
        Dictionary<MethodInfo, string> result = [];

        HashSet<string> propertyNames = [.. properties.Select(p => TypeMapper.ToPascalCase(p.Getter.Name))];

        List<(MethodInfo Method, string Simplified, string Full, string ParamKey)> entries = [];
        foreach (MethodInfo m in methods)
        {
            if (m.Selector == null || !m.Selector.Contains(':'))
            {
                continue;
            }

            string firstPart = m.Selector[..m.Selector.IndexOf(':')];
            entries.Add((m, SimplifyMethodName(firstPart), BuildMethodNameFromSelector(m.Selector), ComputeParamTypesKey(m)));
        }

        foreach (var group in entries.GroupBy(e => (e.Simplified, e.ParamKey)))
        {
            List<(MethodInfo Method, string Simplified, string Full, string ParamKey)> items = [.. group];

            bool hasConflict = items.Count > 1 || propertyNames.Contains(items[0].Simplified);
            foreach (var (method, simplified, full, _) in items)
            {
                result[method] = hasConflict ? full : simplified;
            }
        }

        return result;
    }

    #endregion

    #region Free Function Emission

    /// <summary>
    /// Emits a free function as a <c>[LibraryImport]</c> P/Invoke declaration followed
    /// by a public static wrapper that handles <c>NativeObject</c> marshalling.
    /// </summary>
    void EmitFreeFunction(StringBuilder sb, FreeFunctionDef func, string csClassName)
    {
        string csReturnType = TypeMapper.MapType(func.ReturnType);

        string? returnArrayElemType = null;
        if (csReturnType == "NSArray")
        {
            returnArrayElemType = TryResolveNSArrayElementType(csClassName, func.Name);
        }
        bool returnsArray = returnArrayElemType != null;
        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(csReturnType);

        List<string> pinvokeParams = [];
        foreach (ParamDef p in func.Parameters)
        {
            string csType = TypeMapper.MapType(p.Type);
            if (typeMapper.IsNativeObjectType(csType))
            {
                pinvokeParams.Add($"nint {TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name))}");
            }
            else
            {
                pinvokeParams.Add($"{csType} {TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name))}");
            }
        }

        string pinvokeReturnType = (nullable || returnsArray) ? "nint" : csReturnType;

        sb.AppendLine($"    [LibraryImport(\"{func.LibraryPath}\", EntryPoint = \"{func.CEntryPoint}\")]");
        sb.AppendLine($"    private static partial {pinvokeReturnType} {func.CEntryPoint}({string.Join(", ", pinvokeParams)});");
        sb.AppendLine();

        List<string> wrapperParams = [];
        List<string> callArgs = [];
        foreach (ParamDef p in func.Parameters)
        {
            string csType = TypeMapper.MapType(p.Type);
            string csName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name));
            if (typeMapper.IsNativeObjectType(csType))
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

        string csFullReturnType = returnsArray ? $"{returnArrayElemType}[]" : csReturnType;
        string wrapperParamStr = string.Join(", ", wrapperParams);
        string callArgStr = string.Join(", ", callArgs);

        if (returnsArray)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.Name}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine($"        {returnArrayElemType}[] result = NSArray.ToArray<{returnArrayElemType}>(nativePtr);");
            sb.AppendLine();
            sb.AppendLine("        ObjectiveC.Release(nativePtr);");
            sb.AppendLine();
            sb.AppendLine("        return result;");
            sb.AppendLine("    }");
        }
        else if (nullable)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.Name}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine("        return new(nativePtr, NativeObjectOwnership.Owned);");
            sb.AppendLine("    }");
        }
        else if (csReturnType == "void")
        {
            sb.AppendLine($"    public static void {func.Name}({wrapperParamStr}) => {func.CEntryPoint}({callArgStr});");
        }
        else
        {
            sb.AppendLine($"    public static {csReturnType} {func.Name}({wrapperParamStr}) => {func.CEntryPoint}({callArgStr});");
        }
    }

    #endregion

    #region ObjectiveC.cs Generation

    /// <summary>
    /// Generates the auto-generated Common/ObjectiveC.cs file containing all required
    /// MsgSend overloads using delegate* unmanaged function pointers, null-guard wrappers,
    /// and Alloc/Init/Release helpers.
    /// Signatures are collected during property/method emission via RecordMsgSend().
    /// </summary>
    void GenerateObjectiveCFile()
    {
        string dir = Path.Combine(outputDir, "Common");
        Directory.CreateDirectory(dir);

        StringBuilder sb = new();
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();
        sb.AppendLine("internal static unsafe partial class ObjectiveC");
        sb.AppendLine("{");

        sb.AppendLine("    private static readonly nint msgSend;");
        sb.AppendLine();
        sb.AppendLine("    static ObjectiveC()");
        sb.AppendLine("    {");
        sb.AppendLine("        string[] frameworks =");
        sb.AppendLine("        [");
        sb.AppendLine("            \"CoreGraphics\",");
        sb.AppendLine("            \"QuartzCore\",");
        sb.AppendLine("            \"AppKit\",");
        sb.AppendLine("            \"Metal\",");
        sb.AppendLine("            \"MetalFX\",");
        sb.AppendLine("            \"MetalKit\"");
        sb.AppendLine("        ];");
        sb.AppendLine();
        sb.AppendLine("        foreach (string framework in frameworks)");
        sb.AppendLine("        {");
        sb.AppendLine("            NativeLibrary.TryLoad(framework, out _);");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        msgSend = NativeLibrary.GetExport(NativeLibrary.Load(\"/usr/lib/libobjc.A.dylib\"), \"objc_msgSend\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    #region Class and Selector Lookups");
        sb.AppendLine();
        sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"objc_getClass\", StringMarshalling = StringMarshalling.Utf8)]");
        sb.AppendLine("    private static partial nint _GetClass(string name);");
        sb.AppendLine();
        sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"sel_registerName\", StringMarshalling = StringMarshalling.Utf8)]");
        sb.AppendLine("    private static partial Selector _RegisterName(string name);");
        sb.AppendLine();
        sb.AppendLine("    public static nint GetClass(string name)");
        sb.AppendLine("    {");
        sb.AppendLine("        if (string.IsNullOrEmpty(name))");
        sb.AppendLine("        {");
        sb.AppendLine("            return 0;");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        return _GetClass(name);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static Selector RegisterName(string name)");
        sb.AppendLine("    {");
        sb.AppendLine("        if (string.IsNullOrEmpty(name))");
        sb.AppendLine("        {");
        sb.AppendLine("            return default;");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        return _RegisterName(name);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    #endregion");

        var groups = context.MsgSendSignatures.Keys.OrderBy(k => k == "MsgSend" ? "" : k).ToList();

        foreach (string group in groups)
        {
            sb.AppendLine();
            sb.AppendLine($"    #region {group}");

            string returnType = GetReturnTypeForGroup(group);
            bool isVoid = returnType == "void";

            foreach (string sig in context.MsgSendSignatures[group])
            {
                ParsedParam[] parameters = ParseSignature(sig);

                sb.AppendLine();
                sb.AppendLine($"    public static {returnType} {group}(nint receiver, Selector selector{BuildPublicParams(parameters)})");
                sb.AppendLine("    {");

                // Null guard
                sb.AppendLine("        if (receiver is 0)");
                sb.AppendLine("        {");
                var outGuardParams = parameters.Where(p => p.Kind == ParamKind.Out).ToList();
                foreach (var p in outGuardParams)
                {
                    sb.AppendLine($"            {p.Letter} = default;");
                }
                if (outGuardParams.Count > 1)
                {
                    sb.AppendLine();
                }
                sb.AppendLine(isVoid ? "            return;" : "            return default;");
                sb.AppendLine("        }");
                sb.AppendLine();

                // Build and emit call expression
                string delegateType = BuildDelegateUnmanagedType(parameters, returnType);
                string callArgs = BuildCallArgs(parameters);
                string callExpr = $"(({delegateType})msgSend)(receiver, selector{callArgs})";

                EmitCallBody(sb, callExpr, isVoid, parameters);

                sb.AppendLine("    }");
            }

            sb.AppendLine();
            sb.AppendLine("    #endregion");
        }

        sb.AppendLine();
        sb.AppendLine("    public static nint Alloc(nint @class)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendNInt(@class, \"alloc\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint Init(nint receiver)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendNInt(receiver, \"init\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint AllocInit(nint @class)");
        sb.AppendLine("    {");
        sb.AppendLine("        return Init(Alloc(@class));");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint Retain(nint receiver)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendNInt(receiver, \"retain\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static void Release(nint receiver)");
        sb.AppendLine("    {");
        sb.AppendLine("        MsgSend(receiver, \"release\");");
        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(dir, "ObjectiveC.cs"), sb.ToString(), new UTF8Encoding(true));

        int totalOverloads = context.MsgSendSignatures.Values.Sum(s => s.Count);
        Console.WriteLine($"  Generated: Common/ObjectiveC.cs ({totalOverloads} overloads across {context.MsgSendSignatures.Count} groups)");
    }

    /// <summary>Classification of a parameter in a MsgSend signature.</summary>
    enum ParamKind { Regular, Out }

    /// <summary>A parsed parameter from a MsgSend signature string.</summary>
    readonly record struct ParsedParam(char Letter, string Type, ParamKind Kind)
    {
        /// <summary>The base type for out parameters (strips "out " prefix), or the original type.</summary>
        public string BaseType => Kind == ParamKind.Out ? Type[4..] : Type;
    }

    /// <summary>Maps a MsgSend group name to its C# return type.</summary>
    static string GetReturnTypeForGroup(string group) => group switch
    {
        "MsgSend" => "void",
        "MsgSendBool" => "Bool8",
        "MsgSendNInt" => "nint",
        "MsgSendInt" => "int",
        "MsgSendUInt" => "uint",
        "MsgSendLong" => "long",
        "MsgSendULong" => "ulong",
        "MsgSendFloat" => "float",
        "MsgSendDouble" => "double",
        "MsgSendNUInt" => "nuint",
        _ => group.Replace("MsgSend", "")
    };

    /// <summary>
    /// Parses a comma-separated signature string into structured parameter info.
    /// Each parameter is classified as Regular or Out, and assigned a sequential letter.
    /// </summary>
    static ParsedParam[] ParseSignature(string sig)
    {
        if (string.IsNullOrEmpty(sig)) return [];

        string[] types = sig.Split(", ");
        ParsedParam[] result = new ParsedParam[types.Length];
        char letter = 'a';

        for (int i = 0; i < types.Length; i++)
        {
            string type = types[i];
            ParamKind kind = type.StartsWith("out ")
                ? ParamKind.Out
                : ParamKind.Regular;
            result[i] = new ParsedParam(letter, type, kind);
            letter++;
        }

        return result;
    }

    /// <summary>Builds the public parameter list string (e.g., ", nint a, nint b").</summary>
    static string BuildPublicParams(ParsedParam[] parameters)
    {
        if (parameters.Length == 0) return "";

        StringBuilder sb = new();
        foreach (var p in parameters)
        {
            sb.Append($", {p.Type} {p.Letter}");
        }
        return sb.ToString();
    }

    /// <summary>
    /// Builds the delegate* unmanaged type string for a given signature.
    /// E.g., "delegate* unmanaged&lt;nint, Selector, nint, nint, void&gt;"
    /// Out parameters become pointers.
    /// </summary>
    static string BuildDelegateUnmanagedType(ParsedParam[] parameters, string returnType)
    {
        List<string> typeArgs = ["nint", "Selector"];

        foreach (var p in parameters)
        {
            typeArgs.Add(p.Kind switch
            {
                ParamKind.Out => $"{p.BaseType}*",
                _ => p.Type
            });
        }

        typeArgs.Add(returnType);
        return $"delegate* unmanaged<{string.Join(", ", typeArgs)}>";
    }

    /// <summary>
    /// Builds the call argument string for the function pointer call.
    /// Out parameters use pointer variables (e.g., aPtr).
    /// </summary>
    static string BuildCallArgs(ParsedParam[] parameters)
    {
        if (parameters.Length == 0) return "";

        StringBuilder sb = new();
        foreach (var p in parameters)
        {
            sb.Append(p.Kind switch
            {
                ParamKind.Out => $", {p.Letter}Ptr",
                _ => $", {p.Letter}"
            });
        }
        return sb.ToString();
    }

    /// <summary>
    /// Emits the method body after the null guard: fixed blocks, call expression,
    /// and return statement.
    /// </summary>
    static void EmitCallBody(StringBuilder sb, string callExpr, bool isVoid, ParsedParam[] parameters)
    {
        var outParams = parameters.Where(p => p.Kind == ParamKind.Out).ToList();
        bool hasOutParams = outParams.Count > 0;

        // Each fixed block nests inside the previous, increasing indent by 4 spaces
        const string baseIndent = "        ";
        string innerIndent = hasOutParams ? baseIndent + new string(' ', 4 * outParams.Count) : baseIndent;

        // Emit nested fixed blocks
        for (int i = 0; i < outParams.Count; i++)
        {
            string fixedIndent = baseIndent + new string(' ', 4 * i);
            var p = outParams[i];
            sb.AppendLine($"{fixedIndent}fixed ({p.BaseType}* {p.Letter}Ptr = &{p.Letter})");
            sb.AppendLine($"{fixedIndent}{{");
        }

        sb.AppendLine(isVoid ? $"{innerIndent}{callExpr};" : $"{innerIndent}return {callExpr};");

        // Close nested fixed blocks in reverse order
        for (int i = outParams.Count - 1; i >= 0; i--)
        {
            string fixedIndent = baseIndent + new string(' ', 4 * i);
            sb.AppendLine($"{fixedIndent}}}");
        }
    }

    #endregion
}