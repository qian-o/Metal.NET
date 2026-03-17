namespace Metal.NET;

/// <summary>
/// A protocol to identify call graph nodes.
/// </summary>
public class MTLFunctionStitchingNode(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingNode>
{
    #region INativeObject
    public static new MTLFunctionStitchingNode Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingNode New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLFunctionStitchingNodeBindings
{
}
