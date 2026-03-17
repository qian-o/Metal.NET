namespace Metal.NET;

/// <summary>
/// An interface that represents a graphics pipeline configuration for a render pass, which the pass applies to the draw commands you encode.
/// </summary>
public class MTLRenderPipelineState(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTLRenderPipelineState>
{
    #region INativeObject
    public static new MTLRenderPipelineState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying a pipeline state - Properties

    /// <summary>
    /// The device instance that creates the pipeline state.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Device);
    }

    /// <summary>
    /// A string that helps you identify the render pipeline state during debugging.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Label);
    }

    /// <summary>
    /// An unique identifier that represents the pipeline state, which you can add to an argument buffer.
    /// </summary>
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLRenderPipelineStateBindings.GpuResourceID);
    }
    #endregion

    #region Checking object shader memory requirements - Properties

    /// <summary>
    /// The largest number of threads the pipeline state can have in a single object shader threadgroup.
    /// </summary>
    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerObjectThreadgroup);
    }

    /// <summary>
    /// The number of threads the render pass applies to a SIMD group for an object shader.
    /// </summary>
    public nuint ObjectThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ObjectThreadExecutionWidth);
    }
    #endregion

    #region Checking mesh shader memory requirements - Properties

    /// <summary>
    /// The largest number of threads the pipeline state can have in a single mesh shader threadgroup.
    /// </summary>
    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerMeshThreadgroup);
    }

    /// <summary>
    /// The largest number of threadgroups the pipeline state can have in a single mesh shader grid.
    /// </summary>
    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadgroupsPerMeshGrid);
    }

    /// <summary>
    /// The number of threads the render pass applies to a SIMD group for a mesh shader.
    /// </summary>
    public nuint MeshThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MeshThreadExecutionWidth);
    }
    #endregion

    #region Checking tile shader memory requirements - Properties

    /// <summary>
    /// The largest number of threads the pipeline state can have in a single tile shader threadgroup.
    /// </summary>
    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    /// <summary>
    /// A Boolean value that indicates whether the pipeline state needs a threadgroup’s size to equal a tile’s size.
    /// </summary>
    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineStateBindings.ThreadgroupSizeMatchesTileSize);
    }

    /// <summary>
    /// The memory size, in byes, of the render pipeline’s imageblock for a single sample.
    /// </summary>
    public nuint ImageblockSampleLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ImageblockSampleLength);
    }
    #endregion

    #region Checking feature support - Properties

    /// <summary>
    /// A Boolean value that indicates whether the render pipeline supports encoding commands into an indirect command buffer.
    /// </summary>
    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineStateBindings.SupportIndirectCommandBuffers);
    }
    #endregion

    #region Checking shader validation - Properties

    /// <summary>
    /// The current state of shader validation for the pipeline.
    /// </summary>
    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLRenderPipelineStateBindings.ShaderValidation);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLRenderPipelineReflection Reflection
    {
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Reflection);
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerMeshThreadgroup);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerObjectThreadgroup);
    }

    public MTLSize RequiredThreadsPerTileThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerTileThreadgroup);
    }
    #endregion

    #region Checking tile shader memory requirements - Methods

    /// <summary>
    /// Returns the length of an imageblock’s memory for the specified imageblock dimensions.
    /// </summary>
    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }
    #endregion

    #region Creating function handles and tables - Methods

    /// <summary>
    /// Creates a function handle for a shader.
    /// </summary>
    public MTLFunctionHandle FunctionHandle(NSString name, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandle, name.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a function handle for a shader.
    /// </summary>
    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithBinaryFunctionstage, function.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a function handle for a shader.
    /// </summary>
    public MTLFunctionHandle FunctionHandle(MTLFunction function, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithFunctionstage, function.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new visible function table.
    /// </summary>
    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewVisibleFunctionTable, descriptor.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new intersection function table.
    /// </summary>
    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewIntersectionFunctionTable, descriptor.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating modified clones of the render pipeline - Methods

    /// <summary>
    /// Creates a new pipeline state that’s a copy of the current pipeline state with additional shaders.
    /// </summary>
    public MTLRenderPipelineState NewRenderPipelineState(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineState, binaryFunctionsDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new pipeline state that’s a copy of the current pipeline state with additional shaders.
    /// </summary>
    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineStateWithAdditionalBinaryFunctionserror, additionalBinaryFunctions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    public MTL4PipelineDescriptor NewRenderPipelineDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLRenderPipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionHandle = "functionHandleWithName:stage:";

    public static readonly Selector FunctionHandleWithBinaryFunctionstage = "functionHandleWithBinaryFunction:stage:";

    public static readonly Selector FunctionHandleWithFunctionstage = "functionHandleWithFunction:stage:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ImageblockMemoryLength = "imageblockMemoryLengthForDimensions:";

    public static readonly Selector ImageblockSampleLength = "imageblockSampleLength";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector MeshThreadExecutionWidth = "meshThreadExecutionWidth";

    public static readonly Selector NewIntersectionFunctionTable = "newIntersectionFunctionTableWithDescriptor:stage:";

    public static readonly Selector NewRenderPipelineDescriptor = "newRenderPipelineDescriptorForSpecialization";

    public static readonly Selector NewRenderPipelineState = "newRenderPipelineStateWithBinaryFunctions:error:";

    public static readonly Selector NewRenderPipelineStateWithAdditionalBinaryFunctionserror = "newRenderPipelineStateWithAdditionalBinaryFunctions:error:";

    public static readonly Selector NewVisibleFunctionTable = "newVisibleFunctionTableWithDescriptor:stage:";

    public static readonly Selector ObjectThreadExecutionWidth = "objectThreadExecutionWidth";

    public static readonly Selector Reflection = "reflection";

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = "requiredThreadsPerMeshThreadgroup";

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = "requiredThreadsPerObjectThreadgroup";

    public static readonly Selector RequiredThreadsPerTileThreadgroup = "requiredThreadsPerTileThreadgroup";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";
}
