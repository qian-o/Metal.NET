namespace Metal.NET;

public class MTLIOScratchBufferAllocator : IDisposable
{
    public MTLIOScratchBufferAllocator(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
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

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        MTLIOScratchBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferAllocatorSelector.NewScratchBufferWithMinimumSize, minimumSize));

        return result;
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

file class MTLIOScratchBufferAllocatorSelector
{
    public static readonly Selector NewScratchBufferWithMinimumSize = Selector.Register("newScratchBufferWithMinimumSize:");
}
