namespace Metal.NET;

public class MTLIOScratchBuffer : IDisposable
{
    public MTLIOScratchBuffer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLIOScratchBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIOScratchBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOScratchBuffer(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public MTLBuffer Buffer
    {
        get => new MTLBuffer(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferSelector.Buffer));
    }

}

file class MTLIOScratchBufferSelector
{
    public static readonly Selector Buffer = Selector.Register("buffer");
}
