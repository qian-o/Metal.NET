namespace Metal.NET;

/// <summary>
/// A pipeline state that you can use with machine-learning encoder instances.
/// </summary>
public class MTL4MachineLearningPipelineState(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTL4MachineLearningPipelineState>
{
    #region INativeObject
    public static new MTL4MachineLearningPipelineState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4MachineLearningPipelineState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// Returns the device the pipeline state belongs to.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Device);
    }

    /// <summary>
    /// Obtain the size of the heap, in bytes, this pipeline requires during the execution.
    /// </summary>
    public nuint IntermediatesHeapSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateBindings.IntermediatesHeapSize);
    }

    /// <summary>
    /// Queries the string that helps identify this object.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Label);
    }

    /// <summary>
    /// Returns reflection information for this machine learning pipeline state.
    /// </summary>
    public MTL4MachineLearningPipelineReflection Reflection
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Reflection);
    }
    #endregion
}

file static class MTL4MachineLearningPipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector IntermediatesHeapSize = "intermediatesHeapSize";

    public static readonly Selector Label = "label";

    public static readonly Selector Reflection = "reflection";
}
