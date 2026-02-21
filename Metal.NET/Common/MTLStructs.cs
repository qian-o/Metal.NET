using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct MTLOrigin(nuint x, nuint y, nuint z)
{
    public nuint X = x;

    public nuint Y = y;

    public nuint Z = z;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSize(nuint width, nuint height, nuint depth)
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
public struct MTLScissorRect(nuint x, nuint y, nuint width, nuint height)
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
public struct MTLSizeAndAlign(nuint size, nuint align)
{
    public nuint Size = size;

    public nuint Align = align;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLAccelerationStructureSizes(nuint accelerationStructureSize, nuint buildScratchBufferSize, nuint refitScratchBufferSize)
{
    public nuint AccelerationStructureSize = accelerationStructureSize;

    public nuint BuildScratchBufferSize = buildScratchBufferSize;

    public nuint RefitScratchBufferSize = refitScratchBufferSize;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLTextureSwizzleChannels(MTLTextureSwizzle red, MTLTextureSwizzle green, MTLTextureSwizzle blue, MTLTextureSwizzle alpha)
{
    public MTLTextureSwizzle Red = red;

    public MTLTextureSwizzle Green = green;

    public MTLTextureSwizzle Blue = blue;

    public MTLTextureSwizzle Alpha = alpha;
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
public struct MTLVertexAmplificationViewMapping(nuint viewportArrayIndexOffset, nuint renderTargetArrayIndexOffset)
{
    public nuint ViewportArrayIndexOffset = viewportArrayIndexOffset;

    public nuint RenderTargetArrayIndexOffset = renderTargetArrayIndexOffset;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Origin(nuint x, nuint y, nuint z)
{
    public nuint X = x;

    public nuint Y = y;

    public nuint Z = z;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Size(nuint width, nuint height, nuint depth)
{
    public nuint Width = width;

    public nuint Height = height;

    public nuint Depth = depth;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4Range(nuint location, nuint length)
{
    public nuint Location = location;

    public nuint Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4BufferRange(nuint offset, nuint length)
{
    public nuint Offset = offset;

    public nuint Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct NSRange(nuint location, nuint length)
{
    public nuint Location = location;

    public nuint Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4CopySparseBufferMappingOperation(nuint sourceStartPage, nuint destinationStartPage, nuint pageCount)
{
    public nuint SourceStartPage = sourceStartPage;

    public nuint DestinationStartPage = destinationStartPage;

    public nuint PageCount = pageCount;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4CopySparseTextureMappingOperation(MTLRegion sourceRegion, nuint sourceMipLevel, nuint sourceSlice, MTL4Origin destinationOrigin, nuint destinationMipLevel, nuint destinationSlice)
{
    public MTLRegion SourceRegion = sourceRegion;

    public nuint SourceMipLevel = sourceMipLevel;

    public nuint SourceSlice = sourceSlice;

    public MTL4Origin DestinationOrigin = destinationOrigin;

    public nuint DestinationMipLevel = destinationMipLevel;

    public nuint DestinationSlice = destinationSlice;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4UpdateSparseBufferMappingOperation(nuint startPage, nuint pageCount)
{
    public nuint StartPage = startPage;

    public nuint PageCount = pageCount;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4UpdateSparseTextureMappingOperation(MTLRegion region, nuint mipLevel, nuint slice)
{
    public MTLRegion Region = region;

    public nuint MipLevel = mipLevel;

    public nuint Slice = slice;
}

[StructLayout(LayoutKind.Sequential)]
public struct SimdFloat4(float x, float y, float z, float w)
{
    public float X = x;

    public float Y = y;

    public float Z = z;

    public float W = w;
}

[StructLayout(LayoutKind.Sequential)]
public struct SimdFloat4x4(SimdFloat4 column0, SimdFloat4 column1, SimdFloat4 column2, SimdFloat4 column3)
{
    public SimdFloat4 Column0 = column0;

    public SimdFloat4 Column1 = column1;

    public SimdFloat4 Column2 = column2;

    public SimdFloat4 Column3 = column3;
}
