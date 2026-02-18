namespace Metal.NET;

public class MTLDispatchThreadgroupsIndirectArguments : IDisposable
{
    public MTLDispatchThreadgroupsIndirectArguments(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLDispatchThreadgroupsIndirectArguments()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDispatchThreadgroupsIndirectArguments value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDispatchThreadgroupsIndirectArguments(nint value)
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

file class MTLDispatchThreadgroupsIndirectArgumentsSelector
{
}
