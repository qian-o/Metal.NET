using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Deserializes metal-ast.json and populates a <see cref="GeneratorContext"/>
/// with enum, class, struct, free function, and block type alias definitions.
/// </summary>
partial class AstJsonParser
{
    /// <summary>Methods to skip during parsing (ObjC runtime methods handled by the framework).</summary>
    static readonly HashSet<string> SkipMethods = ["alloc", "init", "retain", "release", "autorelease", "copy", "retainCount"];

    /// <summary>Selectors to skip entirely (not relevant for generated bindings).</summary>
    static readonly HashSet<string> SkipSelectors =
    [
        "isEqual:", "hash", "superclass", "class", "self", "zone", "performSelector:",
        "performSelector:withObject:", "performSelector:withObject:withObject:",
        "isProxy", "isKindOfClass:", "isMemberOfClass:", "conformsToProtocol:",
        "respondsToSelector:", "retain", "release", "autorelease", "retainCount",
        "description", "debugDescription", "dealloc", "finalize",
        "observationInfo", "setObservationInfo:", "classForCoder",
        "replacementObjectForCoder:", "awakeAfterUsingCoder:",
        "observeValueForKeyPath:ofObject:change:context:",
        "encodeWithCoder:", "initWithCoder:",
        "supportsSecureCoding", "countByEnumeratingWithState:objects:count:",
        "copyWithZone:", "mutableCopyWithZone:",
        "array", "arrayWithObject:", "arrayWithObjects:count:",
        "objectAtIndex:", "count",
    ];

    /// <summary>Known inline block signatures mapped to delegate names.</summary>
    static readonly Dictionary<string, string> InlineBlockDelegateNames = new()
    {
        ["void * _Nonnull, NSUInteger"] = "MTLDeallocator",
        ["unichar * _Nonnull, NSUInteger"] = "MTLDeallocator",
    };

    /// <summary>Override parameter names for known inline block types.</summary>
    static readonly Dictionary<string, string[]> InlineBlockParamNames = new()
    {
        ["MTLDeallocator"] = ["pointer", "length"],
    };

