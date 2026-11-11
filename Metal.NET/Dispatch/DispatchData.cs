using System.Runtime.InteropServices;

namespace Metal.NET;

public readonly partial struct DispatchData(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public void Release()
    {
        if (!IsNull)
        {
            DispatchRelease(NativePtr);
        }
    }

    public void Dispose()
    {
        Release();
    }

    public static unsafe DispatchData Create<T>(ReadOnlySpan<T> data) where T : unmanaged
    {
        fixed (T* pData = data)
        {
            return new(DispatchDataCreate((nint)pData, (nuint)(data.Length * sizeof(T)), 0, 0));
        }
    }

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void DispatchRelease(nint @object);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_data_create")]
    private static partial nint DispatchDataCreate(nint buffer, nuint size, nint queue, nint destructor);
}
