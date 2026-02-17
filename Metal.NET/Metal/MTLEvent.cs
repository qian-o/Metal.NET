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

    public MTLDevice Device
    {
        get => new MTLDevice(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLEventSelector.Device));
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLEventSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLEventSelector.SetLabel, value.NativePtr);
    }

}

file class MTLEventSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
