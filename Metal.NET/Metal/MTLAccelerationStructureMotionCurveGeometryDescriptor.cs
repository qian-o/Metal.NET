namespace Metal.NET;

public readonly struct MTLAccelerationStructureMotionCurveGeometryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLAccelerationStructureMotionCurveGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.Class))
    {
    }

    public NSArray? ControlPointBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointBuffers);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointBuffers, value?.NativePtr ?? 0);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTLBuffer? IndexBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.IndexBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexBuffer, value?.NativePtr ?? 0);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public NSArray? RadiusBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusBuffers);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusBuffers, value?.NativePtr ?? 0);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }

    public static MTLAccelerationStructureMotionCurveGeometryDescriptor? Descriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.Descriptor);
        return ptr is not 0 ? new MTLAccelerationStructureMotionCurveGeometryDescriptor(ptr) : default;
    }
}

file static class MTLAccelerationStructureMotionCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionCurveGeometryDescriptor");

    public static readonly Selector ControlPointBuffers = Selector.Register("controlPointBuffers");

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

    public static readonly Selector RadiusBuffers = Selector.Register("radiusBuffers");

    public static readonly Selector RadiusFormat = Selector.Register("radiusFormat");

    public static readonly Selector RadiusStride = Selector.Register("radiusStride");

    public static readonly Selector SegmentControlPointCount = Selector.Register("segmentControlPointCount");

    public static readonly Selector SegmentCount = Selector.Register("segmentCount");

    public static readonly Selector SetControlPointBuffers = Selector.Register("setControlPointBuffers:");

    public static readonly Selector SetControlPointCount = Selector.Register("setControlPointCount:");

    public static readonly Selector SetControlPointFormat = Selector.Register("setControlPointFormat:");

    public static readonly Selector SetControlPointStride = Selector.Register("setControlPointStride:");

    public static readonly Selector SetCurveBasis = Selector.Register("setCurveBasis:");

    public static readonly Selector SetCurveEndCaps = Selector.Register("setCurveEndCaps:");

    public static readonly Selector SetCurveType = Selector.Register("setCurveType:");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector SetRadiusBuffers = Selector.Register("setRadiusBuffers:");

    public static readonly Selector SetRadiusFormat = Selector.Register("setRadiusFormat:");

    public static readonly Selector SetRadiusStride = Selector.Register("setRadiusStride:");

    public static readonly Selector SetSegmentControlPointCount = Selector.Register("setSegmentControlPointCount:");

    public static readonly Selector SetSegmentCount = Selector.Register("setSegmentCount:");
}
