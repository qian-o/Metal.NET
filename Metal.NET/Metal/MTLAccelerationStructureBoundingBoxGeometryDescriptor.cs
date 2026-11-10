namespace Metal.NET;

public readonly struct MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLAccelerationStructureGeometryDescriptor(MTLAccelerationStructureBoundingBoxGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLAccelerationStructureBoundingBoxGeometryDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructureBoundingBoxGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructureBoundingBoxGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLBuffer BoundingBoxBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffer, value.NativePtr);
    }

    public nuint BoundingBoxBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBufferOffset, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLBuffer PrimitiveDataBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.PrimitiveDataBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataBuffer, value.NativePtr);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.PrimitiveDataBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Class, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Descriptor);
    }
}

file static class MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureBoundingBoxGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector BoundingBoxBuffer = "boundingBoxBuffer";

    public static readonly Selector BoundingBoxBufferOffset = "boundingBoxBufferOffset";

    public static readonly Selector BoundingBoxCount = "boundingBoxCount";

    public static readonly Selector BoundingBoxStride = "boundingBoxStride";

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataBufferOffset = "primitiveDataBufferOffset";

    public static readonly Selector PrimitiveDataElementSize = "primitiveDataElementSize";

    public static readonly Selector PrimitiveDataStride = "primitiveDataStride";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetBoundingBoxBuffer = "setBoundingBoxBuffer:";

    public static readonly Selector SetBoundingBoxBufferOffset = "setBoundingBoxBufferOffset:";

    public static readonly Selector SetBoundingBoxCount = "setBoundingBoxCount:";

    public static readonly Selector SetBoundingBoxStride = "setBoundingBoxStride:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataBufferOffset = "setPrimitiveDataBufferOffset:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";
}
