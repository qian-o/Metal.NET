namespace Metal.NET;

public class MTLVisibleFunctionTable : IDisposable
{
    public MTLVisibleFunctionTable(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLVisibleFunctionTable()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void SetFunction(MTLFunctionHandle function, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableSelector.SetFunctionIndex, function.NativePtr, (nint)index);
    }

}

file class MTLVisibleFunctionTableSelector
{
    public static readonly Selector SetFunctionIndex = Selector.Register("setFunction:index:");
}
