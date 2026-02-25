namespace Metal.NET;

public class MTLFunctionStitchingNode(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFunctionStitchingNode>
{
    public static MTLFunctionStitchingNode Null { get; } = new(0, false, false);

    public static MTLFunctionStitchingNode Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);
}

file static class MTLFunctionStitchingNodeBindings
{
}
