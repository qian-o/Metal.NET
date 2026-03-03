namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingNode>
{
    public static new MTLFunctionStitchingNode Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingNode Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class MTLFunctionStitchingNodeBindings
{
}
