namespace Metal.NET;

public class MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTLAccelerationStructureMotionTriangleGeometryDescriptor>
{
    #region INativeObject
    public static new MTLAccelerationStructureMotionTriangleGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructureMotionTriangleGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAccelerationStructureMotionTriangleGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLMotionKeyframeData[] VertexBuffers
    {
        get => GetArrayProperty<MTLMotionKeyframeData>(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexBuffers);
        set => SetArrayProperty(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexBuffers, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }

    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTLBuffer TransformationMatrixBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    public nuint TransformationMatrixBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBufferOffset, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Descriptor);
    }
}

file static class MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");

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

    public static readonly Selector SetVertexBuffers = "setVertexBuffers:";

    public static readonly Selector SetVertexFormat = "setVertexFormat:";

    public static readonly Selector SetVertexStride = "setVertexStride:";

    public static readonly Selector TransformationMatrixBuffer = "transformationMatrixBuffer";

    public static readonly Selector TransformationMatrixBufferOffset = "transformationMatrixBufferOffset";

    public static readonly Selector TransformationMatrixLayout = "transformationMatrixLayout";

    public static readonly Selector TriangleCount = "triangleCount";

    public static readonly Selector VertexBuffers = "vertexBuffers";

    public static readonly Selector VertexFormat = "vertexFormat";

    public static readonly Selector VertexStride = "vertexStride";
}
