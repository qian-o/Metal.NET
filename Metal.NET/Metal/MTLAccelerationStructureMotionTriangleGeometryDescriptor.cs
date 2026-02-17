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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBuffer, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(uint indexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBufferOffset, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexType, (nint)(uint)indexType);
    }

    public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, transformationMatrixBuffer.NativePtr);
    }

    public void SetTransformationMatrixBufferOffset(uint transformationMatrixBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset, (nint)transformationMatrixBufferOffset);
    }

    public void SetTransformationMatrixLayout(MTLMatrixLayout transformationMatrixLayout)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (nint)(uint)transformationMatrixLayout);
    }

    public void SetTriangleCount(uint triangleCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTriangleCount, (nint)triangleCount);
    }

    public void SetVertexBuffers(NSArray vertexBuffers)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexBuffers, vertexBuffers.NativePtr);
    }

    public void SetVertexFormat(MTLAttributeFormat vertexFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexFormat, (nint)(uint)vertexFormat);
    }

    public void SetVertexStride(uint vertexStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexStride, (nint)vertexStride);
    }

    public static MTLAccelerationStructureMotionTriangleGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureMotionTriangleGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.Descriptor));

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
