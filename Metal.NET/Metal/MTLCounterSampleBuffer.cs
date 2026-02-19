namespace Metal.NET;

public readonly struct MTLCounterSampleBuffer(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferBindings.SampleCount);
    }
}

file static class MTLCounterSampleBufferBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");
}
