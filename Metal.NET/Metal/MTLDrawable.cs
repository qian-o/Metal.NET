namespace Metal.NET;

/// <summary>
/// A displayable resource that can be rendered or written to.
/// </summary>
public class MTLDrawable(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLDrawable>
{
    #region INativeObject
    public static new MTLDrawable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLDrawable New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the drawable - Properties

    /// <summary>
    /// A positive integer that identifies the drawable.
    /// </summary>
    public nuint DrawableID
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDrawableBindings.DrawableID);
    }
    #endregion

    #region Getting presentation information - Properties

    /// <summary>
    /// The host time, in seconds, when the drawable was displayed onscreen.
    /// </summary>
    public double PresentedTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLDrawableBindings.PresentedTime);
    }
    #endregion

    #region Presenting the drawable - Methods

    /// <summary>
    /// Presents the drawable onscreen as soon as possible.
    /// </summary>
    public void Present()
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.Present);
    }
    #endregion

    #region Getting presentation information - Methods

    /// <summary>
    /// Registers a block of code to be called immediately after the drawable is presented.
    /// </summary>
    public void AddPresentedHandler(MTLDrawablePresentedHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.AddPresentedHandler, block.NativePtr);
    }
    #endregion

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
