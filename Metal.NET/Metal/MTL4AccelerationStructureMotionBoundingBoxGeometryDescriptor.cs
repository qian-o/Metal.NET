namespace Metal.NET;

public readonly struct MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor value) => new(value.NativePtr);

    public MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class))
    {
    }

    public MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4BufferRange BoundingBoxBuffers
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffers, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }
}

file static class MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector BoundingBoxBuffers = "boundingBoxBuffers";

    public static readonly Selector BoundingBoxCount = "boundingBoxCount";

    public static readonly Selector BoundingBoxStride = "boundingBoxStride";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

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

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";
}
