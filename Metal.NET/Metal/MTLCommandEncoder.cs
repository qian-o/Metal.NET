namespace Metal.NET;

public readonly struct MTLCommandEncoder(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandEncoderBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandEncoderBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderBindings.BarrierAfterQueueStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderBindings.EndEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderBindings.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }
}

file static class MTLCommandEncoderBindings
{
    public static readonly Selector BarrierAfterQueueStages = Selector.Register("barrierAfterQueueStages:beforeStages:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndEncoding = Selector.Register("endEncoding");

    public static readonly Selector InsertDebugSignpost = Selector.Register("insertDebugSignpost:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
