namespace Metal.NET;

public class MTL4CommitFeedback(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTL4CommitFeedback>
{
    #region INativeObject
    public static MTL4CommitFeedback Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CommitFeedback New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSError Error
    {
        get => GetProperty(ref field, MTL4CommitFeedbackBindings.Error);
    }

    public double GPUEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUStartTime);
    }
}

file static class MTL4CommitFeedbackBindings
{
    public static readonly Selector Error = "error";

    public static readonly Selector GPUEndTime = "GPUEndTime";

    public static readonly Selector GPUStartTime = "GPUStartTime";
}
