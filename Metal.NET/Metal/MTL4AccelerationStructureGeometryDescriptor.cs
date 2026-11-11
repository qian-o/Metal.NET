namespace Metal.NET;

public readonly struct MTL4AccelerationStructureGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4AccelerationStructureGeometryDescriptor value) => new(value.NativePtr);

    public MTL4AccelerationStructureGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureGeometryDescriptorBindings.Class))
    {
    }

    public MTL4AccelerationStructureGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }
}

file static class MTL4AccelerationStructureGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureGeometryDescriptor");

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
