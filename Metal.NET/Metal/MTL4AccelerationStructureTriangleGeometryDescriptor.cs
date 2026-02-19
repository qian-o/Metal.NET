namespace Metal.NET;

public readonly struct MTL4AccelerationStructureTriangleGeometryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4AccelerationStructureTriangleGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureTriangleGeometryDescriptorBindings.Class))
    {
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public MTL4BufferRange TransformationMatrixBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTL4BufferRange VertexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBuffer, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }
}

file static class MTL4AccelerationStructureTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureTriangleGeometryDescriptor");

    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector SetTransformationMatrixBuffer = Selector.Register("setTransformationMatrixBuffer:");

    public static readonly Selector SetTransformationMatrixLayout = Selector.Register("setTransformationMatrixLayout:");

    public static readonly Selector SetTriangleCount = Selector.Register("setTriangleCount:");

    public static readonly Selector SetVertexBuffer = Selector.Register("setVertexBuffer:");

    public static readonly Selector SetVertexFormat = Selector.Register("setVertexFormat:");

    public static readonly Selector SetVertexStride = Selector.Register("setVertexStride:");

    public static readonly Selector TransformationMatrixBuffer = Selector.Register("transformationMatrixBuffer");

    public static readonly Selector TransformationMatrixLayout = Selector.Register("transformationMatrixLayout");

    public static readonly Selector TriangleCount = Selector.Register("triangleCount");

    public static readonly Selector VertexBuffer = Selector.Register("vertexBuffer");

    public static readonly Selector VertexFormat = Selector.Register("vertexFormat");

    public static readonly Selector VertexStride = Selector.Register("vertexStride");
}
