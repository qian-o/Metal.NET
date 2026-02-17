namespace Metal.NET;

public class MTLDepthStencilState : IDisposable
{
    public MTLDepthStencilState(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLDepthStencilState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDepthStencilState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDepthStencilState(nint value)
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

file class MTLDepthStencilStateSelector
{
}
