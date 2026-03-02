using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps a CoreGraphics CGColorSpace object.
/// </summary>
public partial class CGColorSpace : IDisposable
{
    private nint _handle;
    private bool _ownsHandle;

    private CGColorSpace(nint handle, bool ownsHandle)
    {
        _handle = handle;
        _ownsHandle = ownsHandle;
    }

    /// <summary>
    /// Gets the native CGColorSpaceRef pointer.
    /// </summary>
    public nint NativePtr => _handle;

    /// <summary>
    /// Gets a value indicating whether this color space is null.
    /// </summary>
    public bool IsNull => _handle == 0;

    /// <summary>
    /// Creates a device-dependent RGB color space.
    /// </summary>
    public static CGColorSpace CreateDeviceRGB()
    {
        nint handle = CGColorSpaceCreateDeviceRGB_Native();
        return new(handle, ownsHandle: true);
    }

    /// <summary>
    /// Creates a color space using a predefined name.
    /// </summary>
    /// <param name="name">A CFStringRef specifying the color space name.</param>
    public static CGColorSpace CreateWithName(nint name)
    {
        nint handle = CGColorSpaceCreateWithName_Native(name);
        return new(handle, ownsHandle: true);
    }

    /// <summary>
    /// Returns the number of components in the color space.
    /// </summary>
    public nuint NumberOfComponents => CGColorSpaceGetNumberOfComponents_Native(_handle);

    /// <summary>
    /// Creates a CGColorSpace wrapper from a native handle.
    /// </summary>
    public static CGColorSpace FromNativePtr(nint handle, bool ownsHandle) => new(handle, ownsHandle);

    public void Dispose()
    {
        if (_ownsHandle && _handle != 0)
        {
            CGColorSpaceRelease_Native(_handle);
            _handle = 0;
        }
        GC.SuppressFinalize(this);
    }

    ~CGColorSpace()
    {
        if (_ownsHandle && _handle != 0)
        {
            CGColorSpaceRelease_Native(_handle);
        }
    }

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateDeviceRGB")]
    private static partial nint CGColorSpaceCreateDeviceRGB_Native();

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateWithName")]
    private static partial nint CGColorSpaceCreateWithName_Native(nint name);

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceRetain")]
    private static partial nint CGColorSpaceRetain_Native(nint colorSpace);

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceRelease")]
    private static partial void CGColorSpaceRelease_Native(nint colorSpace);

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceGetNumberOfComponents")]
    private static partial nuint CGColorSpaceGetNumberOfComponents_Native(nint colorSpace);
}
