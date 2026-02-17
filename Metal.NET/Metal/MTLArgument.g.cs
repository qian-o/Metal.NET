namespace Metal.NET;

public class MTLArgument : IDisposable
{
    public MTLArgument(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLArgument()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLArgument value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArgument(nint value)
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

file class MTLArgumentSelector
{
}
