namespace Metal.NET;

public class MTLLogContainer(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLLogContainer>
{
    public static MTLLogContainer Create(nint nativePtr) => new(nativePtr);
}

file static class MTLLogContainerBindings
{
}
