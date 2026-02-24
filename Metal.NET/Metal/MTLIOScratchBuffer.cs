namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLIOScratchBuffer>
{
    public static MTLIOScratchBuffer Create(nint nativePtr) => new(nativePtr);

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLIOScratchBufferBindings.Buffer);
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = "buffer";
}
