namespace Metal.NET;

/// <summary>
/// Describes how a <see cref="NativeObject"/> manages its native reference.
/// </summary>
public enum NativeObjectOwnership
{
    /// <summary>
    /// The wrapper does not own the reference. <c>Dispose()</c> and the
    /// finalizer do nothing. Used for property getters, <c>objectAtIndex:</c>.
    /// </summary>
    Borrowed,

    /// <summary>
    /// The wrapper owns the reference and sends <c>release</c> on explicit
    /// <c>Dispose()</c>. The finalizer does nothing. Used for method return values,
    /// <c>out NSError</c> parameters.
    /// </summary>
    Owned,

    /// <summary>
    /// The wrapper fully manages the reference. <c>Dispose()</c> sends
    /// <c>release</c>, and the GC finalizer acts as a safety net.
    /// Used for objects created via <c>AllocInit</c> (parameterless constructor).
    /// </summary>
    Managed
}

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
    static abstract TSelf Create(nint nativePtr, NativeObjectOwnership ownership);
}

/// <summary>
/// Abstract base class for managed wrappers around Objective-C objects.
/// Holds a native pointer and manages its lifetime according to the
/// <see cref="Ownership"/> policy.
/// </summary>
/// <param name="nativePtr">The Objective-C object pointer (<c>id</c>).</param>
/// <param name="ownership">The ownership policy for the native reference.</param>
public abstract class NativeObject(nint nativePtr, NativeObjectOwnership ownership) : IDisposable
{
    private volatile uint disposed;

    /// <summary>
    /// Release the native reference if it has not been released yet.
    /// Only runs for <see cref="NativeObjectOwnership.Managed"/> instances;
    /// the finalizer does nothing for other ownership modes.
    /// </summary>
    ~NativeObject()
    {
        if (Ownership is NativeObjectOwnership.Managed)
        {
            Release();
        }
    }

    /// <summary>
    /// The raw pointer (<c>id</c>) to the underlying Objective-C object.
    /// </summary>
    public nint NativePtr { get; } = nativePtr;

    /// <summary>
    /// The ownership policy for the native reference.
    /// </summary>
    public NativeObjectOwnership Ownership { get; } = ownership;

    /// <summary>
    /// Indicates whether the native pointer is zero (<c>nil</c>).
    /// </summary>
    public bool IsNull => NativePtr is 0;

    /// <summary>
    /// Releases the native reference (if owned) and suppresses finalization.
    /// </summary>
    public void Dispose()
    {
        if (IsNull)
        {
            return;
        }

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
            field = T.Create(nativePtr, NativeObjectOwnership.Borrowed);
        }

        return field;
    }

    /// <summary>
    /// Writes an Objective-C object property and refreshes the cached wrapper.
    /// </summary>
    protected void SetProperty<T>(ref T? field, Selector selector, T value) where T : NativeObject, INativeObject<T>
    {
        ObjectiveCRuntime.MsgSend(NativePtr, selector, value.NativePtr);

        field = T.Create(value.NativePtr, NativeObjectOwnership.Borrowed);
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

        if (Ownership is not NativeObjectOwnership.Borrowed)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}
