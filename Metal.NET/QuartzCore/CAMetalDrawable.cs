namespace Metal.NET;

public readonly struct CAMetalDrawable(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public CAMetalLayer? Layer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableBindings.Layer);
            return ptr is not 0 ? new CAMetalLayer(ptr) : default;
        }
    }

    public MTLTexture? Texture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableBindings.Texture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
    }
}

file static class CAMetalDrawableBindings
{
    public static readonly Selector Layer = Selector.Register("layer");

    public static readonly Selector Texture = Selector.Register("texture");
}
