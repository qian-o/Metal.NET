namespace Metal.NET;

public class MTLLogState(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogState>
{
    public static MTLLogState Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLLogState Null => Create(0, false);
    public static MTLLogState Empty => Null;
}

file static class MTLLogStateBindings
{
}
