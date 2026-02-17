namespace Metal.NET;

public class MTLCommandEncoder : IDisposable
{
    public MTLCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandEncoderSelector.Device));

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandEncoderSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderSelector.SetLabel, value.NativePtr);
    }

    public void BarrierAfterQueueStages(nuint afterQueueStages, nuint beforeStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandEncoderSelector.BarrierAfterQueueStagesBeforeStages, afterQueueStages, beforeStages);
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

    public static implicit operator nint(MTLCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandEncoder(nint value)
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

}

file class MTLCommandEncoderSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector BarrierAfterQueueStagesBeforeStages = Selector.Register("barrierAfterQueueStages:beforeStages:");

    public static readonly Selector EndEncoding = Selector.Register("endEncoding");

    public static readonly Selector InsertDebugSignpost = Selector.Register("insertDebugSignpost:");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");
}
