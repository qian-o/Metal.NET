namespace Metal.NET;

public partial class MTL4CommitFeedback : NativeObject
{
    public MTL4CommitFeedback(nint nativePtr) : base(nativePtr)
    {
    }

    public double GPUEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackSelector.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackSelector.GPUStartTime);
    }

    public NSError? Error
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommitFeedbackSelector.Error);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTL4CommitFeedbackSelector
{
    public static readonly Selector Error = Selector.Register("error");

    public static readonly Selector GPUEndTime = Selector.Register("GPUEndTime");

    public static readonly Selector GPUStartTime = Selector.Register("GPUStartTime");
}