    /// <summary>Known ObjC class names that support AllocInit (have a registered ObjC class).</summary>
    static readonly HashSet<string> AllocInitClasses =
    [
        "MTLTextureDescriptor", "MTLRenderPipelineDescriptor", "MTLComputePipelineDescriptor",
        "MTLRenderPassDescriptor", "MTLDepthStencilDescriptor", "MTLStencilDescriptor",
        "MTLSamplerDescriptor", "MTLCompileOptions", "MTLVertexDescriptor",
        "MTLRenderPipelineColorAttachmentDescriptor", "MTLTileRenderPipelineColorAttachmentDescriptor",
        "MTLTileRenderPipelineDescriptor", "MTLMeshRenderPipelineDescriptor",
        "MTLComputePassDescriptor", "MTLBlitPassDescriptor", "MTLRenderPassAttachmentDescriptor",
        "MTLRenderPassColorAttachmentDescriptor", "MTLRenderPassDepthAttachmentDescriptor",
        "MTLRenderPassStencilAttachmentDescriptor",
        "MTLFunctionDescriptor", "MTLIntersectionFunctionDescriptor",
        "MTLFunctionConstantValues", "MTLLinkedFunctions",
        "MTLBinaryArchiveDescriptor", "MTLCaptureDescriptor",
        "MTLResourceStatePassDescriptor", "MTLAccelerationStructurePassDescriptor",
        "MTLBlitPassSampleBufferAttachmentDescriptor", "MTLComputePassSampleBufferAttachmentDescriptor",
        "MTLRenderPassSampleBufferAttachmentDescriptor", "MTLResourceStatePassSampleBufferAttachmentDescriptor",
        "MTLAccelerationStructurePassSampleBufferAttachmentDescriptor",
        "MTLAccelerationStructureDescriptor", "MTLAccelerationStructureGeometryDescriptor",
        "MTLPrimitiveAccelerationStructureDescriptor",
        "MTLAccelerationStructureTriangleGeometryDescriptor",
        "MTLAccelerationStructureBoundingBoxGeometryDescriptor",
        "MTLAccelerationStructureMotionTriangleGeometryDescriptor",
        "MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor",
        "MTLAccelerationStructureCurveGeometryDescriptor",
        "MTLAccelerationStructureMotionCurveGeometryDescriptor",
        "MTLInstanceAccelerationStructureDescriptor",
        "MTLIndirectInstanceAccelerationStructureDescriptor",
        "MTLMotionKeyframeData",
        "MTLHeapDescriptor", "MTLCommandBufferDescriptor",
        "MTLIndirectCommandBufferDescriptor",
        "MTLVisibleFunctionTableDescriptor", "MTLIntersectionFunctionTableDescriptor",
        "MTLCounterSampleBufferDescriptor", "MTLResidencySetDescriptor",
        "MTLTextureViewDescriptor", "MTLIOCommandQueueDescriptor",
        "MTLLogStateDescriptor", "MTLRasterizationRateMapDescriptor",
        "MTLSharedEventListener", "MTLArgumentDescriptor",
        "MTLStageInputOutputDescriptor", "MTLAttributeDescriptor",
        "MTLBufferLayoutDescriptor", "MTLVertexAttributeDescriptor",
        "MTLVertexBufferLayoutDescriptor", "MTLPipelineBufferDescriptor",
        "MTLCommandQueueDescriptor", "MTLTensorDescriptor",
        "MTLRenderPipelineFunctionsDescriptor",
        "MTLStitchedLibraryDescriptor", "MTLRasterizationRateLayerDescriptor",
        "MTLResourceViewPoolDescriptor", "MTLTextureViewPool",
        "MTLCaptureManager",
        // MTL4 classes
        "MTL4CompilerDescriptor", "MTL4CompilerTaskOptions",
        "MTL4LibraryFunctionDescriptor", "MTL4SpecializedFunctionDescriptor",
        "MTL4StitchedFunctionDescriptor",
        "MTL4ComputePipelineDescriptor", "MTL4CounterHeapDescriptor",
        "MTL4ArgumentTableDescriptor",
        "MTL4LibraryDescriptor", "MTL4PipelineOptions",
        "MTL4PipelineDescriptor", "MTL4PipelineDataSetSerializerDescriptor",
        "MTL4StaticLinkingDescriptor", "MTL4PipelineStageDynamicLinkingDescriptor",
        "MTL4RenderPipelineDynamicLinkingDescriptor",
        "MTL4RenderPipelineColorAttachmentDescriptor",
        "MTL4RenderPipelineDescriptor", "MTL4RenderPassDescriptor",
        "MTL4CommandBufferOptions", "MTL4CommitOptions",
        "MTL4CommandQueueDescriptor", "MTL4CommandAllocatorDescriptor",
        "MTL4RenderPipelineBinaryFunctionsDescriptor",
        "MTL4AccelerationStructureDescriptor", "MTL4AccelerationStructureGeometryDescriptor",
        "MTL4PrimitiveAccelerationStructureDescriptor",
        "MTL4AccelerationStructureTriangleGeometryDescriptor",
        "MTL4AccelerationStructureBoundingBoxGeometryDescriptor",
        "MTL4AccelerationStructureMotionTriangleGeometryDescriptor",
        "MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor",
        "MTL4AccelerationStructureCurveGeometryDescriptor",
        "MTL4AccelerationStructureMotionCurveGeometryDescriptor",
        "MTL4InstanceAccelerationStructureDescriptor",
        "MTL4IndirectInstanceAccelerationStructureDescriptor",
        "MTL4BinaryFunctionDescriptor", "MTL4FunctionDescriptor",
        "MTL4MachineLearningPipelineDescriptor",
        "MTL4MeshRenderPipelineDescriptor",
        "MTL4TileRenderPipelineDescriptor",
        // MTLFX classes
        "MTLFXTemporalScalerDescriptor", "MTLFXTemporalDenoisedScalerDescriptor",
        "MTLFXSpatialScalerDescriptor", "MTLFXFrameInterpolatorDescriptor",
        // QuartzCore
        "CAMetalLayer",
    ];

    /// <summary>Protocols to skip (not relevant for generated bindings).</summary>
    static readonly HashSet<string> SkipProtocols =
    [
        "NSObject", "NSCopying", "NSMutableCopying", "NSSecureCoding", "NSFastEnumeration",
    ];

    /// <summary>Classes to skip (hand-written or not relevant).</summary>
    static readonly HashSet<string> SkipClasses =
    [
        "NSObject", "NSArray", "NSString", "NSError", "NSURL",
        "NSDictionary", "NSNumber", "NSValue", "NSData",
        "NSBundle", "NSProcessInfo", "NSAutoreleasePool",
        "NSDate", "NSNotification", "NSNotificationCenter",
        "NSSet", "NSEnumerator",
    ];

    /// <summary>Structs to skip during parsing.</summary>
    static readonly HashSet<string> SkipStructParseNames = ["CGSize", "SimdFloat4", "SimdFloat4x4", "MTLPackedFloat3", "MTLPackedFloat4x3", "MTLPackedFloatQuaternion"];

