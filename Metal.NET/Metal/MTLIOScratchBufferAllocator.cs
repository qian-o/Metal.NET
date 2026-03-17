namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOScratchBufferAllocator>
{
    #region INativeObject
    public static new MTLIOScratchBufferAllocator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOScratchBufferAllocator New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIOScratchBuffer NewScratchBufferWithMinimumSize(nuint minimumSize)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBufferWithMinimumSize, minimumSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        return NewScratchBufferWithMinimumSize(minimumSize);
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBufferWithMinimumSize = "newScratchBufferWithMinimumSize:";
}
