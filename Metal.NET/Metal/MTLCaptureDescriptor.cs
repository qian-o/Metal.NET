namespace Metal.NET;

public class MTLCaptureDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLCaptureDescriptor>
{
    public static MTLCaptureDescriptor Create(nint nativePtr) => new(nativePtr);
    public MTLCaptureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCaptureDescriptorBindings.Class))
    {
    }

    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorBindings.Destination);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetDestination, (nint)value);
    }

    public NSURL OutputURL
    {
        get => GetProperty(ref field, MTLCaptureDescriptorBindings.OutputURL);
        set => SetProperty(ref field, MTLCaptureDescriptorBindings.SetOutputURL, value);
    }
}

file static class MTLCaptureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public static readonly Selector Destination = "destination";

    public static readonly Selector OutputURL = "outputURL";

    public static readonly Selector SetDestination = "setDestination:";

    public static readonly Selector SetOutputURL = "setOutputURL:";
}
