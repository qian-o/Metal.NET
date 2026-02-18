namespace Metal.NET;

public partial class MTLIOScratchBufferAllocator : NativeObject
{
    public MTLIOScratchBufferAllocator(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLIOScratchBuffer? NewScratchBuffer(nuint minimumSize)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorSelector.NewScratchBuffer, minimumSize);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLIOScratchBufferAllocatorSelector
{
    public static readonly Selector NewScratchBuffer = Selector.Register("newScratchBufferWithMinimumSize:");
}
