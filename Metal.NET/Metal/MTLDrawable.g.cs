namespace Metal.NET;

file class MTLDrawableSelector
{
    public static readonly Selector AddPresentedHandler_ = Selector.Register("addPresentedHandler:");
    public static readonly Selector Present = Selector.Register("present");
    public static readonly Selector PresentAfterMinimumDuration_ = Selector.Register("presentAfterMinimumDuration:");
    public static readonly Selector PresentAtTime_ = Selector.Register("presentAtTime:");
}

public class MTLDrawable : IDisposable
{
    public MTLDrawable(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLDrawable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDrawable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDrawable(nint value)
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

    public void AddPresentedHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDrawableSelector.AddPresentedHandler_, function);
    }

    public void Present()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDrawableSelector.Present);
    }

    public void PresentAfterMinimumDuration(double duration)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDrawableSelector.PresentAfterMinimumDuration_, duration);
    }

    public void PresentAtTime(double presentationTime)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDrawableSelector.PresentAtTime_, presentationTime);
    }

}
