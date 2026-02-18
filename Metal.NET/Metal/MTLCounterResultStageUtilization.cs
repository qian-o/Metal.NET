namespace Metal.NET;

public class MTLCounterResultStageUtilization : IDisposable
{
    public MTLCounterResultStageUtilization(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLCounterResultStageUtilization()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCounterResultStageUtilization value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCounterResultStageUtilization(nint value)
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

file class MTLCounterResultStageUtilizationSelector
{
}
