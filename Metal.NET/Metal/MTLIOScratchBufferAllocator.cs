namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLIOScratchBuffer? NewScratchBuffer(nuint minimumSize)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);
        return ptr is not 0 ? new MTLIOScratchBuffer(ptr) : null;
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = "newScratchBufferWithMinimumSize:";
}
