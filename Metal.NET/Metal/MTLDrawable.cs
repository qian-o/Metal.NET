namespace Metal.NET;

public readonly struct MTLDrawable(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLDrawable value) => new(value.NativePtr);

    public MTLDrawable Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public double PresentedTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLDrawableBindings.PresentedTime);
    }

    public nuint DrawableID
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDrawableBindings.DrawableID);
    }

    public void Present()
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.Present);
    }

    public void PresentAtTime(double presentationTime)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.PresentAtTime, presentationTime);
    }

    public void PresentAfterMinimumDuration(double duration)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.PresentAfterMinimumDuration, duration);
    }

    public void AddPresentedHandler(MTLDrawablePresentedHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDrawableBindings.AddPresentedHandler, block.NativePtr);
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
