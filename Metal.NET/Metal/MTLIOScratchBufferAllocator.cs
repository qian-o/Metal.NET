namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLIOScratchBuffer? NewScratchBuffer(nuint minimumSize)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = "newScratchBufferWithMinimumSize:";
}
