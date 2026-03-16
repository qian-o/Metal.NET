namespace Metal.NET;

/// <summary>Describes motion triangle geometry, suitable for motion ray tracing.</summary>
public class MTL4AccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4AccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTL4AccelerationStructureMotionTriangleGeometryDescriptor>
{
    #region INativeObject
    public static new MTL4AccelerationStructureMotionTriangleGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4AccelerationStructureMotionTriangleGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4AccelerationStructureMotionTriangleGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>Assigns an optional index buffer containing references to vertices in the vertex buffers you reference through the vertex buffers property.</summary>
    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    /// <summary>Specifies the size of the indices the indexBuffer contains, which is typically either 16 or 32-bits for each index.</summary>
    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    /// <summary>Assings an optional reference to a buffer containing a float4x3 transformation matrix.</summary>
    public MTL4BufferRange TransformationMatrixBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    /// <summary>Configures the layout for the transformation matrix in the transformation matrix buffer.</summary>
    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    /// <summary>Declares the number of triangles in the vertex buffers that the buffer in the vertex buffers property references.</summary>
    public nuint TriangleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    /// <summary>Assigns a buffer where each entry contains a reference to a vertex buffer.</summary>
    public MTL4BufferRange VertexBuffers
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexBuffers, value);
    }

    /// <summary>Defines the format of the vertices in the vertex buffers.</summary>
    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    /// <summary>Sets the stride, in bytes, between vertices in all the vertex buffer.</summary>
    public nuint VertexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }
    #endregion
}

file static class MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureMotionTriangleGeometryDescriptor");

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetTransformationMatrixBuffer = "setTransformationMatrixBuffer:";

    public static readonly Selector SetTransformationMatrixLayout = "setTransformationMatrixLayout:";

    public static readonly Selector SetTriangleCount = "setTriangleCount:";

    public static readonly Selector SetVertexBuffers = "setVertexBuffers:";

    public static readonly Selector SetVertexFormat = "setVertexFormat:";

    public static readonly Selector SetVertexStride = "setVertexStride:";

    public static readonly Selector TransformationMatrixBuffer = "transformationMatrixBuffer";

    public static readonly Selector TransformationMatrixLayout = "transformationMatrixLayout";

    public static readonly Selector TriangleCount = "triangleCount";

    public static readonly Selector VertexBuffers = "vertexBuffers";

    public static readonly Selector VertexFormat = "vertexFormat";

    public static readonly Selector VertexStride = "vertexStride";
}
