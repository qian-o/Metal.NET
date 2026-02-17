namespace Metal.NET;

file class MTLIOFileHandleSelector
{
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTLIOFileHandle : IDisposable
{
    public MTLIOFileHandle(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIOFileHandle()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIOFileHandle value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOFileHandle(nint value)
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

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOFileHandleSelector.SetLabel_, label.NativePtr);
    }

}
