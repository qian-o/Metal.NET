namespace Metal.NET;

file class MTLCommandBufferSelector
{
    public static readonly Selector AddCompletedHandler_ = Selector.Register("addCompletedHandler:");
    public static readonly Selector AddScheduledHandler_ = Selector.Register("addScheduledHandler:");
    public static readonly Selector Commit = Selector.Register("commit");
    public static readonly Selector EncodeSignalEvent_value_ = Selector.Register("encodeSignalEvent:value:");
    public static readonly Selector EncodeWait_value_ = Selector.Register("encodeWait:value:");
    public static readonly Selector Enqueue = Selector.Register("enqueue");
    public static readonly Selector ParallelRenderCommandEncoder_ = Selector.Register("parallelRenderCommandEncoder:");
    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");
    public static readonly Selector PresentDrawable_ = Selector.Register("presentDrawable:");
    public static readonly Selector PushDebugGroup_ = Selector.Register("pushDebugGroup:");
    public static readonly Selector RenderCommandEncoder_ = Selector.Register("renderCommandEncoder:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector UseResidencySet_ = Selector.Register("useResidencySet:");
    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
    public static readonly Selector WaitUntilScheduled = Selector.Register("waitUntilScheduled");
}

public class MTLCommandBuffer : IDisposable
{
    public MTLCommandBuffer(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLCommandBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCommandBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandBuffer(nint value)
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

    public void AddCompletedHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.AddCompletedHandler_, function);
    }

    public void AddScheduledHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.AddScheduledHandler_, function);
    }

    public void Commit()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.Commit);
    }

    public void EncodeSignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.EncodeSignalEvent_value_, @event.NativePtr, (nint)value);
    }

    public void EncodeWait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.EncodeWait_value_, @event.NativePtr, (nint)value);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.Enqueue);
    }

    public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        var result = new MTLParallelRenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCommandBufferSelector.ParallelRenderCommandEncoder_, renderPassDescriptor.NativePtr));

        return result;
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.PopDebugGroup);
    }

    public void PresentDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.PresentDrawable_, drawable.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.PushDebugGroup_, @string.NativePtr);
    }

    public MTLRenderCommandEncoder RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        var result = new MTLRenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCommandBufferSelector.RenderCommandEncoder_, renderPassDescriptor.NativePtr));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.SetLabel_, label.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.UseResidencySet_, residencySet.NativePtr);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.WaitUntilCompleted);
    }

    public void WaitUntilScheduled()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.WaitUntilScheduled);
    }

}
