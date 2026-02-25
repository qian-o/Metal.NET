namespace Metal.NET;

public class MTL4AccelerationStructureTriangleGeometryDescriptor(nint nativePtr, bool ownsReference) : MTL4AccelerationStructureGeometryDescriptor(nativePtr, ownsReference), INativeObject<MTL4AccelerationStructureTriangleGeometryDescriptor>
{
    public static new MTL4AccelerationStructureTriangleGeometryDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static new MTL4AccelerationStructureTriangleGeometryDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4AccelerationStructureTriangleGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureTriangleGeometryDescriptorBindings.Class), true)
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

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetTransformationMatrixBuffer = "setTransformationMatrixBuffer:";

    public static readonly Selector SetTransformationMatrixLayout = "setTransformationMatrixLayout:";

    public static readonly Selector SetTriangleCount = "setTriangleCount:";

    public static readonly Selector SetVertexBuffer = "setVertexBuffer:";

    public static readonly Selector SetVertexFormat = "setVertexFormat:";

    public static readonly Selector SetVertexStride = "setVertexStride:";

    public static readonly Selector TransformationMatrixBuffer = "transformationMatrixBuffer";

    public static readonly Selector TransformationMatrixLayout = "transformationMatrixLayout";

    public static readonly Selector TriangleCount = "triangleCount";

    public static readonly Selector VertexBuffer = "vertexBuffer";

    public static readonly Selector VertexFormat = "vertexFormat";

    public static readonly Selector VertexStride = "vertexStride";
}
