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
        if (NativePtr is not 0)
        {
            CFRelease(NativePtr);

            NativePtr = 0;
        }
    }

    [LibraryImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation", EntryPoint = "CFRelease")]
    private static partial void CFRelease(nint cf);
}
