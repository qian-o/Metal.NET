namespace Metal.NET;

public class MTLFunctionStitchingAttribute(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingAttribute>
{
    public static MTLFunctionStitchingAttribute Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFunctionStitchingAttribute Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class MTLFunctionStitchingAttributeBindings
{
}
