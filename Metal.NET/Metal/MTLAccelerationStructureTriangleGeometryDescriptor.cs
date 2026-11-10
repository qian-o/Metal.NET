namespace Metal.NET;

public readonly struct MTLAccelerationStructureTriangleGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLAccelerationStructureGeometryDescriptor(MTLAccelerationStructureTriangleGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLAccelerationStructureTriangleGeometryDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructureTriangleGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureTriangleGeometryDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructureTriangleGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLBuffer VertexBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBuffer, value.NativePtr);
    }

    public nuint VertexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexBufferOffset, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexFormat, (nuint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.VertexStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetVertexStride, value);
    }

    public MTLBuffer IndexBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBuffer, value.NativePtr);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TriangleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTriangleCount, value);
    }

    public MTLBuffer TransformationMatrixBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBuffer, value.NativePtr);
    }

    public nuint TransformationMatrixBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixBufferOffset, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.TransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetTransformationMatrixLayout, (nint)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLBuffer PrimitiveDataBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.PrimitiveDataBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetPrimitiveDataBuffer, value.NativePtr);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.PrimitiveDataBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureTriangleGeometryDescriptorBindings.Class, MTLAccelerationStructureTriangleGeometryDescriptorBindings.Descriptor);
    }
}

file static class MTLAccelerationStructureTriangleGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureTriangleGeometryDescriptor");

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
