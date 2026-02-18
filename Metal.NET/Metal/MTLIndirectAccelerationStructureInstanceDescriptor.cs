namespace Metal.NET;

public class MTLIndirectAccelerationStructureInstanceDescriptor : IDisposable
{
    public MTLIndirectAccelerationStructureInstanceDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIndirectAccelerationStructureInstanceDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIndirectAccelerationStructureInstanceDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectAccelerationStructureInstanceDescriptor(nint value)
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

file class MTLIndirectAccelerationStructureInstanceDescriptorSelector
{
}
