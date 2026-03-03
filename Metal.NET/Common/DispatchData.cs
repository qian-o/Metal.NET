using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A managed wrapper around a GCD <c>dispatch_data_t</c> object.
/// Implements <see cref="IDisposable"/> to call <c>dispatch_release</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct DispatchData(nint nativePtr) : IDisposable
{
    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void DispatchRelease(nint @object);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_data_create")]
    private static unsafe partial nint DispatchDataCreate(void* buffer, nuint size, nint queue, nint destructor);

    public nint NativePtr = nativePtr;

    public readonly bool IsNull => NativePtr is 0;

    /// <summary>
    /// Creates a new <see cref="DispatchData"/> by copying the contents of <paramref name="data"/>.
    /// The caller owns the returned object and must dispose it.
    /// </summary>
    public static unsafe DispatchData Create(ReadOnlySpan<byte> data)
    {
        fixed (byte* ptr = data)
        {
            nint handle = DispatchDataCreate(ptr, (nuint)data.Length, 0, 0);

            return new(handle);
        }
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
