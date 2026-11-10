namespace Metal.NET;

public readonly struct MTL4AccelerationStructureCurveGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureCurveGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4AccelerationStructureCurveGeometryDescriptor value) => new(value.NativePtr);

    public MTL4AccelerationStructureCurveGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureCurveGeometryDescriptorBindings.Class))
    {
    }

    public MTL4AccelerationStructureCurveGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4BufferRange ControlPointBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public MTL4BufferRange RadiusBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureCurveGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }
}

file static class MTL4AccelerationStructureCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureCurveGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector ControlPointBuffer = "controlPointBuffer";

    public static readonly Selector ControlPointCount = "controlPointCount";

    public static readonly Selector ControlPointFormat = "controlPointFormat";

    public static readonly Selector ControlPointStride = "controlPointStride";

    public static readonly Selector CurveBasis = "curveBasis";

    public static readonly Selector CurveEndCaps = "curveEndCaps";

    public static readonly Selector CurveType = "curveType";

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataElementSize = "primitiveDataElementSize";

    public static readonly Selector PrimitiveDataStride = "primitiveDataStride";

    public static readonly Selector RadiusBuffer = "radiusBuffer";

    public static readonly Selector RadiusFormat = "radiusFormat";

    public static readonly Selector RadiusStride = "radiusStride";

    public static readonly Selector SegmentControlPointCount = "segmentControlPointCount";

    public static readonly Selector SegmentCount = "segmentCount";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetControlPointBuffer = "setControlPointBuffer:";

    public static readonly Selector SetControlPointCount = "setControlPointCount:";

    public static readonly Selector SetControlPointFormat = "setControlPointFormat:";

    public static readonly Selector SetControlPointStride = "setControlPointStride:";

    public static readonly Selector SetCurveBasis = "setCurveBasis:";

    public static readonly Selector SetCurveEndCaps = "setCurveEndCaps:";

    public static readonly Selector SetCurveType = "setCurveType:";

    public static readonly Selector SetIndexBuffer = "setIndexBuffer:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";

    public static readonly Selector SetRadiusBuffer = "setRadiusBuffer:";

    public static readonly Selector SetRadiusFormat = "setRadiusFormat:";

    public static readonly Selector SetRadiusStride = "setRadiusStride:";

    public static readonly Selector SetSegmentControlPointCount = "setSegmentControlPointCount:";

    public static readonly Selector SetSegmentCount = "setSegmentCount:";
}
