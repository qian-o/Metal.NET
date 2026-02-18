namespace Metal.NET;

public class MTLCounterSampleBuffer(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferSelector.Label));
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferSelector.SampleCount);
    }
}

file static class MTLCounterSampleBufferSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");
}
