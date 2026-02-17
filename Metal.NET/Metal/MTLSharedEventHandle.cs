namespace Metal.NET;

public class MTLSharedEventHandle : IDisposable
{
    public MTLSharedEventHandle(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLSharedEventHandle()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLSharedEventHandle value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSharedEventHandle(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLSharedEventHandle");

    public MTLSharedEventHandle() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventHandleSelector.Label));
    }

}

file class MTLSharedEventHandleSelector
{
    public static readonly Selector Label = Selector.Register("label");
}
