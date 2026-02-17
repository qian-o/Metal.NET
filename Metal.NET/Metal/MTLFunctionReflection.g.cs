namespace Metal.NET;

public class MTLFunctionReflection : IDisposable
{
    public MTLFunctionReflection(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionReflection value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionReflection(nint value)
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

file class MTLFunctionReflectionSelector
{
}
