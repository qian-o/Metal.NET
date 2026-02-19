namespace Metal.NET;

public readonly struct MTLCommandBuffer(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLAccelerationStructureCommandEncoder? AccelerationStructureCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.AccelerationStructureCommandEncoder);
            return ptr is not 0 ? new MTLAccelerationStructureCommandEncoder(ptr) : default;
        }
    }

    public MTLBlitCommandEncoder? BlitCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.BlitCommandEncoder);
            return ptr is not 0 ? new MTLBlitCommandEncoder(ptr) : default;
        }
    }

    public MTLCommandQueue? CommandQueue
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.CommandQueue);
            return ptr is not 0 ? new MTLCommandQueue(ptr) : default;
        }
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoder);
            return ptr is not 0 ? new MTLComputeCommandEncoder(ptr) : default;
        }
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSError? Error
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.Error);
            return ptr is not 0 ? new NSError(ptr) : default;
        }
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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLogContainer? Logs
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.Logs);
            return ptr is not 0 ? new MTLLogContainer(ptr) : default;
        }
    }

    public MTLResourceStateCommandEncoder? ResourceStateCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoder);
            return ptr is not 0 ? new MTLResourceStateCommandEncoder(ptr) : default;
        }
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
        return ptr is not 0 ? new MTLAccelerationStructureCommandEncoder(ptr) : default;
    }

    public MTLBlitCommandEncoder? BlitCommandEncoderWithDescriptor(MTLBlitPassDescriptor blitPassDescriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.BlitCommandEncoder, blitPassDescriptor.NativePtr);
        return ptr is not 0 ? new MTLBlitCommandEncoder(ptr) : default;
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.Commit);
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoderWithDescriptor(MTLComputePassDescriptor computePassDescriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoder, computePassDescriptor.NativePtr);
        return ptr is not 0 ? new MTLComputeCommandEncoder(ptr) : default;
    }

    public MTLComputeCommandEncoder? ComputeCommandEncoderWithDispatchType(MTLDispatchType dispatchType)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoder, (nuint)dispatchType);
        return ptr is not 0 ? new MTLComputeCommandEncoder(ptr) : default;
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
        return ptr is not 0 ? new MTLParallelRenderCommandEncoder(ptr) : default;
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
        return ptr is not 0 ? new MTLRenderCommandEncoder(ptr) : default;
    }

    public MTLResourceStateCommandEncoder? ResourceStateCommandEncoderWithDescriptor(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoder, resourceStatePassDescriptor.NativePtr);
        return ptr is not 0 ? new MTLResourceStateCommandEncoder(ptr) : default;
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
