namespace Metal.NET;

public class MTL4CommitFeedback(nint nativePtr) : NativeObject(nativePtr)
{

    public NSError? Error
    {
        get => GetNullableObject<NSError>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommitFeedbackSelector.Error));
    }

    public double GPUEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackSelector.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackSelector.GPUStartTime);
    }
}

file static class MTL4CommitFeedbackSelector
{
    public static readonly Selector Error = Selector.Register("error");

    public static readonly Selector GPUEndTime = Selector.Register("GPUEndTime");

    public static readonly Selector GPUStartTime = Selector.Register("GPUStartTime");
}
