namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLIOScratchBuffer>
{
    #region INativeObject
    public static MTLIOScratchBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLIOScratchBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLIOScratchBufferBindings.Buffer);
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = "buffer";
}
