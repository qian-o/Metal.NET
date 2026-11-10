namespace Metal.NET;

public readonly struct MTL4AccelerationStructureMotionCurveGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionCurveGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4AccelerationStructureMotionCurveGeometryDescriptor value) => new(value.NativePtr);

    public MTL4AccelerationStructureMotionCurveGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.Class))
    {
    }

    public MTL4AccelerationStructureMotionCurveGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4BufferRange ControlPointBuffers
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointBuffers, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public MTL4BufferRange RadiusBuffers
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusBuffers, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public MTL4BufferRange IndexBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.IndexBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexBuffer, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }
}

file static class MTL4AccelerationStructureMotionCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureMotionCurveGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector ControlPointBuffers = "controlPointBuffers";

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

    public static readonly Selector RadiusBuffers = "radiusBuffers";

    public static readonly Selector RadiusFormat = "radiusFormat";

    public static readonly Selector RadiusStride = "radiusStride";

    public static readonly Selector SegmentControlPointCount = "segmentControlPointCount";

    public static readonly Selector SegmentCount = "segmentCount";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetControlPointBuffers = "setControlPointBuffers:";

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

    public static readonly Selector SetRadiusBuffers = "setRadiusBuffers:";

    public static readonly Selector SetRadiusFormat = "setRadiusFormat:";

    public static readonly Selector SetRadiusStride = "setRadiusStride:";

    public static readonly Selector SetSegmentControlPointCount = "setSegmentControlPointCount:";

    public static readonly Selector SetSegmentCount = "setSegmentCount:";
}
