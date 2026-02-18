namespace Metal.NET;

public partial class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? BoundingBoxBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.BoundingBoxBuffers);
            return ptr is not 0 ? new(ptr) : null;
        }
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
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.Descriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector
{
    public static readonly Selector BoundingBoxBuffers = Selector.Register("boundingBoxBuffers");

    public static readonly Selector BoundingBoxCount = Selector.Register("boundingBoxCount");

    public static readonly Selector BoundingBoxStride = Selector.Register("boundingBoxStride");

    public static readonly Selector Descriptor = Selector.Register("descriptor");

    public static readonly Selector SetBoundingBoxBuffers = Selector.Register("setBoundingBoxBuffers:");

    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");

    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");
}
