namespace Metal.NET;

public class MTLStageInRegionIndirectArguments : IDisposable
{
    public MTLStageInRegionIndirectArguments(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLStageInRegionIndirectArguments()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLStageInRegionIndirectArguments value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStageInRegionIndirectArguments(nint value)
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

file class MTLStageInRegionIndirectArgumentsSelector
{
}
