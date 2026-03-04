namespace Metal.NET;

public class MTLCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLCommandEncoder>
{
    #region INativeObject
    public static MTLCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

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
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.BarrierAfterQueueStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }

    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.EndEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
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
