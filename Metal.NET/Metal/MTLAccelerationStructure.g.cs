namespace Metal.NET;

public class MTLAccelerationStructure : IDisposable
{
    public MTLAccelerationStructure(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructure()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructure value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructure(nint value)
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

file class MTLAccelerationStructureSelector
{
}
