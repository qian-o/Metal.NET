using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A managed wrapper around a Core Graphics <c>CGColorSpaceRef</c> object.
/// Implements <see cref="IDisposable"/> to call <c>CGColorSpaceRelease</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct CGColorSpace(nint nativePtr) : IDisposable
{
    public nint NativePtr = nativePtr;

    public static CGColorSpace SRGB => CreateWithName("kCGColorSpaceSRGB");

    public static CGColorSpace LinearSRGB => CreateWithName("kCGColorSpaceLinearSRGB");

    public static CGColorSpace ExtendedSRGB => CreateWithName("kCGColorSpaceExtendedSRGB");

    public static CGColorSpace ExtendedLinearSRGB => CreateWithName("kCGColorSpaceExtendedLinearSRGB");

    public static CGColorSpace DisplayP3 => CreateWithName("kCGColorSpaceDisplayP3");

    public static CGColorSpace GenericGrayGamma2_2 => CreateWithName("kCGColorSpaceGenericGrayGamma2_2");

    public static CGColorSpace GenericRGBLinear => CreateWithName("kCGColorSpaceGenericRGBLinear");

    public static CGColorSpace AdobeRGB1998 => CreateWithName("kCGColorSpaceAdobeRGB1998");

    public static implicit operator nint(CGColorSpace value)
    {
        return value.NativePtr;
    }

    public static implicit operator CGColorSpace(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        if (NativePtr is not 0)
        {
            CGColorSpaceRelease(NativePtr);

            NativePtr = 0;
        }
    }

    public static CGColorSpace CreateDeviceRGB()
    {
        return new(CGColorSpaceCreateDeviceRGB());
    }

    public static CGColorSpace CreateDeviceGray()
    {
        return new(CGColorSpaceCreateDeviceGray());
    }

    public static CGColorSpace CreateDeviceCMYK()
    {
        return new(CGColorSpaceCreateDeviceCMYK());
    }

    public static CGColorSpace CreateWithName(string name)
    {
        nint cgHandle = NativeLibrary.Load("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics");

        return new(CGColorSpaceCreateWithName(Marshal.ReadIntPtr(NativeLibrary.GetExport(cgHandle, name))));
    }

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceRelease")]
    private static partial void CGColorSpaceRelease(nint colorSpace);

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateDeviceRGB")]
    private static partial nint CGColorSpaceCreateDeviceRGB();

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateDeviceGray")]
    private static partial nint CGColorSpaceCreateDeviceGray();

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateDeviceCMYK")]
    private static partial nint CGColorSpaceCreateDeviceCMYK();

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateWithName")]
    private static partial nint CGColorSpaceCreateWithName(nint name);
}
