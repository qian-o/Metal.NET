namespace Metal.NET;

public class MTLIOCommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOCommandBuffer>
{
    #region INativeObject
    public static new MTLIOCommandBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOCommandBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLIOCommandBufferBindings.Label);
        set => SetProperty(ref field, MTLIOCommandBufferBindings.SetLabel, value);
    }

    public MTLIOStatus Status
    {
        get => (MTLIOStatus)ObjectiveC.MsgSendLong(NativePtr, MTLIOCommandBufferBindings.Status);
    }

    public NSError Error
    {
        get => GetProperty(ref field, MTLIOCommandBufferBindings.Error);
    }

    public void AddCompletedHandler(MTLIOCommandBufferHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.AddCompletedHandler, block.NativePtr);
    }

    public void LoadBytesSizeSourceHandleSourceHandleOffset(nint pointer, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadBytes, pointer, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadBytes(nint pointer, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        LoadBytesSizeSourceHandleSourceHandleOffset(pointer, size, sourceHandle, sourceHandleOffset);
    }

    public void LoadBufferOffsetSizeSourceHandleSourceHandleOffset(MTLBuffer buffer, nuint offset, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadBuffer, buffer.NativePtr, offset, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadBuffer(MTLBuffer buffer, nuint offset, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        LoadBufferOffsetSizeSourceHandleSourceHandleOffset(buffer, offset, size, sourceHandle, sourceHandleOffset);
    }

    public void LoadTextureSliceLevelSizeSourceBytesPerRowSourceBytesPerImageDestinationOriginSourceHandleSourceHandleOffset(MTLTexture texture, nuint slice, nuint level, MTLSize size, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLOrigin destinationOrigin, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadTexture, texture.NativePtr, slice, level, size, sourceBytesPerRow, sourceBytesPerImage, destinationOrigin, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadTexture(MTLTexture texture, nuint slice, nuint level, MTLSize size, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLOrigin destinationOrigin, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        LoadTextureSliceLevelSizeSourceBytesPerRowSourceBytesPerImageDestinationOriginSourceHandleSourceHandleOffset(texture, slice, level, size, sourceBytesPerRow, sourceBytesPerImage, destinationOrigin, sourceHandle, sourceHandleOffset);
    }

    public void CopyStatusToBufferOffset(MTLBuffer buffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.CopyStatusToBuffer, buffer.NativePtr, offset);
    }

    public void CopyStatusToBuffer(MTLBuffer buffer, nuint offset)
    {
        CopyStatusToBufferOffset(buffer, offset);
    }

    public void Commit()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.Commit);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.WaitUntilCompleted);
    }

    public void TryCancel()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.TryCancel);
    }

    public void AddBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.AddBarrier);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.PopDebugGroup);
    }

    public void Enqueue()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.Enqueue);
    }

    public void WaitForEventValue(MTLSharedEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.WaitForEvent, @event.NativePtr, value);
    }

    public void WaitForEvent(MTLSharedEvent @event, ulong value)
    {
        WaitForEventValue(@event, value);
    }

    public void SignalEventValue(MTLSharedEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandBufferBindings.SignalEvent, @event.NativePtr, value);
    }

    public void SignalEvent(MTLSharedEvent @event, ulong value)
    {
        SignalEventValue(@event, value);
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

    public static readonly Selector WaitForEvent = "waitForEvent:value:";

    public static readonly Selector WaitUntilCompleted = "waitUntilCompleted";
}
