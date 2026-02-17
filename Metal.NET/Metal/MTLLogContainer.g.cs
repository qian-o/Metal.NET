namespace Metal.NET;

public class MTLLogContainer : IDisposable
{
    public MTLLogContainer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLLogContainer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLLogContainer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLogContainer(nint value)
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

file class MTLLogContainerSelector
{
}
