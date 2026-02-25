namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFunctionStitchingNode>
{
    public static MTLFunctionStitchingNode Null { get; } = new(0, false);

    public static MTLFunctionStitchingNode Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLFunctionStitchingNodeBindings
{
}
