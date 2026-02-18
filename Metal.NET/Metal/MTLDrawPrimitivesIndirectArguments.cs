namespace Metal.NET;

public class MTLDrawPrimitivesIndirectArguments : IDisposable
{
    public MTLDrawPrimitivesIndirectArguments(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLDrawPrimitivesIndirectArguments()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDrawPrimitivesIndirectArguments value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDrawPrimitivesIndirectArguments(nint value)
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

file class MTLDrawPrimitivesIndirectArgumentsSelector
{
}
