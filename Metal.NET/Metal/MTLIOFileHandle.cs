namespace Metal.NET;

public class MTLIOFileHandle : IDisposable
{
    public MTLIOFileHandle(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIOFileHandle()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOFileHandleSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOFileHandleSelector.SetLabel, value.NativePtr);
    }

    public static implicit operator nint(MTLIOFileHandle value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOFileHandle(nint value)
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

file class MTLIOFileHandleSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
