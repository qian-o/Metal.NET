namespace Metal.NET;

public class MTLAccelerationStructureInstanceDescriptor : IDisposable
{
    public MTLAccelerationStructureInstanceDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLAccelerationStructureInstanceDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureInstanceDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureInstanceDescriptor(nint value)
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

file class MTLAccelerationStructureInstanceDescriptorSelector
{
}
