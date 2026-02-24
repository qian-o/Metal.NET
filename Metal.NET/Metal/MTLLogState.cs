namespace Metal.NET;

public class MTLLogState(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLLogState>
{
    public static MTLLogState Create(nint nativePtr) => new(nativePtr);
}

file static class MTLLogStateBindings
{
}
