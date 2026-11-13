namespace Metal.NET;

public readonly struct MTLCommandBuffer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLCommandBuffer value) => new(value.NativePtr);

    public MTLCommandBuffer Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.Device));
    }

    public MTLCommandQueue CommandQueue
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.CommandQueue));
    }

    public Bool8 RetainedReferences
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCommandBufferBindings.RetainedReferences);
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveC.MsgSendULong(NativePtr, MTLCommandBufferBindings.ErrorOptions);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.SetLabel, value.NativePtr);
    }

    public double KernelStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.KernelStartTime);
    }

    public double KernelEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.KernelEndTime);
    }

    public MTLLogContainer Logs
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.Logs));
    }

    public double GpuStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.GPUStartTime);
    }

    public double GpuEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.GPUEndTime);
    }

    public MTLCommandBufferStatus Status
    {
        get => (MTLCommandBufferStatus)ObjectiveC.MsgSendULong(NativePtr, MTLCommandBufferBindings.Status);
    }

    public NSError Error
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.Error));
    }

    public void Enqueue()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.Enqueue);
    }

    public void Commit()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.Commit);
    }

    public void AddScheduledHandler(MTLCommandBufferHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.AddScheduledHandler, block.NativePtr);
    }

    public void Present(MTLDrawable drawable)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawable, drawable.NativePtr);
    }

    public void PresentDrawableAtTime(MTLDrawable drawable, double presentationTime)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawable_AtTime, drawable.NativePtr, presentationTime);
    }

    public void PresentDrawableAfterMinimumDuration(MTLDrawable drawable, double duration)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawable_AfterMinimumDuration, drawable.NativePtr, duration);
    }

    public void WaitUntilScheduled()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.WaitUntilScheduled);
    }

    public void AddCompletedHandler(MTLCommandBufferHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.AddCompletedHandler, block.NativePtr);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.WaitUntilCompleted);
    }

    public MTLBlitCommandEncoder MakeBlitCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.BlitCommandEncoder);

        return new(nativePtr);
    }

    public MTLRenderCommandEncoder MakeRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.RenderCommandEncoderWithDescriptor, renderPassDescriptor.NativePtr);

        return new(nativePtr);
    }

    public MTLComputeCommandEncoder MakeComputeCommandEncoder(MTLComputePassDescriptor computePassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoderWithDescriptor, computePassDescriptor.NativePtr);

        return new(nativePtr);
    }

    public MTLBlitCommandEncoder MakeBlitCommandEncoder(MTLBlitPassDescriptor blitPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.BlitCommandEncoderWithDescriptor, blitPassDescriptor.NativePtr);

        return new(nativePtr);
    }

    public MTLComputeCommandEncoder MakeComputeCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoder);

        return new(nativePtr);
    }

    public MTLComputeCommandEncoder MakeComputeCommandEncoder(MTLDispatchType dispatchType)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoderWithDispatchType, (nuint)dispatchType);

        return new(nativePtr);
    }

    public void EncodeWaitForEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.EncodeWaitForEvent_Value, @event.NativePtr, value);
    }

    public void EncodeSignalEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.EncodeSignalEvent_Value, @event.NativePtr, value);
    }

    public MTLParallelRenderCommandEncoder MakeParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ParallelRenderCommandEncoderWithDescriptor, renderPassDescriptor.NativePtr);

        return new(nativePtr);
    }

    public MTLResourceStateCommandEncoder MakeResourceStateCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoder);

        return new(nativePtr);
    }

    public MTLResourceStateCommandEncoder ResourceStateCommandEncoder(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoderWithDescriptor, resourceStatePassDescriptor.NativePtr);

        return new(nativePtr);
    }

    public MTLAccelerationStructureCommandEncoder MakeAccelerationStructureCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.AccelerationStructureCommandEncoder);

        return new(nativePtr);
    }

    public MTLAccelerationStructureCommandEncoder MakeAccelerationStructureCommandEncoder(MTLAccelerationStructurePassDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.AccelerationStructureCommandEncoderWithDescriptor, descriptor.NativePtr);

        return new(nativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PopDebugGroup);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.UseResidencySet, residencySet.NativePtr);
    }

    public unsafe void UseResidencySets(ReadOnlySpan<MTLResidencySet> residencySets)
    {
        fixed (MTLResidencySet* pResidencySets = residencySets)
        {
            ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.UseResidencySets_Count, (nint)pResidencySets, (nuint)residencySets.Length);
        }
    }
}

file static class MTLCommandBufferBindings
{
    public static readonly Selector AccelerationStructureCommandEncoder = "accelerationStructureCommandEncoder";

    public static readonly Selector AccelerationStructureCommandEncoderWithDescriptor = "accelerationStructureCommandEncoderWithDescriptor:";

    public static readonly Selector AddCompletedHandler = "addCompletedHandler:";

    public static readonly Selector AddScheduledHandler = "addScheduledHandler:";

    public static readonly Selector BlitCommandEncoder = "blitCommandEncoder";

    public static readonly Selector BlitCommandEncoderWithDescriptor = "blitCommandEncoderWithDescriptor:";

    public static readonly Selector CommandQueue = "commandQueue";

    public static readonly Selector Commit = "commit";

    public static readonly Selector ComputeCommandEncoder = "computeCommandEncoder";

    public static readonly Selector ComputeCommandEncoderWithDescriptor = "computeCommandEncoderWithDescriptor:";

    public static readonly Selector ComputeCommandEncoderWithDispatchType = "computeCommandEncoderWithDispatchType:";

    public static readonly Selector Device = "device";

    public static readonly Selector EncodeSignalEvent_Value = "encodeSignalEvent:value:";

    public static readonly Selector EncodeWaitForEvent_Value = "encodeWaitForEvent:value:";

    public static readonly Selector Enqueue = "enqueue";

    public static readonly Selector Error = "error";

    public static readonly Selector ErrorOptions = "errorOptions";

    public static readonly Selector GPUEndTime = "GPUEndTime";

    public static readonly Selector GPUStartTime = "GPUStartTime";

    public static readonly Selector KernelEndTime = "kernelEndTime";

    public static readonly Selector KernelStartTime = "kernelStartTime";

    public static readonly Selector Label = "label";

    public static readonly Selector Logs = "logs";

    public static readonly Selector ParallelRenderCommandEncoderWithDescriptor = "parallelRenderCommandEncoderWithDescriptor:";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PresentDrawable = "presentDrawable:";

    public static readonly Selector PresentDrawable_AfterMinimumDuration = "presentDrawable:afterMinimumDuration:";

    public static readonly Selector PresentDrawable_AtTime = "presentDrawable:atTime:";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector RenderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";

    public static readonly Selector ResourceStateCommandEncoder = "resourceStateCommandEncoder";

    public static readonly Selector ResourceStateCommandEncoderWithDescriptor = "resourceStateCommandEncoderWithDescriptor:";

    public static readonly Selector RetainedReferences = "retainedReferences";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Status = "status";

    public static readonly Selector UseResidencySet = "useResidencySet:";

    public static readonly Selector UseResidencySets_Count = "useResidencySets:count:";

    public static readonly Selector WaitUntilCompleted = "waitUntilCompleted";

    public static readonly Selector WaitUntilScheduled = "waitUntilScheduled";
}
