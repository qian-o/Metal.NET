namespace Metal.NET;

public readonly struct MTL4MachineLearningPipelineState(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateBindings.IntermediatesHeapSize);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public MTL4MachineLearningPipelineReflection? Reflection
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateBindings.Reflection);
            return ptr is not 0 ? new MTL4MachineLearningPipelineReflection(ptr) : default;
        }
    }
}

file static class MTL4MachineLearningPipelineStateBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector IntermediatesHeapSize = Selector.Register("intermediatesHeapSize");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Reflection = Selector.Register("reflection");
}
