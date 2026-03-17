namespace Metal.NET;

/// <summary>
/// Describes curve geometry suitable for ray tracing.
/// </summary>
public class MTL4AccelerationStructureCurveGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4AccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTL4AccelerationStructureCurveGeometryDescriptor>
{
    #region INativeObject
    public static new MTL4AccelerationStructureCurveGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4AccelerationStructureCurveGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4AccelerationStructureCurveGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureCurveGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// References a buffer containing curve control points.
    /// </summary>
    public MTL4BufferRange ControlPointBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value);
    }

    /// <summary>
    /// Declares the number of control points in the control point buffer.
    /// </summary>
    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    /// <summary>
    /// Declares the format of the control points the control point buffer references.
    /// </summary>
    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    /// <summary>
    /// Sets the stride, in bytes, between control points in the control point buffer the control point buffer references.
    /// </summary>
    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    /// <summary>
    /// Controls the curve basis function, determining how Metal interpolates the control points.
    /// </summary>
    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    /// <summary>
    /// Sets the type of curve end caps.
    /// </summary>
    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    /// <summary>
    /// Controls the curve type.
    /// </summary>
    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    /// <summary>
    /// Assigns an optional index buffer containing references to control points in the control point buffer.
    /// </summary>
    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    /// <summary>
    /// Specifies the size of the indices the indexBuffer contains, which is typically either 16 or 32-bits for each index.
    /// </summary>
    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    /// <summary>
    /// Assigns a reference to a buffer containing the curve radius for each control point.
    /// </summary>
    public MTL4BufferRange RadiusBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value);
    }

    /// <summary>
    /// Declares the format of the radii in the radius buffer.
    /// </summary>
    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    /// <summary>
    /// Configures the stride, in bytes, between radii in the radius buffer.
    /// </summary>
    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    /// <summary>
    /// Declares the number of control points per curve segment.
    /// </summary>
    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    /// <summary>
    /// Declares the number of curve segments.
    /// </summary>
    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }
    #endregion
}

file static class MTL4AccelerationStructureCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureCurveGeometryDescriptor");

    public static readonly Selector ControlPointBuffer = "controlPointBuffer";

    public static readonly Selector ControlPointCount = "controlPointCount";

    public static readonly Selector ControlPointFormat = "controlPointFormat";

    public static readonly Selector ControlPointStride = "controlPointStride";

    public static readonly Selector CurveBasis = "curveBasis";

    public static readonly Selector CurveEndCaps = "curveEndCaps";

    public static readonly Selector CurveType = "curveType";

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector RadiusBuffer = "radiusBuffer";

    public static readonly Selector RadiusFormat = "radiusFormat";

    public static readonly Selector RadiusStride = "radiusStride";

    public static readonly Selector SegmentControlPointCount = "segmentControlPointCount";

    public static readonly Selector SegmentCount = "segmentCount";

    public static readonly Selector SetControlPointBuffer = "setControlPointBuffer:";

    public static readonly Selector SetControlPointCount = "setControlPointCount:";

    public static readonly Selector SetControlPointFormat = "setControlPointFormat:";

    public static readonly Selector SetControlPointStride = "setControlPointStride:";

    public static readonly Selector SetCurveBasis = "setCurveBasis:";

    public static readonly Selector SetCurveEndCaps = "setCurveEndCaps:";

    public static readonly Selector SetCurveType = "setCurveType:";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetRadiusBuffer = "setRadiusBuffer:";

    public static readonly Selector SetRadiusFormat = "setRadiusFormat:";

    public static readonly Selector SetRadiusStride = "setRadiusStride:";

    public static readonly Selector SetSegmentControlPointCount = "setSegmentControlPointCount:";

    public static readonly Selector SetSegmentCount = "setSegmentCount:";
}
