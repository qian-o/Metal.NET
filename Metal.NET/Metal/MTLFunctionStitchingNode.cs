namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingNode>
{
    #region INativeObject
    public static MTLFunctionStitchingNode Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFunctionStitchingNode New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLFunctionStitchingNodeBindings
{
}
