namespace Metal.NET;

public class MTLLogState(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogState>
{
    public static MTLLogState Null => Create(0, false);
    public static MTLLogState Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLLogStateBindings
{
}