    public GeneratorContext Parse(string astJsonPath)
    {
        GeneratorContext context = new();

        byte[] bytes = File.ReadAllBytes(astJsonPath);
        int offset = bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF ? 3 : 0;

        AstRoot ast = JsonSerializer.Deserialize<AstRoot>(bytes.AsSpan(offset))
            ?? throw new InvalidOperationException("Failed to deserialize metal-ast.json");

        ParseEnums(ast, context);
        ParseStructs(ast, context);
        ParseBlockTypedefs(ast, context);
        ParseProtocols(ast, context);
        ParseClasses(ast, context);
        ParseFreeFunctions(ast, context);

        return context;
    }

    #region Enum Parsing

    static void ParseEnums(AstRoot ast, GeneratorContext context)
    {
        foreach (AstEnum astEnum in ast.Enums)
        {
            if (astEnum.Framework is null or "CoreFoundation" or "CoreImage" or "CoreGraphics")
            {
                continue;
            }

            string cppNamespace = InferNamespaceFromName(astEnum.Name);
            string prefix = TypeMapper.GetPrefix(cppNamespace);
            string backingType = MapEnumBackingType(astEnum.UnderlyingType);

            // Strip the ObjC prefix from enum name to get the bare name
            string bareName = astEnum.Name;
            if (bareName.StartsWith(prefix))
            {
                bareName = bareName[prefix.Length..];
            }

            string csEnumName = prefix + bareName;
            context.EnumBackingTypes[csEnumName] = backingType;

            List<EnumMember> members = [];
            foreach (AstEnumMember m in astEnum.Members)
            {
                // Strip the enum prefix from member names
                string memberName = m.Name;
                if (memberName.StartsWith(astEnum.Name))
                {
                    memberName = memberName[astEnum.Name.Length..];
                }
                else if (memberName.StartsWith(prefix))
                {
                    memberName = memberName[prefix.Length..];
                    // If the remaining starts with the bare enum name, strip that too
                    if (memberName.StartsWith(bareName))
                    {
                        memberName = memberName[bareName.Length..];
                    }
                }

                if (memberName.Length > 0 && char.IsDigit(memberName[0]))
                {
                    memberName = prefix + memberName;
                }

                if (string.IsNullOrEmpty(memberName))
                {
                    memberName = m.Name;
                }

                members.Add(new EnumMember(memberName, m.Value));
            }

            context.Enums.Add(new EnumDef(
                cppNamespace, bareName, backingType, astEnum.IsOptions, members,
                astEnum.Deprecated, astEnum.DeprecationMessage));
        }
    }

    static string MapEnumBackingType(string objcType) => objcType.Trim() switch
    {
        "NSUInteger" => "ulong",
        "NSInteger" => "long",
        "uint32_t" => "uint",
        "int32_t" => "int",
        "uint8_t" => "byte",
        "uint64_t" => "ulong",
        "int64_t" => "long",
        _ => "ulong"
    };

    #endregion

    #region Struct Parsing

    static void ParseStructs(AstRoot ast, GeneratorContext context)
    {
        foreach (AstStruct astStruct in ast.Structs)
        {
            if (SkipStructParseNames.Contains(astStruct.Name))
            {
                continue;
            }

            string cppNamespace = InferNamespaceFromName(astStruct.Name);
            if (cppNamespace == "")
            {
                // Structs without a known prefix (like CGSize) are skipped
                continue;
            }

            string prefix = TypeMapper.GetPrefix(cppNamespace);
            string bareName = astStruct.Name.StartsWith(prefix)
                ? astStruct.Name[prefix.Length..]
                : astStruct.Name;

            List<StructFieldDef> fields = [];
            foreach (AstStructField f in astStruct.Fields)
            {
                string fieldType = f.Type;

                // Handle array fields: "Type[N]" → expand to N individual fields
                Match arrayMatch = ArrayFieldRegex().Match(fieldType);
                if (arrayMatch.Success)
                {
                    string elemType = arrayMatch.Groups[1].Value;
                    if (int.TryParse(arrayMatch.Groups[2].Value, out int count))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            fields.Add(new StructFieldDef(elemType, $"{f.Name}{i}"));
                        }
                        continue;
                    }
                }

                // Skip union/nested struct types
                if (fieldType.Contains("union") || fieldType.Contains("anonymous"))
                {
                    continue;
                }

                fields.Add(new StructFieldDef(fieldType, f.Name));
            }

