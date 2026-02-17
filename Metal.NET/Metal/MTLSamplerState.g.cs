namespace Metal.NET;

file class MTLSamplerStateSelector
{
}

public class MTLSamplerState : IDisposable
{
    public MTLSamplerState(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLSamplerState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLSamplerState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSamplerState(nint value)
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
