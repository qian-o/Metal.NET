namespace Metal.NET;

public class MTLAccelerationStructureMotionTriangleGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBuffer, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(uint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBufferOffset, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexType, (nint)(uint)indexType);
    }

    public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, transformationMatrixBuffer.NativePtr);
    }

    public void SetTransformationMatrixBufferOffset(uint transformationMatrixBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset, (nint)transformationMatrixBufferOffset);
    }

    public void SetTransformationMatrixLayout(MTLMatrixLayout transformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (nint)(uint)transformationMatrixLayout);
    }

    public void SetTriangleCount(uint triangleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTriangleCount, (nint)triangleCount);
    }

    public void SetVertexBuffers(NSArray vertexBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexBuffers, vertexBuffers.NativePtr);
    }

    public void SetVertexFormat(MTLAttributeFormat vertexFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexFormat, (nint)(uint)vertexFormat);
    }

    public void SetVertexStride(uint vertexStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexStride, (nint)vertexStride);
    }

    public static MTLAccelerationStructureMotionTriangleGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureMotionTriangleGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector
{
    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");
    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");
    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");
    public static readonly Selector SetTransformationMatrixBuffer = Selector.Register("setTransformationMatrixBuffer:");
    public static readonly Selector SetTransformationMatrixBufferOffset = Selector.Register("setTransformationMatrixBufferOffset:");
    public static readonly Selector SetTransformationMatrixLayout = Selector.Register("setTransformationMatrixLayout:");
    public static readonly Selector SetTriangleCount = Selector.Register("setTriangleCount:");
    public static readonly Selector SetVertexBuffers = Selector.Register("setVertexBuffers:");
    public static readonly Selector SetVertexFormat = Selector.Register("setVertexFormat:");
    public static readonly Selector SetVertexStride = Selector.Register("setVertexStride:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
