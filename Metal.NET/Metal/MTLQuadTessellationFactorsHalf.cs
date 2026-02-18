namespace Metal.NET;

public class MTLQuadTessellationFactorsHalf : IDisposable
{
    public MTLQuadTessellationFactorsHalf(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLQuadTessellationFactorsHalf()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLQuadTessellationFactorsHalf value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLQuadTessellationFactorsHalf(nint value)
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

file class MTLQuadTessellationFactorsHalfSelector
{
}
