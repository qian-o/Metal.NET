namespace Metal.NET;

public class MTLFunctionStitchingAttribute(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLFunctionStitchingAttribute>
{
    public static MTLFunctionStitchingAttribute Create(nint nativePtr) => new(nativePtr);
}

file static class MTLFunctionStitchingAttributeBindings
{
}
