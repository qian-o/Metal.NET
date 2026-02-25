namespace Metal.NET;

public class MTLLogState(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLLogState>
{
    public static MTLLogState Null { get; } = new(0, false, false);

    public static MTLLogState Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);
}

file static class MTLLogStateBindings
{
}
