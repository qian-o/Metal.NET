namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLIOScratchBufferAllocator>
{
    public static MTLIOScratchBufferAllocator Create(nint nativePtr) => new(nativePtr);

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
