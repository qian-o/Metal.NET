namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLIOScratchBuffer? NewScratchBuffer(nuint minimumSize)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBuffer, minimumSize);

        return nativePtr is not 0 ? new(nativePtr, true) : null;
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBuffer = "newScratchBufferWithMinimumSize:";
}
