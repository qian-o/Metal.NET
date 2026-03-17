namespace Metal.NET;

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

    public MTLBuffer ControlPointBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value);
    }

    public nuint ControlPointBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBufferOffset, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public MTLBuffer RadiusBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value);
    }

    public nuint RadiusBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBufferOffset, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public MTLBuffer ControlPointBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value);
    }

    public nuint ControlPointBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBufferOffset, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public MTLBuffer RadiusBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value);
    }

    public nuint RadiusBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBufferOffset, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public void SetControlPointBuffer(MTLBuffer controlPointBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, controlPointBuffer.NativePtr);
    }

    public void SetControlPointBufferOffset(nuint controlPointBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBufferOffset, controlPointBufferOffset);
    }

    public void SetControlPointCount(nuint controlPointCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, controlPointCount);
    }

    public void SetControlPointStride(nuint controlPointStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, controlPointStride);
    }

    public void SetControlPointFormat(MTLAttributeFormat controlPointFormat)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)controlPointFormat);
    }

    public void SetRadiusBuffer(MTLBuffer radiusBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, radiusBuffer.NativePtr);
    }

    public void SetRadiusBufferOffset(nuint radiusBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBufferOffset, radiusBufferOffset);
    }

    public void SetRadiusFormat(MTLAttributeFormat radiusFormat)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)radiusFormat);
    }

    public void SetRadiusStride(nuint radiusStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, radiusStride);
    }

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(nuint indexBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBufferOffset, indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)indexType);
    }

    public void SetSegmentCount(nuint segmentCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, segmentCount);
    }

    public void SetSegmentControlPointCount(nuint segmentControlPointCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, segmentControlPointCount);
    }

    public void SetCurveType(MTLCurveType curveType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)curveType);
    }

    public void SetCurveBasis(MTLCurveBasis curveBasis)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)curveBasis);
    }

    public void SetCurveEndCaps(MTLCurveEndCaps curveEndCaps)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)curveEndCaps);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class, MTLAccelerationStructureCurveGeometryDescriptorBindings.Descriptor);
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
