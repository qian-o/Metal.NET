namespace Metal.NET;

public class MTL4AccelerationStructureCurveGeometryDescriptor(nint nativePtr, bool ownsReference) : MTL4AccelerationStructureGeometryDescriptor(nativePtr, ownsReference), INativeObject<MTL4AccelerationStructureCurveGeometryDescriptor>
{
    public static new MTL4AccelerationStructureCurveGeometryDescriptor Null => Create(0, false);
    public static new MTL4AccelerationStructureCurveGeometryDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4AccelerationStructureCurveGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureCurveGeometryDescriptorBindings.Class), true)
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
