namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr) : MTLDrawable(nativePtr)
{
    public CAMetalLayer Layer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableSelector.Layer));
    }

    public MTLTexture Texture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableSelector.Texture));
    }

    public static implicit operator nint(CAMetalDrawable value)
    {
        return value.NativePtr;
    }

    public static implicit operator CAMetalDrawable(nint value)
    {
        return new(value);
    }
}

file class CAMetalDrawableSelector
{
    public static readonly Selector Layer = Selector.Register("layer");

    public static readonly Selector Texture = Selector.Register("texture");
}
