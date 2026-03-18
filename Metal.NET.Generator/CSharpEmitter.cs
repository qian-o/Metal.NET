namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
partial class CSharpEmitter(string outputDir, GeneratorContext context, TypeMapper typeMapper)
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

}