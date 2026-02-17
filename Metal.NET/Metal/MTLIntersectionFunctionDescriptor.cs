namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor : IDisposable
{
    public MTLIntersectionFunctionDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIntersectionFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIntersectionFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIntersectionFunctionDescriptor(nint value)
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

file class MTLIntersectionFunctionDescriptorSelector
{
}
