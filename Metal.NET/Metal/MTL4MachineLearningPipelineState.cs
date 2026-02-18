namespace Metal.NET;

public class MTL4MachineLearningPipelineState(nint nativePtr) : MTLAllocation(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Device));
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateSelector.IntermediatesHeapSize);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Label));
    }

    public MTL4MachineLearningPipelineReflection? Reflection
    {
        get => GetNullableObject<MTL4MachineLearningPipelineReflection>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Reflection));
    }
}

file static class MTL4MachineLearningPipelineStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector IntermediatesHeapSize = Selector.Register("intermediatesHeapSize");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Reflection = Selector.Register("reflection");
}
