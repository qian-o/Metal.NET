namespace Metal.NET;

public readonly struct MTL4CommandBufferOptions(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTL4CommandBufferOptions value) => new(value.NativePtr);

    public MTL4CommandBufferOptions() : this(ObjectiveC.AllocInit(MTL4CommandBufferOptionsBindings.Class))
    {
    }

    public MTL4CommandBufferOptions Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLLogState LogState
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferOptionsBindings.LogState));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferOptionsBindings.SetLogState, value.NativePtr);
    }
}

file static class MTL4CommandBufferOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommandBufferOptions");

    public static readonly Selector LogState = "logState";

    public static readonly Selector SetLogState = "setLogState:";
}
