using System.Runtime.InteropServices;

namespace Metal.NET;

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
public struct MTLTriangleTessellationFactorsHalf(ushort insideTessellationFactor)
{
    public ushort InsideTessellationFactor = insideTessellationFactor;
}
