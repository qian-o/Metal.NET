namespace Metal.NET;

public readonly struct MTL4AccelerationStructureCurveGeometryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4AccelerationStructureCurveGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureCurveGeometryDescriptorBindings.Class))
    {
    }

    public MTL4BufferRange ControlPointBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public MTL4BufferRange RadiusBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }
}

file static class MTL4AccelerationStructureCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureCurveGeometryDescriptor");

    public static readonly Selector ControlPointBuffer = Selector.Register("controlPointBuffer");

    public static readonly Selector ControlPointCount = Selector.Register("controlPointCount");

    public static readonly Selector ControlPointFormat = Selector.Register("controlPointFormat");

    public static readonly Selector ControlPointStride = Selector.Register("controlPointStride");

    public static readonly Selector CurveBasis = Selector.Register("curveBasis");

    public static readonly Selector CurveEndCaps = Selector.Register("curveEndCaps");

    public static readonly Selector CurveType = Selector.Register("curveType");

    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector RadiusBuffer = Selector.Register("radiusBuffer");

    public static readonly Selector RadiusFormat = Selector.Register("radiusFormat");

    public static readonly Selector RadiusStride = Selector.Register("radiusStride");

    public static readonly Selector SegmentControlPointCount = Selector.Register("segmentControlPointCount");

    public static readonly Selector SegmentCount = Selector.Register("segmentCount");

    public static readonly Selector SetControlPointBuffer = Selector.Register("setControlPointBuffer:");

    public static readonly Selector SetControlPointCount = Selector.Register("setControlPointCount:");

    public static readonly Selector SetControlPointFormat = Selector.Register("setControlPointFormat:");

    public static readonly Selector SetControlPointStride = Selector.Register("setControlPointStride:");

    public static readonly Selector SetCurveBasis = Selector.Register("setCurveBasis:");

    public static readonly Selector SetCurveEndCaps = Selector.Register("setCurveEndCaps:");

    public static readonly Selector SetCurveType = Selector.Register("setCurveType:");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector SetRadiusBuffer = Selector.Register("setRadiusBuffer:");

    public static readonly Selector SetRadiusFormat = Selector.Register("setRadiusFormat:");

    public static readonly Selector SetRadiusStride = Selector.Register("setRadiusStride:");

    public static readonly Selector SetSegmentControlPointCount = Selector.Register("setSegmentControlPointCount:");

    public static readonly Selector SetSegmentCount = Selector.Register("setSegmentCount:");
}