            if (fields.Count > 0)
            {
                context.Structs.Add(new StructDef(cppNamespace, bareName, fields));
            }
        }
    }

    #endregion

    #region Block Typedef Parsing

    static void ParseBlockTypedefs(AstRoot ast, GeneratorContext context)
    {
        foreach (AstTypedef td in ast.Typedefs)
        {
            if (!td.UnderlyingType.Contains("(^)"))
            {
                continue;
            }

            string cppNamespace = InferNamespaceFromName(td.Name);

            // Parse the block signature: "void (^)(ParamType1 name1, ParamType2 name2)"
            Match blockMatch = BlockSignatureRegex().Match(td.UnderlyingType);
            if (!blockMatch.Success)
            {
                continue;
            }

            string paramsStr = blockMatch.Groups[1].Value.Trim();
            List<BlockParam> blockParams = [new BlockParam("nint", "nint", "block")]; // ObjC block pointer is always first

            if (!string.IsNullOrWhiteSpace(paramsStr))
            {
                int paramIndex = 0;
                foreach (string part in SplitBlockParams(paramsStr))
                {
                    string p = part.Trim();
                    if (string.IsNullOrWhiteSpace(p))
                    {
                        continue;
                    }

                    // Parse ObjC type and infer param name
                    string objcType = p;
                    string paramName = InferParamNameFromObjCType(objcType, paramIndex);
                    string csType = MapBlockParamType(objcType);

                    blockParams.Add(new BlockParam(objcType, csType, paramName));
                    paramIndex++;
                }
            }

            // Deduplicate param names
            HashSet<string> usedNames = [];
            for (int i = 0; i < blockParams.Count; i++)
            {
                string name = blockParams[i].Name;
                if (!usedNames.Add(name))
                {
                    int suffix = 2;
                    while (!usedNames.Add($"{name}{suffix}"))
                    {
                        suffix++;
                    }
                    blockParams[i] = blockParams[i] with { Name = $"{name}{suffix}" };
                }
            }

            context.BlockTypeAliases.Add(new BlockTypeAlias(cppNamespace, td.Name, td.Name, blockParams));
        }
    }

    static string InferParamNameFromObjCType(string objcType, int index)
    {
        // Strip nullability annotations
        string t = StripNullability(objcType);

        // id<MTLFoo> → foo
        Match idMatch = IdProtocolRegex().Match(t);
        if (idMatch.Success)
        {
            string typeName = idMatch.Groups[1].Value;
            return char.ToLower(typeName[0]) + typeName[1..];
        }

        // MTLFoo * → foo
        if (t.EndsWith('*'))
        {
            string baseName = t.TrimEnd('*').Trim();
            if (baseName.Length > 0)
            {
                // Get last component
                string[] parts = baseName.Split(' ');
                string last = parts[^1];
                return char.ToLower(last[0]) + last[1..];
            }
        }

        // void * → pointer
        if (t.StartsWith("void"))
        {
            return "pointer";
        }

        // Primitive types
        return t switch
        {
            "NSUInteger" or "uint64_t" => "value",
            _ => $"param{index}"
        };
    }

    static string MapBlockParamType(string objcType)
    {
        string t = StripNullability(objcType).Trim();

        // id<Protocol> → nint (pointer to ObjC object)
        if (t.StartsWith("id<") || t.StartsWith("id "))
        {
            return "nint";
        }

        // Any pointer type → nint
        if (t.EndsWith('*'))
        {
            return "nint";
        }

        return t switch
        {
            "NSUInteger" => "nuint",
            "NSInteger" => "nint",
            "uint64_t" => "ulong",
            "int64_t" => "long",
            "uint32_t" => "uint",
            "int32_t" => "int",
            "float" => "float",
            "double" => "double",
            "BOOL" => "bool",
            _ when t.Contains("MTL") || t.Contains("NS") || t.Contains("CA") => "long",
            _ => "nint"
        };
    }

    static List<string> SplitBlockParams(string paramsStr)
    {
        List<string> result = [];
        int depth = 0;
        int start = 0;

        for (int i = 0; i < paramsStr.Length; i++)
        {
            char c = paramsStr[i];
            if (c == '<' || c == '(')
            {
                depth++;
            }
            else if (c == '>' || c == ')')
            {
                depth--;
            }
            else if (c == ',' && depth == 0)
            {
                result.Add(paramsStr[start..i]);
                start = i + 1;
            }
        }

        result.Add(paramsStr[start..]);
        return result;
    }

    #endregion

    #region Protocol & Class Parsing

    void ParseProtocols(AstRoot ast, GeneratorContext context)
    {
        foreach (AstClass proto in ast.Protocols)
        {
            if (SkipProtocols.Contains(proto.Name) || SkipClasses.Contains(proto.Name))
            {
                continue;
            }

            if (proto.Framework is null or "CoreFoundation" or "CoreImage" or "CoreGraphics")
            {
                continue;
            }

            ParseClassOrProtocol(proto, context, isProtocol: true);
        }
    }

    void ParseClasses(AstRoot ast, GeneratorContext context)
    {
        foreach (AstClass cls in ast.Classes)
        {
            if (SkipClasses.Contains(cls.Name))
            {
                continue;
            }

            if (cls.Framework is null or "CoreFoundation" or "CoreImage" or "CoreGraphics")
            {
                continue;
            }

            ParseClassOrProtocol(cls, context, isProtocol: false);
        }
    }

    void ParseClassOrProtocol(AstClass ast, GeneratorContext context, bool isProtocol)
    {
        string cppNamespace = InferNamespaceFromName(ast.Name);
        string prefix = TypeMapper.GetPrefix(cppNamespace);

        string bareName = ast.Name.StartsWith(prefix) ? ast.Name[prefix.Length..] : ast.Name;

        // Determine base class
        string? csBaseClassName = null;
        if (!isProtocol && !string.IsNullOrEmpty(ast.Super) && ast.Super != "NSObject")
        {
            csBaseClassName = ast.Super;
        }

        // Check if class supports AllocInit
        bool hasAllocInit = AllocInitClasses.Contains(ast.Name);

        // Parse methods from the AST (both explicit methods and property accessors)
        List<MethodInfo> methods = [];

        // Track selectors emitted from properties to avoid duplicates from explicit methods
        HashSet<string> propertySelectors = [];

        // Parse properties → generate getter and optional setter methods
        foreach (AstProperty prop in ast.Properties)
        {
            if (SkipSelectors.Contains(prop.Name) || SkipSelectors.Contains(prop.Getter ?? prop.Name))
            {
                continue;
            }

            // Skip unmappable types
            string propObjcType = prop.Type;
            if (IsUnmappableObjCType(propObjcType))
            {
                continue;
            }

            string getterSelector = prop.Getter ?? prop.Name;
            string cppGetterName = SelectorToMethodName(getterSelector);
            string returnType = MapObjCTypeForModel(propObjcType);

            // Getter
            propertySelectors.Add(getterSelector);
            methods.Add(new MethodInfo
            {
                CppName = cppGetterName,
                ReturnType = returnType,
                IsStatic = false,
                IsConst = true,
                Parameters = [],
                UsesClassTarget = false,
                SelectorAccessor = null,
                Selector = getterSelector,
                DeprecationMessage = prop.Deprecated ? prop.DeprecationMessage : null,
            });

            // Setter (if not readonly)
            if (!prop.Readonly)
            {
                string setterSelector = prop.Setter ?? $"set{char.ToUpper(prop.Name[0])}{prop.Name[1..]}:";
                string setCppName = $"set{char.ToUpper(cppGetterName[0])}{cppGetterName[1..]}";
                string paramName = cppGetterName;

                // Map the parameter type
                string paramType = returnType;

                propertySelectors.Add(setterSelector);
                methods.Add(new MethodInfo
                {
                    CppName = setCppName,
                    ReturnType = "void",
                    IsStatic = false,
                    IsConst = false,
                    Parameters = [new ParamDef(paramType, paramName)],
                    UsesClassTarget = false,
                    SelectorAccessor = null,
                    Selector = setterSelector,
                    DeprecationMessage = prop.Deprecated ? prop.DeprecationMessage : null,
                });
            }
        }

        // Parse explicit methods
        foreach (AstMethod astMethod in ast.Methods)
        {
            if (SkipSelectors.Contains(astMethod.Selector))
            {
                continue;
            }

            // Skip methods that duplicate property selectors
            if (propertySelectors.Contains(astMethod.Selector))
            {
                continue;
            }

            string selector = astMethod.Selector;
            string cppName = SelectorToMethodName(selector);

            if (SkipMethods.Contains(cppName))
            {
                continue;
            }

            string returnType = MapObjCTypeForModel(astMethod.ReturnType);

            // Skip unmappable return types
            if (IsUnmappableObjCType(astMethod.ReturnType))
            {
                continue;
            }

            // Parse parameters
            List<ParamDef> parameters = [];
            bool skipMethod = false;
            foreach (AstParam p in astMethod.Parameters)
            {
                if (IsUnmappableObjCType(p.Type))
                {
                    skipMethod = true;
                    break;
                }

                string paramType = MapObjCTypeForModel(p.Type);
                parameters.Add(new ParamDef(paramType, p.Name));
            }

            if (skipMethod)
            {
                continue;
            }

            bool usesClassTarget = astMethod.IsClassMethod;

            methods.Add(new MethodInfo
            {
                CppName = cppName,
                ReturnType = returnType,
                IsStatic = astMethod.IsClassMethod,
                IsConst = !astMethod.IsClassMethod && returnType != "void",
                Parameters = parameters,
                UsesClassTarget = usesClassTarget,
                SelectorAccessor = null,
                Selector = selector,
                DeprecationMessage = astMethod.Deprecated ? astMethod.DeprecationMessage : null,
            });
        }

        context.Classes.Add(new ClassDef
        {
            CppNamespace = cppNamespace,
            Name = bareName,
            IsCopying = false,
            BaseClassName = csBaseClassName,
            Methods = methods,
            HasAllocInit = hasAllocInit,
        });
    }

    #endregion

    #region Free Function Parsing

    static void ParseFreeFunctions(AstRoot ast, GeneratorContext context)
    {
        foreach (AstFunction func in ast.Functions)
        {
            if (func.Framework is null)
            {
                continue;
            }

            string returnType = MapObjCTypeForModel(func.ReturnType);
            if (IsUnmappableObjCType(func.ReturnType))
            {
                continue;
            }

            List<ParamDef> parameters = [];
            bool skip = false;
            foreach (AstParam p in func.Parameters)
            {
                if (IsUnmappableObjCType(p.Type))
                {
                    skip = true;
                    break;
                }
                parameters.Add(new ParamDef(MapObjCTypeForModel(p.Type), p.Name));
            }
            if (skip)
            {
                continue;
            }

            string libraryPath = FrameworkToLibraryPath(func.Framework);

            // Determine correct prefix: try longest prefixes first (MTL4FX, MTL4, MTLFX, MTL, NS, CA)
            string funcNs = InferNamespaceFromName(func.Name);
            string prefix = funcNs != "" ? TypeMapper.GetPrefix(funcNs) : "";

            string cppName = func.Name.StartsWith(prefix) && prefix.Length > 0
                ? func.Name[prefix.Length..]
                : func.Name;

            // Determine target class name from function name
            string targetClassName = DeriveTargetClassName(func.Name, prefix);

            string cppNamespace = funcNs != "" ? funcNs : FrameworkToNamespace(func.Framework);

            context.FreeFunctions.Add(new FreeFunctionDef(
                func.Name, returnType, cppName, parameters,
                libraryPath, cppNamespace, targetClassName));
        }
    }

    static string DeriveTargetClassName(string funcName, string prefix)
    {
        // e.g., MTLCopyAllDevices → MTLDevice, MTLCreateSystemDefaultDevice → MTLDevice
        return prefix + "Device";
    }

    static string FrameworkToLibraryPath(string framework) => framework switch
    {
        "Metal" => "/System/Library/Frameworks/Metal.framework/Metal",
        "MetalFX" => "/System/Library/Frameworks/MetalFX.framework/MetalFX",
        "Foundation" => "/System/Library/Frameworks/Foundation.framework/Foundation",
        "QuartzCore" => "/System/Library/Frameworks/QuartzCore.framework/QuartzCore",
        _ => "/System/Library/Frameworks/Metal.framework/Metal"
    };

    #endregion

    #region Type Mapping Helpers

    /// <summary>
    /// Maps an ObjC type string to the internal C++-style type used in the model.
    /// This bridges ObjC types from the AST to what the existing TypeMapper expects.
    /// </summary>
    static string MapObjCTypeForModel(string objcType)
    {
        string t = StripNullability(objcType).Trim();

        // id<Protocol> → Protocol*
        Match idMatch = IdProtocolRegex().Match(t);
        if (idMatch.Success)
        {
            string protoName = idMatch.Groups[1].Value;
            return protoName + "*";
        }

        // BOOL → bool
        if (t == "BOOL")
        {
            return "bool";
        }

        // instancetype → id (treated as object pointer)
        if (t == "instancetype")
        {
            return "void*";
        }

        // NSUInteger/NSInteger
        if (t == "NSUInteger")
        {
            return "NS::UInteger";
        }

        if (t == "NSInteger")
        {
            return "NS::Integer";
        }

        // Block handler types (named typedefs)
        if (t.Contains("Handler") || t.Contains("Block"))
        {
            // If it's a known block typedef name, return as-is
            if (!t.Contains('*') && !t.Contains('<') && !t.Contains('('))
            {
                return t;
            }
        }

        // Inline block: void (^ _Nullable)(...) or void (^)(...)
        if (t.Contains("(^"))
        {
            // Parse the inline block signature and try to resolve it
            Match inlineBlockMatch = InlineBlockTypeRegex().Match(t);
            if (inlineBlockMatch.Success)
            {
                string paramPart = inlineBlockMatch.Groups[1].Value.Trim();
                if (InlineBlockDelegateNames.TryGetValue(paramPart, out string? delegateName))
                {
                    return $"INLINE_BLOCK:{delegateName}";
                }
                return "INLINE_BLOCK:UNKNOWN_BLOCK";
            }
            return "INLINE_BLOCK:UNKNOWN_BLOCK";
        }

        // CGColorSpaceRef
        if (t == "CGColorSpaceRef")
        {
            return "CGColorSpaceRef";
        }

        // IOSurfaceRef
        if (t == "IOSurfaceRef")
        {
            return "IOSurfaceRef";
        }

        // CFTimeInterval
        if (t == "CFTimeInterval")
        {
            return "CFTimeInterval";
        }

        // CGSize
        if (t == "CGSize")
        {
            return "CGSize";
        }

        // dispatch_queue_t
        if (t == "dispatch_queue_t")
        {
            return "dispatch_queue_t";
        }

        // dispatch_data_t
        if (t == "dispatch_data_t")
        {
            return "dispatch_data_t";
        }

        // CGFloat
        if (t == "CGFloat")
        {
            return "double";
        }

        // C primitive types
        if (t is "uint32_t" or "int32_t" or "uint8_t" or "int8_t" or "uint16_t" or "int16_t"
            or "uint64_t" or "int64_t" or "float" or "double" or "void")
        {
            return t;
        }

        // MTLGPUAddress → nuint mapping
        if (t == "MTLGPUAddress")
        {
            return "NS::UInteger";
        }

        // MTLCoordinate2D → MTLSamplePosition
        if (t == "MTLCoordinate2D")
        {
            return "MTL::Coordinate2D*";
        }

        // char *
        if (t is "const char *" or "char *")
        {
            return "char*";
        }

        // NSError ** → Error**
        if (t.Contains("NSError") && t.Contains("*") && t.Contains("*"))
        {
            int stars = t.Count(c => c == '*');
            if (stars >= 2)
            {
                return "NS::Error**";
            }
        }

        // Pointer types: MTLFoo * → MTL::Foo* style (but keep ObjC name directly)
        if (t.EndsWith('*'))
        {
            string baseName = t.TrimEnd('*', ' ').Trim();
            // Handle const prefix
            if (baseName.StartsWith("const "))
            {
                baseName = baseName["const ".Length..].Trim();
                string ns = InferNamespaceFromName(baseName);
                if (ns != "")
                {
                    return "const " + baseName + "*";
                }
            }

            return baseName + "*";
        }

        // Non-pointer ObjC types (enum values, struct values)
        // These are returned as-is since they're already the ObjC name
        return t;
    }

    /// <summary>
    /// Returns true if an ObjC type cannot be mapped to a C# type and should cause the method to be skipped.
    /// </summary>
    static bool IsUnmappableObjCType(string objcType)
    {
        string t = StripNullability(objcType).Trim();

        // Skip API_UNAVAILABLE types
        if (t.StartsWith("API_UNAVAILABLE"))
        {
            return true;
        }

        // Skip NSDictionary, NSSet, Class, IMP
        if (t.StartsWith("NSDictionary") || t.StartsWith("NSSet<"))
        {
            return true;
        }

        if (t is "Class" or "IMP" or "SEL" or "FourCharCode")
        {
            return true;
        }

        if (t.Contains("NS::Process") || t.Contains("NS::Observer") || t.Contains("NSProcess") || t.Contains("NSObserver"))
        {
            return true;
        }

        if (t.Contains("kern_return_t") || t.Contains("task_id_token_t"))
        {
            return true;
        }

        // Skip ObjectType (generic NSArray type params)
        if (t.Contains("ObjectType"))
        {
            return true;
        }

        // Skip NS_RETURNS_INNER_POINTER annotated types
        if (t.Contains("NS_RETURNS_INNER_POINTER"))
        {
            return true;
        }

        // Skip NSStringEncoding (typedef for NSUInteger but context-dependent)
        if (t.Contains("NSStringEncoding"))
        {
            return true;
        }

        // Skip const data pointer params (array params from ObjC will need special handling)
        // but keep the simpler ones
        if (t.Contains("*const ") || (t.Contains("const") && t.Contains("* _Nonnull *")))
        {
            return true;
        }

        // Skip 'const unichar *'
        if (t.Contains("unichar"))
        {
            return true;
        }

        // Skip CAEDRMetadata
        if (t.Contains("CAEDRMetadata"))
        {
            return true;
        }

        return false;
    }

    #endregion

    #region Selector & Name Helpers

    /// <summary>
    /// Converts an ObjC selector to a C++ method name for the internal model.
    /// E.g., "newCommandQueueWithMaxCommandBufferCount:" → "newCommandQueueWithMaxCommandBufferCount"
    /// E.g., "setFoo:" → "setFoo"
    /// E.g., "foo" → "foo"
    /// </summary>
    static string SelectorToMethodName(string selector)
    {
        // Remove trailing colons and split on colons to get the base name
        if (!selector.Contains(':'))
        {
            return selector;
        }

        // For multi-part selectors like "foo:bar:baz:", use the first part as the method name
        int firstColon = selector.IndexOf(':');
        return selector[..firstColon];
    }

    /// <summary>
    /// Infers a C++ namespace prefix from an ObjC name.
    /// E.g., "MTLDevice" → "MTL", "MTL4Compiler" → "MTL4", "NSString" → "NS"
    /// </summary>
    static string InferNamespaceFromName(string name)
    {
        if (name.StartsWith("MTL4FX")) return "MTL4FX";
        if (name.StartsWith("MTLFX")) return "MTLFX";
        if (name.StartsWith("MTL4")) return "MTL4";
        if (name.StartsWith("MTL")) return "MTL";
        if (name.StartsWith("NS")) return "NS";
        if (name.StartsWith("CA")) return "CA";
        if (name.StartsWith("CG")) return "CG";
        return "";
    }

    static string FrameworkToNamespace(string framework) => framework switch
    {
        "Metal" => "MTL",
        "MetalFX" => "MTLFX",
        "Foundation" => "NS",
        "QuartzCore" => "CA",
        _ => "MTL"
    };

    /// <summary>Strips nullability annotations from ObjC type strings.</summary>
    static string StripNullability(string objcType)
    {
        return NullabilityRegex().Replace(objcType, "").Trim();
    }

    #endregion

    #region Generated Regex

    [GeneratedRegex(@"\b(?:_Nonnull|_Nullable|_Nullable_result|__nonnull|__nullable|_Null_unspecified|__null_unspecified)\b")]
    private static partial Regex NullabilityRegex();

    [GeneratedRegex(@"^id<(\w+)>$")]
    private static partial Regex IdProtocolRegex();

    [GeneratedRegex(@"void\s*\(\^\s*(?:_Nullable)?\s*\)\s*\(([^)]*)\)")]
    private static partial Regex InlineBlockTypeRegex();

    [GeneratedRegex(@"^void\s*\(\^\)\s*\(([^)]*)\)$")]
    private static partial Regex BlockSignatureRegex();

    [GeneratedRegex(@"^(.+?)\[(\d+)\]$")]
    private static partial Regex ArrayFieldRegex();

    #endregion
}

