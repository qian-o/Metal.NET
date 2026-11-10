namespace Metal.NET;

public readonly struct MTLSharedEventHandle(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLSharedEventHandle value) => new(value.NativePtr);

    public MTLSharedEventHandle Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLSharedEventHandleBindings.Label));
    }
}

file static class MTLSharedEventHandleBindings
{
    public static readonly Selector Label = "label";
}
