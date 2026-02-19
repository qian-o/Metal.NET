namespace Metal.NET;

public class MTL4MachineLearningPipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTL4FunctionDescriptor? MachineLearningFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.MachineLearningFunctionDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4FunctionDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetMachineLearningFunctionDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLTensorExtents? InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.InputDimensionsAtBufferIndex, bufferIndex);
        return ptr is not 0 ? new MTLTensorExtents(ptr) : null;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.Reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions, dimensions.NativePtr, bufferIndex);
    }

    public void SetInputDimensions(NSArray dimensions, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions, dimensions.NativePtr, range);
    }
}

file static class MTL4MachineLearningPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineDescriptor");

    public static readonly Selector InputDimensionsAtBufferIndex = Selector.Register("inputDimensionsAtBufferIndex:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MachineLearningFunctionDescriptor = Selector.Register("machineLearningFunctionDescriptor");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetInputDimensions = Selector.Register("setInputDimensions:atBufferIndex:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetMachineLearningFunctionDescriptor = Selector.Register("setMachineLearningFunctionDescriptor:");
}
