namespace Metal.NET;

/// <summary>
/// A Metal drawable associated with a Core Animation layer.
/// </summary>
public class CAMetalDrawable(nint nativePtr, NativeObjectOwnership ownership) : MTLDrawable(nativePtr, ownership), INativeObject<CAMetalDrawable>
{
    #region INativeObject
    public static new CAMetalDrawable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new CAMetalDrawable New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Getting the Drawable’s Texture - Properties

    /// <summary>
    /// A Metal texture object that contains the drawable’s contents.
    /// </summary>
    public MTLTexture Texture
    {
        get => GetProperty(ref field, CAMetalDrawableBindings.Texture);
    }
    #endregion

    #region Getting the Owning Layer - Properties

    /// <summary>
    /// The layer that owns this drawable object.
    /// </summary>
    public CAMetalLayer Layer
    {
        get => GetProperty(ref field, CAMetalDrawableBindings.Layer);
    }
    #endregion
}

file static class CAMetalDrawableBindings
{
    public static readonly Selector Layer = "layer";

    public static readonly Selector Texture = "texture";
}
