namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingNode>
{
    public static MTLFunctionStitchingNode Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLFunctionStitchingNode Null => Create(0, false);
    public static MTLFunctionStitchingNode Empty => Null;
}

file static class MTLFunctionStitchingNodeBindings
{
}
