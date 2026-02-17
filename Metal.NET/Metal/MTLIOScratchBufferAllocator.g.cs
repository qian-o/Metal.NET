namespace Metal.NET;

file class MTLIOScratchBufferAllocatorSelector
{
    public static readonly Selector NewScratchBuffer_ = Selector.Register("newScratchBuffer:");
}

public class MTLIOScratchBufferAllocator : IDisposable
{
    public MTLIOScratchBufferAllocator(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIOScratchBufferAllocator()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIOScratchBufferAllocator value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOScratchBufferAllocator(nint value)
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

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        var result = new MTLIOScratchBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIOScratchBufferAllocatorSelector.NewScratchBuffer_, (nint)minimumSize));

        return result;
    }

}
