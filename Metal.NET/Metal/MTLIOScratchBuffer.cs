namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLIOScratchBuffer>
{
    public static MTLIOScratchBuffer Null { get; } = new(0, false);

    public static MTLIOScratchBuffer Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLIOScratchBufferBindings.Buffer);
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = "buffer";
}
