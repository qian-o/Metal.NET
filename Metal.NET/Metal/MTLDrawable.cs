namespace Metal.NET;

public class MTLDrawable : IDisposable
{
    public MTLDrawable(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLDrawable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint DrawableID
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDrawableSelector.DrawableID);
    }

    public double PresentedTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLDrawableSelector.PresentedTime);
    }

    public void Present()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableSelector.Present);
    }

    public void PresentAfterMinimumDuration(double duration)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableSelector.PresentAfterMinimumDuration, duration);
    }

    public void PresentAtTime(double presentationTime)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableSelector.PresentAtTime, presentationTime);
    }

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
}

file class MTLDrawableSelector
{
    public static readonly Selector DrawableID = Selector.Register("drawableID");

    public static readonly Selector PresentedTime = Selector.Register("presentedTime");

    public static readonly Selector Present = Selector.Register("present");

    public static readonly Selector PresentAfterMinimumDuration = Selector.Register("presentAfterMinimumDuration:");

    public static readonly Selector PresentAtTime = Selector.Register("presentAtTime:");
}
