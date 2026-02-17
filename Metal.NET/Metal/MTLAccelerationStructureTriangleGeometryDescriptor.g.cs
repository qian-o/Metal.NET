namespace Metal.NET;

file class MTLAccelerationStructureTriangleGeometryDescriptorSelector
{
    public static readonly Selector SetIndexBuffer_ = Selector.Register("setIndexBuffer:");
    public static readonly Selector SetIndexBufferOffset_ = Selector.Register("setIndexBufferOffset:");
    public static readonly Selector SetIndexType_ = Selector.Register("setIndexType:");
    public static readonly Selector SetTransformationMatrixBuffer_ = Selector.Register("setTransformationMatrixBuffer:");
    public static readonly Selector SetTransformationMatrixBufferOffset_ = Selector.Register("setTransformationMatrixBufferOffset:");
    public static readonly Selector SetTransformationMatrixLayout_ = Selector.Register("setTransformationMatrixLayout:");
    public static readonly Selector SetTriangleCount_ = Selector.Register("setTriangleCount:");
    public static readonly Selector SetVertexBuffer_ = Selector.Register("setVertexBuffer:");
    public static readonly Selector SetVertexBufferOffset_ = Selector.Register("setVertexBufferOffset:");
    public static readonly Selector SetVertexFormat_ = Selector.Register("setVertexFormat:");
    public static readonly Selector SetVertexStride_ = Selector.Register("setVertexStride:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureTriangleGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureTriangleGeometryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLAccelerationStructureTriangleGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureTriangleGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureTriangleGeometryDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureTriangleGeometryDescriptor");

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBuffer_, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(nuint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBufferOffset_, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexType_, (nint)(uint)indexType);
    }

    public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer_, transformationMatrixBuffer.NativePtr);
    }

    public void SetTransformationMatrixBufferOffset(nuint transformationMatrixBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset_, (nint)transformationMatrixBufferOffset);
    }

    public void SetTransformationMatrixLayout(MTLMatrixLayout transformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout_, (nint)(uint)transformationMatrixLayout);
    }

    public void SetTriangleCount(nuint triangleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTriangleCount_, (nint)triangleCount);
    }

    public void SetVertexBuffer(MTLBuffer vertexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBuffer_, vertexBuffer.NativePtr);
    }

    public void SetVertexBufferOffset(nuint vertexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBufferOffset_, (nint)vertexBufferOffset);
    }

    public void SetVertexFormat(MTLAttributeFormat vertexFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexFormat_, (nint)(uint)vertexFormat);
    }

    public void SetVertexStride(nuint vertexStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexStride_, (nint)vertexStride);
    }

    public static MTLAccelerationStructureTriangleGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureTriangleGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureTriangleGeometryDescriptorSelector.Descriptor));

        return result;
    }

}
