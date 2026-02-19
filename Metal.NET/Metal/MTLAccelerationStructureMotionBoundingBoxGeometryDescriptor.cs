namespace Metal.NET;

public readonly struct MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class))
    {
    }

    public NSArray? BoundingBoxBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffers);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffers, value?.NativePtr ?? 0);
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
        return ptr is not 0 ? new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(ptr) : default;
    }
}

file static class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings
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
