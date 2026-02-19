namespace Metal.NET;

public class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr) : MTLAccelerationStructureGeometryDescriptor(nativePtr)
{
    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class))
    {
    }

    public NSArray? BoundingBoxBuffers
    {
        get => GetProperty(ref field, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffers);
        set => SetProperty(ref field, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffers, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }

    public static MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor? Descriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Descriptor);
        return ptr is not 0 ? new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(ptr) : null;
    }
}

file static class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public static readonly Selector BoundingBoxBuffers = "boundingBoxBuffers";

    public static readonly Selector BoundingBoxCount = "boundingBoxCount";

    public static readonly Selector BoundingBoxStride = "boundingBoxStride";

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector SetBoundingBoxBuffers = "setBoundingBoxBuffers:";

    public static readonly Selector SetBoundingBoxCount = "setBoundingBoxCount:";

    public static readonly Selector SetBoundingBoxStride = "setBoundingBoxStride:";
}
