namespace Metal.NET;

public partial class MTLCaptureDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public MTLCaptureDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nint CaptureObject
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorSelector.CaptureObject);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetCaptureObject, value);
    }

    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorSelector.Destination);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetDestination, (nint)value);
    }

    public NSURL? OutputURL
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorSelector.OutputURL);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetOutputURL, value?.NativePtr ?? 0);
    }
}

file static class MTLCaptureDescriptorSelector
{
    public static readonly Selector CaptureObject = Selector.Register("captureObject");

    public static readonly Selector Destination = Selector.Register("destination");

    public static readonly Selector OutputURL = Selector.Register("outputURL");

    public static readonly Selector SetCaptureObject = Selector.Register("setCaptureObject:");

    public static readonly Selector SetDestination = Selector.Register("setDestination:");

    public static readonly Selector SetOutputURL = Selector.Register("setOutputURL:");
}
