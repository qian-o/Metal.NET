namespace Metal.NET;

public readonly struct MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLAccelerationStructureGeometryDescriptor(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTLMotionKeyframeData> BoundingBoxBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffers));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffers, value.NativePtr);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLBuffer PrimitiveDataBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.PrimitiveDataBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataBuffer, value.NativePtr);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.PrimitiveDataBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Descriptor);
    }
}

file static class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector BoundingBoxBuffers = "boundingBoxBuffers";

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

    public static readonly Selector SetBoundingBoxBuffers = "setBoundingBoxBuffers:";

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
