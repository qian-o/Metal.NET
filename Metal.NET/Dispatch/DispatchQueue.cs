using System.Runtime.InteropServices;

namespace Metal.NET;

public readonly partial struct DispatchQueue(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public void Dispose()
    {
        if (!IsNull)
        {
            DispatchRelease(NativePtr);
        }
    }

    public static DispatchQueue Create(string label, nint attr)
    {
        return new DispatchQueue(DispatchQueueCreate(label, attr));
    }

    public static DispatchQueue GetGlobalQueue(nint identifier, nuint flags)
    {
        return new DispatchQueue(DispatchGetGlobalQueue(identifier, flags));
    }

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void DispatchRelease(nint @object);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_queue_create", StringMarshalling = StringMarshalling.Utf8)]
    private static partial nint DispatchQueueCreate(string label, nint attr);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_get_global_queue")]
    private static partial nint DispatchGetGlobalQueue(nint identifier, nuint flags);
}
