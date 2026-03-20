using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class DispatchQueue(nint nativePtr, NativeObjectOwnership ownership) : DispatchObject(nativePtr, ownership), INativeObject<DispatchQueue>
{
    #region INativeObject
    public static DispatchQueue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static DispatchQueue New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public static DispatchQueue Create(string label, nint attr)
    {
        return new DispatchQueue(DispatchQueueCreate(label, attr), NativeObjectOwnership.Managed);
    }

    public static DispatchQueue GetGlobalQueue(nint identifier, nuint flags)
    {
        return new DispatchQueue(DispatchGetGlobalQueue(identifier, flags), NativeObjectOwnership.Borrowed);
    }

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_queue_create", StringMarshalling = StringMarshalling.Utf8)]
    private static partial nint DispatchQueueCreate(string label, nint attr);

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_get_global_queue")]
    private static partial nint DispatchGetGlobalQueue(nint identifier, nuint flags);
}
