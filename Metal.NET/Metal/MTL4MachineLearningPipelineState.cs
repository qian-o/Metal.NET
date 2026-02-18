namespace Metal.NET;

public partial class MTL4MachineLearningPipelineState : NativeObject
{
    public MTL4MachineLearningPipelineState(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateSelector.IntermediatesHeapSize);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTL4MachineLearningPipelineReflection? Reflection
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Reflection);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTL4MachineLearningPipelineStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector IntermediatesHeapSize = Selector.Register("intermediatesHeapSize");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Reflection = Selector.Register("reflection");
}
