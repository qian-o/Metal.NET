namespace Metal.NET;

public class MTLCommandQueueDescriptor : IDisposable
{
    public MTLCommandQueueDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCommandQueueDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCommandQueueDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandQueueDescriptor(nint value)
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

    public void SetLogState(MTLLogState logState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueueDescriptorSelector.SetLogState, logState.NativePtr);
    }

    public void SetMaxCommandBufferCount(uint maxCommandBufferCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueueDescriptorSelector.SetMaxCommandBufferCount, (nint)maxCommandBufferCount);
    }

}

file class MTLCommandQueueDescriptorSelector
{
    public static readonly Selector SetLogState = Selector.Register("setLogState:");
    public static readonly Selector SetMaxCommandBufferCount = Selector.Register("setMaxCommandBufferCount:");
}
