namespace Metal.NET;

public readonly struct MTL4AccelerationStructureTriangleGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureTriangleGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4AccelerationStructureTriangleGeometryDescriptor value) => new(value.NativePtr);

    public MTL4AccelerationStructureTriangleGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureTriangleGeometryDescriptorBindings.Class))
    {
    }

    public MTL4AccelerationStructureTriangleGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4BufferRange VertexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBuffer, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTL4BufferRange TransformationMatrixBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureTriangleGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }
}

file static class MTL4AccelerationStructureTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureTriangleGeometryDescriptor");

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
