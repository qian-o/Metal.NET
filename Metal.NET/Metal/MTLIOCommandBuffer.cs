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

    public void AddBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.AddBarrier);
    }

    public void AddCompletedHandler(int function)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.AddCompletedHandler, function);
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.Commit);
    }

    public void CopyStatusToBuffer(MTLBuffer buffer, uint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.CopyStatusToBufferOffset, buffer.NativePtr, (nint)offset);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.Enqueue);
    }

    public void LoadBuffer(MTLBuffer buffer, uint offset, uint size, MTLIOFileHandle sourceHandle, uint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.LoadBufferOffsetSizeSourceHandleSourceHandleOffset, buffer.NativePtr, (nint)offset, (nint)size, sourceHandle.NativePtr, (nint)sourceHandleOffset);
    }

    public void LoadBytes(int pointer, uint size, MTLIOFileHandle sourceHandle, uint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.LoadBytesSizeSourceHandleSourceHandleOffset, pointer, (nint)size, sourceHandle.NativePtr, (nint)sourceHandleOffset);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.PushDebugGroup, @string.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.SetLabel, label.NativePtr);
    }

    public void SignalEvent(MTLSharedEvent @event, uint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.SignalEventValue, @event.NativePtr, (nint)value);
    }

    public void TryCancel()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.TryCancel);
    }

    public void Wait(MTLSharedEvent @event, uint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.WaitValue, @event.NativePtr, (nint)value);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferSelector.WaitUntilCompleted);
    }

}

file class MTLIOCommandBufferSelector
{
    public static readonly Selector AddBarrier = Selector.Register("addBarrier");

    public static readonly Selector AddCompletedHandler = Selector.Register("addCompletedHandler:");

    public static readonly Selector Commit = Selector.Register("commit");

    public static readonly Selector CopyStatusToBufferOffset = Selector.Register("copyStatusToBuffer:offset:");

    public static readonly Selector Enqueue = Selector.Register("enqueue");

    public static readonly Selector LoadBufferOffsetSizeSourceHandleSourceHandleOffset = Selector.Register("loadBuffer:offset:size:sourceHandle:sourceHandleOffset:");

    public static readonly Selector LoadBytesSizeSourceHandleSourceHandleOffset = Selector.Register("loadBytes:size:sourceHandle:sourceHandleOffset:");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SignalEventValue = Selector.Register("signalEvent:value:");

    public static readonly Selector TryCancel = Selector.Register("tryCancel");

    public static readonly Selector WaitValue = Selector.Register("wait:value:");

    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
}
