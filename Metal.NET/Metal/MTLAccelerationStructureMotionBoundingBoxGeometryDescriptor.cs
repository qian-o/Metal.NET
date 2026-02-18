namespace Metal.NET;

public class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr) : MTLAccelerationStructureGeometryDescriptor(nativePtr)
{
    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.Class))
    {
    }

    public NSArray? BoundingBoxBuffers
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.BoundingBoxBuffers));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffers, value?.NativePtr ?? 0);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.BoundingBoxCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.BoundingBoxStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride, value);
    }

    public static MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor? Descriptor()
    {
        return GetNullableObject<MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.Class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.Descriptor));
    }
}

file static class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public static readonly Selector BoundingBoxBuffers = Selector.Register("boundingBoxBuffers");

    public static readonly Selector BoundingBoxCount = Selector.Register("boundingBoxCount");

    public static readonly Selector BoundingBoxStride = Selector.Register("boundingBoxStride");

    public static readonly Selector Descriptor = Selector.Register("descriptor");

    public static readonly Selector SetBoundingBoxBuffers = Selector.Register("setBoundingBoxBuffers:");

    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");

    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");
}
