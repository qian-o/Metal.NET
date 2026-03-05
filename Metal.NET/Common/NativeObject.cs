namespace Metal.NET;

public enum NativeObjectOwnership
{
    Borrowed,

    Owned,

    Managed
}

public interface INativeObject<TSelf> where TSelf : NativeObject, INativeObject<TSelf>
{
    static abstract TSelf Null { get; }

    static abstract TSelf New(nint nativePtr, NativeObjectOwnership ownership);
}

public abstract class NativeObject(nint nativePtr, NativeObjectOwnership ownership) : IDisposable
{
    private volatile uint disposed;

    ~NativeObject()
    {
        if (Ownership is NativeObjectOwnership.Managed)
        {
            Release();
        }
    }

    public nint NativePtr { get; } = nativePtr;

    public NativeObjectOwnership Ownership { get; } = ownership;

    public bool IsNull => NativePtr is 0;

    protected abstract void ReleaseNative();

    public void Dispose()
    {
        if (IsNull)
        {
            return;
        }

        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (Interlocked.Exchange(ref disposed, 1) is not 0)
        {
            return;
        }

        if (Ownership is not NativeObjectOwnership.Borrowed)
        {
            ReleaseNative();
        }
    }
}
