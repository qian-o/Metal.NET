namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLIOScratchBufferAllocator>
{
    public static MTLIOScratchBufferAllocator Create(nint nativePtr) => new(nativePtr);

    public static MTLIOScratchBufferAllocator CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);

        return new(nativePtr);
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = "newScratchBufferWithMinimumSize:";
}
