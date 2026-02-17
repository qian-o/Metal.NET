namespace Metal.NET;

public class MTLIOCommandBuffer : IDisposable
{
    public MTLIOCommandBuffer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLIOCommandBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSError Error => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandBufferSelector.Error));

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandBufferSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.SetLabel, value.NativePtr);
    }

    public MTLIOStatus Status => (MTLIOStatus)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLIOCommandBufferSelector.Status));

    public void AddBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.AddBarrier);
    }

    public void AddCompletedHandler(nint function)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.AddCompletedHandler, function);
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.Commit);
    }

    public void CopyStatusToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.CopyStatusToBufferOffset, buffer.NativePtr, offset);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.Enqueue);
    }

    public void LoadBuffer(MTLBuffer buffer, nuint offset, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.LoadBufferOffsetSizeSourceHandleSourceHandleOffset, buffer.NativePtr, offset, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadBytes(nint pointer, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.LoadBytesSizeSourceHandleSourceHandleOffset, pointer, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadTexture(MTLTexture texture, nuint slice, nuint level, MTLSize size, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLOrigin destinationOrigin, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.LoadTextureSliceLevelSizeSourceBytesPerRowSourceBytesPerImageDestinationOriginSourceHandleSourceHandleOffset, texture.NativePtr, slice, level, size, sourceBytesPerRow, sourceBytesPerImage, destinationOrigin, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.PushDebugGroup, @string.NativePtr);
    }

    public void SignalEvent(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.SignalEventValue, @event.NativePtr, value);
    }

    public void TryCancel()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.TryCancel);
    }

    public void Wait(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.WaitValue, @event.NativePtr, value);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.WaitUntilCompleted);
    }

    public static implicit operator nint(MTLIOCommandBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOCommandBuffer(nint value)
    {
        return new(value);
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

file class MTLIOCommandBufferSelector
{
    public static readonly Selector Error = Selector.Register("error");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Status = Selector.Register("status");

    public static readonly Selector AddBarrier = Selector.Register("addBarrier");

    public static readonly Selector AddCompletedHandler = Selector.Register("addCompletedHandler:");

    public static readonly Selector Commit = Selector.Register("commit");

    public static readonly Selector CopyStatusToBufferOffset = Selector.Register("copyStatusToBuffer:offset:");

    public static readonly Selector Enqueue = Selector.Register("enqueue");

    public static readonly Selector LoadBufferOffsetSizeSourceHandleSourceHandleOffset = Selector.Register("loadBuffer:offset:size:sourceHandle:sourceHandleOffset:");

    public static readonly Selector LoadBytesSizeSourceHandleSourceHandleOffset = Selector.Register("loadBytes:size:sourceHandle:sourceHandleOffset:");

    public static readonly Selector LoadTextureSliceLevelSizeSourceBytesPerRowSourceBytesPerImageDestinationOriginSourceHandleSourceHandleOffset = Selector.Register("loadTexture:slice:level:size:sourceBytesPerRow:sourceBytesPerImage:destinationOrigin:sourceHandle:sourceHandleOffset:");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector SignalEventValue = Selector.Register("signalEvent:value:");

    public static readonly Selector TryCancel = Selector.Register("tryCancel");

    public static readonly Selector WaitValue = Selector.Register("wait:value:");

    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
}
