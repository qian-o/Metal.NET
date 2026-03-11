using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct MTL4BufferRange(ulong bufferAddress, ulong length)
{
    public ulong BufferAddress = bufferAddress;

    public ulong Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4CopySparseBufferMappingOperation(NSRange sourceRange, nuint destinationOffset)
{
    public NSRange SourceRange = sourceRange;

    public nuint DestinationOffset = destinationOffset;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4CopySparseTextureMappingOperation(MTLRegion sourceRegion, nuint sourceLevel, nuint sourceSlice, MTLOrigin destinationOrigin, nuint destinationLevel, nuint destinationSlice)
{
    public MTLRegion SourceRegion = sourceRegion;

    public nuint SourceLevel = sourceLevel;

    public nuint SourceSlice = sourceSlice;

    public MTLOrigin DestinationOrigin = destinationOrigin;

    public nuint DestinationLevel = destinationLevel;

    public nuint DestinationSlice = destinationSlice;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4TimestampHeapEntry(ulong timestamp)
{
    public ulong Timestamp = timestamp;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4UpdateSparseBufferMappingOperation(MTLSparseTextureMappingMode mode, NSRange bufferRange, nuint heapOffset)
{
    public MTLSparseTextureMappingMode Mode = mode;

    public NSRange BufferRange = bufferRange;

    public nuint HeapOffset = heapOffset;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTL4UpdateSparseTextureMappingOperation(MTLSparseTextureMappingMode mode, MTLRegion textureRegion, nuint textureLevel, nuint textureSlice, nuint heapOffset)
{
    public MTLSparseTextureMappingMode Mode = mode;

    public MTLRegion TextureRegion = textureRegion;

    public nuint TextureLevel = textureLevel;

    public nuint TextureSlice = textureSlice;

    public nuint HeapOffset = heapOffset;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLAccelerationStructureInstanceDescriptor(MTLPackedFloat4x3 transformationMatrix, MTLAccelerationStructureInstanceOptions options, uint mask, uint intersectionFunctionTableOffset, uint accelerationStructureIndex)
{
    public MTLPackedFloat4x3 TransformationMatrix = transformationMatrix;

    public MTLAccelerationStructureInstanceOptions Options = options;

    public uint Mask = mask;

    public uint IntersectionFunctionTableOffset = intersectionFunctionTableOffset;

    public uint AccelerationStructureIndex = accelerationStructureIndex;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLAccelerationStructureMotionInstanceDescriptor(MTLAccelerationStructureInstanceOptions options, uint mask, uint intersectionFunctionTableOffset, uint accelerationStructureIndex, uint userID, uint motionTransformsStartIndex, uint motionTransformsCount, MTLMotionBorderMode motionStartBorderMode, MTLMotionBorderMode motionEndBorderMode, float motionStartTime, float motionEndTime)
{
    public MTLAccelerationStructureInstanceOptions Options = options;

    public uint Mask = mask;

    public uint IntersectionFunctionTableOffset = intersectionFunctionTableOffset;

    public uint AccelerationStructureIndex = accelerationStructureIndex;

    public uint UserID = userID;

    public uint MotionTransformsStartIndex = motionTransformsStartIndex;

    public uint MotionTransformsCount = motionTransformsCount;

    public MTLMotionBorderMode MotionStartBorderMode = motionStartBorderMode;

    public MTLMotionBorderMode MotionEndBorderMode = motionEndBorderMode;

    public float MotionStartTime = motionStartTime;

    public float MotionEndTime = motionEndTime;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLAccelerationStructureSizes(nuint accelerationStructureSize, nuint buildScratchBufferSize, nuint refitScratchBufferSize)
{
    public nuint AccelerationStructureSize = accelerationStructureSize;

    public nuint BuildScratchBufferSize = buildScratchBufferSize;

    public nuint RefitScratchBufferSize = refitScratchBufferSize;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLAccelerationStructureUserIDInstanceDescriptor(MTLPackedFloat4x3 transformationMatrix, MTLAccelerationStructureInstanceOptions options, uint mask, uint intersectionFunctionTableOffset, uint accelerationStructureIndex, uint userID)
{
    public MTLPackedFloat4x3 TransformationMatrix = transformationMatrix;

    public MTLAccelerationStructureInstanceOptions Options = options;

    public uint Mask = mask;

    public uint IntersectionFunctionTableOffset = intersectionFunctionTableOffset;

    public uint AccelerationStructureIndex = accelerationStructureIndex;

    public uint UserID = userID;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLAxisAlignedBoundingBox(MTLPackedFloat3 min, MTLPackedFloat3 max)
{
    public MTLPackedFloat3 Min = min;

    public MTLPackedFloat3 Max = max;
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
public struct MTLComponentTransform(MTLPackedFloat3 scale, MTLPackedFloat3 shear, MTLPackedFloat3 pivot, MTLPackedFloatQuaternion rotation, MTLPackedFloat3 translation)
{
    public MTLPackedFloat3 Scale = scale;

    public MTLPackedFloat3 Shear = shear;

    public MTLPackedFloat3 Pivot = pivot;

    public MTLPackedFloatQuaternion Rotation = rotation;

    public MTLPackedFloat3 Translation = translation;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLCounterResultStageUtilization(ulong totalCycles, ulong vertexCycles, ulong tessellationCycles, ulong postTessellationVertexCycles, ulong fragmentCycles, ulong renderTargetCycles)
{
    public ulong TotalCycles = totalCycles;

    public ulong VertexCycles = vertexCycles;

    public ulong TessellationCycles = tessellationCycles;

    public ulong PostTessellationVertexCycles = postTessellationVertexCycles;

    public ulong FragmentCycles = fragmentCycles;

    public ulong RenderTargetCycles = renderTargetCycles;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLCounterResultStatistic(ulong tessellationInputPatches, ulong vertexInvocations, ulong postTessellationVertexInvocations, ulong clipperInvocations, ulong clipperPrimitivesOut, ulong fragmentInvocations, ulong fragmentsPassed, ulong computeKernelInvocations)
{
    public ulong TessellationInputPatches = tessellationInputPatches;

    public ulong VertexInvocations = vertexInvocations;

    public ulong PostTessellationVertexInvocations = postTessellationVertexInvocations;

    public ulong ClipperInvocations = clipperInvocations;

    public ulong ClipperPrimitivesOut = clipperPrimitivesOut;

    public ulong FragmentInvocations = fragmentInvocations;

    public ulong FragmentsPassed = fragmentsPassed;

    public ulong ComputeKernelInvocations = computeKernelInvocations;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLCounterResultTimestamp(ulong timestamp)
{
    public ulong Timestamp = timestamp;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLDispatchThreadgroupsIndirectArguments(uint threadgroupsPerGrid0, uint threadgroupsPerGrid1, uint threadgroupsPerGrid2)
{
    public uint ThreadgroupsPerGrid0 = threadgroupsPerGrid0;

    public uint ThreadgroupsPerGrid1 = threadgroupsPerGrid1;

    public uint ThreadgroupsPerGrid2 = threadgroupsPerGrid2;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLDispatchThreadsIndirectArguments(uint threadsPerGrid0, uint threadsPerGrid1, uint threadsPerGrid2, uint threadsPerThreadgroup0, uint threadsPerThreadgroup1, uint threadsPerThreadgroup2)
{
    public uint ThreadsPerGrid0 = threadsPerGrid0;

    public uint ThreadsPerGrid1 = threadsPerGrid1;

    public uint ThreadsPerGrid2 = threadsPerGrid2;

    public uint ThreadsPerThreadgroup0 = threadsPerThreadgroup0;

    public uint ThreadsPerThreadgroup1 = threadsPerThreadgroup1;

    public uint ThreadsPerThreadgroup2 = threadsPerThreadgroup2;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLDrawIndexedPrimitivesIndirectArguments(uint indexCount, uint instanceCount, uint indexStart, int baseVertex, uint baseInstance)
{
    public uint IndexCount = indexCount;

    public uint InstanceCount = instanceCount;

    public uint IndexStart = indexStart;

    public int BaseVertex = baseVertex;

    public uint BaseInstance = baseInstance;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLDrawPatchIndirectArguments(uint patchCount, uint instanceCount, uint patchStart, uint baseInstance)
{
    public uint PatchCount = patchCount;

    public uint InstanceCount = instanceCount;

    public uint PatchStart = patchStart;

    public uint BaseInstance = baseInstance;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLDrawPrimitivesIndirectArguments(uint vertexCount, uint instanceCount, uint vertexStart, uint baseInstance)
{
    public uint VertexCount = vertexCount;

    public uint InstanceCount = instanceCount;

    public uint VertexStart = vertexStart;

    public uint BaseInstance = baseInstance;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLIndirectAccelerationStructureInstanceDescriptor(MTLPackedFloat4x3 transformationMatrix, MTLAccelerationStructureInstanceOptions options, uint mask, uint intersectionFunctionTableOffset, uint userID, MTLResourceID accelerationStructureID)
{
    public MTLPackedFloat4x3 TransformationMatrix = transformationMatrix;

    public MTLAccelerationStructureInstanceOptions Options = options;

    public uint Mask = mask;

    public uint IntersectionFunctionTableOffset = intersectionFunctionTableOffset;

    public uint UserID = userID;

    public MTLResourceID AccelerationStructureID = accelerationStructureID;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLIndirectAccelerationStructureMotionInstanceDescriptor(MTLAccelerationStructureInstanceOptions options, uint mask, uint intersectionFunctionTableOffset, uint userID, MTLResourceID accelerationStructureID, uint motionTransformsStartIndex, uint motionTransformsCount, MTLMotionBorderMode motionStartBorderMode, MTLMotionBorderMode motionEndBorderMode, float motionStartTime, float motionEndTime)
{
    public MTLAccelerationStructureInstanceOptions Options = options;

    public uint Mask = mask;

    public uint IntersectionFunctionTableOffset = intersectionFunctionTableOffset;

    public uint UserID = userID;

    public MTLResourceID AccelerationStructureID = accelerationStructureID;

    public uint MotionTransformsStartIndex = motionTransformsStartIndex;

    public uint MotionTransformsCount = motionTransformsCount;

    public MTLMotionBorderMode MotionStartBorderMode = motionStartBorderMode;

    public MTLMotionBorderMode MotionEndBorderMode = motionEndBorderMode;

    public float MotionStartTime = motionStartTime;

    public float MotionEndTime = motionEndTime;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLIndirectCommandBufferExecutionRange(uint location, uint length)
{
    public uint Location = location;

    public uint Length = length;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLIntersectionFunctionBufferArguments(ulong intersectionFunctionBuffer, ulong intersectionFunctionBufferSize, ulong intersectionFunctionStride)
{
    public ulong IntersectionFunctionBuffer = intersectionFunctionBuffer;

    public ulong IntersectionFunctionBufferSize = intersectionFunctionBufferSize;

    public ulong IntersectionFunctionStride = intersectionFunctionStride;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLMapIndirectArguments(uint regionOriginX, uint regionOriginY, uint regionOriginZ, uint regionSizeWidth, uint regionSizeHeight, uint regionSizeDepth, uint mipMapLevel, uint sliceId)
{
    public uint RegionOriginX = regionOriginX;

    public uint RegionOriginY = regionOriginY;

    public uint RegionOriginZ = regionOriginZ;

    public uint RegionSizeWidth = regionSizeWidth;

    public uint RegionSizeHeight = regionSizeHeight;

    public uint RegionSizeDepth = regionSizeDepth;

    public uint MipMapLevel = mipMapLevel;

    public uint SliceId = sliceId;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLOrigin(nuint x, nuint y, nuint z)
{
    public nuint X = x;

    public nuint Y = y;

    public nuint Z = z;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLPackedFloat3(float x, float y, float z)
{
    public float X = x;

    public float Y = y;

    public float Z = z;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLPackedFloat4x3(MTLPackedFloat3 columns0, MTLPackedFloat3 columns1, MTLPackedFloat3 columns2, MTLPackedFloat3 columns3)
{
    public MTLPackedFloat3 Columns0 = columns0;

    public MTLPackedFloat3 Columns1 = columns1;

    public MTLPackedFloat3 Columns2 = columns2;

    public MTLPackedFloat3 Columns3 = columns3;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLPackedFloatQuaternion(float x, float y, float z, float w)
{
    public float X = x;

    public float Y = y;

    public float Z = z;

    public float W = w;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLQuadTessellationFactorsHalf(ushort edgeTessellationFactor0, ushort edgeTessellationFactor1, ushort edgeTessellationFactor2, ushort edgeTessellationFactor3, ushort insideTessellationFactor0, ushort insideTessellationFactor1)
{
    public ushort EdgeTessellationFactor0 = edgeTessellationFactor0;

    public ushort EdgeTessellationFactor1 = edgeTessellationFactor1;

    public ushort EdgeTessellationFactor2 = edgeTessellationFactor2;

    public ushort EdgeTessellationFactor3 = edgeTessellationFactor3;

    public ushort InsideTessellationFactor0 = insideTessellationFactor0;

    public ushort InsideTessellationFactor1 = insideTessellationFactor1;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLRegion(MTLOrigin origin, MTLSize size)
{
    public MTLOrigin Origin = origin;

    public MTLSize Size = size;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLResourceID(ulong impl)
{
    public ulong Impl = impl;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSamplePosition(float x, float y)
{
    public float X = x;

    public float Y = y;
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
public struct MTLSize(nuint width, nuint height, nuint depth)
{
    public nuint Width = width;

    public nuint Height = height;

    public nuint Depth = depth;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLSizeAndAlign(nuint size, nuint align)
{
    public nuint Size = size;

    public nuint Align = align;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLStageInRegionIndirectArguments(uint stageInOrigin0, uint stageInOrigin1, uint stageInOrigin2, uint stageInSize0, uint stageInSize1, uint stageInSize2)
{
    public uint StageInOrigin0 = stageInOrigin0;

    public uint StageInOrigin1 = stageInOrigin1;

    public uint StageInOrigin2 = stageInOrigin2;

    public uint StageInSize0 = stageInSize0;

    public uint StageInSize1 = stageInSize1;

    public uint StageInSize2 = stageInSize2;
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
public struct MTLTriangleTessellationFactorsHalf(ushort edgeTessellationFactor0, ushort edgeTessellationFactor1, ushort edgeTessellationFactor2, ushort insideTessellationFactor)
{
    public ushort EdgeTessellationFactor0 = edgeTessellationFactor0;

    public ushort EdgeTessellationFactor1 = edgeTessellationFactor1;

    public ushort EdgeTessellationFactor2 = edgeTessellationFactor2;

    public ushort InsideTessellationFactor = insideTessellationFactor;
}

[StructLayout(LayoutKind.Sequential)]
public struct MTLVertexAmplificationViewMapping(uint viewportArrayIndexOffset, uint renderTargetArrayIndexOffset)
{
    public uint ViewportArrayIndexOffset = viewportArrayIndexOffset;

    public uint RenderTargetArrayIndexOffset = renderTargetArrayIndexOffset;
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
