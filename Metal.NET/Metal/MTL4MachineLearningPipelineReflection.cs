namespace Metal.NET;

public class MTL4MachineLearningPipelineReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4MachineLearningPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineReflectionSelector.Class))
    {
    }

    public NSArray? Bindings
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineReflectionSelector.Bindings));
    }
}

file static class MTL4MachineLearningPipelineReflectionSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineReflection");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
