namespace Metal.NET;

/// <summary>A command buffer that contains input/output commands that work with files in the file systems and Metal resources.</summary>
public class MTLIOCommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOCommandBuffer>
{
    #region INativeObject
    public static new MTLIOCommandBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOCommandBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Checking the state of a command buffer - Properties

    /// <summary>Represents the state of the input/output command buffer.</summary>
    public MTLIOStatus Status
    {
        get => (MTLIOStatus)ObjectiveC.MsgSendLong(NativePtr, MTLIOCommandBufferBindings.Status);
    }

    /// <summary>Stores the details of an error when the GPU experienced a problem with the input/output command buffer.</summary>
    public NSError Error
    {
        get => GetProperty(ref field, MTLIOCommandBufferBindings.Error);
    }
    #endregion

    #region Debugging a command buffer - Properties

    /// <summary>An optional name for the input/output command buffer.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLIOCommandBufferBindings.Label);
        set => SetProperty(ref field, MTLIOCommandBufferBindings.SetLabel, value);
    }
    #endregion

    #region Loading assets - Methods

    /// <summary>Encodes a command that loads data from a file handle into a GPU buffer.</summary>
    public void LoadBuffer(MTLBuffer buffer, nuint offset, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadBuffer, buffer.NativePtr, offset, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    /// <summary>Encodes a command that loads data from a file handle into a GPU texture.</summary>
    public void LoadTexture(MTLTexture texture, nuint slice, nuint level, MTLSize size, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLOrigin destinationOrigin, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadTexture, texture.NativePtr, slice, level, size, sourceBytesPerRow, sourceBytesPerImage, destinationOrigin, sourceHandle.NativePtr, sourceHandleOffset);
    }

    /// <summary>Encodes a command that loads data from a file handle into CPU-accessible memory buffer.</summary>
    public void LoadBytes(nint pointer, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadBytes, pointer, size, sourceHandle.NativePtr, sourceHandleOffset);
    }
    #endregion

    #region Adding a barrier - Methods

    /// <summary>Encodes a barrier into the command buffer.</summary>
    public void AddBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.AddBarrier);
    }
    #endregion

    #region Synchronizing a command buffer - Methods

    /// <summary>Encodes a command that signals a shared event to other parts of your app.</summary>
    public void SignalEvent(MTLSharedEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.SignalEvent, @event.NativePtr, value);
    }
    #endregion

    #region Adding final commands - Methods

    /// <summary>Encodes a command that writes the input/output command buffer’s status to a buffer.</summary>
    public void CopyStatusToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.CopyStatusToBuffer, buffer.NativePtr, offset);
    }

    /// <summary>Adds a closure that Metal calls immediately after the GPU finishes executing the commands in the input/output command buffer.</summary>
    public void AddCompletedHandler(MTLIOCommandBufferHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.AddCompletedHandler, block.NativePtr);
    }
    #endregion

    #region Submitting a command buffer - Methods

    /// <summary>Submits the command buffer to the queue for execution on the GPU.</summary>
    public void Commit()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.Commit);
    }

    /// <summary>Reserves a place for the input/output command buffer in the input/output command queue without committing the command buffer.</summary>
    public void Enqueue()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.Enqueue);
    }
    #endregion

    #region Canceling a command buffer - Methods

    /// <summary>Submits a request to abandon a command buffer the queue is currently running.</summary>
    public void TryCancel()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.TryCancel);
    }
    #endregion

    #region Waiting for a command buffer - Methods

    /// <summary>Blocks the current thread until the GPU finishes executing the input/output command buffer and all of its completion handlers.</summary>
    public void WaitUntilCompleted()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.WaitUntilCompleted);
    }
    #endregion

    #region Debugging a command buffer - Methods

    /// <summary>Sets the current name for this input/output command encoder by adding it to the top of the debug name stack.</summary>
    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    /// <summary>Restores the previous name for this input/output command encoder by removing the top item of the debug name stack.</summary>
    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.PopDebugGroup);
    }
    #endregion

    public void Wait(MTLSharedEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.Wait, @event.NativePtr, value);
    }
}

file static class MTLIOCommandBufferBindings
{
    public static readonly Selector AddBarrier = "addBarrier";

    public static readonly Selector AddCompletedHandler = "addCompletedHandler:";

    public static readonly Selector Commit = "commit";

    public static readonly Selector CopyStatusToBuffer = "copyStatusToBuffer:offset:";

    public static readonly Selector Enqueue = "enqueue";

    public static readonly Selector Error = "error";

    public static readonly Selector Label = "label";

    public static readonly Selector LoadBuffer = "loadBuffer:offset:size:sourceHandle:sourceHandleOffset:";

    public static readonly Selector LoadBytes = "loadBytes:size:sourceHandle:sourceHandleOffset:";

    public static readonly Selector LoadTexture = "loadTexture:slice:level:size:sourceBytesPerRow:sourceBytesPerImage:destinationOrigin:sourceHandle:sourceHandleOffset:";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SignalEvent = "signalEvent:value:";

    public static readonly Selector Status = "status";

    public static readonly Selector TryCancel = "tryCancel";

    public static readonly Selector Wait = "waitForEvent:value:";

    public static readonly Selector WaitUntilCompleted = "waitUntilCompleted";
}
