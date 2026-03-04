namespace Metal.NET;

public class MTLFunctionStitchingAttribute(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingAttribute>
{
    #region INativeObject
    public static MTLFunctionStitchingAttribute Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFunctionStitchingAttribute New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLFunctionStitchingAttributeBindings
{
}
