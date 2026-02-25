namespace Metal.NET;

public class MTLCommandEncoder(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCommandEncoder>
{
    public static MTLCommandEncoder Null => Create(0, false);
    public static MTLCommandEncoder Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCommandEncoderBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLCommandEncoderBindings.Label);
        set => SetProperty(ref field, MTLCommandEncoderBindings.SetLabel, value);
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
    public static readonly Selector BarrierAfterQueueStages = "barrierAfterQueueStages:beforeStages:";

    public static readonly Selector Device = "device";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SetLabel = "setLabel:";
}
