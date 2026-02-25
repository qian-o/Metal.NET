namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Create(nint nativePtr) => new(nativePtr, true);

    public static MTLLogContainer CreateBorrowed(nint nativePtr) => new(nativePtr, false);
}

file static class MTLLogContainerBindings
{
}
