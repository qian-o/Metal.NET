namespace Metal.NET;

public class MTLDrawIndexedPrimitivesIndirectArguments : IDisposable
{
    public MTLDrawIndexedPrimitivesIndirectArguments(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLDrawIndexedPrimitivesIndirectArguments()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDrawIndexedPrimitivesIndirectArguments value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDrawIndexedPrimitivesIndirectArguments(nint value)
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

file class MTLDrawIndexedPrimitivesIndirectArgumentsSelector
{
}
