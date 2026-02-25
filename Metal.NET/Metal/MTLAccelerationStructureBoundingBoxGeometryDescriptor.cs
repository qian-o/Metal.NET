namespace Metal.NET;

public class MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr, bool ownsReference) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownsReference), INativeObject<MTLAccelerationStructureBoundingBoxGeometryDescriptor>
{
    public static new MTLAccelerationStructureBoundingBoxGeometryDescriptor Null { get; } = new(0, false);

    public static new MTLAccelerationStructureBoundingBoxGeometryDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLAccelerationStructureBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Class), true)
    {
        IsFullyManaged = true;
    }

    public MTLBuffer BoundingBoxBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffer, value);
    }

    public nuint BoundingBoxBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBufferOffset, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }

    public static MTLAccelerationStructureBoundingBoxGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Class, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, true);
    }
}

file static class MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureBoundingBoxGeometryDescriptor");

    public static readonly Selector BoundingBoxBuffer = "boundingBoxBuffer";

    public static readonly Selector BoundingBoxBufferOffset = "boundingBoxBufferOffset";

    public static readonly Selector BoundingBoxCount = "boundingBoxCount";

    public static readonly Selector BoundingBoxStride = "boundingBoxStride";

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector SetBoundingBoxBuffer = "setBoundingBoxBuffer:";

    public static readonly Selector SetBoundingBoxBufferOffset = "setBoundingBoxBufferOffset:";

    public static readonly Selector SetBoundingBoxCount = "setBoundingBoxCount:";

    public static readonly Selector SetBoundingBoxStride = "setBoundingBoxStride:";
}
