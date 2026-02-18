namespace Metal.NET;

public class MTL4AccelerationStructureTriangleGeometryDescriptor(nint nativePtr) : MTL4AccelerationStructureGeometryDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureTriangleGeometryDescriptor");

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.IndexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.IndexType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.SetIndexType, (ulong)value);
    }

    public MTL4BufferRange TransformationMatrixBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.TransformationMatrixBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.TransformationMatrixLayout));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (ulong)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.SetTriangleCount, value);
    }

    public MTL4BufferRange VertexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.VertexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBuffer, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.VertexFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.SetVertexFormat, (ulong)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorSelector.SetVertexStride, value);
    }

    public static implicit operator nint(MTL4AccelerationStructureTriangleGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4AccelerationStructureTriangleGeometryDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTL4AccelerationStructureTriangleGeometryDescriptorSelector
{
    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector TransformationMatrixBuffer = Selector.Register("transformationMatrixBuffer");

    public static readonly Selector SetTransformationMatrixBuffer = Selector.Register("setTransformationMatrixBuffer:");

    public static readonly Selector TransformationMatrixLayout = Selector.Register("transformationMatrixLayout");

    public static readonly Selector SetTransformationMatrixLayout = Selector.Register("setTransformationMatrixLayout:");

    public static readonly Selector TriangleCount = Selector.Register("triangleCount");

    public static readonly Selector SetTriangleCount = Selector.Register("setTriangleCount:");

    public static readonly Selector VertexBuffer = Selector.Register("vertexBuffer");

    public static readonly Selector SetVertexBuffer = Selector.Register("setVertexBuffer:");

    public static readonly Selector VertexFormat = Selector.Register("vertexFormat");

    public static readonly Selector SetVertexFormat = Selector.Register("setVertexFormat:");

    public static readonly Selector VertexStride = Selector.Register("vertexStride");

    public static readonly Selector SetVertexStride = Selector.Register("setVertexStride:");
}
