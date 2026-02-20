namespace Metal.NET;

/// <summary>
/// Abstract base class for managed wrappers around Objective-C objects.
/// Each instance holds a raw pointer (<see cref="NativePtr"/>) to an Objective-C object
/// and decrements its reference count by sending <c>release</c> on <see cref="Dispose"/>.
/// </summary>
/// <param name="nativePtr">A non-zero Objective-C object pointer (<c>id</c>).</param>
public abstract class NativeObject(nint nativePtr) : IDisposable
{
    /// <summary>
    /// The raw pointer (<c>id</c>) to the wrapped Objective-C object.
    /// </summary>
    public nint NativePtr { get; } = nativePtr;

    /// <summary>
    /// Sends <c>release</c> to the underlying Objective-C object, decrementing its reference count.
    /// </summary>
    public void Dispose()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, NativeObjectBindings.Release);

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Invokes an Objective-C property getter via <c>objc_msgSend</c> and returns a managed wrapper.
    /// The wrapper is lazily created and cached in <paramref name="field"/>;
    /// it is re-created only when the returned native pointer differs from the cached one.
    /// </summary>
    /// <param name="field">Backing field that caches the managed wrapper between calls.</param>
    /// <param name="selector">The Objective-C getter selector to invoke.</param>
    /// <returns>A cached wrapper for the native object, or <see langword="null"/> if the native pointer is zero.</returns>
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
    /// Invokes an Objective-C property setter via <c>objc_msgSend</c> and updates the cached wrapper.
    /// </summary>
    /// <param name="field">Backing field that caches the managed wrapper between calls.</param>
    /// <param name="selector">The Objective-C setter selector to invoke.</param>
    /// <param name="value">The new value, or <see langword="null"/> to pass a nil pointer.</param>
    protected void SetProperty<T>(ref T? field, Selector selector, T? value) where T : NativeObject
    {
        ObjectiveCRuntime.MsgSend(NativePtr, selector, value?.NativePtr ?? 0);

        field = value;
    }
}

file static class NativeObjectBindings
{
    public static readonly Selector Release = "release";
}
