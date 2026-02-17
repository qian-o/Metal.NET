namespace Metal.NET;

file class MTLCounterSampleBufferDescriptorSelector
{
    public static readonly Selector SetCounterSet_ = Selector.Register("setCounterSet:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetSampleCount_ = Selector.Register("setSampleCount:");
    public static readonly Selector SetStorageMode_ = Selector.Register("setStorageMode:");
}

public class MTLCounterSampleBufferDescriptor : IDisposable
{
    public MTLCounterSampleBufferDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetCounterSet_, counterSet.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetSampleCount(nuint sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetSampleCount_, (nint)sampleCount);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetStorageMode_, (nint)(uint)storageMode);
    }

}
