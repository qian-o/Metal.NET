namespace Metal.NET;

/// <summary>A description of a list of bounding boxes to turn into an acceleration structure.</summary>
public class MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTLAccelerationStructureBoundingBoxGeometryDescriptor>
{
    #region INativeObject
    public static new MTLAccelerationStructureBoundingBoxGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructureBoundingBoxGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAccelerationStructureBoundingBoxGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying the number of bounding boxes - Properties

    /// <summary>The number of bounding boxes in the bounding box buffer.</summary>
    public nuint BoundingBoxCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }
    #endregion

    #region Specifying bounding boxes data - Properties

    /// <summary>A buffer that contains an array of bounding box structures.</summary>
    public MTLBuffer BoundingBoxBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffer, value);
    }

    /// <summary>The offset, in bytes, to the first bounding box in the buffer.</summary>
    public nuint BoundingBoxBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBufferOffset, value);
    }

    /// <summary>The stride, in bytes, between bounding boxes in the buffer.</summary>
    public nuint BoundingBoxStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }
    #endregion

    public static MTLAccelerationStructureBoundingBoxGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Class, MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLAccelerationStructureBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureBoundingBoxGeometryDescriptor");

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
