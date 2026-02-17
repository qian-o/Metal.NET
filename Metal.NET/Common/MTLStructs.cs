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
public struct MTLSize(uint width, uint height, uint depth)
{
    public nuint Width = width;

    public nuint Height = height;

    public nuint Depth = depth;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLRegion(MTLOrigin origin, MTLSize size)
{
    public MTLOrigin Origin = origin;

    public MTLSize Size = size;
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
public struct MTLClearColor(double red, double green, double blue, double alpha)
{
    public double Red = red;

    public double Green = green;

    public double Blue = blue;

    public double Alpha = alpha;
}

[StructLayout(LayoutKind.Sequential)]
public struct CGSize(double width, double height)
{
    public double Width = width;

    public double Height = height;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSamplePosition(float x, float y)
{
    public float X = x;

    public float Y = y;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSizeAndAlign
{
    public nuint Size;
    public nuint Align;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLRange(nuint location, nuint length)
{
    public nuint Location = location;

    public nuint Length = length;
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
