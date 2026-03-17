namespace Metal.NET;

/// <summary>
/// Describes an object containing debug information from Metal to your app after completing a workload.
/// </summary>
public class MTL4CommitFeedback(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommitFeedback>
{
    #region INativeObject
    public static new MTL4CommitFeedback Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommitFeedback New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// A description of an error when the GPU encounters an issue as it runs the committed command buffers.
    /// </summary>
    public NSError Error
    {
        get => GetProperty(ref field, MTL4CommitFeedbackBindings.Error);
    }

    /// <summary>
    /// The host time, in seconds, when the GPU finishes execution of the committed command buffers.
    /// </summary>
    public double GPUEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUEndTime);
    }

    /// <summary>
    /// The host time, in seconds, when the GPU starts execution of the committed command buffers.
    /// </summary>
    public double GPUStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUStartTime);
    }
    #endregion
}

file static class MTL4CommitFeedbackBindings
{
    public static readonly Selector Error = "error";

    public static readonly Selector GPUEndTime = "GPUEndTime";

    public static readonly Selector GPUStartTime = "GPUStartTime";
}
