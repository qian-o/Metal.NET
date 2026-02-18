namespace Metal.NET;

public class MTLVisibleFunctionTable : IDisposable
{
    public MTLVisibleFunctionTable(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLVisibleFunctionTable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLVisibleFunctionTableSelector.GpuResourceID);
    }

    public static implicit operator nint(MTLVisibleFunctionTable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVisibleFunctionTable(nint value)
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

file class MTLVisibleFunctionTableSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");
}
