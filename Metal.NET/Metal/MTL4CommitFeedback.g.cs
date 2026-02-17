namespace Metal.NET;

public class MTL4CommitFeedback : IDisposable
{
    public MTL4CommitFeedback(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CommitFeedback()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommitFeedback value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommitFeedback(nint value)
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

}

file class MTL4CommitFeedbackSelector
{
}
