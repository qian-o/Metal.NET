namespace Metal.NET;

public class MTLCounterSampleBufferDescriptor : IDisposable
{
    public MTLCounterSampleBufferDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCounterSampleBufferDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLCounterSet CounterSet
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferDescriptorSelector.CounterSet));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetCounterSet, value.NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetLabel, value.NativePtr);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferDescriptorSelector.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetSampleCount, value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLCounterSampleBufferDescriptorSelector.StorageMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetStorageMode, (uint)value);
    }

    public static implicit operator nint(MTLCounterSampleBufferDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCounterSampleBufferDescriptor(nint value)
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

file class MTLCounterSampleBufferDescriptorSelector
{
    public static readonly Selector CounterSet = Selector.Register("counterSet");

    public static readonly Selector SetCounterSet = Selector.Register("setCounterSet:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");
}
