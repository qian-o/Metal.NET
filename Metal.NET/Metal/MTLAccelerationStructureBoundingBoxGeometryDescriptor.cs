namespace Metal.NET;

public class MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr) : MTLAccelerationStructureGeometryDescriptor(nativePtr)
{
    public MTLAccelerationStructureBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.Class))
    {
    }

    public MTLBuffer? BoundingBoxBuffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffer, value?.NativePtr ?? 0);
    }

    public nuint BoundingBoxBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBufferOffset, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride, value);
    }

    public static MTLAccelerationStructureBoundingBoxGeometryDescriptor? Descriptor()
    {
        return GetNullableObject<MTLAccelerationStructureBoundingBoxGeometryDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.Class, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.Descriptor));
    }
}

file static class MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureBoundingBoxGeometryDescriptor");

    public static readonly Selector BoundingBoxBuffer = Selector.Register("boundingBoxBuffer");

    public static readonly Selector BoundingBoxBufferOffset = Selector.Register("boundingBoxBufferOffset");

    public static readonly Selector BoundingBoxCount = Selector.Register("boundingBoxCount");

    public static readonly Selector BoundingBoxStride = Selector.Register("boundingBoxStride");

    public static readonly Selector Descriptor = Selector.Register("descriptor");

    public static readonly Selector SetBoundingBoxBuffer = Selector.Register("setBoundingBoxBuffer:");

    public static readonly Selector SetBoundingBoxBufferOffset = Selector.Register("setBoundingBoxBufferOffset:");

    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");

    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");
}
