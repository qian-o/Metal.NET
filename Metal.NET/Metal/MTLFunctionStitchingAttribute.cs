namespace Metal.NET;

public class MTLFunctionStitchingAttribute(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingAttribute>
{
    public static MTLFunctionStitchingAttribute Create(nint nativePtr) => new(nativePtr);

    public static MTLFunctionStitchingAttribute CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);
}

file static class MTLFunctionStitchingAttributeBindings
{
}
