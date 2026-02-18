namespace Metal.NET;

public partial class MTL4AccelerationStructureMotionTriangleGeometryDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureMotionTriangleGeometryDescriptor");

    public MTL4AccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.IndexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.SetIndexType, (nuint)value);
    }

    public MTL4BufferRange TransformationMatrixBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.TransformationMatrixBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.TransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.SetTriangleCount, value);
    }

    public MTL4BufferRange VertexBuffers
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.VertexBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexBuffers, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.VertexFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector.SetVertexStride, value);
    }
}

file static class MTL4AccelerationStructureMotionTriangleGeometryDescriptorSelector
{
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
