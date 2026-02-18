namespace Metal.NET;

public class MTLIOScratchBufferAllocator(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLIOScratchBuffer? NewScratchBuffer(nuint minimumSize)
    {
        return GetNullableObject<MTLIOScratchBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorSelector.NewScratchBuffer, minimumSize));
    }
}

file static class MTLIOScratchBufferAllocatorSelector
{
    public static readonly Selector NewScratchBuffer = Selector.Register("newScratchBufferWithMinimumSize:");
}
