namespace Metal.NET;

public class MTL4CommitOptions : IDisposable
{
    public MTL4CommitOptions(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CommitOptions()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommitOptions value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommitOptions(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public void AddFeedbackHandler(int function)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommitOptionsSelector.AddFeedbackHandler, function);
    }

}

file class MTL4CommitOptionsSelector
{
    public static readonly Selector AddFeedbackHandler = Selector.Register("addFeedbackHandler:");
}
