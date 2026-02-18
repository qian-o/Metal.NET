namespace Metal.NET;

public class MTL4AccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr) : MTL4AccelerationStructureGeometryDescriptor(nativePtr)
{
    public MTL4AccelerationStructureBoundingBoxGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector.Class))
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
}

file static class MTL4AccelerationStructureBoundingBoxGeometryDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureBoundingBoxGeometryDescriptor");

    public static readonly Selector BoundingBoxBuffer = Selector.Register("boundingBoxBuffer");

    public static readonly Selector BoundingBoxCount = Selector.Register("boundingBoxCount");

    public static readonly Selector BoundingBoxStride = Selector.Register("boundingBoxStride");

    public static readonly Selector SetBoundingBoxBuffer = Selector.Register("setBoundingBoxBuffer:");

    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");

    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");
}
