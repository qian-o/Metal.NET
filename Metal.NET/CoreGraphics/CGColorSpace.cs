using System.Runtime.InteropServices;

namespace Metal.NET;

public enum CGColorSpaceName
{
    SRGB,

    LinearSRGB,

    ExtendedSRGB,

    ExtendedLinearSRGB,

    DisplayP3,

    GenericGrayGamma2_2,

    GenericRGBLinear,

    AdobeRGB1998
}

public partial class CGColorSpace(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<CGColorSpace>
{
    static readonly nint CGHandle = NativeLibrary.Load("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics");

    #region INativeObject
    public static CGColorSpace Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static CGColorSpace New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    protected override void ReleaseNative()
    {
        CGColorSpaceRelease(NativePtr);
    }

    public static CGColorSpace Create(CGColorSpaceName name)
    {
        string symbolName = name switch
        {
            CGColorSpaceName.SRGB => "kCGColorSpaceSRGB",
            CGColorSpaceName.LinearSRGB => "kCGColorSpaceLinearSRGB",
            CGColorSpaceName.ExtendedSRGB => "kCGColorSpaceExtendedSRGB",
            CGColorSpaceName.ExtendedLinearSRGB => "kCGColorSpaceExtendedLinearSRGB",
            CGColorSpaceName.DisplayP3 => "kCGColorSpaceDisplayP3",
            CGColorSpaceName.GenericGrayGamma2_2 => "kCGColorSpaceGenericGrayGamma2_2",
            CGColorSpaceName.GenericRGBLinear => "kCGColorSpaceGenericRGBLinear",
            CGColorSpaceName.AdobeRGB1998 => "kCGColorSpaceAdobeRGB1998",
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
        };

        return new(CGColorSpaceCreateWithName(Marshal.ReadIntPtr(NativeLibrary.GetExport(CGHandle, symbolName))), NativeObjectOwnership.Managed);
    }

    public static CGColorSpace CreateDeviceRGB()
    {
        return new(CGColorSpaceCreateDeviceRGB(), NativeObjectOwnership.Managed);
    }

    public static CGColorSpace CreateDeviceGray()
    {
        return new(CGColorSpaceCreateDeviceGray(), NativeObjectOwnership.Managed);
    }

    public static CGColorSpace CreateDeviceCMYK()
    {
        return new(CGColorSpaceCreateDeviceCMYK(), NativeObjectOwnership.Managed);
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
