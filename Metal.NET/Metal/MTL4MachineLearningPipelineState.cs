namespace Metal.NET;

public readonly struct MTL4MachineLearningPipelineState(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLAllocation(MTL4MachineLearningPipelineState value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4MachineLearningPipelineState value) => new(value.NativePtr);

    public MTL4MachineLearningPipelineState Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineStateBindings.Label));
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineStateBindings.Device));
    }

    public MTL4MachineLearningPipelineReflection Reflection
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineStateBindings.Reflection));
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateBindings.IntermediatesHeapSize);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateBindings.AllocatedSize);
    }
}

file static class MTL4MachineLearningPipelineStateBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector Device = "device";

    public static readonly Selector IntermediatesHeapSize = "intermediatesHeapSize";

    public static readonly Selector Label = "label";

    public static readonly Selector Reflection = "reflection";
}
