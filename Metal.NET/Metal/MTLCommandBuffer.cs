namespace Metal.NET;

public class MTLCommandBuffer(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLAccelerationStructureCommandEncoder? AccelerationStructureCommandEncoder
    {
        get => GetNullableObject<MTLAccelerationStructureCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.AccelerationStructureCommandEncoder));
    }

    public MTLBlitCommandEncoder? BlitCommandEncoder
    {
        get => GetNullableObject<MTLBlitCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.BlitCommandEncoder));
    }

    public MTLCommandQueue? CommandQueue
    {
        get => GetNullableObject<MTLCommandQueue>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.CommandQueue));
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoder
    {
        get => GetNullableObject<MTLComputeCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ComputeCommandEncoder));
    }

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.Device));
    }

    public NSError? Error
    {
        get => GetNullableObject<NSError>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.Error));
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandBufferSelector.ErrorOptions);
    }

    public double GPUEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferSelector.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferSelector.GPUStartTime);
    }

    public double KernelEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferSelector.KernelEndTime);
    }

    public double KernelStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferSelector.KernelStartTime);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLogContainer? Logs
    {
        get => GetNullableObject<MTLLogContainer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.Logs));
    }

    public MTLResourceStateCommandEncoder? ResourceStateCommandEncoder
    {
        get => GetNullableObject<MTLResourceStateCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ResourceStateCommandEncoder));
    }

    public bool RetainedReferences
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCommandBufferSelector.RetainedReferences);
    }

    public MTLCommandBufferStatus Status
    {
        get => (MTLCommandBufferStatus)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandBufferSelector.Status);
    }

    public MTLAccelerationStructureCommandEncoder? AccelerationStructureCommandEncoderWithDescriptor(MTLAccelerationStructurePassDescriptor descriptor)
    {
        return GetNullableObject<MTLAccelerationStructureCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.AccelerationStructureCommandEncoder, descriptor.NativePtr));
    }

    public MTLBlitCommandEncoder? BlitCommandEncoderWithDescriptor(MTLBlitPassDescriptor blitPassDescriptor)
    {
        return GetNullableObject<MTLBlitCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.BlitCommandEncoder, blitPassDescriptor.NativePtr));
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.Commit);
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoderWithDescriptor(MTLComputePassDescriptor computePassDescriptor)
    {
        return GetNullableObject<MTLComputeCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ComputeCommandEncoder, computePassDescriptor.NativePtr));
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoderWithDispatchType(MTLDispatchType dispatchType)
    {
        return GetNullableObject<MTLComputeCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ComputeCommandEncoder, (nuint)dispatchType));
    }

    public void EncodeSignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.EncodeSignalEvent, @event.NativePtr, value);
    }

    public void EncodeWait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.EncodeWait, @event.NativePtr, value);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferSelector.Enqueue);
    }

    public MTLParallelRenderCommandEncoder? ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        return GetNullableObject<MTLParallelRenderCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ParallelRenderCommandEncoder, renderPassDescriptor.NativePtr));
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

    public MTLRenderCommandEncoder? RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        return GetNullableObject<MTLRenderCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.RenderCommandEncoder, renderPassDescriptor.NativePtr));
    }

    public MTLResourceStateCommandEncoder? ResourceStateCommandEncoderWithDescriptor(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
    {
        return GetNullableObject<MTLResourceStateCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferSelector.ResourceStateCommandEncoder, resourceStatePassDescriptor.NativePtr));
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
}

file static class MTLCommandBufferSelector
{
    public static readonly Selector AccelerationStructureCommandEncoder = Selector.Register("accelerationStructureCommandEncoder");

    public static readonly Selector BlitCommandEncoder = Selector.Register("blitCommandEncoder");

    public static readonly Selector CommandQueue = Selector.Register("commandQueue");

    public static readonly Selector Commit = Selector.Register("commit");

    public static readonly Selector ComputeCommandEncoder = Selector.Register("computeCommandEncoder");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EncodeSignalEvent = Selector.Register("encodeSignalEvent:value:");

    public static readonly Selector EncodeWait = Selector.Register("encodeWaitForEvent:value:");

    public static readonly Selector Enqueue = Selector.Register("enqueue");

    public static readonly Selector Error = Selector.Register("error");

    public static readonly Selector ErrorOptions = Selector.Register("errorOptions");

    public static readonly Selector GPUEndTime = Selector.Register("GPUEndTime");

    public static readonly Selector GPUStartTime = Selector.Register("GPUStartTime");

    public static readonly Selector KernelEndTime = Selector.Register("kernelEndTime");

    public static readonly Selector KernelStartTime = Selector.Register("kernelStartTime");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Logs = Selector.Register("logs");

    public static readonly Selector ParallelRenderCommandEncoder = Selector.Register("parallelRenderCommandEncoderWithDescriptor:");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PresentDrawable = Selector.Register("presentDrawable:");

    public static readonly Selector PresentDrawableAfterMinimumDuration = Selector.Register("presentDrawable:afterMinimumDuration:");

    public static readonly Selector PresentDrawableAtTime = Selector.Register("presentDrawable:atTime:");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoderWithDescriptor:");

    public static readonly Selector ResourceStateCommandEncoder = Selector.Register("resourceStateCommandEncoder");

    public static readonly Selector RetainedReferences = Selector.Register("retainedReferences");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Status = Selector.Register("status");

    public static readonly Selector UseResidencySet = Selector.Register("useResidencySet:");

    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");

    public static readonly Selector WaitUntilScheduled = Selector.Register("waitUntilScheduled");
}
