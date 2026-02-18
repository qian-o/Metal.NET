namespace Metal.NET;

public class MTL4CommandBufferOptions(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CommandBufferOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommandBufferOptionsSelector.Class))
    {
    }

    public MTLLogState? LogState
    {
        get => GetNullableObject<MTLLogState>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferOptionsSelector.LogState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferOptionsSelector.SetLogState, value?.NativePtr ?? 0);
    }
}

file static class MTL4CommandBufferOptionsSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandBufferOptions");

    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");
}
