namespace Metal.NET;

public class MTLCounterResultStatistic : IDisposable
{
    public MTLCounterResultStatistic(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLCounterResultStatistic()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCounterResultStatistic value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCounterResultStatistic(nint value)
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

file class MTLCounterResultStatisticSelector
{
}
