namespace Metal.NET;

public class MTLFunctionStitchingAttribute(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingAttribute>
{
    public static MTLFunctionStitchingAttribute Null => Create(0, false);
    public static MTLFunctionStitchingAttribute Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLFunctionStitchingAttributeBindings
{
}
