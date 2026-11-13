namespace Metal.NET;

public readonly struct MTLIOScratchBufferAllocator(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLIOScratchBufferAllocator value) => new(value.NativePtr);

    public MTLIOScratchBufferAllocator Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLIOScratchBuffer MakeScratchBuffer(nuint minimumSize)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOScratchBufferAllocatorBindings.NewScratchBufferWithMinimumSize, minimumSize);

        return new(nativePtr);
    }
}

file static class MTLIOScratchBufferAllocatorBindings
{
    public static readonly Selector NewScratchBufferWithMinimumSize = "newScratchBufferWithMinimumSize:";
}
