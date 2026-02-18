namespace Metal.NET;

public partial class MTLIOCommandBuffer : NativeObject
{
    public MTLIOCommandBuffer(nint nativePtr) : base(nativePtr)
    {
    }

    public NSError? Error
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandBufferSelector.Error);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandBufferSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLIOStatus Status
    {
        get => (MTLIOStatus)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandBufferSelector.Status);
    }

    public void AddBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.AddBarrier);
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.Commit);
    }

    public void CopyStatusToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.CopyStatusToBuffer, buffer.NativePtr, offset);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.Enqueue);
    }

    public void LoadBuffer(MTLBuffer buffer, nuint offset, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.LoadBuffer, buffer.NativePtr, offset, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadBytes(nint pointer, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.LoadBytes, pointer, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadTexture(MTLTexture texture, nuint slice, nuint level, MTLSize size, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLOrigin destinationOrigin, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.LoadTexture, texture.NativePtr, slice, level, size, sourceBytesPerRow, sourceBytesPerImage, destinationOrigin, sourceHandle.NativePtr, sourceHandleOffset);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.SignalEvent, @event.NativePtr, value);
    }

    public void TryCancel()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.TryCancel);
    }

    public void Wait(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.Wait, @event.NativePtr, value);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.WaitUntilCompleted);
    }
}

file static class MTLIOCommandBufferSelector
{
    public static readonly Selector AddBarrier = Selector.Register("addBarrier");

    public static readonly Selector Commit = Selector.Register("commit");

    public static readonly Selector CopyStatusToBuffer = Selector.Register("copyStatusToBuffer:offset:");

    public static readonly Selector Enqueue = Selector.Register("enqueue");

    public static readonly Selector Error = Selector.Register("error");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector LoadBuffer = Selector.Register("loadBuffer:offset:size:sourceHandle:sourceHandleOffset:");

    public static readonly Selector LoadBytes = Selector.Register("loadBytes:size:sourceHandle:sourceHandleOffset:");

    public static readonly Selector LoadTexture = Selector.Register("loadTexture:slice:level:size:sourceBytesPerRow:sourceBytesPerImage:destinationOrigin:sourceHandle:sourceHandleOffset:");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SignalEvent = Selector.Register("signalEvent:value:");

    public static readonly Selector Status = Selector.Register("status");

    public static readonly Selector TryCancel = Selector.Register("tryCancel");

    public static readonly Selector Wait = Selector.Register("waitForEvent:value:");

    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
}
