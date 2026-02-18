namespace Metal.NET;

public class MTLIndirectAccelerationStructureMotionInstanceDescriptor : IDisposable
{
    public MTLIndirectAccelerationStructureMotionInstanceDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIndirectAccelerationStructureMotionInstanceDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIndirectAccelerationStructureMotionInstanceDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectAccelerationStructureMotionInstanceDescriptor(nint value)
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

file class MTLIndirectAccelerationStructureMotionInstanceDescriptorSelector
{
}
