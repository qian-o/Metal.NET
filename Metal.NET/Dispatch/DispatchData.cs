using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps a libdispatch (GCD) dispatch data object.
/// </summary>
public partial class DispatchData : IDisposable
{
    private nint _handle;
    private bool _ownsHandle;

    private DispatchData(nint handle, bool ownsHandle)
    {
        _handle = handle;
        _ownsHandle = ownsHandle;
    }

    /// <summary>
    /// Gets the native pointer to the dispatch data object.
    /// </summary>
    public nint NativePtr => _handle;

    /// <summary>
    /// Gets a value indicating whether this data object is null.
    /// </summary>
    public bool IsNull => _handle == 0;

    /// <summary>
    /// Creates a dispatch data object from a buffer.
    /// </summary>
    public static DispatchData Create(nint buffer, nuint size, DispatchQueue? queue = null, nint destructor = 0)
    {
        nint queueHandle = queue?.NativePtr ?? 0;
        nint handle = dispatch_data_create(buffer, size, queueHandle, destructor);
        return new(handle, ownsHandle: true);
    }

    /// <summary>
    /// Gets the size of this dispatch data object.
    /// </summary>
    public nuint Size => dispatch_data_get_size(_handle);

    /// <summary>
    /// Creates a DispatchData wrapper from a native handle.
    /// </summary>
    public static DispatchData FromNativePtr(nint handle, bool ownsHandle) => new(handle, ownsHandle);

    public void Dispose()
    {
        if (_ownsHandle && _handle != 0)
        {
            dispatch_release(_handle);
            _handle = 0;
        }
        GC.SuppressFinalize(this);
    }

    ~DispatchData()
    {
        if (_ownsHandle && _handle != 0)
        {
            dispatch_release(_handle);
        }
    }

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_data_create")]
    private static partial nint dispatch_data_create(nint buffer, nuint size, nint queue, nint destructor);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_data_get_size")]
    private static partial nuint dispatch_data_get_size(nint data);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void dispatch_release(nint obj);
}
