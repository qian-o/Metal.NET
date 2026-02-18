namespace Metal.NET;

public class MTL4AccelerationStructureMotionCurveGeometryDescriptor(nint nativePtr) : MTL4AccelerationStructureGeometryDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureMotionCurveGeometryDescriptor");

    public MTL4AccelerationStructureMotionCurveGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    public MTL4BufferRange ControlPointBuffers
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.ControlPointBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointBuffers, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.ControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointCount, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.ControlPointFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointFormat, (ulong)value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.ControlPointStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointStride, value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.CurveBasis);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveBasis, (ulong)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.CurveEndCaps);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveEndCaps, (ulong)value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.CurveType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveType, (ulong)value);
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.IndexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexType, (ulong)value);
    }

    public MTL4BufferRange RadiusBuffers
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.RadiusBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusBuffers, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.RadiusFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusFormat, (ulong)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.RadiusStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusStride, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SegmentControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetSegmentControlPointCount, value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SegmentCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector.SetSegmentCount, value);
    }

    public static implicit operator nint(MTL4AccelerationStructureMotionCurveGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4AccelerationStructureMotionCurveGeometryDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTL4AccelerationStructureMotionCurveGeometryDescriptorSelector
{
    public static readonly Selector ControlPointBuffers = Selector.Register("controlPointBuffers");

    public static readonly Selector SetControlPointBuffers = Selector.Register("setControlPointBuffers:");

    public static readonly Selector ControlPointCount = Selector.Register("controlPointCount");

    public static readonly Selector SetControlPointCount = Selector.Register("setControlPointCount:");

    public static readonly Selector ControlPointFormat = Selector.Register("controlPointFormat");

    public static readonly Selector SetControlPointFormat = Selector.Register("setControlPointFormat:");

    public static readonly Selector ControlPointStride = Selector.Register("controlPointStride");

    public static readonly Selector SetControlPointStride = Selector.Register("setControlPointStride:");

    public static readonly Selector CurveBasis = Selector.Register("curveBasis");

    public static readonly Selector SetCurveBasis = Selector.Register("setCurveBasis:");

    public static readonly Selector CurveEndCaps = Selector.Register("curveEndCaps");

    public static readonly Selector SetCurveEndCaps = Selector.Register("setCurveEndCaps:");

    public static readonly Selector CurveType = Selector.Register("curveType");

    public static readonly Selector SetCurveType = Selector.Register("setCurveType:");

    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector RadiusBuffers = Selector.Register("radiusBuffers");

    public static readonly Selector SetRadiusBuffers = Selector.Register("setRadiusBuffers:");

    public static readonly Selector RadiusFormat = Selector.Register("radiusFormat");

    public static readonly Selector SetRadiusFormat = Selector.Register("setRadiusFormat:");

    public static readonly Selector RadiusStride = Selector.Register("radiusStride");

    public static readonly Selector SetRadiusStride = Selector.Register("setRadiusStride:");

    public static readonly Selector SegmentControlPointCount = Selector.Register("segmentControlPointCount");

    public static readonly Selector SetSegmentControlPointCount = Selector.Register("setSegmentControlPointCount:");

    public static readonly Selector SegmentCount = Selector.Register("segmentCount");

    public static readonly Selector SetSegmentCount = Selector.Register("setSegmentCount:");
}
