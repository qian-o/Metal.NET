namespace Metal.NET;

public readonly struct MTLCaptureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLCaptureDescriptor value) => new(value.NativePtr);

    public MTLCaptureDescriptor() : this(ObjectiveC.AllocInit(MTLCaptureDescriptorBindings.Class))
    {
    }

    public MTLCaptureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSObject CaptureObject
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureDescriptorBindings.CaptureObject));
        set => ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetCaptureObject, value.NativePtr);
    }

    public MTLCaptureDestination Destination
    {
        get => (MTLCaptureDestination)ObjectiveC.MsgSendLong(NativePtr, MTLCaptureDescriptorBindings.Destination);
        set => ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetDestination, (nint)value);
    }

    public NSURL OutputURL
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureDescriptorBindings.OutputURL));
        set => ObjectiveC.MsgSend(NativePtr, MTLCaptureDescriptorBindings.SetOutputURL, value.NativePtr);
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
