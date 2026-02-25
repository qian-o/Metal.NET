namespace Metal.NET;

public class MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr, bool ownsReference) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownsReference), INativeObject<MTLAccelerationStructureMotionTriangleGeometryDescriptor>
{
    public static new MTLAccelerationStructureMotionTriangleGeometryDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTLAccelerationStructureMotionTriangleGeometryDescriptor Null => Create(0, false);
    public static new MTLAccelerationStructureMotionTriangleGeometryDescriptor Empty => Null;

    public MTLAccelerationStructureMotionTriangleGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Class), true)
    {
    }

    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public MTLBuffer TransformationMatrixBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    public nuint TransformationMatrixBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBufferOffset, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTLMotionKeyframeData[] VertexBuffers
    {
        get => GetArrayProperty<MTLMotionKeyframeData>(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexBuffers);
        set => SetArrayProperty(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexBuffers, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }

    public static MTLAccelerationStructureMotionTriangleGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, false);
    }
}

file static class MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");

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
