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
public struct MTLViewport(double originX, double originY, double width, double height, double znear, double zfar)
{
    public double OriginX = originX;

    public double OriginY = originY;

    public double Width = width;

    public double Height = height;

    public double Znear = znear;

    public double Zfar = zfar;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLScissorRect(uint x, uint y, uint width, uint height)
{
    public nuint X = x;

    public nuint Y = y;

    public nuint Width = width;

    public nuint Height = height;
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
public struct MTLSizeAndAlign(uint size, uint align)
{
    public nuint Size = size;

    public nuint Align = align;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLRange(nuint location, nuint length)
{
    public nuint Location = location;

    public nuint Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLResourceID(ulong impl)
{
    public ulong Impl = impl;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLVertexAmplificationViewMapping(uint viewportArrayIndexOffset, uint renderTargetArrayIndexOffset)
{
    public uint ViewportArrayIndexOffset = viewportArrayIndexOffset;

    public uint RenderTargetArrayIndexOffset = renderTargetArrayIndexOffset;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Origin(uint x, uint y, uint z)
{
    public nuint X = x;

    public nuint Y = y;

    public nuint Z = z;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Size(uint width, uint height, uint depth)
{
    public nuint Width = width;

    public nuint Height = height;

    public nuint Depth = depth;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Range(uint location, uint length)
{
    public nuint Location = location;

    public nuint Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4BufferRange(uint offset, uint length)
{
    public nuint Offset = offset;

    public nuint Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct NSRange(uint location, uint length)
{
    public nuint Location = location;

    public nuint Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4CopySparseBufferMappingOperation(uint sourceStartPage, uint destinationStartPage, uint pageCount)
{
    public nuint SourceStartPage = sourceStartPage;

    public nuint DestinationStartPage = destinationStartPage;

    public nuint PageCount = pageCount;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4CopySparseTextureMappingOperation(MTLRegion sourceRegion, uint sourceMipLevel, uint sourceSlice, MTL4Origin destinationOrigin, uint destinationMipLevel, uint destinationSlice)
{
    public MTLRegion SourceRegion = sourceRegion;

    public nuint SourceMipLevel = sourceMipLevel;

    public nuint SourceSlice = sourceSlice;

    public MTL4Origin DestinationOrigin = destinationOrigin;

    public nuint DestinationMipLevel = destinationMipLevel;

    public nuint DestinationSlice = destinationSlice;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4UpdateSparseBufferMappingOperation(uint startPage, uint pageCount)
{
    public nuint StartPage = startPage;

    public nuint PageCount = pageCount;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4UpdateSparseTextureMappingOperation(MTLRegion region, uint mipLevel, uint slice)
{
    public MTLRegion Region = region;

    public nuint MipLevel = mipLevel;

    public nuint Slice = slice;
}
