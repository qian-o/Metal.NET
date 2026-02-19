namespace Metal.NET;

public readonly struct MTL4CommandBufferOptions(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4CommandBufferOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommandBufferOptionsBindings.Class))
    {
    }

    public MTLLogState? LogState
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferOptionsBindings.LogState);
            return ptr is not 0 ? new MTLLogState(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferOptionsBindings.SetLogState, value?.NativePtr ?? 0);
    }
}

file static class MTL4CommandBufferOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandBufferOptions");

    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");
}
