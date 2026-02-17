using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors
{
    internal static readonly Selector setIndexBuffer_ = Selector.Register("setIndexBuffer:");
    internal static readonly Selector setIndexBufferOffset_ = Selector.Register("setIndexBufferOffset:");
    internal static readonly Selector setIndexType_ = Selector.Register("setIndexType:");
    internal static readonly Selector setTransformationMatrixBuffer_ = Selector.Register("setTransformationMatrixBuffer:");
    internal static readonly Selector setTransformationMatrixBufferOffset_ = Selector.Register("setTransformationMatrixBufferOffset:");
    internal static readonly Selector setTransformationMatrixLayout_ = Selector.Register("setTransformationMatrixLayout:");
    internal static readonly Selector setTriangleCount_ = Selector.Register("setTriangleCount:");
    internal static readonly Selector setVertexBuffers_ = Selector.Register("setVertexBuffers:");
    internal static readonly Selector setVertexFormat_ = Selector.Register("setVertexFormat:");
    internal static readonly Selector setVertexStride_ = Selector.Register("setVertexStride:");
    internal static readonly Selector descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureMotionTriangleGeometryDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructureMotionTriangleGeometryDescriptor o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint ptr) => new MTLAccelerationStructureMotionTriangleGeometryDescriptor(ptr);

    ~MTLAccelerationStructureMotionTriangleGeometryDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setIndexBuffer_, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(nuint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setIndexBufferOffset_, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setIndexType_, (nint)(uint)indexType);
    }

    public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setTransformationMatrixBuffer_, transformationMatrixBuffer.NativePtr);
    }

    public void SetTransformationMatrixBufferOffset(nuint transformationMatrixBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setTransformationMatrixBufferOffset_, (nint)transformationMatrixBufferOffset);
    }

    public void SetTransformationMatrixLayout(MTLMatrixLayout transformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setTransformationMatrixLayout_, (nint)(uint)transformationMatrixLayout);
    }

    public void SetTriangleCount(nuint triangleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setTriangleCount_, (nint)triangleCount);
    }

    public void SetVertexBuffers(NSArray vertexBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setVertexBuffers_, vertexBuffers.NativePtr);
    }

    public void SetVertexFormat(MTLAttributeFormat vertexFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setVertexFormat_, (nint)(uint)vertexFormat);
    }

    public void SetVertexStride(nuint vertexStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.setVertexStride_, (nint)vertexStride);
    }

    public static MTLAccelerationStructureMotionTriangleGeometryDescriptor Descriptor()
    {
        var __r = new MTLAccelerationStructureMotionTriangleGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureMotionTriangleGeometryDescriptor_Selectors.descriptor));
        return __r;
    }

}
