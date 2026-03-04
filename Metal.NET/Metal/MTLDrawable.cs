namespace Metal.NET;

public class MTLDrawable(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLDrawable>
{
    #region INativeObject
    public static MTLDrawable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLDrawable New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint DrawableID
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDrawableBindings.DrawableID);
    }

    public double PresentedTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLDrawableBindings.PresentedTime);
    }

    public void AddPresentedHandler(MTLDrawablePresentedHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.AddPresentedHandler, block);
    }

    public void Present()
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.Present);
    }

    public void PresentAfterMinimumDuration(double duration)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.PresentAfterMinimumDuration, duration);
    }

    public void PresentAtTime(double presentationTime)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.PresentAtTime, presentationTime);
    }
}

file static class MTLDrawableBindings
{
    public static readonly Selector AddPresentedHandler = "addPresentedHandler:";

    public static readonly Selector DrawableID = "drawableID";

    public static readonly Selector Present = "present";

    public static readonly Selector PresentAfterMinimumDuration = "presentAfterMinimumDuration:";

    public static readonly Selector PresentAtTime = "presentAtTime:";

    public static readonly Selector PresentedTime = "presentedTime";
}
