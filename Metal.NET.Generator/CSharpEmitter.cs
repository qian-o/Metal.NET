using System.Text;

namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-cpp definitions.
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

    /// <summary>Hand-written structs to skip during generation (already defined in MTLStructs.cs).</summary>
    static readonly HashSet<string> SkipStructs =
    [
        "CGSize",
        "MTL4BufferRange",
        "MTL4CopySparseBufferMappingOperation",
        "MTL4CopySparseTextureMappingOperation",
        "MTL4Origin",
        "MTL4Range",
        "MTL4Size",
        "MTL4TimestampHeapEntry",
        "MTL4UpdateSparseBufferMappingOperation",
        "MTL4UpdateSparseTextureMappingOperation",
        "MTLAccelerationStructureSizes",
        "MTLAxisAlignedBoundingBox",
        "MTLClearColor",
        "MTLComponentTransform",
        "MTLCounterResultStageUtilization",
        "MTLCounterResultStatistic",
        "MTLCounterResultTimestamp",
        "MTLOrigin",
        "MTLPackedFloat3",
        "MTLPackedFloat4x3",
        "MTLPackedFloatQuaternion",
        "MTLRange",
        "MTLRegion",
        "MTLResourceID",
        "MTLSamplePosition",
        "MTLScissorRect",
        "MTLSize",
        "MTLSizeAndAlign",
        "MTLTextureSwizzleChannels",
        "MTLVertexAmplificationViewMapping",
        "MTLViewport",
        "NSRange",
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
            set = new SortedSet<string>(StringComparer.Ordinal);
            context.MsgSendSignatures[group] = set;
        }
        set.Add(key);
    }

    #region Generation Entry Point

    public void GenerateAll()
    {
        // Group enums by namespace into consolidated files (e.g., MTLEnums.cs, NSEnums.cs, MTLFXEnums.cs)
        var enumsBySubdir = context.Enums.GroupBy(e => TypeMapper.GetOutputSubdir(e.CppNamespace));
        foreach (var group in enumsBySubdir)
        {
            GenerateEnumFile(group.Key, group.ToList());
        }

        // Group structs by namespace into consolidated files (e.g., MTLStructs.cs)
        var structsBySubdir = context.Structs.GroupBy(s => TypeMapper.GetOutputSubdir(s.CppNamespace));
        foreach (var group in structsBySubdir)
        {
            GenerateStructFile(group.Key, group.ToList());
        }

        // Generate consolidated delegate file for block type aliases
        if (context.BlockTypeAliases.Count > 0)
        {
            GenerateDelegateFile();
        }

        // Build known class names (both generated and hand-written)
        foreach (ClassDef classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            context.KnownClassNames.Add(prefix + classDef.Name);
        }
        context.KnownClassNames.UnionWith(["NSObject", "NSString", "NSError", "NSArray", "NSURL", "NSDictionary", "NSNumber", "NSData", "NSBundle", "NativeObject"]);

        // Build a map of class name → property names for inheritance detection
        Dictionary<string, HashSet<string>> classPropertyMap = [];
        foreach (ClassDef classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            string csClassName = prefix + classDef.Name;
            classPropertyMap[csClassName] =
            [
                .. classDef.Methods.Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget && m.IsConst)
                                   .Select(m => TypeMapper.ToPascalCase(m.CppName))
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
            ClassDef classDef = context.Classes.First(c => TypeMapper.GetPrefix(c.CppNamespace) + c.Name == csClassName);
            string? current = classDef.BaseClassName;
            while (current != null && context.KnownClassNames.Contains(current) && classPropertyMap.TryGetValue(current, out HashSet<string>? parentProps))
            {
                result.UnionWith(parentProps);
                ClassDef? parentDef = context.Classes.FirstOrDefault(c => TypeMapper.GetPrefix(c.CppNamespace) + c.Name == current);
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

        RecordMsgSend("MsgSendPtr");
        RecordMsgSend("MsgSendPtr", "nint");
        RecordMsgSend("MsgSendPtr", "nint", "nint");
        RecordMsgSend("MsgSendPtr", "Bool8");
        RecordMsgSend("MsgSendPtr", "float");
        RecordMsgSend("MsgSendPtr", "double");
        RecordMsgSend("MsgSendPtr", "int");
        RecordMsgSend("MsgSendPtr", "uint");
        RecordMsgSend("MsgSendPtr", "long");
        RecordMsgSend("MsgSendPtr", "ulong");
        RecordMsgSend("MsgSendPtr", "nuint");

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
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            string csClassName = prefix + classDef.Name;
            HashSet<string> inheritedProps = GetInheritedProperties(csClassName);
            freeFuncsByClass.TryGetValue(csClassName, out List<FreeFunctionDef>? classFuncs);
            GenerateClass(classDef, inheritedProps, classFuncs ?? []);
        }

        GenerateObjectiveCFile();
    }

    #endregion

    #region Enum Generation

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
            string prefix = TypeMapper.GetPrefix(enumDef.CppNamespace);
            string oldFile = Path.Combine(dir, $"{prefix}{enumDef.Name}.cs");
            if (File.Exists(oldFile))
            {
                File.Delete(oldFile);
            }
        }

        StringBuilder sb = new();
        sb.AppendLine("namespace Metal.NET;");

        List<EnumDef> sortedEnums = [.. enums.OrderBy(e => TypeMapper.GetPrefix(e.CppNamespace) + e.Name)];

        for (int ei = 0; ei < sortedEnums.Count; ei++)
        {
            EnumDef enumDef = sortedEnums[ei];
            string prefix = TypeMapper.GetPrefix(enumDef.CppNamespace);
            string csEnumName = prefix + enumDef.Name;

            sb.AppendLine();
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

    void GenerateStructFile(string subdir, List<StructDef> structs)
    {
        // Filter out hand-written structs
        List<StructDef> generatable = structs
            .Where(s => !SkipStructs.Contains(TypeMapper.GetPrefix(s.CppNamespace) + s.Name))
            .ToList();

        if (generatable.Count == 0)
        {
            return;
        }

        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        string fileName = subdir switch
        {
            "Metal" => "MTLPackedStructs.cs",
            "Foundation" => "NSPackedStructs.cs",
            "MetalFX" => "MTLFXPackedStructs.cs",
            _ => $"{subdir}PackedStructs.cs"
        };

        StringBuilder sb = new();
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");

        List<StructDef> sortedStructs = [.. generatable.OrderBy(s => TypeMapper.GetPrefix(s.CppNamespace) + s.Name)];

        foreach (StructDef structDef in sortedStructs)
        {
            string prefix = TypeMapper.GetPrefix(structDef.CppNamespace);
            string csStructName = prefix + structDef.Name;

            sb.AppendLine();
            sb.AppendLine("[StructLayout(LayoutKind.Sequential)]");

            List<string> ctorParams = [];
            List<string> fieldLines = [];
            foreach (StructFieldDef field in structDef.Fields)
            {
                string csType = TypeMapper.MapCppType(field.CppType, structDef.CppNamespace);
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

    void GenerateDelegateFile()
    {
        string dir = Path.Combine(outputDir, "Metal");
        Directory.CreateDirectory(dir);

        StringBuilder sb = new();
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");

        foreach (BlockTypeAlias alias in context.BlockTypeAliases.OrderBy(a => a.CsDelegateName))
        {
            sb.AppendLine();
            sb.AppendLine("[UnmanagedFunctionPointer(CallingConvention.Cdecl)]");

            string paramStr = string.Join(", ", alias.Parameters.Select(p => $"{p.CsType} {p.Name}"));
            sb.AppendLine($"public delegate void {alias.CsDelegateName}({paramStr});");
        }

        File.WriteAllText(Path.Combine(dir, "MTLDelegates.cs"), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: Metal/MTLDelegates.cs ({context.BlockTypeAliases.Count} delegates)");
    }

    #endregion

    #region Class Generation

    void GenerateClass(ClassDef classDef, HashSet<string> inheritedProperties, List<FreeFunctionDef> freeFunctions)
    {
        string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
        string csClassName = prefix + classDef.Name;

        if (SkipClasses.Contains(csClassName))
        {
            return;
        }

        string subdir = TypeMapper.GetOutputSubdir(classDef.CppNamespace);
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        bool hasClassField = context.RegisteredClasses.Contains(csClassName);
        bool hasFreeFunctions = freeFunctions.Count > 0;

        List<MethodInfo> validMethods =
        [
            .. classDef.Methods.Where(m => !m.Parameters.Any(p => p.CppType == "ARRAY_PARAM")
                                           && !HasUnmergableArrayParam(m)
                                           && !HasFunctionPointerParam(m)
                                           && !HasUnmappableParam(m))
        ];

        HashSet<string> hasZeroParamVersion =
        [
            .. validMethods
                .Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget)
                .Select(m => m.CppName)
        ];

        (List<PropertyDef> properties, List<MethodInfo> methods) = CategorizeMembers(validMethods);

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
        sb.AppendLine($"    #region INativeObject");
        sb.AppendLine($"    public static {newKeyword}{csClassName} Null {{ get; }} = new(0, NativeObjectOwnership.Borrowed);");
        sb.AppendLine();
        sb.AppendLine($"    public static {newKeyword}{csClassName} New(nint nativePtr, NativeObjectOwnership ownership)");
        sb.AppendLine("    {");
        sb.AppendLine("        return new(nativePtr, ownership);");
        sb.AppendLine("    }");
        sb.AppendLine("    #endregion");

        bool hasPrecedingMember = true;
        if (hasClassField)
        {
            sb.AppendLine();
            sb.AppendLine($"    public {csClassName}() : this(ObjectiveC.AllocInit({csClassName}Bindings.Class), NativeObjectOwnership.Managed)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        foreach (PropertyDef prop in properties)
        {
            int prevLen = sb.Length;
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            if (EmitProperty(sb, prop, csClassName, classDef.CppNamespace, selectors, inheritedProperties))
            {
                hasPrecedingMember = true;
            }
            else
            {
                sb.Length = prevLen;
            }
        }

        MethodInfo? indexerGetter = methods.FirstOrDefault(m =>
            m.SelectorAccessor is "objectAtIndexedSubscript_"
            || (m.CppName == "object" && m.Parameters.Count == 1 && m.ReturnType != "void"));
        MethodInfo? indexerSetter = methods.FirstOrDefault(m =>
            m.SelectorAccessor is "setObject_atIndexedSubscript_"
            || (m.CppName == "setObject" && m.Parameters.Count == 2 && m.ReturnType == "void"));

        if (indexerGetter != null)
        {
            const string getterSelectorObjC = "objectAtIndexedSubscript:";
            const string setterSelectorObjC = "setObject:atIndexedSubscript:";

            selectors.TryAdd("Object", getterSelectorObjC);

            string elemType = TypeMapper.MapCppType(indexerGetter.ReturnType, classDef.CppNamespace);
            string indexParam = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(indexerGetter.Parameters[0].Name));

            sb.AppendLine();
            sb.AppendLine($"    public {elemType} this[nuint {indexParam}]");
            sb.AppendLine("    {");
            sb.AppendLine("        get");
            sb.AppendLine("        {");
            sb.AppendLine($"            nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, {csClassName}Bindings.Object, {indexParam});");
            sb.AppendLine();
            sb.AppendLine("            return new(nativePtr, NativeObjectOwnership.Borrowed);");
            sb.AppendLine("        }");
            RecordMsgSend("MsgSendPtr", "nuint");

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

        foreach (MethodInfo method in methods)
        {
            if (method == indexerGetter || method == indexerSetter)
            {
                continue;
            }

            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitMethod(sb, method, csClassName, classDef.CppNamespace, selectors, hasZeroParamVersion);
            hasPrecedingMember = true;
        }

        foreach (FreeFunctionDef func in freeFunctions)
        {
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitFreeFunction(sb, func, classDef.CppNamespace, csClassName);
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
    /// Separates methods into properties (getter/setter pairs) and remaining methods.
    /// A method is treated as a property getter if it has no parameters, returns non-void,
    /// is const, is not static, and is not an ownership-transfer method (new/alloc/copy/init).
    /// </summary>
    static (List<PropertyDef> Properties, List<MethodInfo> Methods) CategorizeMembers(List<MethodInfo> allMethods)
    {
        List<PropertyDef> properties = [];
        List<MethodInfo> methods = [];
        HashSet<MethodInfo> used = new(ReferenceEqualityComparer.Instance);

        Dictionary<string, MethodInfo> setterMap = new(StringComparer.Ordinal);
        foreach (MethodInfo m in allMethods)
        {
            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3]) &&
                m.ReturnType == "void" && m.Parameters.Count == 1)
            {
                string propName = char.ToLower(m.CppName[3]) + (m.CppName.Length > 4 ? m.CppName[4..] : "");
                setterMap[propName] = m;
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

            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3]))
            {
                continue;
            }

            if (TypeMapper.IsOwnershipTransferMethod(m.CppName))
            {
                continue;
            }

            if (!m.IsConst)
            {
                continue;
            }

            MethodInfo? setter = null;
            if (setterMap.TryGetValue(m.CppName, out MethodInfo? s))
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

        properties.Sort((a, b) => string.CompareOrdinal(TypeMapper.ToPascalCase(a.Getter.CppName), TypeMapper.ToPascalCase(b.Getter.CppName)));

        return (properties, methods);
    }

    #endregion

    #region Method Filtering

    /// <summary>
    /// Returns true if the method has std::function or unknown function pointer params that should be skipped.
    /// Block handler params (Handler/Block types and INLINE_BLOCK: markers) are NOT considered function pointers.
    /// </summary>
    bool HasFunctionPointerParam(MethodInfo method)
    {
        return method.Parameters.Any(p =>
        {
            if (p.CppType.StartsWith("INLINE_BLOCK:"))
            {
                string delegateName = p.CppType["INLINE_BLOCK:".Length..];
                return delegateName == "UNKNOWN_BLOCK";
            }

            if (p.CppType.Contains("std::function") || p.CppType.Contains("Function&") || p.CppType.Contains("Function &"))
            {
                return true;
            }

            if (p.CppType.Contains("Handler") || p.CppType.Contains("Block"))
            {
                string csType = TypeMapper.MapCppType(p.CppType, "MTL");
                return !context.BlockTypeAliases.Any(b => b.CsDelegateName == csType);
            }

            if (p.CppType.Contains("function") || p.CppType.Contains("void("))
            {
                return true;
            }

            return false;
        });
    }

    /// <summary>
    /// Returns true if the C++ parameter type is a known block handler type (using-aliased).
    /// </summary>
    bool IsBlockHandlerCppType(string cppType)
    {
        if (cppType.Contains("Handler") || cppType.Contains("Block"))
        {
            string csType = TypeMapper.MapCppType(cppType, "MTL");
            return context.BlockTypeAliases.Any(b => b.CsDelegateName == csType);
        }

        return false;
    }

    static bool HasUnmappableParam(MethodInfo method)
    {
        foreach (ParamDef p in method.Parameters)
        {
            if (p.CppType.StartsWith("OBJ_ARRAY:") ||
                p.CppType.StartsWith("PRIM_ARRAY:") ||
                p.CppType.StartsWith("STRUCT_ARRAY:") ||
                p.CppType.StartsWith("INLINE_BLOCK:") ||
                p.CppType == "ARRAY_PARAM")
            {
                continue;
            }

            if (p.CppType.Contains("Handler") || p.CppType.Contains("Block") ||
                p.CppType.Contains("Function&") || p.CppType.Contains("Function &") ||
                p.CppType.Contains("std::function"))
            {
                continue;
            }

            if (TypeMapper.IsUnmappableCppType(p.CppType))
            {
                return true;
            }
        }

        return TypeMapper.IsUnmappableCppType(method.ReturnType);
    }

    static bool HasUnmergableArrayParam(MethodInfo method)
    {
        List<ParamDef> p = method.Parameters;
        for (int i = 0; i < p.Count; i++)
        {
            if (p[i].CppType.StartsWith("OBJ_ARRAY:") ||
                p[i].CppType.StartsWith("PRIM_ARRAY:") ||
                p[i].CppType.StartsWith("STRUCT_ARRAY:"))
            {
                bool nextIsCount = i + 1 < p.Count &&
                    p[i + 1].CppType is "NS::UInteger" &&
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

    bool EmitProperty(StringBuilder sb, PropertyDef prop, string csClassName, string ns, SortedDictionary<string, string> selectors, HashSet<string> inheritedProperties)
    {
        MethodInfo getter = prop.Getter;
        string csPropName = TypeMapper.ToPascalCase(getter.CppName);

        if (inheritedProperties.Contains(csPropName))
        {
            return false;
        }

        string csType = TypeMapper.MapCppType(getter.ReturnType, ns);

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
        string selectorObjC;
        if (getter.SelectorAccessor != null && context.SelectorMap.TryGetValue(getter.SelectorAccessor, out string? objcSel))
        {
            selectorObjC = objcSel;
        }
        else
        {
            selectorObjC = getter.CppName;
        }
        selectors.TryAdd(selectorName, selectorObjC);

        const string Target = "NativePtr";

        string selectorRef = $"{csClassName}Bindings.{selectorName}";
        string typeStr = csType;

        string? setSelName = null;
        if (prop.Setter != null)
        {
            setSelName = "Set" + csPropName;
            string setSelObjC;
            if (prop.Setter.SelectorAccessor != null && context.SelectorMap.TryGetValue(prop.Setter.SelectorAccessor, out string? setObjC))
            {
                setSelObjC = setObjC;
            }
            else
            {
                setSelObjC = "set" + csPropName + ":";
            }
            selectors.TryAdd(setSelName, setSelObjC);
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

    void EmitMethod(StringBuilder sb, MethodInfo method, string csClassName, string ns, SortedDictionary<string, string> selectors, HashSet<string> hasZeroParamVersion)
    {
        string csMethodName;
        string selectorObjC;
        string cppName = method.CppName;

        if (method.SelectorAccessor != null)
        {
            if (context.SelectorMap.TryGetValue(method.SelectorAccessor, out string? objcSel))
            {
                selectorObjC = objcSel;
            }
            else
            {
                selectorObjC = method.SelectorAccessor.Replace('_', ':');
            }

            string selectorBaseName = selectorObjC.Contains(':')
                ? selectorObjC[..selectorObjC.IndexOf(':')]
                : selectorObjC;

            if (hasZeroParamVersion.Contains(cppName) && method.Parameters.Count > 0)
            {
                csMethodName = TypeMapper.ToPascalCase(selectorBaseName);
            }
            else
            {
                csMethodName = TypeMapper.ToPascalCase(cppName);
            }
        }
        else
        {
            csMethodName = TypeMapper.ToPascalCase(cppName);
            int colonCount = method.Parameters.Count;
            selectorObjC = method.CppName + (colonCount > 0 ? new string(':', colonCount) : "");
        }

        bool isStaticClassMethod = method.IsStatic && method.UsesClassTarget;
        string target = isStaticClassMethod ? $"{csClassName}Bindings.Class" : "NativePtr";

        string selectorKey;
        if (hasZeroParamVersion.Contains(method.CppName) && method.Parameters.Count > 0)
        {
            selectorKey = TypeMapper.ToPascalCase(selectorObjC.Replace(":", " ").Trim()).Replace(" ", "");
        }
        else
        {
            selectorKey = TypeMapper.ToPascalCase(method.CppName);
        }
        if (selectors.TryGetValue(selectorKey, out string? existingSelector) && existingSelector != selectorObjC)
        {
            selectorKey = TypeMapper.ToPascalCase(selectorObjC.Replace(":", " ").Trim()).Replace(" ", "");
        }
        selectors.TryAdd(selectorKey, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        string returnType = TypeMapper.MapCppType(method.ReturnType, ns);

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

        bool hasOutError = method.Parameters.Any(p => p.CppType.Contains("Error**"));

        List<string> csParams = [];
        List<string> callArgs = [target, selectorRef];
        List<string> callArgTypes = [];
        List<string> arraySetupLines = [];
        List<string> fixedStatements = [];
        List<string> nsArrayReleaseVars = [];
        bool needsUnsafeContext = false;

        for (int pi = 0; pi < method.Parameters.Count; pi++)
        {
            ParamDef param = method.Parameters[pi];
            if (param.CppType == "ARRAY_PARAM")
            {
                continue;
            }

            if (param.CppType.StartsWith("OBJ_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemCppType = param.CppType["OBJ_ARRAY:".Length..];
                string elemCsType = TypeMapper.MapCppType(elemCppType + "*", ns);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].CppType is "NS::UInteger" &&
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

            if (param.CppType.StartsWith("PRIM_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemType = param.CppType["PRIM_ARRAY:".Length..];
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

            if (param.CppType.StartsWith("STRUCT_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemCppType = param.CppType["STRUCT_ARRAY:".Length..];
                string elemCsType = TypeMapper.MapCppType(elemCppType, ns);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].CppType is "NS::UInteger" &&
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

            if (param.CppType.StartsWith("INLINE_BLOCK:"))
            {
                string delegateName = param.CppType["INLINE_BLOCK:".Length..];
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                csParams.Add($"{delegateName} {csParamName}");
                callArgs.Add(csParamName);
                callArgTypes.Add(delegateName);
                continue;
            }

            if (IsBlockHandlerCppType(param.CppType))
            {
                string csType = TypeMapper.MapCppType(param.CppType, ns);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                csParams.Add($"{csType} {csParamName}");
                callArgs.Add(csParamName);
                callArgTypes.Add(csType);
                continue;
            }

            string csParamType = TypeMapper.MapCppType(param.CppType, ns);
            string paramName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

            if (param.CppType.Contains("Error**"))
            {
                csParams.Add("out NSError error");
                callArgs.Add("out nint errorPtr");
                callArgTypes.Add("out nint");
                continue;
            }

            if (param.CppType.Contains("Timestamp*") && !param.CppType.Contains("TimestampGranularity"))
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
            RecordMsgSend("MsgSendPtr", argTypesArray);
            msgSendExpr = $"ObjectiveC.MsgSendPtr({argsStr})";
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
        else if (hasOutError)
        {
            sb.AppendLine($"{indent}{csReturnType} result = {msgSendExpr};");
            sb.AppendLine();
            sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
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

    #endregion

    #region Free Function Emission

    void EmitFreeFunction(StringBuilder sb, FreeFunctionDef func, string cppNamespace, string csClassName)
    {
        string csReturnType = TypeMapper.MapCppType(func.ReturnType, cppNamespace);

        string? returnArrayElemType = null;
        if (csReturnType == "NSArray")
        {
            returnArrayElemType = TryResolveNSArrayElementType(csClassName, func.CppName);
        }
        bool returnsArray = returnArrayElemType != null;
        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(csReturnType);

        List<string> pinvokeParams = [];
        foreach (ParamDef p in func.Parameters)
        {
            string csType = TypeMapper.MapCppType(p.CppType, cppNamespace);
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
            string csType = TypeMapper.MapCppType(p.CppType, cppNamespace);
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
            sb.AppendLine($"    public static {csFullReturnType} {func.CppName}({wrapperParamStr})");
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
            sb.AppendLine($"    public static {csFullReturnType} {func.CppName}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine("        return new(nativePtr, NativeObjectOwnership.Owned);");
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

    #endregion

    #region ObjectiveC.cs Generation

    /// <summary>
    /// Generates the auto-generated Common/ObjectiveC.cs file containing all required
    /// P/Invoke MsgSend overloads, null-guard wrappers, and Alloc/Init/Release helpers.
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
        sb.AppendLine("public static partial class ObjectiveC");
        sb.AppendLine("{");

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
            string privatePrefix = $"_{group}";
            bool isVoid = returnType == "void";

            var signatures = context.MsgSendSignatures[group];

            foreach (string sig in signatures)
            {
                sb.AppendLine();
                string pinvokeParams = BuildPInvokeParams(sig);
                sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"objc_msgSend\")]");
                sb.AppendLine($"    private static partial {returnType} {privatePrefix}(nint receiver, Selector selector{pinvokeParams});");
            }

            foreach (string sig in signatures)
            {
                string publicParams = BuildPublicParams(sig);
                string callArgStr = BuildCallArgs(sig);
                List<string> outParams = GetOutParams(sig);

                sb.AppendLine();
                sb.AppendLine($"    public static {returnType} {group}(nint receiver, Selector selector{publicParams})");
                sb.AppendLine("    {");
                sb.AppendLine("        if (receiver is 0)");
                sb.AppendLine("        {");

                foreach (string outParam in outParams)
                {
                    sb.AppendLine($"            {outParam} = default;");
                }

                if (isVoid)
                {
                    sb.AppendLine("            return;");
                }
                else
                {
                    sb.AppendLine("            return default;");
                }

                sb.AppendLine("        }");
                sb.AppendLine();

                if (isVoid)
                {
                    sb.AppendLine($"        {privatePrefix}(receiver, selector{callArgStr});");
                }
                else
                {
                    sb.AppendLine($"        return {privatePrefix}(receiver, selector{callArgStr});");
                }

                sb.AppendLine("    }");
            }

            sb.AppendLine();
            sb.AppendLine("    #endregion");
        }

        sb.AppendLine();
        sb.AppendLine("    public static nint Alloc(nint @class)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendPtr(@class, \"alloc\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint Init(nint receiver)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendPtr(receiver, \"init\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint AllocInit(nint @class)");
        sb.AppendLine("    {");
        sb.AppendLine("        return Init(Alloc(@class));");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint Retain(nint receiver)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendPtr(receiver, \"retain\");");
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

    static string GetReturnTypeForGroup(string group) => group switch
    {
        "MsgSend" => "void",
        "MsgSendBool" => "Bool8",
        "MsgSendPtr" => "nint",
        "MsgSendInt" => "int",
        "MsgSendUInt" => "uint",
        "MsgSendLong" => "long",
        "MsgSendULong" => "ulong",
        "MsgSendFloat" => "float",
        "MsgSendDouble" => "double",
        "MsgSendNUInt" => "nuint",
        _ => group.Replace("MsgSend", "")
    };

    static string BuildPInvokeParams(string sig)
    {
        if (string.IsNullOrEmpty(sig)) return "";

        string[] types = sig.Split(", ");
        StringBuilder sb = new();
        char letter = 'a';
        foreach (string type in types)
        {
            sb.Append($", {type} {letter}");
            letter++;
        }
        return sb.ToString();
    }

    static string BuildPublicParams(string sig) => BuildPInvokeParams(sig);

    static string BuildCallArgs(string sig)
    {
        if (string.IsNullOrEmpty(sig)) return "";

        string[] types = sig.Split(", ");
        StringBuilder sb = new();
        char letter = 'a';
        foreach (string type in types)
        {
            if (type.StartsWith("out "))
            {
                sb.Append($", out {letter}");
            }
            else
            {
                sb.Append($", {letter}");
            }
            letter++;
        }
        return sb.ToString();
    }

    static List<string> GetOutParams(string sig)
    {
        if (string.IsNullOrEmpty(sig)) return [];

        string[] types = sig.Split(", ");
        List<string> outParams = [];
        char letter = 'a';
        foreach (string type in types)
        {
            if (type.StartsWith("out "))
            {
                outParams.Add(letter.ToString());
            }
            letter++;
        }
        return outParams;
    }

    #endregion
}