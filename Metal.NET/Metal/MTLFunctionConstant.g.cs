namespace Metal.NET;

public class MTLFunctionConstant : IDisposable
{
    public MTLFunctionConstant(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionConstant()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionConstant value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionConstant(nint value)
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

file class MTLFunctionConstantSelector
{
}
