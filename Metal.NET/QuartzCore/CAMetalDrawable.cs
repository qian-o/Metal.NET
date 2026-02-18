namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr) : MTLDrawable(nativePtr)
{

    public CAMetalLayer? Layer
    {
        get => GetNullableObject<CAMetalLayer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableSelector.Layer));
    }

    public MTLTexture? Texture
    {
        get => GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableSelector.Texture));
    }
}

file static class CAMetalDrawableSelector
{
    public static readonly Selector Layer = Selector.Register("layer");

    public static readonly Selector Texture = Selector.Register("texture");
}
