namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr, bool ownsReference) : MTLDrawable(nativePtr, ownsReference), INativeObject<CAMetalDrawable>
{
    public static new CAMetalDrawable Create(nint nativePtr) => new(nativePtr, true);

    public static new CAMetalDrawable CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public CAMetalLayer Layer
    {
        get => GetProperty(ref field, CAMetalDrawableBindings.Layer);
    }

    public MTLTexture Texture
    {
        get => GetProperty(ref field, CAMetalDrawableBindings.Texture);
    }
}

file static class CAMetalDrawableBindings
{
    public static readonly Selector Layer = "layer";

    public static readonly Selector Texture = "texture";
}
