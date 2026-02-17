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

    public void SetControlPointBuffer(MTLBuffer controlPointBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBuffer, controlPointBuffer.NativePtr);
    }

    public void SetControlPointBufferOffset(uint controlPointBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBufferOffset, (nint)controlPointBufferOffset);
    }

    public void SetControlPointCount(uint controlPointCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointCount, (nint)controlPointCount);
    }

    public void SetControlPointFormat(MTLAttributeFormat controlPointFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointFormat, (nint)(uint)controlPointFormat);
    }

    public void SetControlPointStride(uint controlPointStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointStride, (nint)controlPointStride);
    }

    public void SetCurveBasis(MTLCurveBasis curveBasis)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveBasis, (nint)(uint)curveBasis);
    }

    public void SetCurveEndCaps(MTLCurveEndCaps curveEndCaps)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveEndCaps, (nint)(uint)curveEndCaps);
    }

    public void SetCurveType(MTLCurveType curveType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveType, (nint)(uint)curveType);
    }

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBuffer, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(uint indexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBufferOffset, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexType, (nint)(uint)indexType);
    }

    public void SetRadiusBuffer(MTLBuffer radiusBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBuffer, radiusBuffer.NativePtr);
    }

    public void SetRadiusBufferOffset(uint radiusBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBufferOffset, (nint)radiusBufferOffset);
    }

    public void SetRadiusFormat(MTLAttributeFormat radiusFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusFormat, (nint)(uint)radiusFormat);
    }

    public void SetRadiusStride(uint radiusStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusStride, (nint)radiusStride);
    }

    public void SetSegmentControlPointCount(uint segmentControlPointCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentControlPointCount, (nint)segmentControlPointCount);
    }

    public void SetSegmentCount(uint segmentCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentCount, (nint)segmentCount);
    }

    public static MTLAccelerationStructureCurveGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureCurveGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLAccelerationStructureCurveGeometryDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLAccelerationStructureCurveGeometryDescriptorSelector
{
    public static readonly Selector SetControlPointBuffer = Selector.Register("setControlPointBuffer:");

    public static readonly Selector SetControlPointBufferOffset = Selector.Register("setControlPointBufferOffset:");

    public static readonly Selector SetControlPointCount = Selector.Register("setControlPointCount:");

    public static readonly Selector SetControlPointFormat = Selector.Register("setControlPointFormat:");

    public static readonly Selector SetControlPointStride = Selector.Register("setControlPointStride:");

    public static readonly Selector SetCurveBasis = Selector.Register("setCurveBasis:");

    public static readonly Selector SetCurveEndCaps = Selector.Register("setCurveEndCaps:");

    public static readonly Selector SetCurveType = Selector.Register("setCurveType:");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector SetRadiusBuffer = Selector.Register("setRadiusBuffer:");

    public static readonly Selector SetRadiusBufferOffset = Selector.Register("setRadiusBufferOffset:");

    public static readonly Selector SetRadiusFormat = Selector.Register("setRadiusFormat:");

    public static readonly Selector SetRadiusStride = Selector.Register("setRadiusStride:");

    public static readonly Selector SetSegmentControlPointCount = Selector.Register("setSegmentControlPointCount:");

    public static readonly Selector SetSegmentCount = Selector.Register("setSegmentCount:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
