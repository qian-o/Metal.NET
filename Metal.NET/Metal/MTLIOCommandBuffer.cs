namespace Metal.NET;

public class MTLIOCommandBuffer(nint nativePtr) : NativeObject(nativePtr)
{
    public NSError? Error
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandBufferBindings.Error);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSError(ptr);
            }

            return field;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandBufferBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLIOStatus Status
    {
        get => (MTLIOStatus)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandBufferBindings.Status);
    }

    public void AddBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.AddBarrier);
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.Commit);
    }

    public void CopyStatusToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.CopyStatusToBuffer, buffer.NativePtr, offset);
    }

    public void Enqueue()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.Enqueue);
    }

    public void LoadBuffer(MTLBuffer buffer, nuint offset, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadBuffer, buffer.NativePtr, offset, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadBytes(nint pointer, nuint size, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadBytes, pointer, size, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void LoadTexture(MTLTexture texture, nuint slice, nuint level, MTLSize size, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLOrigin destinationOrigin, MTLIOFileHandle sourceHandle, nuint sourceHandleOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.LoadTexture, texture.NativePtr, slice, level, size, sourceBytesPerRow, sourceBytesPerImage, destinationOrigin, sourceHandle.NativePtr, sourceHandleOffset);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public void SignalEvent(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.SignalEvent, @event.NativePtr, value);
    }

    public void TryCancel()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.TryCancel);
    }

    public void Wait(MTLSharedEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.Wait, @event.NativePtr, value);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferBindings.WaitUntilCompleted);
    }
}

file static class MTLIOCommandBufferBindings
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
