namespace Metal.NET;

file class MTLIOCommandBufferSelector
{
    public static readonly Selector AddBarrier = Selector.Register("addBarrier");
    public static readonly Selector AddCompletedHandler_ = Selector.Register("addCompletedHandler:");
    public static readonly Selector Commit = Selector.Register("commit");
    public static readonly Selector CopyStatusToBuffer_offset_ = Selector.Register("copyStatusToBuffer:offset:");
    public static readonly Selector Enqueue = Selector.Register("enqueue");
    public static readonly Selector LoadBuffer_offset_size_sourceHandle_sourceHandleOffset_ = Selector.Register("loadBuffer:offset:size:sourceHandle:sourceHandleOffset:");
    public static readonly Selector LoadBytes_size_sourceHandle_sourceHandleOffset_ = Selector.Register("loadBytes:size:sourceHandle:sourceHandleOffset:");
    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");
    public static readonly Selector PushDebugGroup_ = Selector.Register("pushDebugGroup:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SignalEvent_value_ = Selector.Register("signalEvent:value:");
    public static readonly Selector TryCancel = Selector.Register("tryCancel");
    public static readonly Selector Wait_value_ = Selector.Register("wait:value:");
    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
}

public class MTLIOCommandBuffer : IDisposable
{
    public MTLIOCommandBuffer(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.AddBarrier);
    }

    public void AddCompletedHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.AddCompletedHandler_, function);
    }

    public void Commit()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.Commit);
    }

    public void CopyStatusToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.CopyStatusToBuffer_offset_, buffer.NativePtr, (nint)offset);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.Enqueue);
    }

    public void LoadBuffer(MTLBuffer buffer, nuint offset, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.LoadBuffer_offset_size_sourceHandle_sourceHandleOffset_, buffer.NativePtr, (nint)offset, (nint)size, sourceHandle.NativePtr, (nint)sourceHandleOffset);
    }

    public void LoadBytes(nint pointer, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.LoadBytes_size_sourceHandle_sourceHandleOffset_, pointer, (nint)size, sourceHandle.NativePtr, (nint)sourceHandleOffset);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.PushDebugGroup_, @string.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.SetLabel_, label.NativePtr);
    }

    public void SignalEvent(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.SignalEvent_value_, @event.NativePtr, (nint)value);
    }

    public void TryCancel()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.TryCancel);
    }

    public void Wait(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.Wait_value_, @event.NativePtr, (nint)value);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandBufferSelector.WaitUntilCompleted);
    }

}
