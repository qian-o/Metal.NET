using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct MTLOrigin
{
    public UIntPtr x;
    public UIntPtr y;
    public UIntPtr z;

    public MTLOrigin(uint x, uint y, uint z)
    {
        this.x = (UIntPtr)x;
        this.y = (UIntPtr)y;
        this.z = (UIntPtr)z;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSize
{
    public UIntPtr width;
    public UIntPtr height;
    public UIntPtr depth;

    public MTLSize(uint width, uint height, uint depth)
    {
        this.width = (UIntPtr)width;
        this.height = (UIntPtr)height;
        this.depth = (UIntPtr)depth;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLRegion
{
    public MTLOrigin origin;
    public MTLSize size;

    public MTLRegion(MTLOrigin origin, MTLSize size)
    {
        this.origin = origin;
        this.size = size;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLViewport
{
    public double originX;
    public double originY;
    public double width;
    public double height;
    public double znear;
    public double zfar;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLScissorRect
{
    public UIntPtr x;
    public UIntPtr y;
    public UIntPtr width;
    public UIntPtr height;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLClearColor
{
    public double red;
    public double green;
    public double blue;
    public double alpha;

    public MTLClearColor(double red, double green, double blue, double alpha)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct CGSize
{
    public double width;
    public double height;

    public CGSize(double width, double height)
    {
        this.width = width;
        this.height = height;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSamplePosition
{
    public float x;
    public float y;

    public MTLSamplePosition(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSizeAndAlign
{
    public UIntPtr size;
    public UIntPtr align;
}
