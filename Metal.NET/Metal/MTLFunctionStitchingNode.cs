namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLFunctionStitchingNode>
{
    public static MTLFunctionStitchingNode Create(nint nativePtr) => new(nativePtr);
}

file static class MTLFunctionStitchingNodeBindings
{
}
