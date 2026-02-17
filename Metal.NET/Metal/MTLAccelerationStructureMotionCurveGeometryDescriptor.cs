namespace Metal.NET;

public class MTLAccelerationStructureMotionCurveGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureMotionCurveGeometryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructureMotionCurveGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureMotionCurveGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureMotionCurveGeometryDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionCurveGeometryDescriptor");

    public void SetControlPointBuffers(NSArray controlPointBuffers)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointBuffers, controlPointBuffers.NativePtr);
    }

    public void SetControlPointCount(uint controlPointCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointCount, (nint)controlPointCount);
    }

    public void SetControlPointFormat(MTLAttributeFormat controlPointFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointFormat, (nint)(uint)controlPointFormat);
    }

    public void SetControlPointStride(uint controlPointStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointStride, (nint)controlPointStride);
    }

    public void SetCurveBasis(MTLCurveBasis curveBasis)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveBasis, (nint)(uint)curveBasis);
    }

    public void SetCurveEndCaps(MTLCurveEndCaps curveEndCaps)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveEndCaps, (nint)(uint)curveEndCaps);
    }

    public void SetCurveType(MTLCurveType curveType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveType, (nint)(uint)curveType);
    }

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexBuffer, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(uint indexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexBufferOffset, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexType, (nint)(uint)indexType);
    }

    public void SetRadiusBuffers(NSArray radiusBuffers)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusBuffers, radiusBuffers.NativePtr);
    }

    public void SetRadiusFormat(MTLAttributeFormat radiusFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusFormat, (nint)(uint)radiusFormat);
    }

    public void SetRadiusStride(uint radiusStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusStride, (nint)radiusStride);
    }

    public void SetSegmentControlPointCount(uint segmentControlPointCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetSegmentControlPointCount, (nint)segmentControlPointCount);
    }

    public void SetSegmentCount(uint segmentCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetSegmentCount, (nint)segmentCount);
    }

    public static MTLAccelerationStructureMotionCurveGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureMotionCurveGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLAccelerationStructureMotionCurveGeometryDescriptorSelector
{
    public static readonly Selector SetControlPointBuffers = Selector.Register("setControlPointBuffers:");

    public static readonly Selector SetControlPointCount = Selector.Register("setControlPointCount:");

    public static readonly Selector SetControlPointFormat = Selector.Register("setControlPointFormat:");

    public static readonly Selector SetControlPointStride = Selector.Register("setControlPointStride:");

    public static readonly Selector SetCurveBasis = Selector.Register("setCurveBasis:");

    public static readonly Selector SetCurveEndCaps = Selector.Register("setCurveEndCaps:");

    public static readonly Selector SetCurveType = Selector.Register("setCurveType:");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector SetRadiusBuffers = Selector.Register("setRadiusBuffers:");

    public static readonly Selector SetRadiusFormat = Selector.Register("setRadiusFormat:");

    public static readonly Selector SetRadiusStride = Selector.Register("setRadiusStride:");

    public static readonly Selector SetSegmentControlPointCount = Selector.Register("setSegmentControlPointCount:");

    public static readonly Selector SetSegmentCount = Selector.Register("setSegmentCount:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
