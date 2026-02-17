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

    public void BarrierAfterQueueStages(uint afterQueueStages, uint beforeStages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoderSelector.BarrierAfterQueueStagesBeforeStages, (nint)afterQueueStages, (nint)beforeStages);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoderSelector.EndEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoderSelector.InsertDebugSignpost, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoderSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoderSelector.PushDebugGroup, @string.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoderSelector.SetLabel, label.NativePtr);
    }

}

file class MTLCommandEncoderSelector
{
    public static readonly Selector BarrierAfterQueueStagesBeforeStages = Selector.Register("barrierAfterQueueStages:beforeStages:");
    public static readonly Selector EndEncoding = Selector.Register("endEncoding");
    public static readonly Selector InsertDebugSignpost = Selector.Register("insertDebugSignpost:");
    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");
    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
