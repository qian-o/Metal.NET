namespace Metal.NET;

public class MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr) : MTLAccelerationStructureGeometryDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");

    public MTLBuffer IndexBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.IndexBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBuffer, value.NativePtr);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.IndexType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexType, (ulong)value);
    }

    public MTLBuffer TransformationMatrixBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.TransformationMatrixBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, value.NativePtr);
    }

    public nuint TransformationMatrixBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.TransformationMatrixBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.TransformationMatrixLayout));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (ulong)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTriangleCount, value);
    }

    public NSArray VertexBuffers
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.VertexBuffers));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexBuffers, value.NativePtr);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.VertexFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexFormat, (ulong)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexStride, value);
    }

    public static implicit operator nint(MTLAccelerationStructureMotionTriangleGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLAccelerationStructureMotionTriangleGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureMotionTriangleGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector.Descriptor));

        return result;
    }
}

file class MTLAccelerationStructureMotionTriangleGeometryDescriptorSelector
{
    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector IndexBufferOffset = Selector.Register("indexBufferOffset");

    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector TransformationMatrixBuffer = Selector.Register("transformationMatrixBuffer");

    public static readonly Selector SetTransformationMatrixBuffer = Selector.Register("setTransformationMatrixBuffer:");

    public static readonly Selector TransformationMatrixBufferOffset = Selector.Register("transformationMatrixBufferOffset");

    public static readonly Selector SetTransformationMatrixBufferOffset = Selector.Register("setTransformationMatrixBufferOffset:");

    public static readonly Selector TransformationMatrixLayout = Selector.Register("transformationMatrixLayout");

    public static readonly Selector SetTransformationMatrixLayout = Selector.Register("setTransformationMatrixLayout:");

    public static readonly Selector TriangleCount = Selector.Register("triangleCount");

    public static readonly Selector SetTriangleCount = Selector.Register("setTriangleCount:");

    public static readonly Selector VertexBuffers = Selector.Register("vertexBuffers");

    public static readonly Selector SetVertexBuffers = Selector.Register("setVertexBuffers:");

    public static readonly Selector VertexFormat = Selector.Register("vertexFormat");

    public static readonly Selector SetVertexFormat = Selector.Register("setVertexFormat:");

    public static readonly Selector VertexStride = Selector.Register("vertexStride");

    public static readonly Selector SetVertexStride = Selector.Register("setVertexStride:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
