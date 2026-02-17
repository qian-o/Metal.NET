namespace Metal.NET;

public class MTLCaptureDescriptor : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public MTLCaptureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLCaptureDescriptor() : this(ObjectiveCRuntime.AllocInit(s_class))
    {
    }

    ~MTLCaptureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nint CaptureObject
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorSelector.CaptureObject);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetCaptureObject, value);
    }

    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLCaptureDescriptorSelector.Destination));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetDestination, (uint)value);
    }

    public NSURL OutputURL
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorSelector.OutputURL));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetOutputURL, value.NativePtr);
    }

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

}

file class MTLCaptureDescriptorSelector
{
    public static readonly Selector CaptureObject = Selector.Register("captureObject");

    public static readonly Selector SetCaptureObject = Selector.Register("setCaptureObject:");

    public static readonly Selector Destination = Selector.Register("destination");

    public static readonly Selector SetDestination = Selector.Register("setDestination:");

    public static readonly Selector OutputURL = Selector.Register("outputURL");

    public static readonly Selector SetOutputURL = Selector.Register("setOutputURL:");
}
