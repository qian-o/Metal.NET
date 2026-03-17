namespace Metal.NET;

/// <summary>
/// An interface that represents a GPU pipeline configuration for running kernels in a compute pass.
/// </summary>
public class MTLComputePipelineState(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTLComputePipelineState>
{
    #region INativeObject
    public static new MTLComputePipelineState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePipelineState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying a pipeline state - Properties

    /// <summary>
    /// The device instance that created the pipeline state.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Device);
    }

    /// <summary>
    /// An unique identifier that represents the pipeline state, which you can add to an argument buffer.
    /// </summary>
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLComputePipelineStateBindings.GpuResourceID);
    }

    /// <summary>
    /// A string that helps you identify the compute pipeline state during debugging.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Label);
    }
    #endregion

    #region Checking threadgroup attributes - Properties

    /// <summary>
    /// The maximum number of threads in a threadgroup that you can dispatch to the pipeline.
    /// </summary>
    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    /// <summary>
    /// The number of threads that the GPU executes simultaneously.
    /// </summary>
    public nuint ThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ThreadExecutionWidth);
    }

    /// <summary>
    /// The length, in bytes, of statically allocated threadgroup memory.
    /// </summary>
    public nuint StaticThreadgroupMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.StaticThreadgroupMemoryLength);
    }
    #endregion

    #region Checking indirect command buffer support - Properties

    /// <summary>
    /// A Boolean value that indicates whether the compute pipeline supports indirect command buffers.
    /// </summary>
    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineStateBindings.SupportIndirectCommandBuffers);
    }
    #endregion

    #region Checking shader validation - Properties

    /// <summary>
    /// The current state of shader validation for the pipeline.
    /// </summary>
    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineStateBindings.ShaderValidation);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLComputePipelineReflection Reflection
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Reflection);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLComputePipelineStateBindings.RequiredThreadsPerThreadgroup);
    }
    #endregion

    #region Checking imageblock attributes - Methods

    /// <summary>
    /// Returns the length of reserved memory for an imageblock of a given size.
    /// </summary>
    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }
    #endregion

    #region Creating function handles - Methods

    /// <summary>
    /// Creates a function handle for a visible function.
    /// </summary>
    public MTLFunctionHandle FunctionHandle(NSString name)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandle, name.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a function handle for a visible function.
    /// </summary>
    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a function handle for a visible function.
    /// </summary>
    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating function tables - Methods

    /// <summary>
    /// Creates a new visible function table.
    /// </summary>
    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewVisibleFunctionTable, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new intersection function table.
    /// </summary>
    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewIntersectionFunctionTable, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Allocates a new compute pipeline state by adding binary functions to this pipeline state.
    /// </summary>
    public MTLComputePipelineState NewComputePipelineState(MTLFunction[] functions, out NSError error)
    {
        nint pFunctions = NSArray.FromArray(functions);

        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineState, pFunctions, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        ObjectiveC.Release(pFunctions);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    public MTLComputePipelineState NewComputePipelineStateWithBinaryFunctions(MTL4BinaryFunction[] additionalBinaryFunctions, out NSError error)
    {
        nint pAdditionalBinaryFunctions = NSArray.FromArray(additionalBinaryFunctions);

        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineStateWithBinaryFunctions, pAdditionalBinaryFunctions, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        ObjectiveC.Release(pAdditionalBinaryFunctions);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLComputePipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionHandle = "functionHandleWithName:";

    public static readonly Selector FunctionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:";

    public static readonly Selector FunctionHandleWithFunction = "functionHandleWithFunction:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ImageblockMemoryLength = "imageblockMemoryLengthForDimensions:";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector NewComputePipelineState = "newComputePipelineStateWithAdditionalBinaryFunctions:error:";

    public static readonly Selector NewComputePipelineStateWithBinaryFunctions = "newComputePipelineStateWithBinaryFunctions:error:";

    public static readonly Selector NewIntersectionFunctionTable = "newIntersectionFunctionTableWithDescriptor:";

    public static readonly Selector NewVisibleFunctionTable = "newVisibleFunctionTableWithDescriptor:";

    public static readonly Selector Reflection = "reflection";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector StaticThreadgroupMemoryLength = "staticThreadgroupMemoryLength";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadExecutionWidth = "threadExecutionWidth";
}
