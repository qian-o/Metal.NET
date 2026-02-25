namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLLogContainer Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class MTLLogContainerBindings
{
}
