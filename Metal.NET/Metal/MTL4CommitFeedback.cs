namespace Metal.NET;

public class MTL4CommitFeedback(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public NSError? Error
    {
        get => GetProperty(ref field, MTL4CommitFeedbackBindings.Error);
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
    public static readonly Selector Error = "error";

    public static readonly Selector GPUEndTime = "GPUEndTime";

    public static readonly Selector GPUStartTime = "GPUStartTime";
}
