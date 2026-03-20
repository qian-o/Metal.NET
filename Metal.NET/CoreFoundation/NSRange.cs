using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct NSRange(nuint location, nuint length)
{
    public nuint Location = location;

    public nuint Length = length;
}
