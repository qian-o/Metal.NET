namespace Metal.NET;

public class MTLIndirectCommandBufferExecutionRange : IDisposable
{
    public MTLIndirectCommandBufferExecutionRange(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIndirectCommandBufferExecutionRange()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIndirectCommandBufferExecutionRange value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectCommandBufferExecutionRange(nint value)
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

file class MTLIndirectCommandBufferExecutionRangeSelector
{
}
