namespace Metal.NET;

public class MTLAccelerationStructureGeometryDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAccelerationStructureGeometryDescriptor>
{
    public static MTLAccelerationStructureGeometryDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTLAccelerationStructureGeometryDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLAccelerationStructureGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureGeometryDescriptorBindings.Class), true)
    {
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLAccelerationStructureGeometryDescriptorBindings.Label);
        set => SetProperty(ref field, MTLAccelerationStructureGeometryDescriptorBindings.SetLabel, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.Opaque);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetOpaque, value);
    }

    public MTLBuffer PrimitiveDataBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
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

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataBufferOffset = "primitiveDataBufferOffset";

    public static readonly Selector PrimitiveDataElementSize = "primitiveDataElementSize";

    public static readonly Selector PrimitiveDataStride = "primitiveDataStride";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataBufferOffset = "setPrimitiveDataBufferOffset:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";
}
