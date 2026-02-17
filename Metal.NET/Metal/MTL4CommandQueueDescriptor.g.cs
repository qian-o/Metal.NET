namespace Metal.NET;

file class MTL4CommandQueueDescriptorSelector
{
    public static readonly Selector SetFeedbackQueue_ = Selector.Register("setFeedbackQueue:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTL4CommandQueueDescriptor : IDisposable
{
    public MTL4CommandQueueDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4CommandQueueDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommandQueueDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandQueueDescriptor(nint value)
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

    public void SetFeedbackQueue(nint feedbackQueue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueDescriptorSelector.SetFeedbackQueue_, feedbackQueue);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueDescriptorSelector.SetLabel_, label.NativePtr);
    }

}
