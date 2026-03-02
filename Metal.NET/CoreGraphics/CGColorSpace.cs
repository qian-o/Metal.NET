using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Provides P/Invoke bindings for CoreGraphics CGColorSpace functions.
/// </summary>
public static partial class CGColorSpace
{
    /// <summary>
    /// Creates a device-dependent RGB color space.
    /// </summary>
    /// <returns>A CGColorSpaceRef. The caller must call <see cref="Release"/> when done.</returns>
    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateDeviceRGB")]
    public static partial nint CreateDeviceRGB();

    /// <summary>
    /// Creates a color space using a predefined name.
    /// </summary>
    /// <param name="name">A CFStringRef specifying the color space name (e.g., kCGColorSpaceSRGB).</param>
    /// <returns>A CGColorSpaceRef. The caller must call <see cref="Release"/> when done.</returns>
    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateWithName")]
    public static partial nint CreateWithName(nint name);

    /// <summary>
    /// Retains a CGColorSpace object.
    /// </summary>
    /// <param name="colorSpace">The CGColorSpaceRef to retain.</param>
    /// <returns>The same CGColorSpaceRef.</returns>
    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceRetain")]
    public static partial nint Retain(nint colorSpace);

    /// <summary>
    /// Releases a CGColorSpace object.
    /// </summary>
    /// <param name="colorSpace">The CGColorSpaceRef to release.</param>
    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceRelease")]
    public static partial void Release(nint colorSpace);

    /// <summary>
    /// Returns the number of components in the color space.
    /// </summary>
    /// <param name="colorSpace">The CGColorSpaceRef to query.</param>
    /// <returns>The number of color components.</returns>
    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceGetNumberOfComponents")]
    public static partial nuint GetNumberOfComponents(nint colorSpace);
}
