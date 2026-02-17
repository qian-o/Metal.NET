namespace Metal.NET;

public class MTLAccelerationStructureTriangleGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureTriangleGeometryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBuffer, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(uint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBufferOffset, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexType, (nint)(uint)indexType);
    }

    public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, transformationMatrixBuffer.NativePtr);
    }

    public void SetTransformationMatrixBufferOffset(uint transformationMatrixBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset, (nint)transformationMatrixBufferOffset);
    }

    public void SetTransformationMatrixLayout(MTLMatrixLayout transformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (nint)(uint)transformationMatrixLayout);
    }

    public void SetTriangleCount(uint triangleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTriangleCount, (nint)triangleCount);
    }

    public void SetVertexBuffer(MTLBuffer vertexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBuffer, vertexBuffer.NativePtr);
    }

    public void SetVertexBufferOffset(uint vertexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBufferOffset, (nint)vertexBufferOffset);
    }

    public void SetVertexFormat(MTLAttributeFormat vertexFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexFormat, (nint)(uint)vertexFormat);
    }

    public void SetVertexStride(uint vertexStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexStride, (nint)vertexStride);
    }

    public static MTLAccelerationStructureTriangleGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureTriangleGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureTriangleGeometryDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLAccelerationStructureTriangleGeometryDescriptorSelector
{
    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");
    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");
    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");
    public static readonly Selector SetTransformationMatrixBuffer = Selector.Register("setTransformationMatrixBuffer:");
    public static readonly Selector SetTransformationMatrixBufferOffset = Selector.Register("setTransformationMatrixBufferOffset:");
    public static readonly Selector SetTransformationMatrixLayout = Selector.Register("setTransformationMatrixLayout:");
    public static readonly Selector SetTriangleCount = Selector.Register("setTriangleCount:");
    public static readonly Selector SetVertexBuffer = Selector.Register("setVertexBuffer:");
    public static readonly Selector SetVertexBufferOffset = Selector.Register("setVertexBufferOffset:");
    public static readonly Selector SetVertexFormat = Selector.Register("setVertexFormat:");
    public static readonly Selector SetVertexStride = Selector.Register("setVertexStride:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
