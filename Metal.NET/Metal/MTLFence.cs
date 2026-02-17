namespace Metal.NET;

public class MTLFence : IDisposable
{
    public MTLFence(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFence()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFence value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFence(nint value)
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFenceSelector.SetLabel, label.NativePtr);
    }

}

file class MTLFenceSelector
{
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
