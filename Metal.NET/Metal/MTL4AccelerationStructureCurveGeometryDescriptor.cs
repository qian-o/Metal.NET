namespace Metal.NET;

public partial class MTL4AccelerationStructureCurveGeometryDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureCurveGeometryDescriptor");

    public MTL4AccelerationStructureCurveGeometryDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4BufferRange ControlPointBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.ControlPointBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBuffer, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.ControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetControlPointCount, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.ControlPointFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetControlPointFormat, (nuint)value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.ControlPointStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetControlPointStride, value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.CurveBasis);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.CurveEndCaps);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetCurveEndCaps, (nint)value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.CurveType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetCurveType, (nint)value);
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.IndexBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetIndexType, (nuint)value);
    }

    public MTL4BufferRange RadiusBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.RadiusBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBuffer, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.RadiusFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.RadiusStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetRadiusStride, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SegmentControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetSegmentControlPointCount, value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SegmentCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorSelector.SetSegmentCount, value);
    }
}

file static class MTL4AccelerationStructureCurveGeometryDescriptorSelector
{
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
