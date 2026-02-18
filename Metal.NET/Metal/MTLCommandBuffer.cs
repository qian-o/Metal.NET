namespace Metal.NET;

public class MTLCommandBuffer : IDisposable
{
    public MTLCommandBuffer(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLCommandBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public double GPUEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferSelector.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferSelector.GPUStartTime);
    }

    public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.AccelerationStructureCommandEncoder));
    }

    public MTLBlitCommandEncoder BlitCommandEncoder
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.BlitCommandEncoder));
    }

    public MTLCommandQueue CommandQueue
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.CommandQueue));
    }

    public MTLComputeCommandEncoder ComputeCommandEncoder
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ComputeCommandEncoder));
    }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.Device));
    }

    public NSError Error
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.Error));
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLCommandBufferSelector.ErrorOptions);
    }

    public double KernelEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferSelector.KernelEndTime);
    }

    public double KernelStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferSelector.KernelStartTime);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.SetLabel, value.NativePtr);
    }

    public MTLLogContainer Logs
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.Logs));
    }

    public MTLResourceStateCommandEncoder ResourceStateCommandEncoder
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ResourceStateCommandEncoder));
    }

    public Bool8 RetainedReferences
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCommandBufferSelector.RetainedReferences);
    }

    public MTLCommandBufferStatus Status
    {
        get => (MTLCommandBufferStatus)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLCommandBufferSelector.Status);
    }

    public static implicit operator nint(MTLCommandBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandBuffer(nint value)
    {
        return new(value);
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.Commit);
    }

    public void EncodeSignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.EncodeSignalEventValue, @event.NativePtr, value);
    }

    public void EncodeWait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.EncodeWaitForEventValue, @event.NativePtr, value);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.Enqueue);
    }

    public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        MTLParallelRenderCommandEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ParallelRenderCommandEncoderWithDescriptor, renderPassDescriptor.NativePtr));

        return result;
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.PopDebugGroup);
    }

    public void PresentDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.PresentDrawable, drawable.NativePtr);
    }

    public void PresentDrawableAfterMinimumDuration(MTLDrawable drawable, double duration)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.PresentDrawableAfterMinimumDuration, drawable.NativePtr, duration);
    }

    public void PresentDrawableAtTime(MTLDrawable drawable, double presentationTime)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.PresentDrawableAtTime, drawable.NativePtr, presentationTime);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.PushDebugGroup, @string.NativePtr);
    }

    public MTLRenderCommandEncoder RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        MTLRenderCommandEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.RenderCommandEncoderWithDescriptor, renderPassDescriptor.NativePtr));

        return result;
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.UseResidencySet, residencySet.NativePtr);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.WaitUntilCompleted);
    }

    public void WaitUntilScheduled()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.WaitUntilScheduled);
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
}

file class MTLCommandBufferSelector
{
    public static readonly Selector GPUEndTime = Selector.Register("GPUEndTime");

    public static readonly Selector GPUStartTime = Selector.Register("GPUStartTime");

    public static readonly Selector AccelerationStructureCommandEncoder = Selector.Register("accelerationStructureCommandEncoder");

    public static readonly Selector BlitCommandEncoder = Selector.Register("blitCommandEncoder");

    public static readonly Selector CommandQueue = Selector.Register("commandQueue");

    public static readonly Selector ComputeCommandEncoder = Selector.Register("computeCommandEncoder");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Error = Selector.Register("error");

    public static readonly Selector ErrorOptions = Selector.Register("errorOptions");

    public static readonly Selector KernelEndTime = Selector.Register("kernelEndTime");

    public static readonly Selector KernelStartTime = Selector.Register("kernelStartTime");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Logs = Selector.Register("logs");

    public static readonly Selector ResourceStateCommandEncoder = Selector.Register("resourceStateCommandEncoder");

    public static readonly Selector RetainedReferences = Selector.Register("retainedReferences");

    public static readonly Selector Status = Selector.Register("status");

    public static readonly Selector Commit = Selector.Register("commit");

    public static readonly Selector EncodeSignalEventValue = Selector.Register("encodeSignalEvent:value:");

    public static readonly Selector EncodeWaitForEventValue = Selector.Register("encodeWaitForEvent:value:");

    public static readonly Selector Enqueue = Selector.Register("enqueue");

    public static readonly Selector ParallelRenderCommandEncoderWithDescriptor = Selector.Register("parallelRenderCommandEncoderWithDescriptor:");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PresentDrawable = Selector.Register("presentDrawable:");

    public static readonly Selector PresentDrawableAfterMinimumDuration = Selector.Register("presentDrawable:afterMinimumDuration:");

    public static readonly Selector PresentDrawableAtTime = Selector.Register("presentDrawable:atTime:");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector RenderCommandEncoderWithDescriptor = Selector.Register("renderCommandEncoderWithDescriptor:");

    public static readonly Selector UseResidencySet = Selector.Register("useResidencySet:");

    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");

    public static readonly Selector WaitUntilScheduled = Selector.Register("waitUntilScheduled");
}
