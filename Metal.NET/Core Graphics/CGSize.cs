using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct CGSize(double width, double height)
{
    public double Width = width;

    public double Height = height;
}
