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

public interface INativeObject<TSelf> where TSelf : NativeObject, INativeObject<TSelf>
{
    static abstract TSelf Null { get; }

    static abstract TSelf New(nint nativePtr, NativeObjectOwnership ownership);
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

    protected abstract void ReleaseNative();

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
            ReleaseNative();
        }
    }
}
