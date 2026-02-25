namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLIOScratchBuffer>
{
    public static MTLIOScratchBuffer Create(nint nativePtr) => new(nativePtr);

    public static MTLIOScratchBuffer CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLIOScratchBufferBindings.Buffer);
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = "buffer";
}
