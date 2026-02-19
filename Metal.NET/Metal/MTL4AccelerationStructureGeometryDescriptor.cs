namespace Metal.NET;

public readonly struct MTL4AccelerationStructureGeometryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4AccelerationStructureGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureGeometryDescriptorBindings.Class))
    {
    }

    public bool AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, (Bool8)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public bool Opaque
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.Opaque);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetOpaque, (Bool8)value);
    }

    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }
}

file static class MTL4AccelerationStructureGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = Selector.Register("allowDuplicateIntersectionFunctionInvocation");

    public static readonly Selector IntersectionFunctionTableOffset = Selector.Register("intersectionFunctionTableOffset");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Opaque = Selector.Register("opaque");

    public static readonly Selector PrimitiveDataBuffer = Selector.Register("primitiveDataBuffer");

    public static readonly Selector PrimitiveDataElementSize = Selector.Register("primitiveDataElementSize");

    public static readonly Selector PrimitiveDataStride = Selector.Register("primitiveDataStride");

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = Selector.Register("setAllowDuplicateIntersectionFunctionInvocation:");

    public static readonly Selector SetIntersectionFunctionTableOffset = Selector.Register("setIntersectionFunctionTableOffset:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetOpaque = Selector.Register("setOpaque:");

    public static readonly Selector SetPrimitiveDataBuffer = Selector.Register("setPrimitiveDataBuffer:");

    public static readonly Selector SetPrimitiveDataElementSize = Selector.Register("setPrimitiveDataElementSize:");

    public static readonly Selector SetPrimitiveDataStride = Selector.Register("setPrimitiveDataStride:");
}
