namespace Metal.NET;

public readonly struct MTLCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLCommandEncoder value) => new(value.NativePtr);

    public MTLCommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandEncoderBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandEncoderBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.SetLabel, value.NativePtr);
    }

    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.EndEncoding);
    }

    public void Barrier(MTLStages afterQueueStages, MTLStages beforeStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.BarrierAfterQueueStages_BeforeStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.PopDebugGroup);
    }
}

file static class MTLCommandEncoderBindings
{
    public static readonly Selector BarrierAfterQueueStages_BeforeStages = "barrierAfterQueueStages:beforeStages:";

    public static readonly Selector Device = "device";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SetLabel = "setLabel:";
}
