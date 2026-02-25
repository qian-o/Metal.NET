namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLIOScratchBuffer>
{
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
