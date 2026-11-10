namespace Metal.NET;

public readonly struct MTLAccelerationStructureCurveGeometryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLAccelerationStructureGeometryDescriptor(MTLAccelerationStructureCurveGeometryDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLAccelerationStructureCurveGeometryDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructureCurveGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructureCurveGeometryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLBuffer ControlPointBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value.NativePtr);
    }

    public nuint ControlPointBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBufferOffset, value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointCount, value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointStride, value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointFormat, (nuint)value);
    }

    public MTLBuffer RadiusBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value.NativePtr);
    }

    public nuint RadiusBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBufferOffset, value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusFormat, (nuint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusStride, value);
    }

    public MTLBuffer IndexBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value.NativePtr);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentCount, value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SegmentControlPointCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetSegmentControlPointCount, value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveType);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveType, (nint)value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveBasis);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveBasis, (nint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)ObjectiveC.MsgSendLong(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.CurveEndCaps);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetCurveEndCaps, (nint)value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetOpaque, value);
    }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLBuffer PrimitiveDataBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.PrimitiveDataBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetPrimitiveDataBuffer, value.NativePtr);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.PrimitiveDataBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class, MTLAccelerationStructureCurveGeometryDescriptorBindings.Descriptor);
    }
}

file static class MTLAccelerationStructureCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureCurveGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector ControlPointBuffer = "controlPointBuffer";

    public static readonly Selector ControlPointBufferOffset = "controlPointBufferOffset";

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

    public static readonly Selector RadiusBuffer = "radiusBuffer";

    public static readonly Selector RadiusBufferOffset = "radiusBufferOffset";

    public static readonly Selector RadiusFormat = "radiusFormat";

    public static readonly Selector RadiusStride = "radiusStride";

    public static readonly Selector SegmentControlPointCount = "segmentControlPointCount";

    public static readonly Selector SegmentCount = "segmentCount";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetControlPointBuffer = "setControlPointBuffer:";

    public static readonly Selector SetControlPointBufferOffset = "setControlPointBufferOffset:";

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

    public static readonly Selector SetRadiusBuffer = "setRadiusBuffer:";

    public static readonly Selector SetRadiusBufferOffset = "setRadiusBufferOffset:";

    public static readonly Selector SetRadiusFormat = "setRadiusFormat:";

    public static readonly Selector SetRadiusStride = "setRadiusStride:";

    public static readonly Selector SetSegmentControlPointCount = "setSegmentControlPointCount:";

    public static readonly Selector SetSegmentCount = "setSegmentCount:";
}
