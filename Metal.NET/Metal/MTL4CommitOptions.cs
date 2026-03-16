namespace Metal.NET;

/// <summary>Represents options to configure a commit operation on a command queue.</summary>
public class MTL4CommitOptions(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommitOptions>
{
    #region INativeObject
    public static new MTL4CommitOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommitOptions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4CommitOptions() : this(ObjectiveC.AllocInit(MTL4CommitOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Methods - Methods

    /// <summary>Registers a commit feedback handler that Metal calls with feedback data when available.</summary>
    public void AddFeedbackHandler(MTL4CommitFeedbackHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommitOptionsBindings.AddFeedbackHandler, block.NativePtr);
    }
    #endregion
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommitOptions");

    public static readonly Selector AddFeedbackHandler = "addFeedbackHandler:";
}
