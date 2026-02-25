namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingNode>
{
    public static MTLFunctionStitchingNode Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFunctionStitchingNode Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class MTLFunctionStitchingNodeBindings
{
}
