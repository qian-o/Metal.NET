using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct SimdFloat4(float x, float y, float z, float w)
{
    public float X = x;

    public float Y = y;

    public float Z = z;

    public float W = w;
}
