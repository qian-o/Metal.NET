namespace Metal.NET;

public class MTLFunctionStitchingAttribute(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingAttribute>
{
    public static MTLFunctionStitchingAttribute Create(nint nativePtr) => new(nativePtr, true);

    public static MTLFunctionStitchingAttribute CreateBorrowed(nint nativePtr) => new(nativePtr, false);
}

file static class MTLFunctionStitchingAttributeBindings
{
}
