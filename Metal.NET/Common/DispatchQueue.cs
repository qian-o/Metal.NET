using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A managed wrapper around a GCD <c>dispatch_queue_t</c> object.
/// Implements <see cref="IDisposable"/> to call <c>dispatch_release</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct DispatchQueue(nint nativePtr) : IDisposable
{
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void DispatchRelease(nint @object);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_get_global_queue")]
    private static partial nint DispatchGetGlobalQueue(nint identifier, nuint flags);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_queue_create", StringMarshalling = StringMarshalling.Utf8)]
    private static partial nint DispatchQueueCreate(string? label, nint attr);

    private static readonly nint _libHandle = NativeLibrary.Load("/usr/lib/libSystem.B.dylib");
    private static readonly nint _mainQueuePtr = NativeLibrary.GetExport(_libHandle, "_dispatch_main_q");
    private static readonly nint _globalQueuePtr = DispatchGetGlobalQueue(0, 0);

    public nint NativePtr = nativePtr;

    public static DispatchQueue MainQueue => new(_mainQueuePtr);

    public static DispatchQueue GlobalQueue => new(_globalQueuePtr);

    public static DispatchQueue Create(string? label, nint attr)
    {
        return new(DispatchQueueCreate(label, attr));
    }

    public static implicit operator nint(DispatchQueue value)
    {
        return value.NativePtr;
    }

    public static implicit operator DispatchQueue(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        if (NativePtr is not 0)
        {
            DispatchRelease(NativePtr);

            NativePtr = 0;
        }
    }
}
