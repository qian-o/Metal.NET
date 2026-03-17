namespace Metal.NET;

public class MTL4CommitFeedback(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommitFeedback>
{
    #region INativeObject
    public static new MTL4CommitFeedback Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommitFeedback New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSError Error
    {
        get => GetProperty(ref field, MTL4CommitFeedbackBindings.Error);
    }

    public double GPUStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUStartTime);
    }

    public double GPUEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUEndTime);
    }

    public NSError Error
    {
        get => GetProperty(ref field, MTL4CommitFeedbackBindings.Error);
    }

    public double GPUStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUStartTime);
    }

    public double GPUEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUEndTime);
    }
}

file static class MTL4CommitFeedbackBindings
{
    public static readonly Selector Error = "error";

    public static readonly Selector GPUEndTime = "GPUEndTime";

    public static readonly Selector GPUStartTime = "GPUStartTime";
}
