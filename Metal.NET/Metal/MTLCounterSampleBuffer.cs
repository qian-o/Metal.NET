namespace Metal.NET;

public class MTLCounterSampleBuffer(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCounterSampleBuffer>
{
    public static MTLCounterSampleBuffer Create(nint nativePtr) => new(nativePtr, true);

    public static MTLCounterSampleBuffer CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCounterSampleBufferBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLCounterSampleBufferBindings.Label);
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
