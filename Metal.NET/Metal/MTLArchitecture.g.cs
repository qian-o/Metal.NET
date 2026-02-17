namespace Metal.NET;

public class MTLArchitecture : IDisposable
{
    public MTLArchitecture(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLArchitecture()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLArchitecture value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArchitecture(nint value)
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

file class MTLArchitectureSelector
{
}
