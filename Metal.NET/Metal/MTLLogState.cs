namespace Metal.NET;

public class MTLLogState(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogState>
{
    public static MTLLogState Create(nint nativePtr) => new(nativePtr, true);

    public static MTLLogState CreateBorrowed(nint nativePtr) => new(nativePtr, false);
}

file static class MTLLogStateBindings
{
}
