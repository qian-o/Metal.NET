namespace Metal.NET;

public class MTLSharedEventListener : IDisposable
{
    public MTLSharedEventListener(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLSharedEventListener()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLSharedEventListener value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSharedEventListener(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public static MTLSharedEventListener SharedListener()
    {
        MTLSharedEventListener result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLSharedEventListenerSelector.SharedListener));

        return result;
    }

}

file class MTLSharedEventListenerSelector
{
    public static readonly Selector SharedListener = Selector.Register("sharedListener");
}
