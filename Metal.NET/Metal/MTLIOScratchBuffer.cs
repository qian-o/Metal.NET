namespace Metal.NET;

public readonly struct MTLIOScratchBuffer(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferBindings.Buffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = Selector.Register("buffer");
}