#region AST JSON Models

class AstRoot
{
    [JsonPropertyName("sdkVersion")]
    public string? SdkVersion { get; set; }

    [JsonPropertyName("enums")]
    public List<AstEnum> Enums { get; set; } = [];

    [JsonPropertyName("protocols")]
    public List<AstClass> Protocols { get; set; } = [];

    [JsonPropertyName("classes")]
    public List<AstClass> Classes { get; set; } = [];

    [JsonPropertyName("typedefs")]
    public List<AstTypedef> Typedefs { get; set; } = [];

    [JsonPropertyName("functions")]
    public List<AstFunction> Functions { get; set; } = [];

    [JsonPropertyName("structs")]
    public List<AstStruct> Structs { get; set; } = [];
}

class AstEnum
{
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "";

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("underlyingType")]
    public string UnderlyingType { get; set; } = "";

    [JsonPropertyName("isOptions")]
    public bool IsOptions { get; set; }

    [JsonPropertyName("members")]
    public List<AstEnumMember> Members { get; set; } = [];

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstEnumMember
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("value")]
    public string Value { get; set; } = "";
}

class AstClass
{
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "";

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("methods")]
    public List<AstMethod> Methods { get; set; } = [];

    [JsonPropertyName("properties")]
    public List<AstProperty> Properties { get; set; } = [];

    [JsonPropertyName("protocols")]
    public List<string> Protocols { get; set; } = [];

    [JsonPropertyName("super")]
    public string? Super { get; set; }

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstMethod
{
    [JsonPropertyName("selector")]
    public string Selector { get; set; } = "";

    [JsonPropertyName("isClassMethod")]
    public bool IsClassMethod { get; set; }

    [JsonPropertyName("returnType")]
    public string ReturnType { get; set; } = "";

    [JsonPropertyName("returnNullability")]
    public string? ReturnNullability { get; set; }

    [JsonPropertyName("parameters")]
    public List<AstParam> Parameters { get; set; } = [];

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstParam
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";

    [JsonPropertyName("nullability")]
    public string? Nullability { get; set; }
}

class AstProperty
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";

    [JsonPropertyName("nullability")]
    public string? Nullability { get; set; }

    [JsonPropertyName("readonly")]
    public bool Readonly { get; set; }

    [JsonPropertyName("getter")]
    public string? Getter { get; set; }

    [JsonPropertyName("setter")]
    public string? Setter { get; set; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("deprecationMessage")]
    public string? DeprecationMessage { get; set; }
}

class AstTypedef
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("underlyingType")]
    public string UnderlyingType { get; set; } = "";

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }
}

class AstFunction
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("returnType")]
    public string ReturnType { get; set; } = "";

    [JsonPropertyName("parameters")]
    public List<AstParam> Parameters { get; set; } = [];

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }
}

class AstStruct
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("fields")]
    public List<AstStructField> Fields { get; set; } = [];

    [JsonPropertyName("framework")]
    public string? Framework { get; set; }
}

class AstStructField
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
}

#endregion
