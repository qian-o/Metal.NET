namespace Metal.NET;

public partial class MTLDrawable : NativeObject
{
    public MTLDrawable(nint nativePtr) : base(nativePtr)
    {
    }

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
}

file static class MTLDrawableSelector
{
    public static readonly Selector DrawableID = Selector.Register("drawableID");

    public static readonly Selector Present = Selector.Register("present");

    public static readonly Selector PresentAfterMinimumDuration = Selector.Register("presentAfterMinimumDuration:");

    public static readonly Selector PresentAtTime = Selector.Register("presentAtTime:");

    public static readonly Selector PresentedTime = Selector.Register("presentedTime");
}
