namespace Metal.NET;

public class MTLLogState(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLLogState>
{
    public static MTLLogState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLLogState Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class MTLLogStateBindings
{
}
