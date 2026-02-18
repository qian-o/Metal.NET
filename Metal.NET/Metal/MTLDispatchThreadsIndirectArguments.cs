namespace Metal.NET;

public class MTLDispatchThreadsIndirectArguments : IDisposable
{
    public MTLDispatchThreadsIndirectArguments(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLDispatchThreadsIndirectArguments()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDispatchThreadsIndirectArguments value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDispatchThreadsIndirectArguments(nint value)
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

file class MTLDispatchThreadsIndirectArgumentsSelector
{
}
