namespace Metal.NET;

public class MTLAccelerationStructureSizes : IDisposable
{
    public MTLAccelerationStructureSizes(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLAccelerationStructureSizes()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureSizes value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureSizes(nint value)
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

file class MTLAccelerationStructureSizesSelector
{
}
