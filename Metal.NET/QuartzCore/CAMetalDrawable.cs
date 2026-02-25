namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr, NativeObjectOwnership ownership) : MTLDrawable(nativePtr, ownership), INativeObject<CAMetalDrawable>
{
    public static new CAMetalDrawable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new CAMetalDrawable Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

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
