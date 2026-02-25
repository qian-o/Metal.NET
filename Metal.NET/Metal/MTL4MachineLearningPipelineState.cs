namespace Metal.NET;

public class MTL4MachineLearningPipelineState(nint nativePtr, bool ownsReference) : MTLAllocation(nativePtr, ownsReference), INativeObject<MTL4MachineLearningPipelineState>
{
    public static new MTL4MachineLearningPipelineState Null { get; } = new(0, false);

    public static new MTL4MachineLearningPipelineState Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Device);
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateBindings.IntermediatesHeapSize);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Label);
    }

    public MTL4MachineLearningPipelineReflection Reflection
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Reflection);
    }
}

file static class MTL4MachineLearningPipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector IntermediatesHeapSize = "intermediatesHeapSize";

    public static readonly Selector Label = "label";

    public static readonly Selector Reflection = "reflection";
}
