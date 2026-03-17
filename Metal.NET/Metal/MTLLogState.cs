namespace Metal.NET;

public class MTLLogState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLogState>
{
    #region INativeObject
    public static new MTLLogState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLogState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLLogStateBindings
{
}
