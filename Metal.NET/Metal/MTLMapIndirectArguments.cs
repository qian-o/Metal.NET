namespace Metal.NET;

public class MTLMapIndirectArguments : IDisposable
{
    public MTLMapIndirectArguments(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLMapIndirectArguments()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLMapIndirectArguments value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLMapIndirectArguments(nint value)
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

file class MTLMapIndirectArgumentsSelector
{
}
