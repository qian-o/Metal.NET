using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCommandBuffer_Selectors
{
    internal static readonly Selector addCompletedHandler_ = Selector.Register("addCompletedHandler:");
    internal static readonly Selector addScheduledHandler_ = Selector.Register("addScheduledHandler:");
    internal static readonly Selector commit = Selector.Register("commit");
    internal static readonly Selector encodeSignalEvent_value_ = Selector.Register("encodeSignalEvent:value:");
    internal static readonly Selector encodeWait_value_ = Selector.Register("encodeWait:value:");
    internal static readonly Selector enqueue = Selector.Register("enqueue");
    internal static readonly Selector parallelRenderCommandEncoder_ = Selector.Register("parallelRenderCommandEncoder:");
    internal static readonly Selector popDebugGroup = Selector.Register("popDebugGroup");
    internal static readonly Selector presentDrawable_ = Selector.Register("presentDrawable:");
    internal static readonly Selector pushDebugGroup_ = Selector.Register("pushDebugGroup:");
    internal static readonly Selector renderCommandEncoder_ = Selector.Register("renderCommandEncoder:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector useResidencySet_ = Selector.Register("useResidencySet:");
    internal static readonly Selector waitUntilCompleted = Selector.Register("waitUntilCompleted");
    internal static readonly Selector waitUntilScheduled = Selector.Register("waitUntilScheduled");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLCommandBuffer
{
    public readonly nint NativePtr;

    public MTLCommandBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCommandBuffer o) => o.NativePtr;
    public static implicit operator MTLCommandBuffer(nint ptr) => new MTLCommandBuffer(ptr);

    public void AddCompletedHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.addCompletedHandler_, function);
    }

    public void AddScheduledHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.addScheduledHandler_, function);
    }

    public void Commit()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.commit);
    }

    public void EncodeSignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.encodeSignalEvent_value_, @event.NativePtr, (nint)value);
    }

    public void EncodeWait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.encodeWait_value_, @event.NativePtr, (nint)value);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.enqueue);
    }

    public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.parallelRenderCommandEncoder_, renderPassDescriptor.NativePtr);
        return new MTLParallelRenderCommandEncoder(__result);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.popDebugGroup);
    }

    public void PresentDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.presentDrawable_, drawable.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.pushDebugGroup_, @string.NativePtr);
    }

    public MTLRenderCommandEncoder RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.renderCommandEncoder_, renderPassDescriptor.NativePtr);
        return new MTLRenderCommandEncoder(__result);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.setLabel_, label.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.useResidencySet_, residencySet.NativePtr);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.waitUntilCompleted);
    }

    public void WaitUntilScheduled()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBuffer_Selectors.waitUntilScheduled);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
