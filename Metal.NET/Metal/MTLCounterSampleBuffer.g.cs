namespace Metal.NET;

public class MTLCounterSampleBuffer : IDisposable
{
    public MTLCounterSampleBuffer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCounterSampleBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCounterSampleBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCounterSampleBuffer(nint value)
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

}

file class MTLCounterSampleBufferSelector
{
}
