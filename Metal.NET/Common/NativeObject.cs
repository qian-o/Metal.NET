namespace Metal.NET;

/// <summary>
/// Base class for all Objective-C native object wrappers.
/// The caller must ensure <paramref name="nativePtr"/> carries a +1 reference;
/// the wrapper releases it on dispose.
/// </summary>
/// <param name="nativePtr">The raw Objective-C pointer.</param>
public abstract class NativeObject(nint nativePtr) : IDisposable
{
    private bool released;

    /// <summary>
    /// The underlying Objective-C pointer.
    /// </summary>
    public nint NativePtr { get; } = nativePtr;

    public void Dispose()
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
            field = (T)Activator.CreateInstance(typeof(T), nativePtr)!;
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
}
