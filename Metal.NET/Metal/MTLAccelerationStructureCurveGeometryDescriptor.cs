namespace Metal.NET;

public class MTLAccelerationStructureCurveGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureCurveGeometryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructureCurveGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureCurveGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureCurveGeometryDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureCurveGeometryDescriptor");

    public MTLBuffer ControlPointBuffer
    {
        get => new MTLBuffer(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBuffer, value.NativePtr);
    }

    public nuint ControlPointBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBufferOffset, (nuint)value);
    }

    public nuint ControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointCount, (nuint)value);
    }

    public MTLAttributeFormat ControlPointFormat
    {
        get => (MTLAttributeFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointFormat, (uint)value);
    }

    public nuint ControlPointStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.ControlPointStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointStride, (nuint)value);
    }

    public MTLCurveBasis CurveBasis
    {
        get => (MTLCurveBasis)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.CurveBasis));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveBasis, (uint)value);
    }

    public MTLCurveEndCaps CurveEndCaps
    {
        get => (MTLCurveEndCaps)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.CurveEndCaps));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveEndCaps, (uint)value);
    }

    public MTLCurveType CurveType
    {
        get => (MTLCurveType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.CurveType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveType, (uint)value);
    }

    public MTLBuffer IndexBuffer
    {
        get => new MTLBuffer(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.IndexBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBuffer, value.NativePtr);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBufferOffset, (nuint)value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.IndexType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexType, (uint)value);
    }

    public MTLBuffer RadiusBuffer
    {
        get => new MTLBuffer(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.RadiusBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBuffer, value.NativePtr);
    }

    public nuint RadiusBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.RadiusBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBufferOffset, (nuint)value);
    }

    public MTLAttributeFormat RadiusFormat
    {
        get => (MTLAttributeFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.RadiusFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusFormat, (uint)value);
    }

    public nuint RadiusStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.RadiusStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusStride, (nuint)value);
    }

    public nuint SegmentControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SegmentControlPointCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentControlPointCount, (nuint)value);
    }

    public nuint SegmentCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SegmentCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentCount, (nuint)value);
    }

    public static MTLAccelerationStructureCurveGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureCurveGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLAccelerationStructureCurveGeometryDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLAccelerationStructureCurveGeometryDescriptorSelector
{
    public static readonly Selector ControlPointBuffer = Selector.Register("controlPointBuffer");

    public static readonly Selector SetControlPointBuffer = Selector.Register("setControlPointBuffer:");

    public static readonly Selector ControlPointBufferOffset = Selector.Register("controlPointBufferOffset");

    public static readonly Selector SetControlPointBufferOffset = Selector.Register("setControlPointBufferOffset:");

    public static readonly Selector ControlPointCount = Selector.Register("controlPointCount");

    public static readonly Selector SetControlPointCount = Selector.Register("setControlPointCount:");

    public static readonly Selector ControlPointFormat = Selector.Register("controlPointFormat");

    public static readonly Selector SetControlPointFormat = Selector.Register("setControlPointFormat:");

    public static readonly Selector ControlPointStride = Selector.Register("controlPointStride");

    public static readonly Selector SetControlPointStride = Selector.Register("setControlPointStride:");

    public static readonly Selector CurveBasis = Selector.Register("curveBasis");

    public static readonly Selector SetCurveBasis = Selector.Register("setCurveBasis:");

    public static readonly Selector CurveEndCaps = Selector.Register("curveEndCaps");

    public static readonly Selector SetCurveEndCaps = Selector.Register("setCurveEndCaps:");

    public static readonly Selector CurveType = Selector.Register("curveType");

    public static readonly Selector SetCurveType = Selector.Register("setCurveType:");

    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector IndexBufferOffset = Selector.Register("indexBufferOffset");

    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector RadiusBuffer = Selector.Register("radiusBuffer");

    public static readonly Selector SetRadiusBuffer = Selector.Register("setRadiusBuffer:");

    public static readonly Selector RadiusBufferOffset = Selector.Register("radiusBufferOffset");

    public static readonly Selector SetRadiusBufferOffset = Selector.Register("setRadiusBufferOffset:");

    public static readonly Selector RadiusFormat = Selector.Register("radiusFormat");

    public static readonly Selector SetRadiusFormat = Selector.Register("setRadiusFormat:");

    public static readonly Selector RadiusStride = Selector.Register("radiusStride");

    public static readonly Selector SetRadiusStride = Selector.Register("setRadiusStride:");

    public static readonly Selector SegmentControlPointCount = Selector.Register("segmentControlPointCount");

    public static readonly Selector SetSegmentControlPointCount = Selector.Register("setSegmentControlPointCount:");

    public static readonly Selector SegmentCount = Selector.Register("segmentCount");

    public static readonly Selector SetSegmentCount = Selector.Register("setSegmentCount:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
