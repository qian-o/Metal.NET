namespace Metal.NET;

file class MTLFunctionHandleSelector
{
}

public class MTLFunctionHandle : IDisposable
{
    public MTLFunctionHandle(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFunctionHandle()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionHandle value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionHandle(nint value)
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
