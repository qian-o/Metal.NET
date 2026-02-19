namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr) : NativeObject(nativePtr)
{
    public CAMetalLayer? Layer
    {
        get => GetProperty<CAMetalLayer>(ref field, CAMetalDrawableBindings.Layer);
    }

    public MTLTexture? Texture
    {
        get => GetProperty<MTLTexture>(ref field, CAMetalDrawableBindings.Texture);
    }
}

file static class CAMetalDrawableBindings
{
    public static readonly Selector Layer = "layer";

    public static readonly Selector Texture = "texture";
}
