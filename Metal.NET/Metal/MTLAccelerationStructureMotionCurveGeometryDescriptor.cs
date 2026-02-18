namespace Metal.NET;

public class MTLAccelerationStructureMotionCurveGeometryDescriptor(nint nativePtr) : MTLAccelerationStructureGeometryDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionCurveGeometryDescriptor");

    public NSArray ControlPointBuffers
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.ControlPointBuffers));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointBuffers, value.NativePtr);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.ControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointCount, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.ControlPointFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointFormat, (ulong)value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.ControlPointStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointStride, value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.CurveBasis));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveBasis, (ulong)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.CurveEndCaps));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveEndCaps, (ulong)value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.CurveType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveType, (ulong)value);
    }

    public MTLBuffer IndexBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.IndexBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexBuffer, value.NativePtr);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.IndexType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexType, (ulong)value);
    }

    public NSArray RadiusBuffers
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.RadiusBuffers));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusBuffers, value.NativePtr);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.RadiusFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusFormat, (ulong)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.RadiusStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusStride, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SegmentControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetSegmentControlPointCount, value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SegmentCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetSegmentCount, value);
    }

    public static implicit operator nint(MTLAccelerationStructureMotionCurveGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureMotionCurveGeometryDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLAccelerationStructureMotionCurveGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureMotionCurveGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.Descriptor));

        return result;
    }
}

file class MTLAccelerationStructureMotionCurveGeometryDescriptorSelector
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

    public static readonly Selector IndexBufferOffset = Selector.Register("indexBufferOffset");

    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");

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

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
