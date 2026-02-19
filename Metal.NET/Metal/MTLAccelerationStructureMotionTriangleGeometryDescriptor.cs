namespace Metal.NET;

public readonly struct MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLAccelerationStructureMotionTriangleGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Class))
    {
    }

    public MTLBuffer? IndexBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBuffer, value?.NativePtr ?? 0);
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

    public MTLBuffer? TransformationMatrixBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value?.NativePtr ?? 0);
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

    public NSArray? VertexBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexBuffers);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexBuffers, value?.NativePtr ?? 0);
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

    public static MTLAccelerationStructureMotionTriangleGeometryDescriptor? Descriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Descriptor);
        return ptr is not 0 ? new MTLAccelerationStructureMotionTriangleGeometryDescriptor(ptr) : default;
    }
}

file static class MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");

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

    public static readonly Selector SetVertexBuffers = Selector.Register("setVertexBuffers:");

    public static readonly Selector SetVertexFormat = Selector.Register("setVertexFormat:");

    public static readonly Selector SetVertexStride = Selector.Register("setVertexStride:");

    public static readonly Selector TransformationMatrixBuffer = Selector.Register("transformationMatrixBuffer");

    public static readonly Selector TransformationMatrixBufferOffset = Selector.Register("transformationMatrixBufferOffset");

    public static readonly Selector TransformationMatrixLayout = Selector.Register("transformationMatrixLayout");

    public static readonly Selector TriangleCount = Selector.Register("triangleCount");

    public static readonly Selector VertexBuffers = Selector.Register("vertexBuffers");

    public static readonly Selector VertexFormat = Selector.Register("vertexFormat");

    public static readonly Selector VertexStride = Selector.Register("vertexStride");
}
