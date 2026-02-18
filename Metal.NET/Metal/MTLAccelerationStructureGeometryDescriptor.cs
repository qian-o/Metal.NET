namespace Metal.NET;

public class MTLAccelerationStructureGeometryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAccelerationStructureGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureGeometryDescriptorSelector.Class))
    {
    }

    public bool AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetAllowDuplicateIntersectionFunctionInvocation, (Bool8)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.IntersectionFunctionTableOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetIntersectionFunctionTableOffset, value);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public bool Opaque
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.Opaque);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetOpaque, (Bool8)value);
    }

    public MTLBuffer? PrimitiveDataBuffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.PrimitiveDataBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBuffer, value?.NativePtr ?? 0);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.PrimitiveDataBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.PrimitiveDataElementSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataElementSize, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.PrimitiveDataStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataStride, value);
    }
}

file static class MTLAccelerationStructureGeometryDescriptorSelector
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
