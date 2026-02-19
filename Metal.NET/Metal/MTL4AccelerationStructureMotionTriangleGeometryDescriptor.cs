namespace Metal.NET;

public readonly struct MTL4AccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4AccelerationStructureMotionTriangleGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.Class))
    {
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public MTL4BufferRange TransformationMatrixBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTL4BufferRange VertexBuffers
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexBuffers, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }
}

file static class MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureMotionTriangleGeometryDescriptor");

    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector SetTransformationMatrixBuffer = Selector.Register("setTransformationMatrixBuffer:");

    public static readonly Selector SetTransformationMatrixLayout = Selector.Register("setTransformationMatrixLayout:");

    public static readonly Selector SetTriangleCount = Selector.Register("setTriangleCount:");

    public static readonly Selector SetVertexBuffers = Selector.Register("setVertexBuffers:");

    public static readonly Selector SetVertexFormat = Selector.Register("setVertexFormat:");

    public static readonly Selector SetVertexStride = Selector.Register("setVertexStride:");

    public static readonly Selector TransformationMatrixBuffer = Selector.Register("transformationMatrixBuffer");

    public static readonly Selector TransformationMatrixLayout = Selector.Register("transformationMatrixLayout");

    public static readonly Selector TriangleCount = Selector.Register("triangleCount");

    public static readonly Selector VertexBuffers = Selector.Register("vertexBuffers");

    public static readonly Selector VertexFormat = Selector.Register("vertexFormat");

    public static readonly Selector VertexStride = Selector.Register("vertexStride");
}
