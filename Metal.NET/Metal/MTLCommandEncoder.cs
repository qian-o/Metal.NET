namespace Metal.NET;

public partial class MTLCommandEncoder : NativeObject
{
    public MTLCommandEncoder(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandEncoderSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandEncoderSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderSelector.BarrierAfterQueueStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderSelector.EndEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderSelector.InsertDebugSignpost, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderSelector.PushDebugGroup, @string.NativePtr);
    }
}

file static class MTLCommandEncoderSelector
{
    public static readonly Selector BarrierAfterQueueStages = Selector.Register("barrierAfterQueueStages::");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndEncoding = Selector.Register("endEncoding");

    public static readonly Selector InsertDebugSignpost = Selector.Register("insertDebugSignpost:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
