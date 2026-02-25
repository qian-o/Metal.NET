namespace Metal.NET;

public class MTLLogState(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLLogState>
{
    public static MTLLogState Null { get; } = new(0, false);

    public static MTLLogState Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLLogStateBindings
{
}
