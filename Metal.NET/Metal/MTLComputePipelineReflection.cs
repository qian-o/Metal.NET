namespace Metal.NET;

public partial class MTLComputePipelineReflection : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineReflection");

    public MTLComputePipelineReflection(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? Arguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionSelector.Arguments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? Bindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionSelector.Bindings);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLComputePipelineReflectionSelector
{
    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
