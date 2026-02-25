namespace Metal.NET;

public class MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr, bool ownsReference = true) : MTL4AccelerationStructureGeometryDescriptor(nativePtr, ownsReference), INativeObject<MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor>
{
    public static new MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor Create(nint nativePtr) => new(nativePtr);

    public static new MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class))
    {
    }

    public MTL4BufferRange BoundingBoxBuffers
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffers, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }
}

file static class MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public static readonly Selector BoundingBoxBuffers = "boundingBoxBuffers";

    public static readonly Selector BoundingBoxCount = "boundingBoxCount";

    public static readonly Selector BoundingBoxStride = "boundingBoxStride";

    public static readonly Selector SetBoundingBoxBuffers = "setBoundingBoxBuffers:";

    public static readonly Selector SetBoundingBoxCount = "setBoundingBoxCount:";

    public static readonly Selector SetBoundingBoxStride = "setBoundingBoxStride:";
}
