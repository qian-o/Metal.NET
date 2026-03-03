namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLIOScratchBuffer>
{
    public static MTLIOScratchBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLIOScratchBuffer Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLIOScratchBufferBindings.Buffer);
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = "buffer";
}
