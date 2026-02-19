namespace Metal.NET;

public readonly struct MTLComputePipelineReflection(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineReflectionBindings.Class))
    {
    }

    public NSArray? Arguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionBindings.Arguments);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSArray? Bindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionBindings.Bindings);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }
}

file static class MTLComputePipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineReflection");

    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
