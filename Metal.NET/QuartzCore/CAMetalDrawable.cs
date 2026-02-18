namespace Metal.NET;

public partial class CAMetalDrawable : NativeObject
{
    public CAMetalDrawable(nint nativePtr) : base(nativePtr)
    {
    }

    public CAMetalLayer? Layer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableSelector.Layer);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLTexture? Texture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableSelector.Texture);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class CAMetalDrawableSelector
{
    public static readonly Selector Layer = Selector.Register("layer");

    public static readonly Selector Texture = Selector.Register("texture");
}
