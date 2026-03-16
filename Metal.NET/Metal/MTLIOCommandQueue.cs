namespace Metal.NET;

/// <summary>A command queue that schedules input/output commands for reading files in the file system, and writing to GPU resources and memory.</summary>
public class MTLIOCommandQueue(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOCommandQueue>
{
    #region INativeObject
    public static new MTLIOCommandQueue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOCommandQueue New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Naming the queue - Properties

    /// <summary>An optional name for the input/output command queue.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLIOCommandQueueBindings.Label);
        set => SetProperty(ref field, MTLIOCommandQueueBindings.SetLabel, value);
    }
    #endregion

    #region Creating a input/output command buffer - Methods

    /// <summary>Creates an input/output command buffer for the command queue.</summary>
    public MTLIOCommandBuffer CommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOCommandQueueBindings.CommandBuffer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates an input/output command buffer for the command queue that doesn’t retain the instances you pass to its methods.</summary>
    public MTLIOCommandBuffer CommandBufferWithUnretainedReferences()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Adding a barrier to the queue - Methods

    /// <summary>Appends a barrier that tells the input/output command queue to finish running all in-flight command buffers before running any new command buffers.</summary>
    public void EnqueueBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueBindings.EnqueueBarrier);
    }
    #endregion
}

file static class MTLIOCommandQueueBindings
{
    public static readonly Selector CommandBuffer = "commandBuffer";

    public static readonly Selector CommandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";

    public static readonly Selector EnqueueBarrier = "enqueueBarrier";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
