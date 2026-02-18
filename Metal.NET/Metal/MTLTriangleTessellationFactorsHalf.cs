namespace Metal.NET;

public class MTLTriangleTessellationFactorsHalf : IDisposable
{
    public MTLTriangleTessellationFactorsHalf(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLTriangleTessellationFactorsHalf()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTriangleTessellationFactorsHalf value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTriangleTessellationFactorsHalf(nint value)
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

file class MTLTriangleTessellationFactorsHalfSelector
{
}
