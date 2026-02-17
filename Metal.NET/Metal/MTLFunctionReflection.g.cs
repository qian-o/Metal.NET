namespace Metal.NET;

file class MTLFunctionReflectionSelector
{
}

public class MTLFunctionReflection : IDisposable
{
    public MTLFunctionReflection(nint nativePtr)
    {
        NativePtr = nativePtr;
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
