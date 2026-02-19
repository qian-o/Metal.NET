namespace Metal.NET;

public readonly struct MTL4CommitFeedback(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public NSError? Error
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommitFeedbackBindings.Error);
            return ptr is not 0 ? new NSError(ptr) : default;
        }
    }

    public double GPUEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUStartTime);
    }
}

file static class MTL4CommitFeedbackBindings
{
    public static readonly Selector Error = Selector.Register("error");

    public static readonly Selector GPUEndTime = Selector.Register("GPUEndTime");

    public static readonly Selector GPUStartTime = Selector.Register("GPUStartTime");
}
