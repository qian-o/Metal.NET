namespace Metal.NET;

public class MTLFunctionLogDebugLocation : IDisposable
{
    public MTLFunctionLogDebugLocation(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionLogDebugLocation()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionLogDebugLocation value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionLogDebugLocation(nint value)
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

file class MTLFunctionLogDebugLocationSelector
{
}
