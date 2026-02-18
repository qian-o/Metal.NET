namespace Metal.NET;

public class MTLIntersectionFunctionBufferArguments : IDisposable
{
    public MTLIntersectionFunctionBufferArguments(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIntersectionFunctionBufferArguments()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIntersectionFunctionBufferArguments value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIntersectionFunctionBufferArguments(nint value)
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

file class MTLIntersectionFunctionBufferArgumentsSelector
{
}
