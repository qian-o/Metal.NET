namespace Metal.NET;

public class MTLSharedTextureHandle : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedTextureHandle");

    public MTLSharedTextureHandle(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLSharedTextureHandle() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLSharedTextureHandle()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedTextureHandleSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedTextureHandleSelector.Label));
    }

    public static implicit operator nint(MTLSharedTextureHandle value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSharedTextureHandle(nint value)
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

file class MTLSharedTextureHandleSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");
}
