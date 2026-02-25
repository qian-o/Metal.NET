namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Create(nint nativePtr) => new(nativePtr);

    public static MTLLogContainer CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);
}

file static class MTLLogContainerBindings
{
}
