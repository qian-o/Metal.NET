namespace Metal.NET;

public readonly struct MTL4AccelerationStructureMotionTriangleGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionTriangleGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4AccelerationStructureMotionTriangleGeometryDescriptor value) => new(value.NativePtr);

    public MTL4AccelerationStructureMotionTriangleGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.Class))
    {
    }

    public MTL4AccelerationStructureMotionTriangleGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4BufferRange VertexBuffers
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexBuffers, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTL4BufferRange TransformationMatrixBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }
}

file static class MTL4AccelerationStructureMotionTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureMotionTriangleGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataElementSize = "primitiveDataElementSize";

    public static readonly Selector PrimitiveDataStride = "primitiveDataStride";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";

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
