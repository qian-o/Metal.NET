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
    static abstract TSelf Create(nint nativePtr, bool ownsReference);
}

/// <summary>
/// Abstract base class for managed wrappers around Objective-C objects.
/// Holds a native pointer and, when the instance owns the reference,
/// sends <c>release</c> on explicit <see cref="Dispose()"/>.
/// <para>
/// The finalizer is suppressed by default so that method-returned wrappers
/// are only released via explicit <see cref="Dispose()"/>. Derived types
/// that create fully-managed instances (via <c>AllocInit</c>) call
/// <see cref="GC.ReRegisterForFinalize"/> so that GC can release them
/// as a safety net.
/// </para>
/// </summary>
public abstract class NativeObject : IDisposable
{
    private volatile uint disposed;

    /// <param name="nativePtr">The Objective-C object pointer (<c>id</c>).</param>
    /// <param name="ownsReference">
    /// <see langword="true"/> to send <c>release</c> on disposal;
    /// <see langword="false"/> for borrowed references that must not be released.
    /// </param>
    protected NativeObject(nint nativePtr, bool ownsReference)
    {
        NativePtr = nativePtr;
        OwnsReference = ownsReference;

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Release the native reference if it has not been released yet.
    /// Only runs for instances that re-registered for finalization.
    /// </summary>
    ~NativeObject()
    {
        Release();
    }

    /// <summary>
    /// The raw pointer (<c>id</c>) to the underlying Objective-C object.
    /// </summary>
    public nint NativePtr { get; }

    /// <summary>
    /// Indicates whether this instance owns the native reference.
    /// </summary>
    public bool OwnsReference { get; }

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

        field = T.Create(value.NativePtr, false);
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
