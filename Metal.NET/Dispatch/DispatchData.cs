using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Provides P/Invoke bindings for libdispatch (GCD) dispatch data objects.
/// </summary>
public static partial class DispatchData
{
    /// <summary>
    /// Creates a dispatch data object from a buffer.
    /// </summary>
    /// <param name="buffer">Pointer to the data buffer.</param>
    /// <param name="size">The size of the buffer in bytes.</param>
    /// <param name="queue">The dispatch queue for the destructor, or <see cref="nint.Zero"/>.</param>
    /// <param name="destructor">A block to call when the data is no longer needed, or <see cref="nint.Zero"/> to copy the data.</param>
    /// <returns>A new dispatch data object. The caller must call <see cref="DispatchQueue.Release"/> when done.</returns>
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_data_create")]
    public static partial nint Create(nint buffer, nuint size, nint queue, nint destructor);

    /// <summary>
    /// Gets the size of a dispatch data object.
    /// </summary>
    /// <param name="data">The dispatch data object.</param>
    /// <returns>The number of bytes in the data object.</returns>
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_data_get_size")]
    public static partial nuint GetSize(nint data);
}
