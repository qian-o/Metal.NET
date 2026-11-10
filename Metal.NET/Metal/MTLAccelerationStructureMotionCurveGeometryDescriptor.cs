namespace Metal.NET;

public readonly struct MTLAccelerationStructureMotionCurveGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLAccelerationStructureGeometryDescriptor(MTLAccelerationStructureMotionCurveGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLAccelerationStructureMotionCurveGeometryDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructureMotionCurveGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructureMotionCurveGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTLMotionKeyframeData> ControlPointBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointBuffers));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointBuffers, value.NativePtr);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public NSArray<MTLMotionKeyframeData> RadiusBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusBuffers));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusBuffers, value.NativePtr);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public MTLBuffer IndexBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.IndexBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexBuffer, value.NativePtr);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLBuffer PrimitiveDataBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.PrimitiveDataBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetPrimitiveDataBuffer, value.NativePtr);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.PrimitiveDataBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.Class, MTLAccelerationStructureMotionCurveGeometryDescriptorBindings.Descriptor);
    }
}

file static class MTLAccelerationStructureMotionCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureMotionCurveGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector ControlPointBuffers = "controlPointBuffers";

    public static readonly Selector ControlPointCount = "controlPointCount";

    public static readonly Selector ControlPointFormat = "controlPointFormat";

    public static readonly Selector ControlPointStride = "controlPointStride";

    public static readonly Selector CurveBasis = "curveBasis";

    public static readonly Selector CurveEndCaps = "curveEndCaps";

    public static readonly Selector CurveType = "curveType";

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector IndexBuffer = "indexBuffer";

    public static readonly Selector IndexBufferOffset = "indexBufferOffset";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataBufferOffset = "primitiveDataBufferOffset";

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

    public static readonly Selector SetIndexBufferOffset = "setIndexBufferOffset:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataBufferOffset = "setPrimitiveDataBufferOffset:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";

    public static readonly Selector SetRadiusBuffers = "setRadiusBuffers:";

    public static readonly Selector SetRadiusFormat = "setRadiusFormat:";

    public static readonly Selector SetRadiusStride = "setRadiusStride:";

    public static readonly Selector SetSegmentControlPointCount = "setSegmentControlPointCount:";

    public static readonly Selector SetSegmentCount = "setSegmentCount:";
}
