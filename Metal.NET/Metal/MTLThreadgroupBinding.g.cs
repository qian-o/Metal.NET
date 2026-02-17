namespace Metal.NET;

file class MTLThreadgroupBindingSelector
{
}

public class MTLThreadgroupBinding : IDisposable
{
    public MTLThreadgroupBinding(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLThreadgroupBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLThreadgroupBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLThreadgroupBinding(nint value)
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
