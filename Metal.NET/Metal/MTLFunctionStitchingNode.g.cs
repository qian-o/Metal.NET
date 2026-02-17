namespace Metal.NET;

file class MTLFunctionStitchingNodeSelector
{
}

public class MTLFunctionStitchingNode : IDisposable
{
    public MTLFunctionStitchingNode(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFunctionStitchingNode()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionStitchingNode value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingNode(nint value)
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
