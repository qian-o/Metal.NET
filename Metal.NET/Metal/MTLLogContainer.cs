namespace Metal.NET;

public class MTLLogContainer(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLLogContainer Null => Create(0, false);
    public static MTLLogContainer Empty => Null;
}

file static class MTLLogContainerBindings
{
}
