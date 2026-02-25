namespace Metal.NET;

public class MTLAccelerationStructureCurveGeometryDescriptor(nint nativePtr, bool ownsReference) : MTLAccelerationStructureGeometryDescriptor(nativePtr, ownsReference), INativeObject<MTLAccelerationStructureCurveGeometryDescriptor>
{
    public static new MTLAccelerationStructureCurveGeometryDescriptor Null => Create(0, false);
    public static new MTLAccelerationStructureCurveGeometryDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLAccelerationStructureCurveGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class), true)
    {
    }

    public MTLBuffer ControlPointBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.ControlPointBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetControlPointBuffer, value);
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

    public MTLBuffer IndexBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.IndexBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetIndexBuffer, value);
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

    public MTLBuffer RadiusBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.RadiusBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureCurveGeometryDescriptorBindings.SetRadiusBuffer, value);
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

    public static MTLAccelerationStructureCurveGeometryDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructureCurveGeometryDescriptorBindings.Class, MTLAccelerationStructureCurveGeometryDescriptorBindings.Descriptor);

        return new(nativePtr, false);
    }
}

file static class MTLAccelerationStructureCurveGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureCurveGeometryDescriptor");

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

    public static readonly Selector RadiusBuffer = "radiusBuffer";

    public static readonly Selector RadiusBufferOffset = "radiusBufferOffset";

    public static readonly Selector RadiusFormat = "radiusFormat";

    public static readonly Selector RadiusStride = "radiusStride";

    public static readonly Selector SegmentControlPointCount = "segmentControlPointCount";

    public static readonly Selector SegmentCount = "segmentCount";

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

    public static readonly Selector SetRadiusBuffer = "setRadiusBuffer:";

    public static readonly Selector SetRadiusBufferOffset = "setRadiusBufferOffset:";

    public static readonly Selector SetRadiusFormat = "setRadiusFormat:";

    public static readonly Selector SetRadiusStride = "setRadiusStride:";

    public static readonly Selector SetSegmentControlPointCount = "setSegmentControlPointCount:";

    public static readonly Selector SetSegmentCount = "setSegmentCount:";
}
