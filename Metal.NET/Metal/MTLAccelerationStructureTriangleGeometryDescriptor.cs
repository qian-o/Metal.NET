namespace Metal.NET;

/// <summary>
/// A description of a list of triangle primitives to turn into an acceleration structure.
/// </summary>
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

    #region Configuring the number of triangles - Properties

    /// <summary>
    /// The number of triangles in the buffers.
    /// </summary>
    public nuint TriangleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }
    #endregion

    #region Configuring index data - Properties

    /// <summary>
    /// The data type of indices in the index buffer.
    /// </summary>
    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    /// <summary>
    /// A buffer that contains indices for the vertices that compose the triangle list.
    /// </summary>
    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    /// <summary>
    /// The offset, in bytes, to the first index in the buffer.
    /// </summary>
    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }
    #endregion

    #region Configuring vertex data - Properties

    /// <summary>
    /// The format of each vertex position in the vertex buffer property.
    /// </summary>
    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    /// <summary>
    /// A buffer that contains vertex data.
    /// </summary>
    public MTLBuffer VertexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBuffer, value);
    }

    /// <summary>
    /// The offset, in bytes, for the first vertex in the vertex buffer.
    /// </summary>
    public nuint VertexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBufferOffset, value);
    }

    /// <summary>
    /// The stride, in bytes, between vertices in the vertex buffer.
    /// </summary>
    public nuint VertexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }
    #endregion

    #region Configuring transformation data - Properties

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
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
    #endregion

    public static MTLAccelerationStructureTriangleGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLAccelerationStructureTriangleGeometryDescriptorBindings.Class, MTLAccelerationStructureTriangleGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
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
