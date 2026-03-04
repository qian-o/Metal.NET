namespace Metal.NET;

public class MTLCaptureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLCaptureDescriptor>
{
    #region INativeObject
    public static MTLCaptureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLCaptureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLCaptureDescriptor() : this(ObjectiveC.AllocInit(MTLCaptureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nint CaptureObject
    {
        get => ObjectiveC.MsgSendPtr(NativePtr, MTLCaptureDescriptorBindings.CaptureObject);
        set => ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetCaptureObject, value);
    }

    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)ObjectiveC.MsgSendLong(NativePtr, MTLCaptureDescriptorBindings.Destination);
        set => ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetDestination, (nint)value);
    }

    public NSURL OutputURL
    {
        get => GetProperty(ref field, MTLCaptureDescriptorBindings.OutputURL);
        set => SetProperty(ref field, MTLCaptureDescriptorBindings.SetOutputURL, value);
    }
}

file static class MTLCaptureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLCaptureDescriptor");

    public static readonly Selector CaptureObject = "captureObject";

    public static readonly Selector Destination = "destination";

    public static readonly Selector OutputURL = "outputURL";

    public static readonly Selector SetCaptureObject = "setCaptureObject:";

    public static readonly Selector SetDestination = "setDestination:";

    public static readonly Selector SetOutputURL = "setOutputURL:";
}
