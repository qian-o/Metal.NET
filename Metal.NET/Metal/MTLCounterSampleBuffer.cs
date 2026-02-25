namespace Metal.NET;

public class MTLCounterSampleBuffer(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLCounterSampleBuffer>
{
    public static MTLCounterSampleBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLCounterSampleBuffer Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

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
