namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLIOScratchBufferAllocator>
{
    #region INativeObject
    public static MTLIOScratchBufferAllocator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLIOScratchBufferAllocator New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = "newScratchBufferWithMinimumSize:";
}
