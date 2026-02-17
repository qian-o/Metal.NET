using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructureTriangleGeometryDescriptor_Selectors
{
    internal static readonly Selector setIndexBuffer_ = Selector.Register("setIndexBuffer:");
    internal static readonly Selector setIndexBufferOffset_ = Selector.Register("setIndexBufferOffset:");
    internal static readonly Selector setIndexType_ = Selector.Register("setIndexType:");
    internal static readonly Selector setTransformationMatrixBuffer_ = Selector.Register("setTransformationMatrixBuffer:");
    internal static readonly Selector setTransformationMatrixBufferOffset_ = Selector.Register("setTransformationMatrixBufferOffset:");
    internal static readonly Selector setTransformationMatrixLayout_ = Selector.Register("setTransformationMatrixLayout:");
    internal static readonly Selector setTriangleCount_ = Selector.Register("setTriangleCount:");
    internal static readonly Selector setVertexBuffer_ = Selector.Register("setVertexBuffer:");
    internal static readonly Selector setVertexBufferOffset_ = Selector.Register("setVertexBufferOffset:");
    internal static readonly Selector setVertexFormat_ = Selector.Register("setVertexFormat:");
    internal static readonly Selector setVertexStride_ = Selector.Register("setVertexStride:");
    internal static readonly Selector descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureTriangleGeometryDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLAccelerationStructureTriangleGeometryDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructureTriangleGeometryDescriptor o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructureTriangleGeometryDescriptor(nint ptr) => new MTLAccelerationStructureTriangleGeometryDescriptor(ptr);

    ~MTLAccelerationStructureTriangleGeometryDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureTriangleGeometryDescriptor");

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setIndexBuffer_, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(nuint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setIndexBufferOffset_, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setIndexType_, (nint)(uint)indexType);
    }

    public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setTransformationMatrixBuffer_, transformationMatrixBuffer.NativePtr);
    }

    public void SetTransformationMatrixBufferOffset(nuint transformationMatrixBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setTransformationMatrixBufferOffset_, (nint)transformationMatrixBufferOffset);
    }

    public void SetTransformationMatrixLayout(MTLMatrixLayout transformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setTransformationMatrixLayout_, (nint)(uint)transformationMatrixLayout);
    }

    public void SetTriangleCount(nuint triangleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setTriangleCount_, (nint)triangleCount);
    }

    public void SetVertexBuffer(MTLBuffer vertexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setVertexBuffer_, vertexBuffer.NativePtr);
    }

    public void SetVertexBufferOffset(nuint vertexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setVertexBufferOffset_, (nint)vertexBufferOffset);
    }

    public void SetVertexFormat(MTLAttributeFormat vertexFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setVertexFormat_, (nint)(uint)vertexFormat);
    }

    public void SetVertexStride(nuint vertexStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.setVertexStride_, (nint)vertexStride);
    }

    public static MTLAccelerationStructureTriangleGeometryDescriptor Descriptor()
    {
        var __r = new MTLAccelerationStructureTriangleGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureTriangleGeometryDescriptor_Selectors.descriptor));
        return __r;
    }

}
