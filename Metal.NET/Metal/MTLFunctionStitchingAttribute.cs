namespace Metal.NET;

/// <summary>
/// A protocol to identify types that customize how the Metal compiler stitches a function together.
/// </summary>
public class MTLFunctionStitchingAttribute(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingAttribute>
{
    #region INativeObject
    public static new MTLFunctionStitchingAttribute Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingAttribute New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLFunctionStitchingAttributeBindings
{
}
