namespace Metal.NET;

public class MTLAccelerationStructureTriangleGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTLAccelerationStructureTriangleGeometryDescriptor>
{
    #region INativeObject
    public static new MTLAccelerationStructureTriangleGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructureTriangleGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAccelerationStructureTriangleGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureTriangleGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBuffer VertexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBuffer, value);
    }

    public nuint VertexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBufferOffset, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }

    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTLBuffer TransformationMatrixBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    public nuint TransformationMatrixBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBufferOffset, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureTriangleGeometryDescriptorBindings.Class, MTLAccelerationStructureTriangleGeometryDescriptorBindings.Descriptor);
    }
}

file static class MTLAccelerationStructureTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureTriangleGeometryDescriptor");

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexBufferOffset = "indexBufferOffset";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexBufferOffset = "setIndexBufferOffset:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetTransformationMatrixBuffer = "setTransformationMatrixBuffer:";

    public static readonly Selector SetTransformationMatrixBufferOffset = "setTransformationMatrixBufferOffset:";

    public static readonly Selector SetTransformationMatrixLayout = "setTransformationMatrixLayout:";

    public static readonly Selector SetTriangleCount = "setTriangleCount:";

    public static readonly Selector SetVertexBuffer = "setVertexBuffer:";

    public static readonly Selector SetVertexBufferOffset = "setVertexBufferOffset:";

    public static readonly Selector SetVertexFormat = "setVertexFormat:";

    public static readonly Selector SetVertexStride = "setVertexStride:";

    public static readonly Selector TransformationMatrixBuffer = "transformationMatrixBuffer";

    public static readonly Selector TransformationMatrixBufferOffset = "transformationMatrixBufferOffset";

    public static readonly Selector TransformationMatrixLayout = "transformationMatrixLayout";

    public static readonly Selector TriangleCount = "triangleCount";

    public static readonly Selector VertexBuffer = "vertexBuffer";

    public static readonly Selector VertexBufferOffset = "vertexBufferOffset";

    public static readonly Selector VertexFormat = "vertexFormat";

    public static readonly Selector VertexStride = "vertexStride";
}
