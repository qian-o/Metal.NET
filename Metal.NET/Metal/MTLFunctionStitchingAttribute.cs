namespace Metal.NET;

public class MTLFunctionStitchingAttribute(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingAttribute>
{
    public static MTLFunctionStitchingAttribute Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLFunctionStitchingAttribute Null => new(0, false);
}

file static class MTLFunctionStitchingAttributeBindings
{
}
