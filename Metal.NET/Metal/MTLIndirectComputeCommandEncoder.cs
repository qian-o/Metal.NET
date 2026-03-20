namespace Metal.NET;

public class MTLIndirectComputeCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIndirectComputeCommandEncoder>
{
    #region INativeObject
    public static new MTLIndirectComputeCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectComputeCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLIndirectComputeCommandEncoderBindings
{
}
