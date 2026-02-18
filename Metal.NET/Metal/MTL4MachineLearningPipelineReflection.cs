namespace Metal.NET;

public partial class MTL4MachineLearningPipelineReflection : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineReflection");

    public MTL4MachineLearningPipelineReflection(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? Bindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineReflectionSelector.Bindings);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTL4MachineLearningPipelineReflectionSelector
{
    public static readonly Selector Bindings = Selector.Register("bindings");
}
