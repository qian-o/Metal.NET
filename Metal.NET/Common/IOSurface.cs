using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A managed wrapper around an <c>IOSurfaceRef</c> object.
/// Implements <see cref="IDisposable"/> to call <c>CFRelease</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct IOSurface(nint nativePtr) : IDisposable
{
    public nint NativePtr = nativePtr;

    public readonly bool IsNull => NativePtr is 0;

    public readonly int Width => IOSurfaceGetWidth(NativePtr);

    public readonly int Height => IOSurfaceGetHeight(NativePtr);

    public readonly int BytesPerElement => IOSurfaceGetBytesPerElement(NativePtr);

    public readonly int BytesPerRow => IOSurfaceGetBytesPerRow(NativePtr);

    public readonly nuint AllocSize => IOSurfaceGetAllocSize(NativePtr);

    public readonly uint PixelFormat => IOSurfaceGetPixelFormat(NativePtr);

    public readonly nuint PlaneCount => IOSurfaceGetPlaneCount(NativePtr);

    public readonly uint SurfaceID => IOSurfaceGetID(NativePtr);

    public readonly nint BaseAddress => IOSurfaceGetBaseAddress(NativePtr);

    public readonly uint Seed => IOSurfaceGetSeed(NativePtr);

    public readonly bool IsInUse => IOSurfaceIsInUse(NativePtr);

    public static implicit operator nint(IOSurface value)
    {
        return value.NativePtr;
    }

    public static implicit operator IOSurface(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        if (IsNull)
        {
            return;
        }

        CFRelease(NativePtr);

        NativePtr = 0;
    }

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetWidth")]
    private static partial int IOSurfaceGetWidth(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetHeight")]
    private static partial int IOSurfaceGetHeight(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetBytesPerElement")]
    private static partial int IOSurfaceGetBytesPerElement(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetBytesPerRow")]
    private static partial int IOSurfaceGetBytesPerRow(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetAllocSize")]
    private static partial nuint IOSurfaceGetAllocSize(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetPixelFormat")]
    private static partial uint IOSurfaceGetPixelFormat(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetPlaneCount")]
    private static partial nuint IOSurfaceGetPlaneCount(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetID")]
    private static partial uint IOSurfaceGetID(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetBaseAddress")]
    private static partial nint IOSurfaceGetBaseAddress(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetSeed")]
    private static partial uint IOSurfaceGetSeed(nint buffer);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceIsInUse")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool IOSurfaceIsInUse(nint buffer);

    [LibraryImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation", EntryPoint = "CFRelease")]
    private static partial void CFRelease(nint cf);
}
