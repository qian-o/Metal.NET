namespace Metal.NET;

public class MTLIndirectRenderCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIndirectRenderCommandEncoder>
{
    #region INativeObject
    public static new MTLIndirectRenderCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectRenderCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLIndirectRenderCommandEncoderBindings
{
}
