namespace Metal.NET;

public class MTLDrawPatchIndirectArguments : IDisposable
{
    public MTLDrawPatchIndirectArguments(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLDrawPatchIndirectArguments()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDrawPatchIndirectArguments value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDrawPatchIndirectArguments(nint value)
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

file class MTLDrawPatchIndirectArgumentsSelector
{
}
