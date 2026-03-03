namespace Metal.NET;

public class MTLCaptureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLCaptureDescriptor>
{
    public static MTLCaptureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLCaptureDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLCaptureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCaptureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nint CaptureObject
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorBindings.CaptureObject);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetCaptureObject, value);
    }

    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)ObjectiveCRuntime.MsgSendLong(NativePtr, MTLCaptureDescriptorBindings.Destination);
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

    public static readonly Selector CaptureObject = "captureObject";

    public static readonly Selector Destination = "destination";

    public static readonly Selector OutputURL = "outputURL";

    public static readonly Selector SetCaptureObject = "setCaptureObject:";

    public static readonly Selector SetDestination = "setDestination:";

    public static readonly Selector SetOutputURL = "setOutputURL:";
}
