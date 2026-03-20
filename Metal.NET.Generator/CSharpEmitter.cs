namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Interop/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
partial class CSharpEmitter(string outputDir, GeneratorContext context, TypeMapper typeMapper)
{
    /// <summary>Shared UTF-8 encoding with BOM for all generated files.</summary>
    static readonly Encoding Utf8Bom = new UTF8Encoding(true);

    /// <summary>Hand-written structs to skip during generation (located in Simd/).</summary>
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
        { ("MTLFunctionStitchingFunctionNode", "Arguments"), "MTLFunctionStitchingNode" },
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
    string? TryResolveNSArrayElementType(string className, string propertyName)
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

        // Fallback: check element types extracted from AST generics by the parser
        if (context.NSArrayReturnTypes.TryGetValue((className, propertyName), out string? astElemType))
        {
            return astElemType;
        }

        return null;
    }

    /// <summary>Returns the consolidated file name for a grouped output (e.g., "MTLEnums.cs", "NSStructs.cs").</summary>
    static string GetConsolidatedFileName(string subdir, string suffix) => subdir switch
    {
        "Metal" => $"MTL{suffix}.cs",
        "Foundation" => $"NS{suffix}.cs",
        "MetalFX" => $"MTLFX{suffix}.cs",
        _ => $"{subdir}{suffix}.cs"
    };

    /// <summary>
    /// Emits <c>[Obsolete]</c> attribute and deprecation XML doc comment into <paramref name="sb"/>.
    /// </summary>
    static void EmitDeprecation(StringBuilder sb, string message)
    {
        sb.AppendLine("    /// <summary>");
        sb.AppendLine($"    /// Deprecated: {message}");
        sb.AppendLine("    /// </summary>");
        sb.AppendLine($"    [Obsolete(\"{message}\")]");
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
            context.KnownClassNames.Add(classDef.FullCsName);
        }
        context.KnownClassNames.UnionWith(["NSObject", "NSString", "NSError", "NSArray", "NSURL", "NSDictionary", "NSNumber", "NSData", "NSBundle", "NativeObject"]);

        // Register hand-written Foundation enums (not in AST)
        context.EnumBackingTypes.TryAdd("NSComparisonResult", "long");
        context.EnumBackingTypes.TryAdd("NSStringCompareOptions", "ulong");
        context.EnumBackingTypes.TryAdd("NSStringEncoding", "ulong");

        // Pre-build a HashSet of known delegate names for O(1) lookup
        HashSet<string> knownDelegateNames = [.. context.BlockTypeAliases.Select(b => b.CsDelegateName)];

        // Build a dictionary for O(1) class lookup by full C# name (last wins for duplicates)
        Dictionary<string, ClassDef> classByName = [];
        foreach (ClassDef c in context.Classes)
        {
            classByName[c.FullCsName] = c;
        }

        // Build a map of class name → property names for inheritance detection
        Dictionary<string, HashSet<string>> classPropertyMap = [];
        foreach (ClassDef classDef in context.Classes)
        {
            classPropertyMap[classDef.FullCsName] =
            [
                .. classDef.Methods.Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget && m.IsConst)
                                   .Select(m => TypeMapper.ToPascalCase(m.Name))
            ];
        }

        // Build inherited property names by walking the inheritance chain
        HashSet<string> GetInheritedProperties(string csClassName)
        {
            HashSet<string> result = [];
            if (!classByName.TryGetValue(csClassName, out ClassDef? classDef))
            {
                return result;
            }
            string? current = classDef.BaseClassName;
            while (current != null && context.KnownClassNames.Contains(current) && classPropertyMap.TryGetValue(current, out HashSet<string>? parentProps))
            {
                result.UnionWith(parentProps);
                current = classByName.TryGetValue(current, out ClassDef? parentDef) ? parentDef.BaseClassName : null;
            }
            return result;
        }

        // Build lookup of free functions per target class
        Dictionary<string, List<FreeFunctionDef>> freeFuncsByClass = context.FreeFunctions
            .GroupBy(f => f.TargetClassName)
            .ToDictionary(g => g.Key, g => g.ToList());

        // Record MsgSend signatures used by hand-written classes
        // (NSObject, NSString, NSArray, NSData, CAMetalLayer, etc.) which are not
        // auto-generated but still need matching ObjectiveC.MsgSend* overloads.
        RecordMsgSend("MsgSend");
        RecordMsgSend("MsgSend", "CGSize");
        RecordMsgSend("MsgSend", "nint");

        RecordMsgSend("MsgSendBool");
        RecordMsgSend("MsgSendCGSize");
        RecordMsgSend("MsgSendDouble");
        RecordMsgSend("MsgSendFloat");
        RecordMsgSend("MsgSendInt");
        RecordMsgSend("MsgSendLong");

        RecordMsgSend("MsgSendNInt");
        RecordMsgSend("MsgSendNInt", "Bool8");
        RecordMsgSend("MsgSendNInt", "double");
        RecordMsgSend("MsgSendNInt", "float");
        RecordMsgSend("MsgSendNInt", "int");
        RecordMsgSend("MsgSendNInt", "long");
        RecordMsgSend("MsgSendNInt", "nint");
        RecordMsgSend("MsgSendNInt", "nint", "nint");
        RecordMsgSend("MsgSendNInt", "nuint");
        RecordMsgSend("MsgSendNInt", "uint");
        RecordMsgSend("MsgSendNInt", "ulong");

        RecordMsgSend("MsgSendNUInt");
        RecordMsgSend("MsgSendUInt");
        RecordMsgSend("MsgSendULong");

        foreach (ClassDef classDef in context.Classes)
        {
            string csClassName = classDef.FullCsName;
            HashSet<string> inheritedProps = GetInheritedProperties(csClassName);
            freeFuncsByClass.TryGetValue(csClassName, out List<FreeFunctionDef>? classFuncs);
            GenerateClass(classDef, inheritedProps, knownDelegateNames, classFuncs ?? []);
        }

        GenerateObjectiveCFile();
    }

    #endregion

}