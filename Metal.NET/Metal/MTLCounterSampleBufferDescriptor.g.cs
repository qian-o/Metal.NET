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

    public void SetCounterSet(MTLCounterSet counterSet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetCounterSet, counterSet.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetSampleCount(uint sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetSampleCount, (nint)sampleCount);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetStorageMode, (nint)(uint)storageMode);
    }

}

file class MTLCounterSampleBufferDescriptorSelector
{
    public static readonly Selector SetCounterSet = Selector.Register("setCounterSet:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");
    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");
}
