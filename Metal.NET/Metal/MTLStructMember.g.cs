namespace Metal.NET;

public class MTLStructMember : IDisposable
{
    public MTLStructMember(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLStructMember()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLStructMember value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStructMember(nint value)
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

file class MTLStructMemberSelector
{
}
