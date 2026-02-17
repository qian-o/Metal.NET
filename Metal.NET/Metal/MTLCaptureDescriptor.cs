namespace Metal.NET;

public class MTLCaptureDescriptor : IDisposable
{
    public MTLCaptureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCaptureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCaptureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCaptureDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public static MTLCaptureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLCaptureDescriptor(ptr);
    }

    public void SetCaptureObject(int captureObject)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetCaptureObject, captureObject);
    }

    public void SetDestination(MTLCaptureDestination destination)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetDestination, (nint)(uint)destination);
    }

    public void SetOutputURL(NSURL outputURL)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetOutputURL, outputURL.NativePtr);
    }

}

file class MTLCaptureDescriptorSelector
{
    public static readonly Selector SetCaptureObject = Selector.Register("setCaptureObject:");

    public static readonly Selector SetDestination = Selector.Register("setDestination:");

    public static readonly Selector SetOutputURL = Selector.Register("setOutputURL:");
}
