namespace Metal.NET;

/// <summary>
/// Factory interface for creating managed wrappers from native Objective-C pointers.
/// </summary>
/// <typeparam name="TSelf">The concrete wrapper type.</typeparam>
public interface INativeObject<TSelf> where TSelf : NativeObject, INativeObject<TSelf>
{
    static abstract TSelf Create(nint nativePtr);

    static abstract TSelf CreateBorrowed(nint nativePtr);
}

/// <summary>
/// Abstract base class for managed wrappers around Objective-C objects.
/// Each instance holds a raw pointer (<see cref="NativePtr"/>) to an Objective-C object
/// and decrements its reference count by sending <c>release</c> on <see cref="Dispose"/>.
/// </summary>
/// <param name="nativePtr">A non-zero Objective-C object pointer (<c>id</c>).</param>
/// <param name="ownsReference">
/// When <see langword="true"/>, <see cref="Dispose()"/> sends <c>release</c> to the
/// native object. When <see langword="false"/>, the pointer is treated as borrowed and will not be released.
/// </param>
public abstract class NativeObject(nint nativePtr, bool ownsReference) : IDisposable
{
    private volatile uint disposed;

    ~NativeObject()
    {
        Release();
    }

    /// <summary>
    /// The raw pointer (<c>id</c>) to the wrapped Objective-C object.
    /// </summary>
    public nint NativePtr { get; } = nativePtr;

    /// <summary>
    /// Returns <see langword="true"/> when this instance owns the native reference
    /// and will send <c>release</c> on disposal.
    /// </summary>
    public bool OwnsReference { get; } = ownsReference;

    /// <summary>
    /// Returns <see langword="true"/> when the native pointer is zero (nil).
    /// </summary>
    public bool IsNull => NativePtr is 0;

    /// <summary>
    /// Sends <c>release</c> to the underlying Objective-C object (if owned),
    /// decrementing its reference count, and suppresses the finalizer.
    /// </summary>
    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Invokes an Objective-C property getter via <c>objc_msgSend</c> and returns a managed wrapper.
    /// The wrapper is lazily created and cached in <paramref name="field"/>;
    /// it is re-created only when the returned native pointer differs from the cached one.
    /// The returned wrapper is <em>borrowed</em> (it does not own the reference).
    /// </summary>
    /// <param name="field">Backing field that caches the managed wrapper between calls.</param>
    /// <param name="selector">The Objective-C getter selector to invoke.</param>
    /// <returns>A cached wrapper for the native object.</returns>
    protected T GetProperty<T>(ref T? field, Selector selector) where T : NativeObject, INativeObject<T>
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, selector);

        if (field is null || field.NativePtr != nativePtr)
        {
            field = T.CreateBorrowed(nativePtr);
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

        GetProperty(ref field, selector);
    }

    /// <summary>
    /// Core dispose logic. Guarantees single-release via <see cref="Interlocked.Exchange"/>.
    /// </summary>
    private void Release()
    {
        if (Interlocked.Exchange(ref disposed, 1) is not 0)
        {
            return;
        }

        if (OwnsReference)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}
