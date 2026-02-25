namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLIOScratchBufferAllocator>
{
    public static MTLIOScratchBufferAllocator Null { get; } = new(0, false);

    public static MTLIOScratchBufferAllocator Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);

        return new(nativePtr, true);
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = "newScratchBufferWithMinimumSize:";
}
