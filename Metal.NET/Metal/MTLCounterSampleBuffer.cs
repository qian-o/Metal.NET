namespace Metal.NET;

public class MTLCounterSampleBuffer(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty<MTLDevice>(ref field, MTLCounterSampleBufferBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLCounterSampleBufferBindings.Label);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferBindings.SampleCount);
    }
}

file static class MTLCounterSampleBufferBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SampleCount = "sampleCount";
}
