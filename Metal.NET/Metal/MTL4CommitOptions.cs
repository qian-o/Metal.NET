namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4CommitOptions>
{
    public static MTL4CommitOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CommitOptions Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4CommitOptions() : this(ObjectiveC.AllocInit(MTL4CommitOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public void AddFeedbackHandler(MTL4CommitFeedbackHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommitOptionsBindings.AddFeedbackHandler, block);
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommitOptions");

    public static readonly Selector AddFeedbackHandler = "addFeedbackHandler:";
}
