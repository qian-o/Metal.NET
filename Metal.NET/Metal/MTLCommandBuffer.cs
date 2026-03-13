namespace Metal.NET;

public class MTLCommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandBuffer>
{
    #region INativeObject
    public static new MTLCommandBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLCommandQueue CommandQueue
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.CommandQueue);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.Device);
    }

    public NSError Error
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.Error);
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveC.MsgSendULong(NativePtr, MTLCommandBufferBindings.ErrorOptions);
    }

    public double GPUEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.GPUStartTime);
    }

    public double KernelEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.KernelEndTime);
    }

    public double KernelStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.KernelStartTime);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.Label);
        set => SetProperty(ref field, MTLCommandBufferBindings.SetLabel, value);
    }

    public MTLLogContainer Logs
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.Logs);
    }

    public Bool8 RetainedReferences
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCommandBufferBindings.RetainedReferences);
    }

    public MTLCommandBufferStatus Status
    {
        get => (MTLCommandBufferStatus)ObjectiveC.MsgSendULong(NativePtr, MTLCommandBufferBindings.Status);
    }

    public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.AccelerationStructureCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoderWithDescriptor(MTLAccelerationStructurePassDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.AccelerationStructureCommandEncoderWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void AddCompletedHandler(MTLCommandBufferHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.AddCompletedHandler, block.NativePtr);
    }

    public void AddScheduledHandler(MTLCommandBufferHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.AddScheduledHandler, block.NativePtr);
    }

    public MTLBlitCommandEncoder BlitCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.BlitCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBlitCommandEncoder BlitCommandEncoderWithDescriptor(MTLBlitPassDescriptor blitPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.BlitCommandEncoderWithDescriptor, blitPassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void Commit()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.Commit);
    }

    public MTLComputeCommandEncoder ComputeCommandEncoderWithDescriptor(MTLComputePassDescriptor computePassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoderWithDescriptor, computePassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputeCommandEncoder ComputeCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputeCommandEncoder ComputeCommandEncoderWithDispatchType(MTLDispatchType dispatchType)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoderWithDispatchType, (nuint)dispatchType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void EncodeSignalEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.EncodeSignalEvent, @event.NativePtr, value);
    }

    public void EncodeWait(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.EncodeWait, @event.NativePtr, value);
    }

    public void Enqueue()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.Enqueue);
    }

    public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ParallelRenderCommandEncoder, renderPassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PopDebugGroup);
    }

    public void PresentDrawable(MTLDrawable drawable)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawable, drawable.NativePtr);
    }

    public void PresentDrawableAfterMinimumDuration(MTLDrawable drawable, double duration)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawableAfterMinimumDuration, drawable.NativePtr, duration);
    }

    public void PresentDrawableAtTime(MTLDrawable drawable, double presentationTime)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawableAtTime, drawable.NativePtr, presentationTime);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public MTLRenderCommandEncoder RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.RenderCommandEncoder, renderPassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLResourceStateCommandEncoder ResourceStateCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLResourceStateCommandEncoder ResourceStateCommandEncoderWithDescriptor(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoderWithDescriptor, resourceStatePassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.UseResidencySet, residencySet.NativePtr);
    }

    public unsafe void UseResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.UseResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.WaitUntilCompleted);
    }

    public void WaitUntilScheduled()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.WaitUntilScheduled);
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

    public static readonly Selector ResourceStateCommandEncoderWithDescriptor = "resourceStateCommandEncoderWithDescriptor:";

    public static readonly Selector RetainedReferences = "retainedReferences";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Status = "status";

    public static readonly Selector UseResidencySet = "useResidencySet:";

    public static readonly Selector UseResidencySets = "useResidencySets:count:";

    public static readonly Selector WaitUntilCompleted = "waitUntilCompleted";

    public static readonly Selector WaitUntilScheduled = "waitUntilScheduled";
}
