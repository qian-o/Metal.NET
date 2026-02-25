namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLDrawable(nativePtr, ownsReference, allowGCRelease), INativeObject<CAMetalDrawable>
{
    public static new CAMetalDrawable Null { get; } = new(0, false, false);

    public static new CAMetalDrawable Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

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
