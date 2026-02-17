namespace Metal.NET;

file class MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector
{
    public static readonly Selector SetIndexBuffer_ = Selector.Register("setIndexBuffer:");
    public static readonly Selector SetIndexBufferOffset_ = Selector.Register("setIndexBufferOffset:");
    public static readonly Selector SetIndexType_ = Selector.Register("setIndexType:");
    public static readonly Selector SetTransformationMatrixBuffer_ = Selector.Register("setTransformationMatrixBuffer:");
    public static readonly Selector SetTransformationMatrixBufferOffset_ = Selector.Register("setTransformationMatrixBufferOffset:");
    public static readonly Selector SetTransformationMatrixLayout_ = Selector.Register("setTransformationMatrixLayout:");
    public static readonly Selector SetTriangleCount_ = Selector.Register("setTriangleCount:");
    public static readonly Selector SetVertexBuffers_ = Selector.Register("setVertexBuffers:");
    public static readonly Selector SetVertexFormat_ = Selector.Register("setVertexFormat:");
    public static readonly Selector SetVertexStride_ = Selector.Register("setVertexStride:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureMotionTriangleGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLAccelerationStructureMotionTriangleGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureMotionTriangleGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBuffer_, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(nuint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBufferOffset_, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexType_, (nint)(uint)indexType);
    }

    public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer_, transformationMatrixBuffer.NativePtr);
    }

    public void SetTransformationMatrixBufferOffset(nuint transformationMatrixBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset_, (nint)transformationMatrixBufferOffset);
    }

    public void SetTransformationMatrixLayout(MTLMatrixLayout transformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout_, (nint)(uint)transformationMatrixLayout);
    }

    public void SetTriangleCount(nuint triangleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTriangleCount_, (nint)triangleCount);
    }

    public void SetVertexBuffers(NSArray vertexBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexBuffers_, vertexBuffers.NativePtr);
    }

    public void SetVertexFormat(MTLAttributeFormat vertexFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexFormat_, (nint)(uint)vertexFormat);
    }

    public void SetVertexStride(nuint vertexStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexStride_, (nint)vertexStride);
    }

    public static MTLAccelerationStructureMotionTriangleGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureMotionTriangleGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.Descriptor));

        return result;
    }

}
