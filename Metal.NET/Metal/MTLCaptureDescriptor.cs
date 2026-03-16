namespace Metal.NET;

/// <summary>A configuration for a Metal capture session.</summary>
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

    #region Setting capture parameters - Properties

    /// <summary>The instance whose contents should be captured.</summary>
    public NSObject CaptureObject
    {
        get => GetProperty(ref field, MTLCaptureDescriptorBindings.CaptureObject);
        set => SetProperty(ref field, MTLCaptureDescriptorBindings.SetCaptureObject, value);
    }

    /// <summary>The destination for any captured command data.</summary>
    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)ObjectiveC.MsgSendLong(NativePtr, MTLCaptureDescriptorBindings.Destination);
        set => ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetDestination, (nint)value);
    }

    /// <summary>A URL for a file to write the capture data into.</summary>
    public NSURL OutputURL
    {
        get => GetProperty(ref field, MTLCaptureDescriptorBindings.OutputURL);
        set => SetProperty(ref field, MTLCaptureDescriptorBindings.SetOutputURL, value);
    }
    #endregion
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
