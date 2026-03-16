namespace Metal.NET;

/// <summary>Description for a machine learning pipeline state.</summary>
public class MTL4MachineLearningPipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4PipelineDescriptor(nativePtr, ownership), INativeObject<MTL4MachineLearningPipelineDescriptor>
{
    #region INativeObject
    public static new MTL4MachineLearningPipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4MachineLearningPipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4MachineLearningPipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties


    /// <summary>Assigns the function that the machine learning pipeline you create from this descriptor executes.</summary>
    public MTL4FunctionDescriptor MachineLearningFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.MachineLearningFunctionDescriptor);
        set => SetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.SetMachineLearningFunctionDescriptor, value);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Obtains the dimensions of the input tensor at bufferIndex if set, nil otherwise.</summary>
    public MTLTensorExtents InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.InputDimensionsAtBufferIndex, bufferIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Resets the descriptor to its default values.</summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.Reset);
    }

    /// <summary>Sets the dimension of an input tensor at a buffer index.</summary>
    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions, dimensions.NativePtr, bufferIndex);
    }

    /// <summary>Sets the dimension of an input tensor at a buffer index.</summary>
    public void SetInputDimensions(MTLTensorExtents[] dimensions, NSRange range)
    {
        nint pDimensions = NSArray.FromArray(dimensions);

        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensionswithRange, pDimensions, range);

        ObjectiveC.Release(pDimensions);
    }
    #endregion
}

file static class MTL4MachineLearningPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4MachineLearningPipelineDescriptor");

    public static readonly Selector InputDimensionsAtBufferIndex = "inputDimensionsAtBufferIndex:";

    public static readonly Selector MachineLearningFunctionDescriptor = "machineLearningFunctionDescriptor";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetInputDimensions = "setInputDimensions:atBufferIndex:";

    public static readonly Selector SetInputDimensionswithRange = "setInputDimensions:withRange:";

    public static readonly Selector SetMachineLearningFunctionDescriptor = "setMachineLearningFunctionDescriptor:";
}
