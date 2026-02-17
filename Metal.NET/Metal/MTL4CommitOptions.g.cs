namespace Metal.NET;

file class MTL4CommitOptionsSelector
{
    public static readonly Selector AddFeedbackHandler_ = Selector.Register("addFeedbackHandler:");
}

public class MTL4CommitOptions : IDisposable
{
    public MTL4CommitOptions(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void AddFeedbackHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommitOptionsSelector.AddFeedbackHandler_, function);
    }

}
