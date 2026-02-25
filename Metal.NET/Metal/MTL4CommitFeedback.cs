namespace Metal.NET;

public class MTL4CommitFeedback(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4CommitFeedback>
{
    public static MTL4CommitFeedback Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CommitFeedback Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

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
