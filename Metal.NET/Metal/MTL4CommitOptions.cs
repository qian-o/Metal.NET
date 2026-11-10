namespace Metal.NET;

public readonly struct MTL4CommitOptions(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CommitOptions value) => new(value.NativePtr);

    public MTL4CommitOptions() : this(ObjectiveC.AllocInit(MTL4CommitOptionsBindings.Class))
    {
    }

    public MTL4CommitOptions Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void AddFeedbackHandler(MTL4CommitFeedbackHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommitOptionsBindings.AddFeedbackHandler, block.NativePtr);
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommitOptions");

    public static readonly Selector AddFeedbackHandler = "addFeedbackHandler:";
}
