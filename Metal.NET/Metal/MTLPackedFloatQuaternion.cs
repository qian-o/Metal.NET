namespace Metal.NET;

public class MTLPackedFloatQuaternion : IDisposable
{
    public MTLPackedFloatQuaternion(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLPackedFloatQuaternion()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLPackedFloatQuaternion value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPackedFloatQuaternion(nint value)
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

file class MTLPackedFloatQuaternionSelector
{
}
