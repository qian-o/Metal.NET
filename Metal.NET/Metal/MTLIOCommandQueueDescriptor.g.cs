namespace Metal.NET;

file class MTLIOCommandQueueDescriptorSelector
{
    public static readonly Selector SetMaxCommandBufferCount_ = Selector.Register("setMaxCommandBufferCount:");
    public static readonly Selector SetMaxCommandsInFlight_ = Selector.Register("setMaxCommandsInFlight:");
    public static readonly Selector SetPriority_ = Selector.Register("setPriority:");
    public static readonly Selector SetScratchBufferAllocator_ = Selector.Register("setScratchBufferAllocator:");
    public static readonly Selector SetType_ = Selector.Register("setType:");
}

public class MTLIOCommandQueueDescriptor : IDisposable
{
    public MTLIOCommandQueueDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void SetMaxCommandBufferCount(nuint maxCommandBufferCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetMaxCommandBufferCount_, (nint)maxCommandBufferCount);
    }

    public void SetMaxCommandsInFlight(nuint maxCommandsInFlight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetMaxCommandsInFlight_, (nint)maxCommandsInFlight);
    }

    public void SetPriority(MTLIOPriority priority)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetPriority_, (nint)(uint)priority);
    }

    public void SetScratchBufferAllocator(MTLIOScratchBufferAllocator scratchBufferAllocator)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetScratchBufferAllocator_, scratchBufferAllocator.NativePtr);
    }

    public void SetType(MTLIOCommandQueueType type)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetType_, (nint)(uint)type);
    }

}
