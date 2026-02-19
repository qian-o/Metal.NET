namespace Metal.NET;

public class MTL4MachineLearningPipelineState(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty<MTLDevice>(ref field, MTL4MachineLearningPipelineStateBindings.Device);
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateBindings.IntermediatesHeapSize);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTL4MachineLearningPipelineStateBindings.Label);
    }

    public MTL4MachineLearningPipelineReflection? Reflection
    {
        get => GetProperty<MTL4MachineLearningPipelineReflection>(ref field, MTL4MachineLearningPipelineStateBindings.Reflection);
    }
}

file static class MTL4MachineLearningPipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector IntermediatesHeapSize = "intermediatesHeapSize";

    public static readonly Selector Label = "label";

    public static readonly Selector Reflection = "reflection";
}
