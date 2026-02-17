namespace Metal.NET;

public class MTLIOCommandQueueDescriptor : IDisposable
{
    public MTLIOCommandQueueDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLIOCommandQueueDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIOCommandQueueDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOCommandQueueDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLIOCommandQueueDescriptor");

    public static MTLIOCommandQueueDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLIOCommandQueueDescriptor(ptr);
    }

    public void SetMaxCommandBufferCount(uint maxCommandBufferCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetMaxCommandBufferCount, (nint)maxCommandBufferCount);
    }

    public void SetMaxCommandsInFlight(uint maxCommandsInFlight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetMaxCommandsInFlight, (nint)maxCommandsInFlight);
    }

    public void SetPriority(MTLIOPriority priority)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetPriority, (nint)(uint)priority);
    }

    public void SetScratchBufferAllocator(MTLIOScratchBufferAllocator scratchBufferAllocator)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetScratchBufferAllocator, scratchBufferAllocator.NativePtr);
    }

    public void SetType(MTLIOCommandQueueType type)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetType, (nint)(uint)type);
    }

}

file class MTLIOCommandQueueDescriptorSelector
{
    public static readonly Selector SetMaxCommandBufferCount = Selector.Register("setMaxCommandBufferCount:");
    public static readonly Selector SetMaxCommandsInFlight = Selector.Register("setMaxCommandsInFlight:");
    public static readonly Selector SetPriority = Selector.Register("setPriority:");
    public static readonly Selector SetScratchBufferAllocator = Selector.Register("setScratchBufferAllocator:");
    public static readonly Selector SetType = Selector.Register("setType:");
}
