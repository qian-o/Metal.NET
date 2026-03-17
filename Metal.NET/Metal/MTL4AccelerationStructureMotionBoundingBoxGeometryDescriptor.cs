namespace Metal.NET;

/// <summary>
/// Describes motion bounding box geometry, suitable for motion ray tracing.
/// </summary>
public class MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4AccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor>
{
    #region INativeObject
    public static new MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Configures a reference to a buffer where each entry contains a reference to a buffer of bounding boxes.
    /// </summary>
    public MTL4BufferRange BoundingBoxBuffers
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxBuffers, value);
    }

    /// <summary>
    /// Declares the number of bounding boxes in each buffer that boundingBoxBuffer references.
    /// </summary>
    public nuint BoundingBoxCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxCount, value);
    }

    /// <summary>
    /// Declares the stride, in bytes, between bounding boxes in the bounding box buffers each entry in boundingBoxBuffer references.
    /// </summary>
    public nuint BoundingBoxStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.BoundingBoxStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings.SetBoundingBoxStride, value);
    }
    #endregion
}

file static class MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public static readonly Selector BoundingBoxBuffers = "boundingBoxBuffers";

    public static readonly Selector BoundingBoxCount = "boundingBoxCount";

    public static readonly Selector BoundingBoxStride = "boundingBoxStride";

    public static readonly Selector SetBoundingBoxBuffers = "setBoundingBoxBuffers:";

    public static readonly Selector SetBoundingBoxCount = "setBoundingBoxCount:";

    public static readonly Selector SetBoundingBoxStride = "setBoundingBoxStride:";
}
