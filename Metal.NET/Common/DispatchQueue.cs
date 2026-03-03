using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A managed wrapper around a GCD <c>dispatch_queue_t</c> object.
/// Implements <see cref="IDisposable"/> to call <c>dispatch_release</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct DispatchQueue(nint nativePtr) : IDisposable
{
    public nint NativePtr = nativePtr;

    public readonly bool IsNull => NativePtr is 0;

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
        if (IsNull)
        {
            return;
        }

        DispatchRelease(NativePtr);

        NativePtr = 0;
    }

    public static DispatchQueue Create(string label, nint attr)
    {
        return new(DispatchQueueCreate(label, attr));
    }

    public static DispatchQueue GlobalQueue(nint identifier, nuint flags)
    {
        return new(DispatchGetGlobalQueue(identifier, flags));
    }

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void DispatchRelease(nint @object);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_queue_create", StringMarshalling = StringMarshalling.Utf8)]
    private static partial nint DispatchQueueCreate(string label, nint attr);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_get_global_queue")]
    private static partial nint DispatchGetGlobalQueue(nint identifier, nuint flags);
}
