namespace Metal.NET;

public readonly struct CAMetalDrawable(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLDrawable(CAMetalDrawable value) => new(value.NativePtr);

    public static implicit operator NSObject(CAMetalDrawable value) => new(value.NativePtr);

    public CAMetalDrawable Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTexture Texture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, CAMetalDrawableBindings.Texture));
    }

    public CAMetalLayer Layer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, CAMetalDrawableBindings.Layer));
    }

    public double PresentedTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, CAMetalDrawableBindings.PresentedTime);
    }

    public nuint DrawableID
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, CAMetalDrawableBindings.DrawableID);
    }

    public void Present()
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalDrawableBindings.Present);
    }

    public void PresentAtTime(double presentationTime)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalDrawableBindings.PresentAtTime, presentationTime);
    }

    public void PresentAfterMinimumDuration(double duration)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalDrawableBindings.PresentAfterMinimumDuration, duration);
    }

    public void AddPresentedHandler(MTLDrawablePresentedHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalDrawableBindings.AddPresentedHandler, block.NativePtr);
    }
}

file static class CAMetalDrawableBindings
{
    public static readonly Selector AddPresentedHandler = "addPresentedHandler:";

    public static readonly Selector DrawableID = "drawableID";

    public static readonly Selector Layer = "layer";

    public static readonly Selector Present = "present";

    public static readonly Selector PresentAfterMinimumDuration = "presentAfterMinimumDuration:";

    public static readonly Selector PresentAtTime = "presentAtTime:";

    public static readonly Selector PresentedTime = "presentedTime";

    public static readonly Selector Texture = "texture";
}
