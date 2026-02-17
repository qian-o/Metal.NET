namespace Metal.NET;

public class MTLSharedEventListener : IDisposable
{
    public MTLSharedEventListener(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLSharedEventListener()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public nint DispatchQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventListenerSelector.DispatchQueue);
    }

    public static implicit operator nint(MTLSharedEventListener value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSharedEventListener(nint value)
    {
        return new(value);
    }

    public static MTLSharedEventListener SharedListener()
    {
        MTLSharedEventListener result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLSharedEventListenerSelector.SharedListener));

        return result;
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

file class MTLSharedEventListenerSelector
{
    public static readonly Selector DispatchQueue = Selector.Register("dispatchQueue");

    public static readonly Selector SharedListener = Selector.Register("sharedListener");
}
