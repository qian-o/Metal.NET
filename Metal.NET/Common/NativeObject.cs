namespace Metal.NET;

/// <summary>
/// Factory interface for creating managed wrappers from native Objective-C pointers.
/// </summary>
/// <typeparam name="TSelf">The concrete wrapper type.</typeparam>
public interface INativeObject<TSelf> where TSelf : NativeObject, INativeObject<TSelf>
{
    static abstract TSelf Create(nint nativePtr);
}

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
    /// Returns <see langword="true"/> when the native pointer is zero (nil).
    /// </summary>
    public bool IsNull => NativePtr is 0;

    /// <summary>
    /// Sends <c>release</c> to the underlying Objective-C object, decrementing its reference count.
    /// </summary>
    public void Dispose()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, NativeObjectBindings.Release);
        }

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Invokes an Objective-C property getter via <c>objc_msgSend</c> and returns a managed wrapper.
    /// The wrapper is lazily created and cached in <paramref name="field"/>;
    /// it is re-created only when the returned native pointer differs from the cached one.
    /// </summary>
    /// <param name="field">Backing field that caches the managed wrapper between calls.</param>
    /// <param name="selector">The Objective-C getter selector to invoke.</param>
    /// <returns>A cached wrapper for the native object.</returns>
    protected T GetProperty<T>(ref T? field, Selector selector) where T : NativeObject, INativeObject<T>
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, selector);

        if (field is null || field.NativePtr != nativePtr)
        {
            field = T.Create(nativePtr);
        }

        return field;
    }

    /// <summary>
    /// Invokes an Objective-C property setter via <c>objc_msgSend</c> and updates the cached wrapper.
    /// </summary>
    /// <param name="field">Backing field that caches the managed wrapper between calls.</param>
    /// <param name="selector">The Objective-C setter selector to invoke.</param>
    /// <param name="value">The new value.</param>
    protected void SetProperty<T>(ref T? field, Selector selector, T value) where T : NativeObject, INativeObject<T>
    {
        ObjectiveCRuntime.MsgSend(NativePtr, selector, value.NativePtr);

        field = value;
    }
}

file static class NativeObjectBindings
{
    public static readonly Selector Release = "release";
}
