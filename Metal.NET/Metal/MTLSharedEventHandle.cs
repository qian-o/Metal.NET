namespace Metal.NET;

public class MTLSharedEventHandle : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventHandle");

    public MTLSharedEventHandle(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLSharedEventHandle() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLSharedEventHandle()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventHandleSelector.Label));
    }

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
}

file class MTLSharedEventHandleSelector
{
    public static readonly Selector Label = Selector.Register("label");
}
