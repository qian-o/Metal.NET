namespace Metal.NET;

/// <summary>
/// Factory interface for creating managed wrappers from native Objective-C pointers.
/// </summary>
/// <typeparam name="TSelf">The concrete wrapper type.</typeparam>
public interface INativeObject<TSelf> where TSelf : NativeObject, INativeObject<TSelf>
{
    static abstract TSelf Null { get; }

    /// <summary>
    /// Creates a managed wrapper around the given native pointer.
    /// </summary>
    static abstract TSelf Create(nint nativePtr, bool ownsReference, bool allowGCRelease);
}

/// <summary>
/// Abstract base class for managed wrappers around Objective-C objects.
/// Holds a native pointer and, when the instance owns the reference,
/// sends <c>release</c> on explicit <see cref="Dispose()"/>.
/// <para>
/// Objects fully created by C# (via <c>AllocInit</c>) pass
/// <c>allowGCRelease: true</c>, enabling the GC finalizer to release
/// the native reference as a safety net. Objects created from native
/// pointers (method returns, borrowed references) leave it
/// <see langword="false"/> so the finalizer does nothing.
/// </para>
/// </summary>
/// <param name="nativePtr">The Objective-C object pointer (<c>id</c>).</param>
/// <param name="ownsReference">
/// <see langword="true"/> to send <c>release</c> on disposal;
/// <see langword="false"/> for borrowed references that must not be released.
/// </param>
/// <param name="allowGCRelease">
/// <see langword="true"/> to allow the GC finalizer to release the native
/// reference; <see langword="false"/> for objects from native that
/// should only be released via explicit <see cref="Dispose()"/>.
/// </param>
public abstract class NativeObject(nint nativePtr, bool ownsReference, bool allowGCRelease) : IDisposable
{
    private volatile uint disposed;

    /// <summary>
    /// Release the native reference if it has not been released yet.
    /// Only releases for instances with <see cref="AllowGCRelease"/> set;
    /// the finalizer does nothing for objects created from native pointers.
    /// </summary>
    ~NativeObject()
    {
        if (AllowGCRelease)
        {
            Release();
        }
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
    /// Indicates whether the GC finalizer is allowed to release the native
    /// reference. <see langword="true"/> for objects fully created by C#
    /// (via <c>AllocInit</c>); <see langword="false"/> for objects from native.
    /// </summary>
    public bool AllowGCRelease { get; } = allowGCRelease;

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
            field = T.Create(nativePtr, false, false);
        }

        return field;
    }

    /// <summary>
    /// Writes an Objective-C object property and refreshes the cached wrapper.
    /// </summary>
    protected void SetProperty<T>(ref T? field, Selector selector, T value) where T : NativeObject, INativeObject<T>
    {
        ObjectiveCRuntime.MsgSend(NativePtr, selector, value.NativePtr);

        field = T.Create(value.NativePtr, false, false);
    }

    /// <summary>
    /// Reads an Objective-C NSArray property and converts it to a C# array.
    /// Each element is a borrowed reference (not retained by the wrapper).
    /// </summary>
    protected T[] GetArrayProperty<T>(Selector selector) where T : NativeObject, INativeObject<T>
    {
        nint arrayPtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, selector);

        return NSArray.ToArray<T>(arrayPtr);
    }

    /// <summary>
    /// Creates a temporary NSArray from a C# array, sets the Objective-C property,
    /// and releases the temporary NSArray.
    /// </summary>
    protected void SetArrayProperty<T>(Selector selector, T[] value) where T : NativeObject
    {
        nint arrayPtr = NSArray.FromArray(value);

        ObjectiveCRuntime.MsgSend(NativePtr, selector, arrayPtr);

        ObjectiveCRuntime.Release(arrayPtr);
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
