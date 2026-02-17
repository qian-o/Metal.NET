namespace Metal.NET;

file class MTLSharedEventHandleSelector
{
}

public class MTLSharedEventHandle : IDisposable
{
    public MTLSharedEventHandle(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public static MTLSharedEventHandle New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLSharedEventHandle(ptr);
    }

}
