namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLLogContainer>
{
    #region INativeObject
    public static MTLLogContainer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLLogContainer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLLogContainerBindings
{
}
