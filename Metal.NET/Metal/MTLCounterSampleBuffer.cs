namespace Metal.NET;

public class MTLCounterSampleBuffer : IDisposable
{
    public MTLCounterSampleBuffer(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLCounterSampleBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferSelector.Label));
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferSelector.SampleCount);
    }

    public nint ResolveCounterRange(NSRange range)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferSelector.ResolveCounterRange, range);

        return result;
    }

    public static implicit operator nint(MTLCounterSampleBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCounterSampleBuffer(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLCounterSampleBufferSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector ResolveCounterRange = Selector.Register("resolveCounterRange:");
}
