using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A managed wrapper around a GCD <c>dispatch_data_t</c> object.
/// Implements <see cref="IDisposable"/> to call <c>dispatch_release</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct DispatchData(nint nativePtr) : IDisposable
{
    public nint NativePtr = nativePtr;

    public readonly bool IsNull => NativePtr is 0;

    public void Dispose()
    {
        if (NativePtr is not 0)
        {
            DispatchRelease(NativePtr);

            NativePtr = 0;
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

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void DispatchRelease(nint @object);
}
