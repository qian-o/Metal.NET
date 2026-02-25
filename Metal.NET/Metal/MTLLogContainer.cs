namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLLogContainer Null => new(0, false);
}

file static class MTLLogContainerBindings
{
}
