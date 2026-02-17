using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructureCurveGeometryDescriptor_Selectors
{
    internal static readonly Selector setControlPointBuffer_ = Selector.Register("setControlPointBuffer:");
    internal static readonly Selector setControlPointBufferOffset_ = Selector.Register("setControlPointBufferOffset:");
    internal static readonly Selector setControlPointCount_ = Selector.Register("setControlPointCount:");
    internal static readonly Selector setControlPointFormat_ = Selector.Register("setControlPointFormat:");
    internal static readonly Selector setControlPointStride_ = Selector.Register("setControlPointStride:");
    internal static readonly Selector setCurveBasis_ = Selector.Register("setCurveBasis:");
    internal static readonly Selector setCurveEndCaps_ = Selector.Register("setCurveEndCaps:");
    internal static readonly Selector setCurveType_ = Selector.Register("setCurveType:");
    internal static readonly Selector setIndexBuffer_ = Selector.Register("setIndexBuffer:");
    internal static readonly Selector setIndexBufferOffset_ = Selector.Register("setIndexBufferOffset:");
    internal static readonly Selector setIndexType_ = Selector.Register("setIndexType:");
    internal static readonly Selector setRadiusBuffer_ = Selector.Register("setRadiusBuffer:");
    internal static readonly Selector setRadiusBufferOffset_ = Selector.Register("setRadiusBufferOffset:");
    internal static readonly Selector setRadiusFormat_ = Selector.Register("setRadiusFormat:");
    internal static readonly Selector setRadiusStride_ = Selector.Register("setRadiusStride:");
    internal static readonly Selector setSegmentControlPointCount_ = Selector.Register("setSegmentControlPointCount:");
    internal static readonly Selector setSegmentCount_ = Selector.Register("setSegmentCount:");
    internal static readonly Selector descriptor = Selector.Register("descriptor");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLAccelerationStructureCurveGeometryDescriptor
{
    public readonly nint NativePtr;

    public MTLAccelerationStructureCurveGeometryDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructureCurveGeometryDescriptor o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructureCurveGeometryDescriptor(nint ptr) => new MTLAccelerationStructureCurveGeometryDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureCurveGeometryDescriptor");

    public void SetControlPointBuffer(MTLBuffer controlPointBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setControlPointBuffer_, controlPointBuffer.NativePtr);
    }

    public void SetControlPointBufferOffset(nuint controlPointBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setControlPointBufferOffset_, (nint)controlPointBufferOffset);
    }

    public void SetControlPointCount(nuint controlPointCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setControlPointCount_, (nint)controlPointCount);
    }

    public void SetControlPointFormat(MTLAttributeFormat controlPointFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setControlPointFormat_, (nint)(uint)controlPointFormat);
    }

    public void SetControlPointStride(nuint controlPointStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setControlPointStride_, (nint)controlPointStride);
    }

    public void SetCurveBasis(MTLCurveBasis curveBasis)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setCurveBasis_, (nint)(uint)curveBasis);
    }

    public void SetCurveEndCaps(MTLCurveEndCaps curveEndCaps)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setCurveEndCaps_, (nint)(uint)curveEndCaps);
    }

    public void SetCurveType(MTLCurveType curveType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setCurveType_, (nint)(uint)curveType);
    }

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setIndexBuffer_, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(nuint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setIndexBufferOffset_, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setIndexType_, (nint)(uint)indexType);
    }

    public void SetRadiusBuffer(MTLBuffer radiusBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setRadiusBuffer_, radiusBuffer.NativePtr);
    }

    public void SetRadiusBufferOffset(nuint radiusBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setRadiusBufferOffset_, (nint)radiusBufferOffset);
    }

    public void SetRadiusFormat(MTLAttributeFormat radiusFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setRadiusFormat_, (nint)(uint)radiusFormat);
    }

    public void SetRadiusStride(nuint radiusStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setRadiusStride_, (nint)radiusStride);
    }

    public void SetSegmentControlPointCount(nuint segmentControlPointCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setSegmentControlPointCount_, (nint)segmentControlPointCount);
    }

    public void SetSegmentCount(nuint segmentCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.setSegmentCount_, (nint)segmentCount);
    }

    public static MTLAccelerationStructureCurveGeometryDescriptor Descriptor()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureCurveGeometryDescriptor_Selectors.descriptor);
        return new MTLAccelerationStructureCurveGeometryDescriptor(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
