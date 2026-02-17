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

    public double GPUEndTime => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackSelector.GPUEndTime);

    public double GPUStartTime => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackSelector.GPUStartTime);

    public NSError Error => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommitFeedbackSelector.Error));

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
    public static readonly Selector GPUEndTime = Selector.Register("GPUEndTime");

    public static readonly Selector GPUStartTime = Selector.Register("GPUStartTime");

    public static readonly Selector Error = Selector.Register("error");
}
