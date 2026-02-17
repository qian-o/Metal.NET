using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIOCommandQueueDescriptor_Selectors
{
    internal static readonly Selector setMaxCommandBufferCount_ = Selector.Register("setMaxCommandBufferCount:");
    internal static readonly Selector setMaxCommandsInFlight_ = Selector.Register("setMaxCommandsInFlight:");
    internal static readonly Selector setPriority_ = Selector.Register("setPriority:");
    internal static readonly Selector setScratchBufferAllocator_ = Selector.Register("setScratchBufferAllocator:");
    internal static readonly Selector setType_ = Selector.Register("setType:");
}

public class MTLIOCommandQueueDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLIOCommandQueueDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIOCommandQueueDescriptor o) => o.NativePtr;
    public static implicit operator MTLIOCommandQueueDescriptor(nint ptr) => new MTLIOCommandQueueDescriptor(ptr);

    ~MTLIOCommandQueueDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptor_Selectors.setMaxCommandBufferCount_, (nint)maxCommandBufferCount);
    }

    public void SetMaxCommandsInFlight(nuint maxCommandsInFlight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptor_Selectors.setMaxCommandsInFlight_, (nint)maxCommandsInFlight);
    }

    public void SetPriority(MTLIOPriority priority)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptor_Selectors.setPriority_, (nint)(uint)priority);
    }

    public void SetScratchBufferAllocator(MTLIOScratchBufferAllocator scratchBufferAllocator)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptor_Selectors.setScratchBufferAllocator_, scratchBufferAllocator.NativePtr);
    }

    public void SetType(MTLIOCommandQueueType type)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueueDescriptor_Selectors.setType_, (nint)(uint)type);
    }

}
