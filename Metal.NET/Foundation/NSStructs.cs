using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct NSOperatingSystemVersion(nint majorVersion, nint minorVersion, nint patchVersion)
{
    public nint MajorVersion = majorVersion;

    public nint MinorVersion = minorVersion;

    public nint PatchVersion = patchVersion;
}

[StructLayout(LayoutKind.Sequential)]
public struct NSRange(nuint location, nuint length)
{
    public nuint Location = location;

    public nuint Length = length;
}
