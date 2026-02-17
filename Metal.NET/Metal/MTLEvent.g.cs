namespace Metal.NET;

public class MTLEvent : IDisposable
{
    public MTLEvent(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLEvent()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLEvent value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLEvent(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLEventSelector.SetLabel, label.NativePtr);
    }

}

file class MTLEventSelector
{
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
