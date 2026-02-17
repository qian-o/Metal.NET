namespace Metal.NET;

file class MTLFunctionLogSelector
{
}

public class MTLFunctionLog : IDisposable
{
    public MTLFunctionLog(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFunctionLog()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionLog value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionLog(nint value)
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
