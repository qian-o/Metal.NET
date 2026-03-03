using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A managed wrapper around a GCD <c>dispatch_data_t</c> object.
/// Implements <see cref="IDisposable"/> to call <c>dispatch_release</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct DispatchData(nint nativePtr) : IDisposable
{
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_data_create")]
    private static unsafe partial nint DispatchDataCreate(void* buffer, nuint size, DispatchQueue queue, nint destructor);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void DispatchRelease(nint @object);

    public nint NativePtr = nativePtr;

    public static unsafe DispatchData Create<T>(ReadOnlySpan<T> data, DispatchQueue queue, nint destructor) where T : unmanaged
    {
    }

    public static implicit operator nint(DispatchData value)
    {
        return value.NativePtr;
    }

    public static implicit operator DispatchData(nint value)
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
