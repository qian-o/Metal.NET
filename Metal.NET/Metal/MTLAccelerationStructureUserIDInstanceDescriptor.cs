namespace Metal.NET;

public class MTLAccelerationStructureUserIDInstanceDescriptor : IDisposable
{
    public MTLAccelerationStructureUserIDInstanceDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLAccelerationStructureUserIDInstanceDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureUserIDInstanceDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureUserIDInstanceDescriptor(nint value)
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

file class MTLAccelerationStructureUserIDInstanceDescriptorSelector
{
}
