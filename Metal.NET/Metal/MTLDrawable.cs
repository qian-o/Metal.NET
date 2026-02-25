namespace Metal.NET;

public class MTLDrawable(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLDrawable>
{
    public static MTLDrawable Create(nint nativePtr) => new(nativePtr, true);

    public static MTLDrawable CreateBorrowed(nint nativePtr) => new(nativePtr, false);

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
    public static readonly Selector DrawableID = "drawableID";

    public static readonly Selector Present = "present";

    public static readonly Selector PresentAfterMinimumDuration = "presentAfterMinimumDuration:";

    public static readonly Selector PresentAtTime = "presentAtTime:";

    public static readonly Selector PresentedTime = "presentedTime";
}
