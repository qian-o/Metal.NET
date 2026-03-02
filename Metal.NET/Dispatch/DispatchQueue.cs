using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Provides P/Invoke bindings for libdispatch (GCD) dispatch queues.
/// </summary>
public static partial class DispatchQueue
{
    /// <summary>
    /// Creates a new dispatch queue with the specified label.
    /// </summary>
    /// <param name="label">A label to attach to the queue for debugging.</param>
    /// <param name="attr">
    /// Queue attributes. Pass <see cref="nint.Zero"/> for a serial queue,
    /// or use <see cref="ConcurrentAttribute"/> for a concurrent queue.
    /// </param>
    /// <returns>A new dispatch queue. The caller must call <see cref="Release"/> when done.</returns>
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_queue_create", StringMarshalling = StringMarshalling.Utf8)]
    public static partial nint Create(string label, nint attr);

    /// <summary>
    /// Gets a global concurrent queue for the specified quality-of-service class.
    /// </summary>
    /// <param name="identifier">The QoS class (e.g., 0x21 for user-interactive, 0x19 for user-initiated, 0x15 for utility, 0x09 for background).</param>
    /// <param name="flags">Reserved for future use; pass 0.</param>
    /// <returns>The global dispatch queue. Do not release this queue.</returns>
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_get_global_queue")]
    public static partial nint GetGlobalQueue(long identifier, nuint flags);

    /// <summary>
    /// Retains a dispatch object, incrementing its reference count.
    /// </summary>
    /// <param name="obj">The dispatch object to retain.</param>
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_retain")]
    public static partial void Retain(nint obj);

    /// <summary>
    /// Releases a dispatch object, decrementing its reference count.
    /// </summary>
    /// <param name="obj">The dispatch object to release.</param>
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    public static partial void Release(nint obj);

    /// <summary>
    /// Gets the main dispatch queue.
    /// </summary>
    /// <remarks>
    /// On macOS, <c>dispatch_get_main_queue()</c> is a macro that resolves to <c>_dispatch_main_q</c>.
    /// </remarks>
    public static nint MainQueue
    {
        get
        {
            if (s_mainQueue == 0)
            {
                nint lib = NativeLibrary.Load("/usr/lib/libSystem.B.dylib");
                s_mainQueue = NativeLibrary.GetExport(lib, "_dispatch_main_q");
            }

            return s_mainQueue;
        }
    }

    /// <summary>
    /// The attribute for creating concurrent dispatch queues.
    /// </summary>
    public static nint ConcurrentAttribute
    {
        get
        {
            if (s_concurrentAttr == 0)
            {
                nint lib = NativeLibrary.Load("/usr/lib/libSystem.B.dylib");
                s_concurrentAttr = NativeLibrary.GetExport(lib, "_dispatch_queue_attr_concurrent");
            }

            return s_concurrentAttr;
        }
    }

    private static nint s_mainQueue;
    private static nint s_concurrentAttr;
}
