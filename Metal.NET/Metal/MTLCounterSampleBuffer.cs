namespace Metal.NET;

public readonly struct MTLCounterSampleBuffer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLCounterSampleBuffer value) => new(value.NativePtr);

    public MTLCounterSampleBuffer Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCounterSampleBufferBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCounterSampleBufferBindings.Label));
    }

    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCounterSampleBufferBindings.SampleCount);
    }

    public NSData ResolveCounterRange(NSRange range)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCounterSampleBufferBindings.ResolveCounterRange, range);

        return new(nativePtr);
    }
}

file static class MTLCounterSampleBufferBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector ResolveCounterRange = "resolveCounterRange:";

    public static readonly Selector SampleCount = "sampleCount";
}
