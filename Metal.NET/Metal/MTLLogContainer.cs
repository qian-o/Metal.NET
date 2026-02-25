namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Null => Create(0, false);
    public static MTLLogContainer Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLLogContainerBindings
{
}
