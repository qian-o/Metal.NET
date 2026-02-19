namespace Metal.NET;

/// <summary>
/// Base class for all Objective-C native object wrappers.
/// </summary>
/// <param name="nativePtr">The raw Objective-C pointer.</param>
/// <param name="owned">
/// <c>true</c> to release on dispose; <c>false</c> for unowned views.
/// </param>
public abstract class NativeObject(nint nativePtr, bool owned) : IDisposable
{
    private bool released;

    ~NativeObject()
    {
        Release();
    }

    /// <summary>
    /// The underlying Objective-C pointer.
    /// </summary>
    public nint NativePtr { get; } = nativePtr;

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Gets a cached nullable property as an unowned view.
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
            field = (T)Activator.CreateInstance(typeof(T), nativePtr, false)!;
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

        if (owned && NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }

        released = true;
    }
}
