namespace Metal.NET;

/// <summary>
/// Factory interface for creating managed wrappers from native Objective-C pointers.
/// </summary>
/// <typeparam name="TSelf">The concrete wrapper type.</typeparam>
public interface INativeObject<TSelf> where TSelf : NativeObject, INativeObject<TSelf>
{
    /// <summary>
    /// Creates a managed wrapper around the given native pointer.
    /// </summary>
    static abstract TSelf Create(nint nativePtr, bool ownsReference);
}

/// <summary>
/// Abstract base class for managed wrappers around Objective-C objects.
/// Holds a native pointer and, when the instance owns the reference,
/// sends <c>release</c> exactly once — either via <see cref="Dispose()"/>
/// or via the finalizer.
/// </summary>
/// <param name="nativePtr">The Objective-C object pointer (<c>id</c>).</param>
/// <param name="ownsReference">
/// <see langword="true"/> to send <c>release</c> on disposal;
/// <see langword="false"/> for borrowed references that must not be released.
/// </param>
public abstract class NativeObject(nint nativePtr, bool ownsReference) : IDisposable
{
    private volatile uint disposed;

    /// <summary>
    /// Release the native reference if it has not been released yet.
    /// </summary>
    ~NativeObject()
    {
        Release();
    }

    /// <summary>
    /// The raw pointer (<c>id</c>) to the underlying Objective-C object.
    /// </summary>
    public nint NativePtr { get; } = nativePtr;

    /// <summary>
    /// Indicates whether this instance owns the native reference.
    /// </summary>
    public bool OwnsReference { get; } = ownsReference;

    /// <summary>
    /// Indicates whether the native pointer is zero (<c>nil</c>).
    /// </summary>
    public bool IsNull => NativePtr is 0;

    /// <summary>
    /// Releases the native reference (if owned) and suppresses finalization.
    /// </summary>
    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Reads an Objective-C object property and returns a cached, borrowed wrapper.
    /// The wrapper is re-created only when the underlying pointer changes.
    /// </summary>
    protected T GetProperty<T>(ref T? field, Selector selector) where T : NativeObject, INativeObject<T>
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, selector);

        if (field is null || field.NativePtr != nativePtr)
        {
            field = T.Create(nativePtr, false);
        }

        return field;
    }

    /// <summary>
    /// Writes an Objective-C object property and refreshes the cached wrapper.
    /// </summary>
    protected void SetProperty<T>(ref T? field, Selector selector, T value) where T : NativeObject, INativeObject<T>
    {
        ObjectiveCRuntime.MsgSend(NativePtr, selector, value.NativePtr);

        GetProperty(ref field, selector);
    }

    /// <summary>
    /// Sends <c>release</c> to the native object at most once (thread-safe).
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
