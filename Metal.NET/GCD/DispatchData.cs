using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class DispatchData(nint nativePtr, NativeObjectOwnership ownership) : DispatchObject(nativePtr, ownership), INativeObject<DispatchData>
{
    #region INativeObject
    public static DispatchData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static DispatchData New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public static unsafe DispatchData Create<T>(ReadOnlySpan<T> data) where T : unmanaged
    {
        fixed (T* pData = data)
        {
            return new(DispatchDataCreate((nint)pData, (nuint)(data.Length * sizeof(T)), 0, 0), NativeObjectOwnership.Managed);
        }
    }

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_data_create")]
    private static partial nint DispatchDataCreate(nint buffer, nuint size, nint queue, nint destructor);
}
