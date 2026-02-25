namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingNode>
{
    public static MTLFunctionStitchingNode Create(nint nativePtr) => new(nativePtr, true);

    public static MTLFunctionStitchingNode CreateBorrowed(nint nativePtr) => new(nativePtr, false);
}

file static class MTLFunctionStitchingNodeBindings
{
}
