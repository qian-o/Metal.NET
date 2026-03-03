namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLIOScratchBufferAllocator>
{
    public static MTLIOScratchBufferAllocator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLIOScratchBufferAllocator Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = "newScratchBufferWithMinimumSize:";
}
