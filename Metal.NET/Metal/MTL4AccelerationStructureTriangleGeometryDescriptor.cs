namespace Metal.NET;

/// <summary>
/// Describes triangle geometry suitable for ray tracing.
/// </summary>
public class MTL4AccelerationStructureTriangleGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4AccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTL4AccelerationStructureTriangleGeometryDescriptor>
{
    #region INativeObject
    public static new MTL4AccelerationStructureTriangleGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4AccelerationStructureTriangleGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4AccelerationStructureTriangleGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureTriangleGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Sets an optional index buffer containing references to vertices in the vertexBuffer.
    /// </summary>
    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    /// <summary>
    /// Configures the size of the indices the indexBuffer contains, which is typically either 16 or 32-bits for each index.
    /// </summary>
    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    /// <summary>
    /// Assigns an optional reference to a buffer containing a float4x3 transformation matrix.
    /// </summary>
    public MTL4BufferRange TransformationMatrixBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    /// <summary>
    /// Configures the layout for the transformation matrix in the transformation matrix buffer.
    /// </summary>
    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    /// <summary>
    /// Declares the number of triangles in this geometry descriptor.
    /// </summary>
    public nuint TriangleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    /// <summary>
    /// Associates a vertex buffer containing triangle vertices.
    /// </summary>
    public MTL4BufferRange VertexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBuffer, value);
    }

    /// <summary>
    /// Describes the format of the vertices in the vertex buffer.
    /// </summary>
    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    /// <summary>
    /// Sets the stride, in bytes, between vertices in the vertex buffer.
    /// </summary>
    public nuint VertexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }
    #endregion
}

file static class MTL4AccelerationStructureTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureTriangleGeometryDescriptor");

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
