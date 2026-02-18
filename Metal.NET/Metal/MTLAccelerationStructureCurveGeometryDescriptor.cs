namespace Metal.NET;

public class MTLAccelerationStructureCurveGeometryDescriptor(nint nativePtr) : MTLAccelerationStructureGeometryDescriptor(nativePtr)
{
    public MTLAccelerationStructureCurveGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureCurveGeometryDescriptorSelector.Class))
    {
    }

    public MTLBuffer? ControlPointBuffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBuffer, value?.NativePtr ?? 0);
    }

    public nuint ControlPointBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBufferOffset, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointCount, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointFormat, (nuint)value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointStride, value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.CurveBasis);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.CurveEndCaps);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveEndCaps, (nint)value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.CurveType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveType, (nint)value);
    }

    public MTLBuffer? IndexBuffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.IndexBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBuffer, value?.NativePtr ?? 0);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexType, (nuint)value);
    }

    public MTLBuffer? RadiusBuffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.RadiusBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBuffer, value?.NativePtr ?? 0);
    }

    public nuint RadiusBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.RadiusBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBufferOffset, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.RadiusFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.RadiusStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusStride, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SegmentControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentControlPointCount, value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SegmentCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentCount, value);
    }

    public static MTLAccelerationStructureCurveGeometryDescriptor? Descriptor()
    {
        return GetNullableObject<MTLAccelerationStructureCurveGeometryDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureCurveGeometryDescriptorSelector.Class, MTLAccelerationStructureCurveGeometryDescriptorSelector.Descriptor));
    }
}

file static class MTLAccelerationStructureCurveGeometryDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureCurveGeometryDescriptor");

    public static readonly Selector ControlPointBuffer = Selector.Register("controlPointBuffer");

    public static readonly Selector ControlPointBufferOffset = Selector.Register("controlPointBufferOffset");

    public static readonly Selector ControlPointCount = Selector.Register("controlPointCount");

    public static readonly Selector ControlPointFormat = Selector.Register("controlPointFormat");

    public static readonly Selector ControlPointStride = Selector.Register("controlPointStride");

    public static readonly Selector CurveBasis = Selector.Register("curveBasis");

    public static readonly Selector CurveEndCaps = Selector.Register("curveEndCaps");

    public static readonly Selector CurveType = Selector.Register("curveType");

    public static readonly Selector Descriptor = Selector.Register("descriptor");

    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector IndexBufferOffset = Selector.Register("indexBufferOffset");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector RadiusBuffer = Selector.Register("radiusBuffer");

    public static readonly Selector RadiusBufferOffset = Selector.Register("radiusBufferOffset");

    public static readonly Selector RadiusFormat = Selector.Register("radiusFormat");

    public static readonly Selector RadiusStride = Selector.Register("radiusStride");

    public static readonly Selector SegmentControlPointCount = Selector.Register("segmentControlPointCount");

    public static readonly Selector SegmentCount = Selector.Register("segmentCount");

    public static readonly Selector SetControlPointBuffer = Selector.Register("setControlPointBuffer:");

    public static readonly Selector SetControlPointBufferOffset = Selector.Register("setControlPointBufferOffset:");

    public static readonly Selector SetControlPointCount = Selector.Register("setControlPointCount:");

    public static readonly Selector SetControlPointFormat = Selector.Register("setControlPointFormat:");

    public static readonly Selector SetControlPointStride = Selector.Register("setControlPointStride:");

    public static readonly Selector SetCurveBasis = Selector.Register("setCurveBasis:");

    public static readonly Selector SetCurveEndCaps = Selector.Register("setCurveEndCaps:");

    public static readonly Selector SetCurveType = Selector.Register("setCurveType:");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector SetRadiusBuffer = Selector.Register("setRadiusBuffer:");

    public static readonly Selector SetRadiusBufferOffset = Selector.Register("setRadiusBufferOffset:");

    public static readonly Selector SetRadiusFormat = Selector.Register("setRadiusFormat:");

    public static readonly Selector SetRadiusStride = Selector.Register("setRadiusStride:");

    public static readonly Selector SetSegmentControlPointCount = Selector.Register("setSegmentControlPointCount:");

    public static readonly Selector SetSegmentCount = Selector.Register("setSegmentCount:");
}
