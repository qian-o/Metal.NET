using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps a libdispatch (GCD) dispatch queue object.
/// </summary>
public partial class DispatchQueue : IDisposable
{
    private nint _handle;
    private bool _ownsHandle;

    private DispatchQueue(nint handle, bool ownsHandle)
    {
        _handle = handle;
        _ownsHandle = ownsHandle;
    }

    /// <summary>
    /// Gets the native pointer to the dispatch queue.
    /// </summary>
    public nint NativePtr => _handle;

    /// <summary>
    /// Gets a value indicating whether this queue is null.
    /// </summary>
    public bool IsNull => _handle == 0;

    /// <summary>
    /// Creates a new dispatch queue with the specified label.
    /// </summary>
    /// <param name="label">A label to attach to the queue for debugging.</param>
    /// <param name="concurrent">If true, creates a concurrent queue; otherwise, creates a serial queue.</param>
    /// <returns>A new dispatch queue.</returns>
    public static DispatchQueue Create(string label, bool concurrent = false)
    {
        nint attr = concurrent ? DispatchQueueConstants.ConcurrentAttribute : 0;
        nint handle = dispatch_queue_create(label, attr);
        return new(handle, ownsHandle: true);
    }

    /// <summary>
    /// Gets a global concurrent queue for the specified quality-of-service class.
    /// </summary>
    /// <param name="identifier">The QoS class (e.g., 0x21 for user-interactive, 0x19 for user-initiated, 0x15 for utility, 0x09 for background).</param>
    /// <param name="flags">Reserved for future use; pass 0.</param>
    /// <returns>The global dispatch queue (borrowed, must not be released).</returns>
    public static DispatchQueue GetGlobalQueue(long identifier, nuint flags = 0)
    {
        nint handle = dispatch_get_global_queue(identifier, flags);
        return new(handle, ownsHandle: false);
    }

    /// <summary>
    /// Gets the main dispatch queue.
    /// </summary>
    public static DispatchQueue MainQueue => new(DispatchQueueConstants.MainQueuePtr, ownsHandle: false);

    /// <summary>
    /// Creates a DispatchQueue wrapper from a native handle.
    /// </summary>
    public static DispatchQueue FromNativePtr(nint handle, bool ownsHandle) => new(handle, ownsHandle);

    public void Dispose()
    {
        if (_ownsHandle && _handle != 0)
        {
            dispatch_release(_handle);
            _handle = 0;
        }
        GC.SuppressFinalize(this);
    }

    ~DispatchQueue()
    {
        if (_ownsHandle && _handle != 0)
        {
            dispatch_release(_handle);
        }
    }

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_queue_create", StringMarshalling = StringMarshalling.Utf8)]
    private static partial nint dispatch_queue_create(string label, nint attr);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_get_global_queue")]
    private static partial nint dispatch_get_global_queue(long identifier, nuint flags);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_retain")]
    private static partial void dispatch_retain(nint obj);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void dispatch_release(nint obj);
}

file static class DispatchQueueConstants
{
    public static readonly nint MainQueuePtr = NativeLibrary.GetExport(
        NativeLibrary.Load("/usr/lib/libSystem.B.dylib"), "_dispatch_main_q");

    public static readonly nint ConcurrentAttribute = NativeLibrary.GetExport(
        NativeLibrary.Load("/usr/lib/libSystem.B.dylib"), "_dispatch_queue_attr_concurrent");
}
