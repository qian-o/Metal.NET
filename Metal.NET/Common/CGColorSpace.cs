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
        return new(CGColorSpaceCreateDeviceRGB_());
    }

    public static CGColorSpace CreateDeviceGray()
    {
        return new(CGColorSpaceCreateDeviceGray_());
    }

    public static CGColorSpace CreateDeviceCMYK()
    {
        return new(CGColorSpaceCreateDeviceCMYK_());
    }

    public static CGColorSpace CreateWithName(nint name)
    {
        return new(CGColorSpaceCreateWithName_(name));
    }

    public static CGColorSpace SRGB => CreateWithName(GetConstant("kCGColorSpaceSRGB"));

    public static CGColorSpace LinearSRGB => CreateWithName(GetConstant("kCGColorSpaceLinearSRGB"));

    public static CGColorSpace ExtendedSRGB => CreateWithName(GetConstant("kCGColorSpaceExtendedSRGB"));

    public static CGColorSpace ExtendedLinearSRGB => CreateWithName(GetConstant("kCGColorSpaceExtendedLinearSRGB"));

    public static CGColorSpace DisplayP3 => CreateWithName(GetConstant("kCGColorSpaceDisplayP3"));

    public static CGColorSpace GenericGrayGamma2_2 => CreateWithName(GetConstant("kCGColorSpaceGenericGrayGamma2_2"));

    public static CGColorSpace GenericRGBLinear => CreateWithName(GetConstant("kCGColorSpaceGenericRGBLinear"));

    public static CGColorSpace AdobeRGB1998 => CreateWithName(GetConstant("kCGColorSpaceAdobeRGB1998"));

    private static readonly nint _cgHandle = NativeLibrary.Load("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics");

    private static nint GetConstant(string name)
    {
        nint symbol = NativeLibrary.GetExport(_cgHandle, name);

        return Marshal.ReadIntPtr(symbol);
    }

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceRelease")]
    private static partial void CGColorSpaceRelease(nint colorSpace);

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateDeviceRGB")]
    private static partial nint CGColorSpaceCreateDeviceRGB_();

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateDeviceGray")]
    private static partial nint CGColorSpaceCreateDeviceGray_();

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateDeviceCMYK")]
    private static partial nint CGColorSpaceCreateDeviceCMYK_();

    [LibraryImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", EntryPoint = "CGColorSpaceCreateWithName")]
    private static partial nint CGColorSpaceCreateWithName_(nint name);
}
