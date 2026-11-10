namespace Metal.NET;

public readonly struct MTLIOScratchBuffer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLIOScratchBuffer value) => new(value.NativePtr);

    public MTLIOScratchBuffer Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
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
