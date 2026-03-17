namespace Metal.NET;

public class MTLCaptureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCaptureDescriptor>
{
    #region INativeObject
    public static new MTLCaptureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCaptureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLCaptureDescriptor() : this(ObjectiveC.AllocInit(MTLCaptureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public id CaptureObject
    {
        get => GetProperty(ref field, MTLCaptureDescriptorBindings.CaptureObject);
        set => SetProperty(ref field, MTLCaptureDescriptorBindings.SetCaptureObject, value);
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

    public id CaptureObject
    {
        get => GetProperty(ref field, MTLCaptureDescriptorBindings.CaptureObject);
        set => SetProperty(ref field, MTLCaptureDescriptorBindings.SetCaptureObject, value);
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

    public void SetCaptureObject(id captureObject)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetCaptureObject, captureObject.NativePtr);
    }

    public void SetDestination(MTLCaptureDestination destination)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetDestination, (nint)destination);
    }

    public void SetOutputURL(NSURL outputURL)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetOutputURL, outputURL.NativePtr);
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
