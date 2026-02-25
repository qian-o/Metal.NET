namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr, bool ownsReference = true) : MTLDrawable(nativePtr, ownsReference), INativeObject<CAMetalDrawable>
{
    public static new CAMetalDrawable Create(nint nativePtr) => new(nativePtr);

    public static new CAMetalDrawable CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

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
