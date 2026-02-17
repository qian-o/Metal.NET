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

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableSelector.SetFunctionIndex, function.NativePtr, index);
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

    public static readonly Selector SetFunctionIndex = Selector.Register("setFunction:index:");
}
