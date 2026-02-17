using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIOCommandBuffer_Selectors
{
    internal static readonly Selector addBarrier = Selector.Register("addBarrier");
    internal static readonly Selector addCompletedHandler_ = Selector.Register("addCompletedHandler:");
    internal static readonly Selector commit = Selector.Register("commit");
    internal static readonly Selector copyStatusToBuffer_offset_ = Selector.Register("copyStatusToBuffer:offset:");
    internal static readonly Selector enqueue = Selector.Register("enqueue");
    internal static readonly Selector loadBuffer_offset_size_sourceHandle_sourceHandleOffset_ = Selector.Register("loadBuffer:offset:size:sourceHandle:sourceHandleOffset:");
    internal static readonly Selector loadBytes_size_sourceHandle_sourceHandleOffset_ = Selector.Register("loadBytes:size:sourceHandle:sourceHandleOffset:");
    internal static readonly Selector popDebugGroup = Selector.Register("popDebugGroup");
    internal static readonly Selector pushDebugGroup_ = Selector.Register("pushDebugGroup:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector signalEvent_value_ = Selector.Register("signalEvent:value:");
    internal static readonly Selector tryCancel = Selector.Register("tryCancel");
    internal static readonly Selector wait_value_ = Selector.Register("wait:value:");
    internal static readonly Selector waitUntilCompleted = Selector.Register("waitUntilCompleted");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLIOCommandBuffer
{
    public readonly nint NativePtr;

    public MTLIOCommandBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIOCommandBuffer o) => o.NativePtr;
    public static implicit operator MTLIOCommandBuffer(nint ptr) => new MTLIOCommandBuffer(ptr);

    public void AddBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.addBarrier);
    }

    public void AddCompletedHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.addCompletedHandler_, function);
    }

    public void Commit()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.commit);
    }

    public void CopyStatusToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.copyStatusToBuffer_offset_, buffer.NativePtr, (nint)offset);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.enqueue);
    }

    public void LoadBuffer(MTLBuffer buffer, nuint offset, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.loadBuffer_offset_size_sourceHandle_sourceHandleOffset_, buffer.NativePtr, (nint)offset, (nint)size, sourceHandle.NativePtr, (nint)sourceHandleOffset);
    }

    public void LoadBytes(nint pointer, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.loadBytes_size_sourceHandle_sourceHandleOffset_, pointer, (nint)size, sourceHandle.NativePtr, (nint)sourceHandleOffset);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.popDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.pushDebugGroup_, @string.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.setLabel_, label.NativePtr);
    }

    public void SignalEvent(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.signalEvent_value_, @event.NativePtr, (nint)value);
    }

    public void TryCancel()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.tryCancel);
    }

    public void Wait(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.wait_value_, @event.NativePtr, (nint)value);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBuffer_Selectors.waitUntilCompleted);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
