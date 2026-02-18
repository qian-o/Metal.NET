namespace Metal.NET;

public partial class MTLIOScratchBuffer : NativeObject
{
    public MTLIOScratchBuffer(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferSelector.Buffer);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLIOScratchBufferSelector
{
    public static readonly Selector Buffer = Selector.Register("buffer");
}
