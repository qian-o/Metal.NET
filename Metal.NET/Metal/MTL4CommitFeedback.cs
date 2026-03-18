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

    public double GpuStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GpuStartTime);
    }

    public double GpuEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GpuEndTime);
    }
}

file static class MTL4CommitFeedbackBindings
{
    public static readonly Selector Error = "error";

    public static readonly Selector GpuEndTime = "gpuEndTime";

    public static readonly Selector GpuStartTime = "gpuStartTime";
}
