namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Null { get; } = new(0, false);

    public static MTLLogContainer Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLLogContainerBindings
{
}
