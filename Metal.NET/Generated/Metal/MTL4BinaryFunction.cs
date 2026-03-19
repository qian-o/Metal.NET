namespace Metal.NET;

public partial class MTL4BinaryFunction(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4BinaryFunction>
{
    #region INativeObject
    public static new MTL4BinaryFunction Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4BinaryFunction New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTL4BinaryFunctionBindings
{
}
