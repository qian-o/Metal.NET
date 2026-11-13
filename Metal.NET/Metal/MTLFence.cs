namespace Metal.NET;

public readonly struct MTLFence(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFence value) => new(value.NativePtr);

    public MTLFence Retain()
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

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFenceBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFenceBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLFenceBindings.SetLabel, value.NativePtr);
    }
}

file static class MTLFenceBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
