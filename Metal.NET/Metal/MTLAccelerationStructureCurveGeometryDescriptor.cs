namespace Metal.NET;

/// <summary>
/// A descriptor you configure with curve geometry for building acceleration structures.
/// </summary>
public class MTLAccelerationStructureCurveGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownership), INativeObject<MTLAccelerationStructureCurveGeometryDescriptor>
{
    #region INativeObject
    public static new MTLAccelerationStructureCurveGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructureCurveGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAccelerationStructureCurveGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// A buffer that contains curve control points.
    /// </summary>
    public MTLBuffer ControlPointBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value);
    }

    /// <summary>
    /// The offset, in bytes, to the control point data in the buffer.
    /// </summary>
    public nuint ControlPointBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBufferOffset, value);
    }

    /// <summary>
    /// The number of control points in the control point buffer.
    /// </summary>
    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    /// <summary>
    /// The format of the control points in the buffer.
    /// </summary>
    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    /// <summary>
    /// The stride, in bytes, between control points in the buffer.
    /// </summary>
    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    /// <summary>
    /// The basis function for the curve geometry.
    /// </summary>
    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    /// <summary>
    /// An end-cap type for the curves in the geometry.
    /// </summary>
    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    /// <summary>
    /// A curve type for curves in the geometry.
    /// </summary>
    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    /// <summary>
    /// A buffer that contains references to control points in the control point buffer.
    /// </summary>
    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    /// <summary>
    /// The offset, in bytes, to the index data in the buffer.
    /// </summary>
    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    /// <summary>
    /// The size of each index in the index buffer.
    /// </summary>
    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    /// <summary>
    /// A buffer that contains the curve radius for each control point.
    /// </summary>
    public MTLBuffer RadiusBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value);
    }

    /// <summary>
    /// The offset, in bytes, to the radius data in the buffer.
    /// </summary>
    public nuint RadiusBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBufferOffset, value);
    }

    /// <summary>
    /// The format of each radius in the radius buffer.
    /// </summary>
    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    /// <summary>
    /// The stride, in bytes, between the radius elements in the radius buffer.
    /// </summary>
    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    /// <summary>
    /// The number of control points in each curve segment.
    /// </summary>
    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    /// <summary>
    /// The number of curve segments in each curve of the geometry.
    /// </summary>
    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }
    #endregion

    public static MTLAccelerationStructureCurveGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class, MTLAccelerationStructureCurveGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLAccelerationStructureCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureCurveGeometryDescriptor");

    public static readonly Selector ControlPointBuffer = "controlPointBuffer";

    public static readonly Selector ControlPointBufferOffset = "controlPointBufferOffset";

    public static readonly Selector ControlPointCount = "controlPointCount";

    public static readonly Selector ControlPointFormat = "controlPointFormat";

    public static readonly Selector ControlPointStride = "controlPointStride";

    public static readonly Selector CurveBasis = "curveBasis";

    public static readonly Selector CurveEndCaps = "curveEndCaps";

    public static readonly Selector CurveType = "curveType";

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexBufferOffset = "indexBufferOffset";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector RadiusBuffer = "radiusBuffer";

    public static readonly Selector RadiusBufferOffset = "radiusBufferOffset";

    public static readonly Selector RadiusFormat = "radiusFormat";

    public static readonly Selector RadiusStride = "radiusStride";

    public static readonly Selector SegmentControlPointCount = "segmentControlPointCount";

    public static readonly Selector SegmentCount = "segmentCount";

    public static readonly Selector SetControlPointBuffer = "setControlPointBuffer:";

    public static readonly Selector SetControlPointBufferOffset = "setControlPointBufferOffset:";

    public static readonly Selector SetControlPointCount = "setControlPointCount:";

    public static readonly Selector SetControlPointFormat = "setControlPointFormat:";

    public static readonly Selector SetControlPointStride = "setControlPointStride:";

    public static readonly Selector SetCurveBasis = "setCurveBasis:";

    public static readonly Selector SetCurveEndCaps = "setCurveEndCaps:";

    public static readonly Selector SetCurveType = "setCurveType:";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexBufferOffset = "setIndexBufferOffset:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetRadiusBuffer = "setRadiusBuffer:";

    public static readonly Selector SetRadiusBufferOffset = "setRadiusBufferOffset:";

    public static readonly Selector SetRadiusFormat = "setRadiusFormat:";

    public static readonly Selector SetRadiusStride = "setRadiusStride:";

    public static readonly Selector SetSegmentControlPointCount = "setSegmentControlPointCount:";

    public static readonly Selector SetSegmentCount = "setSegmentCount:";
}
