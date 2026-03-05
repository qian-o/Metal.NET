using System.Runtime.InteropServices;

namespace Metal.NET;

public abstract partial class DispatchObject(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership)
{
    protected override void ReleaseNative()
    {
        DispatchRelease(NativePtr);
    }

    [LibraryImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dispatch_release")]
    private static partial void DispatchRelease(nint @object);
}
