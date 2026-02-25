namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Null { get; } = new(0, false, false);

    public static MTLLogContainer Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);
}

file static class MTLLogContainerBindings
{
}
