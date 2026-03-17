namespace Metal.NET;

/// <summary>
/// Describes motion curve geometry, suitable for motion ray tracing.
/// </summary>
public class MTL4AccelerationStructureMotionCurveGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4AccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTL4AccelerationStructureMotionCurveGeometryDescriptor>
{
    #region INativeObject
    public static new MTL4AccelerationStructureMotionCurveGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4AccelerationStructureMotionCurveGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4AccelerationStructureMotionCurveGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Assigns a reference to a buffer where each entry contains a reference to a buffer of control points.
    /// </summary>
    public MTL4BufferRange ControlPointBuffers
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointBuffers, value);
    }

    /// <summary>
    /// Specifies the number of control points in the buffers the control point buffers reference.
    /// </summary>
    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    /// <summary>
    /// Declares the format of the control points in the buffers that the control point buffers reference.
    /// </summary>
    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    /// <summary>
    /// Sets the stride, in bytes, between control points in the control point buffer.
    /// </summary>
    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    /// <summary>
    /// Sets the curve basis function, determining how Metal interpolates the control points.
    /// </summary>
    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    /// <summary>
    /// Configures the type of curve end caps.
    /// </summary>
    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    /// <summary>
    /// Controls the curve type.
    /// </summary>
    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    /// <summary>
    /// Assigns an optional index buffer containing references to control points in the control point buffers.
    /// </summary>
    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    /// <summary>
    /// Configures the size of the indices the indexBuffer contains, which is typically either 16 or 32-bits for each index.
    /// </summary>
    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    /// <summary>
    /// Assigns a reference to a buffer containing, in turn, references to curve radii buffers.
    /// </summary>
    public MTL4BufferRange RadiusBuffers
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusBuffers, value);
    }

    /// <summary>
    /// Sets the format of the radii in the radius buffer.
    /// </summary>
    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    /// <summary>
    /// Sets the stride, in bytes, between radii in the radius buffer.
    /// </summary>
    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    /// <summary>
    /// Controls the number of control points per curve segment.
    /// </summary>
    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    /// <summary>
    /// Declares the number of curve segments.
    /// </summary>
    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }
    #endregion
}

file static class MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureMotionCurveGeometryDescriptor");

    public static readonly Selector ControlPointBuffers = "controlPointBuffers";

    public static readonly Selector ControlPointCount = "controlPointCount";

    public static readonly Selector ControlPointFormat = "controlPointFormat";

    public static readonly Selector ControlPointStride = "controlPointStride";

    public static readonly Selector CurveBasis = "curveBasis";

    public static readonly Selector CurveEndCaps = "curveEndCaps";

    public static readonly Selector CurveType = "curveType";

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector RadiusBuffers = "radiusBuffers";

    public static readonly Selector RadiusFormat = "radiusFormat";

    public static readonly Selector RadiusStride = "radiusStride";

    public static readonly Selector SegmentControlPointCount = "segmentControlPointCount";

    public static readonly Selector SegmentCount = "segmentCount";

    public static readonly Selector SetControlPointBuffers = "setControlPointBuffers:";

    public static readonly Selector SetControlPointCount = "setControlPointCount:";

    public static readonly Selector SetControlPointFormat = "setControlPointFormat:";

    public static readonly Selector SetControlPointStride = "setControlPointStride:";

    public static readonly Selector SetCurveBasis = "setCurveBasis:";

    public static readonly Selector SetCurveEndCaps = "setCurveEndCaps:";

    public static readonly Selector SetCurveType = "setCurveType:";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetRadiusBuffers = "setRadiusBuffers:";

    public static readonly Selector SetRadiusFormat = "setRadiusFormat:";

    public static readonly Selector SetRadiusStride = "setRadiusStride:";

    public static readonly Selector SetSegmentControlPointCount = "setSegmentControlPointCount:";

    public static readonly Selector SetSegmentCount = "setSegmentCount:";
}
