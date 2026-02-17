namespace Metal.NET;

public class MTLCommandBuffer : IDisposable
{
    public MTLCommandBuffer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void AddCompletedHandler(int function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.AddCompletedHandler, function);
    }

    public void AddScheduledHandler(int function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.AddScheduledHandler, function);
    }

    public void Commit()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.Commit);
    }

    public void EncodeSignalEvent(MTLEvent @event, uint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.EncodeSignalEventValue, @event.NativePtr, (nint)value);
    }

    public void EncodeWait(MTLEvent @event, uint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.EncodeWaitValue, @event.NativePtr, (nint)value);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.Enqueue);
    }

    public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        var result = new MTLParallelRenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCommandBufferSelector.ParallelRenderCommandEncoder, renderPassDescriptor.NativePtr));

        return result;
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.PopDebugGroup);
    }

    public void PresentDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.PresentDrawable, drawable.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.PushDebugGroup, @string.NativePtr);
    }

    public MTLRenderCommandEncoder RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        var result = new MTLRenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCommandBufferSelector.RenderCommandEncoder, renderPassDescriptor.NativePtr));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.SetLabel, label.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferSelector.UseResidencySet, residencySet.NativePtr);
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

file class MTLCommandBufferSelector
{
    public static readonly Selector AddCompletedHandler = Selector.Register("addCompletedHandler:");
    public static readonly Selector AddScheduledHandler = Selector.Register("addScheduledHandler:");
    public static readonly Selector Commit = Selector.Register("commit");
    public static readonly Selector EncodeSignalEventValue = Selector.Register("encodeSignalEvent:value:");
    public static readonly Selector EncodeWaitValue = Selector.Register("encodeWait:value:");
    public static readonly Selector Enqueue = Selector.Register("enqueue");
    public static readonly Selector ParallelRenderCommandEncoder = Selector.Register("parallelRenderCommandEncoder:");
    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");
    public static readonly Selector PresentDrawable = Selector.Register("presentDrawable:");
    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");
    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoder:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector UseResidencySet = Selector.Register("useResidencySet:");
    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
    public static readonly Selector WaitUntilScheduled = Selector.Register("waitUntilScheduled");
}
