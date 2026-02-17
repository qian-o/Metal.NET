namespace Metal.NET;

public class MTLIOScratchBufferAllocator : IDisposable
{
    public MTLIOScratchBufferAllocator(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public MTLIOScratchBuffer NewScratchBuffer(uint minimumSize)
    {
        var result = new MTLIOScratchBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIOScratchBufferAllocatorSelector.NewScratchBuffer, (nint)minimumSize));

        return result;
    }

}

file class MTLIOScratchBufferAllocatorSelector
{
    public static readonly Selector NewScratchBuffer = Selector.Register("newScratchBuffer:");
}
