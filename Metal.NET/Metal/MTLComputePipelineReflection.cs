namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineReflectionSelector.Class))
    {
    }

    public NSArray? Arguments
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionSelector.Arguments));
    }

    public NSArray? Bindings
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionSelector.Bindings));
    }
}

file static class MTLComputePipelineReflectionSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineReflection");

    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
