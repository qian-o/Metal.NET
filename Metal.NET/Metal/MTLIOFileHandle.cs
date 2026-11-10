namespace Metal.NET;

public readonly struct MTLIOFileHandle(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLIOFileHandle value) => new(value.NativePtr);

    public MTLIOFileHandle Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIOFileHandleBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLIOFileHandleBindings.SetLabel, value.NativePtr);
    }
}

file static class MTLIOFileHandleBindings
{
    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
