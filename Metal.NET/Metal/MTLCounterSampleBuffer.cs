namespace Metal.NET;

public class MTLCounterSampleBuffer(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCounterSampleBuffer>
{
    public static MTLCounterSampleBuffer Create(nint nativePtr) => new(nativePtr);

    public static MTLCounterSampleBuffer CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

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
