namespace Metal.NET;

public class MTLAccelerationStructureGeometryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAccelerationStructureGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureGeometryDescriptorBindings.Class))
    {
    }

    public bool AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, (Bool8)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public bool Opaque
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.Opaque);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetOpaque, (Bool8)value);
    }

    public MTLBuffer? PrimitiveDataBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataBuffer);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataBuffer, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }
}

file static class MTLAccelerationStructureGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = Selector.Register("allowDuplicateIntersectionFunctionInvocation");

    public static readonly Selector IntersectionFunctionTableOffset = Selector.Register("intersectionFunctionTableOffset");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Opaque = Selector.Register("opaque");

    public static readonly Selector PrimitiveDataBuffer = Selector.Register("primitiveDataBuffer");

    public static readonly Selector PrimitiveDataBufferOffset = Selector.Register("primitiveDataBufferOffset");

    public static readonly Selector PrimitiveDataElementSize = Selector.Register("primitiveDataElementSize");

    public static readonly Selector PrimitiveDataStride = Selector.Register("primitiveDataStride");

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = Selector.Register("setAllowDuplicateIntersectionFunctionInvocation:");

    public static readonly Selector SetIntersectionFunctionTableOffset = Selector.Register("setIntersectionFunctionTableOffset:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetOpaque = Selector.Register("setOpaque:");

    public static readonly Selector SetPrimitiveDataBuffer = Selector.Register("setPrimitiveDataBuffer:");

    public static readonly Selector SetPrimitiveDataBufferOffset = Selector.Register("setPrimitiveDataBufferOffset:");

    public static readonly Selector SetPrimitiveDataElementSize = Selector.Register("setPrimitiveDataElementSize:");

    public static readonly Selector SetPrimitiveDataStride = Selector.Register("setPrimitiveDataStride:");
}
