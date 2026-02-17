namespace Metal.NET;

public class MTL4CommandQueueDescriptor : IDisposable
{
    public MTL4CommandQueueDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetFeedbackQueue(int feedbackQueue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueDescriptorSelector.SetFeedbackQueue, feedbackQueue);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueDescriptorSelector.SetLabel, label.NativePtr);
    }

}

file class MTL4CommandQueueDescriptorSelector
{
    public static readonly Selector SetFeedbackQueue = Selector.Register("setFeedbackQueue:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
