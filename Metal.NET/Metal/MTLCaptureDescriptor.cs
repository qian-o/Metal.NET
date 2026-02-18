namespace Metal.NET;

public class MTLCaptureDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCaptureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCaptureDescriptorSelector.Class))
    {
    }

    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorSelector.Destination);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetDestination, (nint)value);
    }

    public NSURL? OutputURL
    {
        get => GetNullableObject<NSURL>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureDescriptorSelector.OutputURL));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureDescriptorSelector.SetOutputURL, value?.NativePtr ?? 0);
    }
}

file static class MTLCaptureDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public static readonly Selector Destination = Selector.Register("destination");

    public static readonly Selector OutputURL = Selector.Register("outputURL");

    public static readonly Selector SetDestination = Selector.Register("setDestination:");

    public static readonly Selector SetOutputURL = Selector.Register("setOutputURL:");
}
