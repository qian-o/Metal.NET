namespace Metal.NET;

/// <summary>
/// Base class for all Objective-C native object wrappers.
/// Manages the native pointer lifetime with reference counting.
/// </summary>
public abstract class NativeObject : IDisposable
{
    private bool _disposed;

    protected NativeObject(nint nativePtr) : this(nativePtr, true)
    {
    }

    protected NativeObject(nint nativePtr, bool retainOnCreate)
    {
        NativePtr = nativePtr;

        if (nativePtr is not 0 && retainOnCreate)
        {
            ObjectiveCRuntime.Retain(nativePtr);
        }
    }

    ~NativeObject()
    {
        Dispose(false);
    }

    /// <summary>
    /// The underlying Objective-C pointer.
    /// </summary>
    public nint NativePtr { get; }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (NativePtr is not 0)
            {
                ObjectiveCRuntime.Release(NativePtr);
            }

            _disposed = true;
        }
    }
}
