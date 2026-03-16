namespace Metal.NET;

/// <summary>A protocol your app implements to provide scratch memory to an input/output command queue.</summary>
public class MTLIOScratchBufferAllocator(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOScratchBufferAllocator>
{
    #region INativeObject
    public static new MTLIOScratchBufferAllocator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOScratchBufferAllocator New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Providing scratch memory to a queue - Methods

    /// <summary>Creates a scratch memory buffer for an input/output command queue.</summary>
    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = "newScratchBufferWithMinimumSize:";
}
