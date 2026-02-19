namespace Metal.NET;

public class MTLCommandBuffer(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAccelerationStructureCommandEncoder? AccelerationStructureCommandEncoder
    {
        get => GetProperty<MTLAccelerationStructureCommandEncoder>(ref field, MTLCommandBufferBindings.AccelerationStructureCommandEncoder);
    }

    public MTLBlitCommandEncoder? BlitCommandEncoder
    {
        get => GetProperty<MTLBlitCommandEncoder>(ref field, MTLCommandBufferBindings.BlitCommandEncoder);
    }

    public MTLCommandQueue? CommandQueue
    {
        get => GetProperty<MTLCommandQueue>(ref field, MTLCommandBufferBindings.CommandQueue);
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoder
    {
        get => GetProperty<MTLComputeCommandEncoder>(ref field, MTLCommandBufferBindings.ComputeCommandEncoder);
    }

    public MTLDevice? Device
    {
        get => GetProperty<MTLDevice>(ref field, MTLCommandBufferBindings.Device);
    }

    public NSError? Error
    {
        get => GetProperty<NSError>(ref field, MTLCommandBufferBindings.Error);
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandBufferBindings.ErrorOptions);
    }

    public double GPUEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferBindings.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferBindings.GPUStartTime);
    }

    public double KernelEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferBindings.KernelEndTime);
    }

    public double KernelStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLCommandBufferBindings.KernelStartTime);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLCommandBufferBindings.Label);
        set => SetProperty(ref field, MTLCommandBufferBindings.SetLabel, value);
    }

    public MTLLogContainer? Logs
    {
        get => GetProperty<MTLLogContainer>(ref field, MTLCommandBufferBindings.Logs);
    }

    public MTLResourceStateCommandEncoder? ResourceStateCommandEncoder
    {
        get => GetProperty<MTLResourceStateCommandEncoder>(ref field, MTLCommandBufferBindings.ResourceStateCommandEncoder);
    }

    public bool RetainedReferences
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCommandBufferBindings.RetainedReferences);
    }

    public MTLCommandBufferStatus Status
    {
        get => (MTLCommandBufferStatus)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandBufferBindings.Status);
    }

    public MTLAccelerationStructureCommandEncoder? AccelerationStructureCommandEncoderWithDescriptor(MTLAccelerationStructurePassDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.AccelerationStructureCommandEncoder, descriptor.NativePtr);
        return ptr is not 0 ? new MTLAccelerationStructureCommandEncoder(ptr) : null;
    }

    public MTLBlitCommandEncoder? BlitCommandEncoderWithDescriptor(MTLBlitPassDescriptor blitPassDescriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.BlitCommandEncoder, blitPassDescriptor.NativePtr);
        return ptr is not 0 ? new MTLBlitCommandEncoder(ptr) : null;
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.Commit);
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoderWithDescriptor(MTLComputePassDescriptor computePassDescriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoder, computePassDescriptor.NativePtr);
        return ptr is not 0 ? new MTLComputeCommandEncoder(ptr) : null;
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoderWithDispatchType(MTLDispatchType dispatchType)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoder, (nuint)dispatchType);
        return ptr is not 0 ? new MTLComputeCommandEncoder(ptr) : null;
    }

    public void EncodeSignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.EncodeSignalEvent, @event.NativePtr, value);
    }

    public void EncodeWait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.EncodeWait, @event.NativePtr, value);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.Enqueue);
    }

    public MTLParallelRenderCommandEncoder? ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ParallelRenderCommandEncoder, renderPassDescriptor.NativePtr);
        return ptr is not 0 ? new MTLParallelRenderCommandEncoder(ptr) : null;
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.PopDebugGroup);
    }

    public void PresentDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawable, drawable.NativePtr);
    }

    public void PresentDrawableAfterMinimumDuration(MTLDrawable drawable, double duration)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawableAfterMinimumDuration, drawable.NativePtr, duration);
    }

    public void PresentDrawableAtTime(MTLDrawable drawable, double presentationTime)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawableAtTime, drawable.NativePtr, presentationTime);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public MTLRenderCommandEncoder? RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.RenderCommandEncoder, renderPassDescriptor.NativePtr);
        return ptr is not 0 ? new MTLRenderCommandEncoder(ptr) : null;
    }

    public MTLResourceStateCommandEncoder? ResourceStateCommandEncoderWithDescriptor(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoder, resourceStatePassDescriptor.NativePtr);
        return ptr is not 0 ? new MTLResourceStateCommandEncoder(ptr) : null;
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.UseResidencySet, residencySet.NativePtr);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.WaitUntilCompleted);
    }

    public void WaitUntilScheduled()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.WaitUntilScheduled);
    }
}

file static class MTLCommandBufferBindings
{
    public static readonly Selector AccelerationStructureCommandEncoder = "accelerationStructureCommandEncoder";

    public static readonly Selector BlitCommandEncoder = "blitCommandEncoder";

    public static readonly Selector CommandQueue = "commandQueue";

    public static readonly Selector Commit = "commit";

    public static readonly Selector ComputeCommandEncoder = "computeCommandEncoder";

    public static readonly Selector Device = "device";

    public static readonly Selector EncodeSignalEvent = "encodeSignalEvent:value:";

    public static readonly Selector EncodeWait = "encodeWaitForEvent:value:";

    public static readonly Selector Enqueue = "enqueue";

    public static readonly Selector Error = "error";

    public static readonly Selector ErrorOptions = "errorOptions";

    public static readonly Selector GPUEndTime = "GPUEndTime";

    public static readonly Selector GPUStartTime = "GPUStartTime";

    public static readonly Selector KernelEndTime = "kernelEndTime";

    public static readonly Selector KernelStartTime = "kernelStartTime";

    public static readonly Selector Label = "label";

    public static readonly Selector Logs = "logs";

    public static readonly Selector ParallelRenderCommandEncoder = "parallelRenderCommandEncoderWithDescriptor:";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PresentDrawable = "presentDrawable:";

    public static readonly Selector PresentDrawableAfterMinimumDuration = "presentDrawable:afterMinimumDuration:";

    public static readonly Selector PresentDrawableAtTime = "presentDrawable:atTime:";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector RenderCommandEncoder = "renderCommandEncoderWithDescriptor:";

    public static readonly Selector ResourceStateCommandEncoder = "resourceStateCommandEncoder";

    public static readonly Selector RetainedReferences = "retainedReferences";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Status = "status";

    public static readonly Selector UseResidencySet = "useResidencySet:";

    public static readonly Selector WaitUntilCompleted = "waitUntilCompleted";

    public static readonly Selector WaitUntilScheduled = "waitUntilScheduled";
}
