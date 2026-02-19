namespace Metal.NET;

public class MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAccelerationStructureBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Class))
    {
    }

    public MTLBuffer? BoundingBoxBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBuffer(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffer, value?.NativePtr ?? 0);
            field = value;
        }
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

    public static MTLAccelerationStructureBoundingBoxGeometryDescriptor? Descriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Class, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Descriptor);
        return ptr is not 0 ? new MTLAccelerationStructureBoundingBoxGeometryDescriptor(ptr) : null;
    }
}

file static class MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings
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
