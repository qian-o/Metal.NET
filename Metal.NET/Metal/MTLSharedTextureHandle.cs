namespace Metal.NET;

public readonly struct MTLSharedTextureHandle(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLSharedTextureHandle value) => new(value.NativePtr);

    public MTLSharedTextureHandle Retain()
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

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLSharedTextureHandleBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLSharedTextureHandleBindings.Label));
    }
}

file static class MTLSharedTextureHandleBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";
}
