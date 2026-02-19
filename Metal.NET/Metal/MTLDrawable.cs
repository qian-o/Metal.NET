namespace Metal.NET;

public class MTLDrawable(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint DrawableID
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDrawableBindings.DrawableID);
    }

    public double PresentedTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLDrawableBindings.PresentedTime);
    }

    public void Present()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableBindings.Present);
    }

    public void PresentAfterMinimumDuration(double duration)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableBindings.PresentAfterMinimumDuration, duration);
    }

    public void PresentAtTime(double presentationTime)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableBindings.PresentAtTime, presentationTime);
    }
}

file static class MTLDrawableBindings
{
    public static readonly Selector DrawableID = Selector.Register("drawableID");

    public static readonly Selector Present = Selector.Register("present");

    public static readonly Selector PresentAfterMinimumDuration = Selector.Register("presentAfterMinimumDuration:");

    public static readonly Selector PresentAtTime = Selector.Register("presentAtTime:");

    public static readonly Selector PresentedTime = Selector.Register("presentedTime");
}
