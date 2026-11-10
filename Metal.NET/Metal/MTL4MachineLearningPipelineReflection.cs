namespace Metal.NET;

public readonly struct MTL4MachineLearningPipelineReflection(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTL4MachineLearningPipelineReflection value) => new(value.NativePtr);

    public MTL4MachineLearningPipelineReflection Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTLBinding> Bindings
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineReflectionBindings.Bindings));
    }
}

file static class MTL4MachineLearningPipelineReflectionBindings
{
    public static readonly Selector Bindings = "bindings";
}
