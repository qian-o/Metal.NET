namespace Metal.NET;

public readonly struct MTLAccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLAccelerationStructureGeometryDescriptor(MTLAccelerationStructureMotionTriangleGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLAccelerationStructureMotionTriangleGeometryDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructureMotionTriangleGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructureMotionTriangleGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSArray<MTLMotionKeyframeData> VertexBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexBuffers));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexBuffers, value.NativePtr);
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBuffer, value.NativePtr);
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value.NativePtr);
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

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLBuffer PrimitiveDataBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.PrimitiveDataBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetPrimitiveDataBuffer, value.NativePtr);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.PrimitiveDataBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings.Descriptor);
    }
}

file static class MTLAccelerationStructureMotionTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexBufferOffset = "indexBufferOffset";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataBufferOffset = "primitiveDataBufferOffset";

    public static readonly Selector PrimitiveDataElementSize = "primitiveDataElementSize";

    public static readonly Selector PrimitiveDataStride = "primitiveDataStride";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexBufferOffset = "setIndexBufferOffset:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataBufferOffset = "setPrimitiveDataBufferOffset:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";

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
