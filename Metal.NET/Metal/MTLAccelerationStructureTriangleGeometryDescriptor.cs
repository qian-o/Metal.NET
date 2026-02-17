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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBuffer, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(uint indexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBufferOffset, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexType, (nint)(uint)indexType);
    }

    public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, transformationMatrixBuffer.NativePtr);
    }

    public void SetTransformationMatrixBufferOffset(uint transformationMatrixBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset, (nint)transformationMatrixBufferOffset);
    }

    public void SetTransformationMatrixLayout(MTLMatrixLayout transformationMatrixLayout)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (nint)(uint)transformationMatrixLayout);
    }

    public void SetTriangleCount(uint triangleCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTriangleCount, (nint)triangleCount);
    }

    public void SetVertexBuffer(MTLBuffer vertexBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBuffer, vertexBuffer.NativePtr);
    }

    public void SetVertexBufferOffset(uint vertexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBufferOffset, (nint)vertexBufferOffset);
    }

    public void SetVertexFormat(MTLAttributeFormat vertexFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexFormat, (nint)(uint)vertexFormat);
    }

    public void SetVertexStride(uint vertexStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexStride, (nint)vertexStride);
    }

    public static MTLAccelerationStructureTriangleGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureTriangleGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLAccelerationStructureTriangleGeometryDescriptorSelector.Descriptor));

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
