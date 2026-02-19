namespace Metal.NET;

public class MTL4AccelerationStructureGeometryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
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
        get => GetProperty<NSString>(ref field, MTL4AccelerationStructureGeometryDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4AccelerationStructureGeometryDescriptorBindings.SetLabel, value);
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

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataElementSize = "primitiveDataElementSize";

    public static readonly Selector PrimitiveDataStride = "primitiveDataStride";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";
}
