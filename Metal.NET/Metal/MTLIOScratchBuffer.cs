namespace Metal.NET;

/// <summary>A protocol your app implements that wraps a Metal buffer instance to serve as scratch memory for an input/output command queue.</summary>
public class MTLIOScratchBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOScratchBuffer>
{
    #region INativeObject
    public static new MTLIOScratchBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOScratchBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Wrapping a buffer - Properties

    /// <summary>A Metal buffer that serves as scratch memory for an input/output command queue.</summary>
    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLIOScratchBufferBindings.Buffer);
    }
    #endregion
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = "buffer";
}
