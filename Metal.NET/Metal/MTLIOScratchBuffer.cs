namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLBuffer? Buffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferSelector.Buffer));
    }
}

file static class MTLIOScratchBufferSelector
{
    public static readonly Selector Buffer = Selector.Register("buffer");
}
