namespace Metal.NET;

public readonly struct MTLIOScratchBufferAllocator(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLIOScratchBuffer? NewScratchBuffer(nuint minimumSize)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);
        return ptr is not 0 ? new MTLIOScratchBuffer(ptr) : default;
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = Selector.Register("newScratchBufferWithMinimumSize:");
}
