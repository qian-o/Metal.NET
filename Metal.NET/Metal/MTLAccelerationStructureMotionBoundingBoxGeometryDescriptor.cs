namespace Metal.NET;

/// <summary>
/// A description of a list of bounding boxes, as motion keyframe data, to turn into an acceleration structure.
/// </summary>
public class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor>
{
    #region INativeObject
    public static new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying the number of bounding boxes - Properties

    /// <summary>
    /// The number of bounding boxes in each bounding box buffer.
    /// </summary>
    public nuint BoundingBoxCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }
    #endregion

    #region Specifying bounding boxes data - Properties

    /// <summary>
    /// A array of motion keyframes, each containing bounding box data.
    /// </summary>
    public MTLMotionKeyframeData[] BoundingBoxBuffers
    {
        get => GetArrayProperty<MTLMotionKeyframeData>(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffers);
        set => SetArrayProperty(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffers, value);
    }

    /// <summary>
    /// The stride, in bytes, between bounding boxes in each buffer.
    /// </summary>
    public nuint BoundingBoxStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }
    #endregion

    public static MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public static readonly Selector BoundingBoxBuffers = "boundingBoxBuffers";

    public static readonly Selector BoundingBoxCount = "boundingBoxCount";

    public static readonly Selector BoundingBoxStride = "boundingBoxStride";

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector SetBoundingBoxBuffers = "setBoundingBoxBuffers:";

    public static readonly Selector SetBoundingBoxCount = "setBoundingBoxCount:";

    public static readonly Selector SetBoundingBoxStride = "setBoundingBoxStride:";
}
