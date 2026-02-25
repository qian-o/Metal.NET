namespace Metal.NET;

public class MTLFunctionStitchingAttribute(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFunctionStitchingAttribute>
{
    public static MTLFunctionStitchingAttribute Null { get; } = new(0, false);

    public static MTLFunctionStitchingAttribute Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLFunctionStitchingAttributeBindings
{
}
