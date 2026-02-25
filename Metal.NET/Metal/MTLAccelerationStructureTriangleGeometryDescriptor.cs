namespace Metal.NET;

public class MTLAccelerationStructureTriangleGeometryDescriptor(nint nativePtr, bool ownsReference) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownsReference), INativeObject<MTLAccelerationStructureTriangleGeometryDescriptor>
{
    public static new MTLAccelerationStructureTriangleGeometryDescriptor Null { get; } = new(0, false);

    public static new MTLAccelerationStructureTriangleGeometryDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLAccelerationStructureTriangleGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureTriangleGeometryDescriptorBindings.Class), true)
    {
        IsFullyManaged = true;
    }

    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public MTLBuffer TransformationMatrixBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    public nuint TransformationMatrixBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBufferOffset, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTLBuffer VertexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBuffer, value);
    }

    public nuint VertexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBufferOffset, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }

    public static MTLAccelerationStructureTriangleGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureTriangleGeometryDescriptorBindings.Class, MTLAccelerationStructureTriangleGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, true);
    }
}

file static class MTLAccelerationStructureTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureTriangleGeometryDescriptor");

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
