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

    public MTLDevice Device
    {
        get => new MTLDevice(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFenceSelector.Device));
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFenceSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFenceSelector.SetLabel, value.NativePtr);
    }

}

file class MTLFenceSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
