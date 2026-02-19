namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr, bool owned) : MTLDrawable(nativePtr, owned)
{
    public CAMetalLayer? Layer
    {
        get => GetProperty(ref field, CAMetalDrawableBindings.Layer);
    }

    public MTLTexture? Texture
    {
        get => GetProperty(ref field, CAMetalDrawableBindings.Texture);
    }
}

file static class CAMetalDrawableBindings
{
    public static readonly Selector Layer = "layer";

    public static readonly Selector Texture = "texture";
}
