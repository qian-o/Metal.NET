namespace Metal.NET;

/// <summary>
/// Base class for all Objective-C native object wrappers.
/// Every wrapper holds a +1 reference and releases it on dispose.
/// </summary>
public abstract class NativeObject : IDisposable
{
    private bool released;

    /// <summary>
    /// <param name="nativePtr">The raw Objective-C pointer.</param>
    /// <param name="retain">
    /// <c>true</c> to retain a +0 reference (non-ownership returns);
    /// <c>false</c> when the caller already owns a +1 reference (new/alloc/copy/init).
    /// </param>
    /// </summary>
    protected NativeObject(nint nativePtr, bool retain)
    {
        NativePtr = nativePtr;

        if (retain)
        {
            ObjectiveCRuntime.Retain(nativePtr);
        }
    }

    ~NativeObject()
    {
        Release();
    }

    /// <summary>
    /// The underlying Objective-C pointer.
    /// </summary>
    public nint NativePtr { get; }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Gets a cached nullable property. Creates or updates the wrapper only when the native pointer changes.
    /// </summary>
    protected T? GetProperty<T>(ref T? field, Selector selector) where T : NativeObject
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, selector);

        if (nativePtr is 0)
        {
            return field = null;
        }

        if (field is null || field.NativePtr != nativePtr)
        {
            field = (T)Activator.CreateInstance(typeof(T), nativePtr, true)!;
        }

        return field;
    }

    /// <summary>
    /// Sets a nullable property and updates the cached wrapper.
    /// </summary>
    protected void SetProperty<T>(ref T? field, Selector selector, T? value) where T : NativeObject
    {
        ObjectiveCRuntime.MsgSend(NativePtr, selector, value?.NativePtr ?? 0);

        field = value;
    }

    private void Release()
    {
        if (released)
        {
            return;
        }

        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }

        released = true;
    }
}
