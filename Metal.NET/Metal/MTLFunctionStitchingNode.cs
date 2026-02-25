namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingNode>
{
    public static MTLFunctionStitchingNode Create(nint nativePtr) => new(nativePtr);

    public static MTLFunctionStitchingNode CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);
}

file static class MTLFunctionStitchingNodeBindings
{
}
