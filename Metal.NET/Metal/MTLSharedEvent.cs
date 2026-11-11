namespace Metal.NET;

public readonly struct MTLSharedEvent(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLEvent(MTLSharedEvent value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLSharedEvent value) => new(value.NativePtr);

    public MTLSharedEvent Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public ulong SignaledValue
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLSharedEventBindings.SignaledValue);
        set => ObjectiveC.MsgSend(NativePtr, MTLSharedEventBindings.SetSignaledValue, value);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLSharedEventBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLSharedEventBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLSharedEventBindings.SetLabel, value.NativePtr);
    }

    public void Notify(MTLSharedEventListener listener, ulong value, MTLSharedEventNotificationBlock block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSharedEventBindings.NotifyListener_AtValue_Block, listener.NativePtr, value, block.NativePtr);
    }

    public MTLSharedEventHandle MakeSharedEventHandle()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLSharedEventBindings.NewSharedEventHandle);

        return new(nativePtr);
    }

    public bool Wait(ulong value, ulong milliseconds)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLSharedEventBindings.WaitUntilSignaledValue_TimeoutMS, value, milliseconds);
    }
}

file static class MTLSharedEventBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector NewSharedEventHandle = "newSharedEventHandle";

    public static readonly Selector NotifyListener_AtValue_Block = "notifyListener:atValue:block:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetSignaledValue = "setSignaledValue:";

    public static readonly Selector SignaledValue = "signaledValue";

    public static readonly Selector WaitUntilSignaledValue_TimeoutMS = "waitUntilSignaledValue:timeoutMS:";
}
