namespace Metal.NET;

public class MTLLogState(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogState>
{
    public static MTLLogState Create(nint nativePtr) => new(nativePtr);

    public static MTLLogState CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);
}

file static class MTLLogStateBindings
{
}
