namespace Metal.NET;

public partial class MTL4CommandBufferOptions : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandBufferOptions");

    public MTL4CommandBufferOptions(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLLogState? LogState
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferOptionsSelector.LogState);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferOptionsSelector.SetLogState, value?.NativePtr ?? 0);
    }
}

file static class MTL4CommandBufferOptionsSelector
{
    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");
}
