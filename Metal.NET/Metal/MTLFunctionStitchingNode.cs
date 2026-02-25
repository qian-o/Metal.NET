namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingNode>
{
    public static MTLFunctionStitchingNode Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLFunctionStitchingNode Null => new(0, false);
}

file static class MTLFunctionStitchingNodeBindings
{
}
