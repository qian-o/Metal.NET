namespace Metal.NET;

/// <summary>A container that stores a sequence of GPU commands that you encode into it.</summary>
public class MTLCommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandBuffer>
{
    #region INativeObject
    public static new MTLCommandBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Troubleshooting a command buffer - Properties

    /// <summary>The command buffer’s current state.</summary>
    public MTLCommandBufferStatus Status
    {
        get => (MTLCommandBufferStatus)ObjectiveC.MsgSendULong(NativePtr, MTLCommandBufferBindings.Status);
    }
    #endregion

    #region Identifying the command buffer - Properties

    /// <summary>An optional name that can help you identify the command buffer.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.Label);
        set => SetProperty(ref field, MTLCommandBufferBindings.SetLabel, value);
    }

    /// <summary>The command queue that creates the command buffer.</summary>
    public MTLCommandQueue CommandQueue
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.CommandQueue);
    }

    /// <summary>The GPU device that indirectly owns the command buffer because you create it from a command queue the device also owns.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.Device);
    }
    #endregion

    #region Getting error details - Properties

    /// <summary>A description of an error when the GPU encounters an issue as it runs the command buffer.</summary>
    public NSError Error
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.Error);
    }

    /// <summary>Settings that determine which information the command buffer records about execution errors, and how it does it.</summary>
    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveC.MsgSendULong(NativePtr, MTLCommandBufferBindings.ErrorOptions);
    }
    #endregion

    #region Reading the runtime message logs - Properties

    /// <summary>The messages the command buffer records as the GPU runs its commands.</summary>
    public MTLLogContainer Logs
    {
        get => GetProperty(ref field, MTLCommandBufferBindings.Logs);
    }
    #endregion

    #region Checking scheduling times on the CPU - Properties

    /// <summary>The host time, in seconds, when the CPU begins to schedule the command buffer.</summary>
    public double KernelStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.KernelStartTime);
    }

    /// <summary>The host time, in seconds, when the CPU finishes scheduling the command buffer.</summary>
    public double KernelEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.KernelEndTime);
    }
    #endregion

    #region Checking execution times on the GPU - Properties

    /// <summary>The host time, in seconds, when the GPU starts command buffer execution.</summary>
    public double GPUStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.GPUStartTime);
    }

    /// <summary>The host time, in seconds, when the GPU finishes execution of the command buffer.</summary>
    public double GPUEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLCommandBufferBindings.GPUEndTime);
    }
    #endregion

    #region Determining whether to maintain strong references - Properties

    /// <summary>A Boolean value that indicates whether the command buffer maintains strong references to the resources it uses.</summary>
    public Bool8 RetainedReferences
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCommandBufferBindings.RetainedReferences);
    }
    #endregion

    #region Attaching residency sets - Methods

    /// <summary>Applies a residency set to a command buffer.</summary>
    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.UseResidencySet, residencySet.NativePtr);
    }

    /// <summary>Applies multiple residency sets to a command buffer.</summary>
    public unsafe void UseResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.UseResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }
    #endregion

    #region Synchronizing passes with events - Methods

    /// <summary>Encodes a command that updates an event’s value, which can clear the GPU to run passes from other command buffers waiting for the event.</summary>
    public void EncodeSignalEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.EncodeSignalEvent, @event.NativePtr, value);
    }
    #endregion

    #region Presenting a drawable - Methods

    /// <summary>Presents a drawable as early as possible.</summary>
    public void PresentDrawable(MTLDrawable drawable)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawable, drawable.NativePtr);
    }

    /// <summary>Presents a drawable at a specific time.</summary>
    public void PresentDrawableAfterMinimumDuration(MTLDrawable drawable, double duration)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawableAfterMinimumDuration, drawable.NativePtr, duration);
    }
    #endregion

    #region Registering state change handlers - Methods

    /// <summary>Registers a completion handler the GPU device calls immediately after it schedules the command buffer to run on the GPU.</summary>
    public void AddScheduledHandler(MTLCommandBufferHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.AddScheduledHandler, block.NativePtr);
    }

    /// <summary>Registers a completion handler the GPU device calls immediately after the GPU finishes running the commands in the command buffer.</summary>
    public void AddCompletedHandler(MTLCommandBufferHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.AddCompletedHandler, block.NativePtr);
    }
    #endregion

    #region Submitting a command buffer - Methods

    /// <summary>Reserves the next available place for the command buffer in its command queue.</summary>
    public void Enqueue()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.Enqueue);
    }

    /// <summary>Submits the command buffer to run on the GPU.</summary>
    public void Commit()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.Commit);
    }
    #endregion

    #region Waiting for state changes - Methods

    /// <summary>Blocks the current thread until the command queue schedules the buffer.</summary>
    public void WaitUntilScheduled()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.WaitUntilScheduled);
    }

    /// <summary>Blocks the current thread until the GPU finishes executing the command buffer and all of its completion handlers.</summary>
    public void WaitUntilCompleted()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.WaitUntilCompleted);
    }
    #endregion

    #region Creating render encoders - Methods

    /// <summary>Creates a render command encoder from a descriptor.</summary>
    public MTLRenderCommandEncoder RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.RenderCommandEncoder, renderPassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating parallel render encoders - Methods

    /// <summary>Creates a parallel render command encoder from a descriptor.</summary>
    public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ParallelRenderCommandEncoder, renderPassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating acceleration structure encoders - Methods

    /// <summary>Creates a ray-tracing acceleration structure command encoder from a descriptor.</summary>
    public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoderWithDescriptor(MTLAccelerationStructurePassDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.AccelerationStructureCommandEncoderWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a ray-tracing acceleration structure command encoder from a descriptor.</summary>
    public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.AccelerationStructureCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating compute encoders - Methods

    /// <summary>Creates a compute command encoder from a descriptor.</summary>
    public MTLComputeCommandEncoder ComputeCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a compute command encoder from a descriptor.</summary>
    public MTLComputeCommandEncoder ComputeCommandEncoderWithDescriptor(MTLComputePassDescriptor computePassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoderWithDescriptor, computePassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a compute command encoder from a descriptor.</summary>
    public MTLComputeCommandEncoder ComputeCommandEncoderWithDispatchType(MTLDispatchType dispatchType)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ComputeCommandEncoderWithDispatchType, (nuint)dispatchType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating blit encoders - Methods

    /// <summary>Creates a block information transfer (blit) encoder.</summary>
    public MTLBlitCommandEncoder BlitCommandEncoderWithDescriptor(MTLBlitPassDescriptor blitPassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.BlitCommandEncoderWithDescriptor, blitPassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a block information transfer (blit) encoder.</summary>
    public MTLBlitCommandEncoder BlitCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.BlitCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating resource state encoders - Methods

    /// <summary>Creates a resource state command encoder from a descriptor.</summary>
    public MTLResourceStateCommandEncoder ResourceStateCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a resource state command encoder from a descriptor.</summary>
    public MTLResourceStateCommandEncoder ResourceStateCommandEncoderWithDescriptor(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferBindings.ResourceStateCommandEncoderWithDescriptor, resourceStatePassDescriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Grouping commands within a GPU frame capture - Methods

    /// <summary>Marks the beginning of a debug group and gives it an identifying label, which temporarily replaces the previous group, if applicable.</summary>
    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    /// <summary>Marks the end of a debug group and, if applicable, restores the previous group from a stack.</summary>
    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PopDebugGroup);
    }
    #endregion

    public void EncodeWait(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.EncodeWait, @event.NativePtr, value);
    }

    public void PresentDrawableAtTime(MTLDrawable drawable, double presentationTime)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandBufferBindings.PresentDrawableAtTime, drawable.NativePtr, presentationTime);
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
