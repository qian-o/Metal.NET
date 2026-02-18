namespace Metal.NET;

public class MTL4AccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr) : MTL4AccelerationStructureGeometryDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureBoundingBoxGeometryDescriptor");

    public MTL4AccelerationStructureBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    public MTL4BufferRange BoundingBoxBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffer, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride, value);
    }

    public static implicit operator nint(MTL4AccelerationStructureBoundingBoxGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4AccelerationStructureBoundingBoxGeometryDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector
{
    public static readonly Selector BoundingBoxBuffer = Selector.Register("boundingBoxBuffer");

    public static readonly Selector SetBoundingBoxBuffer = Selector.Register("setBoundingBoxBuffer:");

    public static readonly Selector BoundingBoxCount = Selector.Register("boundingBoxCount");

    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");

    public static readonly Selector BoundingBoxStride = Selector.Register("boundingBoxStride");

    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");
}
