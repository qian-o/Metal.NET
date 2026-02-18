namespace Metal.NET;

public partial class MTLAccelerationStructureTriangleGeometryDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureTriangleGeometryDescriptor");

    public MTLAccelerationStructureTriangleGeometryDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBuffer? IndexBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.IndexBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBuffer, value?.NativePtr ?? 0);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexType, (nuint)value);
    }

    public MTLBuffer? TransformationMatrixBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.TransformationMatrixBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, value?.NativePtr ?? 0);
    }

    public nuint TransformationMatrixBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.TransformationMatrixBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.TransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTriangleCount, value);
    }

    public MTLBuffer? VertexBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.VertexBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBuffer, value?.NativePtr ?? 0);
    }

    public nuint VertexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.VertexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBufferOffset, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.VertexFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexStride, value);
    }

    public static MTLAccelerationStructureTriangleGeometryDescriptor? Descriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLAccelerationStructureTriangleGeometryDescriptorSelector.Descriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLAccelerationStructureTriangleGeometryDescriptorSelector
{
    public static readonly Selector Descriptor = Selector.Register("descriptor");

    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector IndexBufferOffset = Selector.Register("indexBufferOffset");

    public static readonly Selector IndexType = Selector.Register("indexType");

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

    public static readonly Selector TransformationMatrixBuffer = Selector.Register("transformationMatrixBuffer");

    public static readonly Selector TransformationMatrixBufferOffset = Selector.Register("transformationMatrixBufferOffset");

    public static readonly Selector TransformationMatrixLayout = Selector.Register("transformationMatrixLayout");

    public static readonly Selector TriangleCount = Selector.Register("triangleCount");

    public static readonly Selector VertexBuffer = Selector.Register("vertexBuffer");

    public static readonly Selector VertexBufferOffset = Selector.Register("vertexBufferOffset");

    public static readonly Selector VertexFormat = Selector.Register("vertexFormat");

    public static readonly Selector VertexStride = Selector.Register("vertexStride");
}
