namespace Metal.NET;

public class MTL4CommitFeedback(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CommitFeedback>
{
    public static MTL4CommitFeedback Create(nint nativePtr) => new(nativePtr);

    public static MTL4CommitFeedback CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public NSError Error
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
