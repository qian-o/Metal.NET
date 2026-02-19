namespace Metal.NET;

public class MTLCaptureDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCaptureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCaptureDescriptorBindings.Class))
    {
    }

    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorBindings.Destination);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetDestination, (nint)value);
    }

    public NSURL? OutputURL
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorBindings.OutputURL);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSURL(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetOutputURL, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTLCaptureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public static readonly Selector Destination = Selector.Register("destination");

    public static readonly Selector OutputURL = Selector.Register("outputURL");

    public static readonly Selector SetDestination = Selector.Register("setDestination:");

    public static readonly Selector SetOutputURL = Selector.Register("setOutputURL:");
}
