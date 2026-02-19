namespace Metal.NET;

public readonly struct MTLAccelerationStructureCurveGeometryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLAccelerationStructureCurveGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class))
    {
    }

    public MTLBuffer? ControlPointBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value?.NativePtr ?? 0);
    }

    public nuint ControlPointBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBufferOffset, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTLBuffer? IndexBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value?.NativePtr ?? 0);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public MTLBuffer? RadiusBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value?.NativePtr ?? 0);
    }

    public nuint RadiusBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBufferOffset, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }

    public static MTLAccelerationStructureCurveGeometryDescriptor? Descriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class, MTLAccelerationStructureCurveGeometryDescriptorBindings.Descriptor);
        return ptr is not 0 ? new MTLAccelerationStructureCurveGeometryDescriptor(ptr) : default;
    }
}

file static class MTLAccelerationStructureCurveGeometryDescriptorBindings
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
