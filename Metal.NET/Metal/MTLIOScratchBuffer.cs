namespace Metal.NET;

public readonly struct MTLIOScratchBuffer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLIOScratchBuffer value) => new(value.NativePtr);

    public MTLIOScratchBuffer Retain()
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

    public MTLBuffer Buffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIOScratchBufferBindings.Buffer));
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = "buffer";
}
