namespace Metal.NET;

public class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr, bool ownsReference) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownsReference), INativeObject<MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor>
{
    public static new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Null { get; } = new(0, false);

    public static new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class), true)
    {
    }

    public MTLMotionKeyframeData[] BoundingBoxBuffers
    {
        get => GetArrayProperty<MTLMotionKeyframeData>(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffers);
        set => SetArrayProperty(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffers, value);
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

    public static MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, false);
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
