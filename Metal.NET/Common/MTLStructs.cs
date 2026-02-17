using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct MTLOrigin(uint x, uint y, uint z)
{
    public nuint X = x;

    public nuint Y = y;

    public nuint Z = z;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSize
{
    public nuint Width;
    public nuint Height;
    public nuint Depth;

    public MTLSize(uint width, uint height, uint depth)
    {
        Width = width;
        Height = height;
        Depth = depth;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLRegion
{
    public MTLOrigin Origin;
    public MTLSize Size;

    public MTLRegion(MTLOrigin origin, MTLSize size)
    {
        Origin = origin;
        Size = size;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLViewport
{
    public double OriginX;
    public double OriginY;
    public double Width;
    public double Height;
    public double Znear;
    public double Zfar;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLScissorRect
{
    public nuint X;
    public nuint Y;
    public nuint Width;
    public nuint Height;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLClearColor
{
    public double Red;
    public double Green;
    public double Blue;
    public double Alpha;

    public MTLClearColor(double red, double green, double blue, double alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct CGSize
{
    public double Width;
    public double Height;

    public CGSize(double width, double height)
    {
        Width = width;
        Height = height;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSamplePosition
{
    public float X;
    public float Y;

    public MTLSamplePosition(float x, float y)
    {
        X = x;
        Y = y;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSizeAndAlign
{
    public nuint Size;
    public nuint Align;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLRange
{
    public nuint Location;
    public nuint Length;

    public MTLRange(nuint location, nuint length)
    {
        Location = location;
        Length = length;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLResourceID
{
    public ulong Impl;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLVertexAmplificationViewMapping
{
    public uint ViewportArrayIndexOffset;
    public uint RenderTargetArrayIndexOffset;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Origin
{
    public nuint X;
    public nuint Y;
    public nuint Z;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Size
{
    public nuint Width;
    public nuint Height;
    public nuint Depth;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Range
{
    public nuint Location;
    public nuint Length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4BufferRange
{
    public nuint Offset;
    public nuint Length;
}

[StructLayout(LayoutKind.Sequential)]
public struct NSRange
{
    public nuint Location;
    public nuint Length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4CopySparseBufferMappingOperation
{
    public nuint SourceStartPage;
    public nuint DestinationStartPage;
    public nuint PageCount;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4CopySparseTextureMappingOperation
{
    public MTLRegion SourceRegion;
    public nuint SourceMipLevel;
    public nuint SourceSlice;
    public MTL4Origin DestinationOrigin;
    public nuint DestinationMipLevel;
    public nuint DestinationSlice;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4UpdateSparseBufferMappingOperation
{
    public nuint StartPage;
    public nuint PageCount;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4UpdateSparseTextureMappingOperation
{
    public MTLRegion Region;
    public nuint MipLevel;
    public nuint Slice;
}
