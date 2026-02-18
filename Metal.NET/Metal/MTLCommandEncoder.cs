namespace Metal.NET;

public class MTLCommandEncoder(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandEncoderSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandEncoderSelector.Label));
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
    public static readonly Selector BarrierAfterQueueStages = Selector.Register("barrierAfterQueueStages:beforeStages:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndEncoding = Selector.Register("endEncoding");

    public static readonly Selector InsertDebugSignpost = Selector.Register("insertDebugSignpost:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
