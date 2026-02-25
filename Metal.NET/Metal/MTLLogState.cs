namespace Metal.NET;

public class MTLLogState(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogState>
{
    public static MTLLogState Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLLogState Null => new(0, false);
}

file static class MTLLogStateBindings
{
}
