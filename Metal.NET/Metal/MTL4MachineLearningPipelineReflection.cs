namespace Metal.NET;

public readonly struct MTL4MachineLearningPipelineReflection(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4MachineLearningPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineReflectionBindings.Class))
    {
    }

    public NSArray? Bindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineReflectionBindings.Bindings);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }
}

file static class MTL4MachineLearningPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineReflection");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
