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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBuffer, controlPointBuffer.NativePtr);
    }

    public void SetControlPointBufferOffset(uint controlPointBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBufferOffset, (nint)controlPointBufferOffset);
    }

    public void SetControlPointCount(uint controlPointCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointCount, (nint)controlPointCount);
    }

    public void SetControlPointFormat(MTLAttributeFormat controlPointFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointFormat, (nint)(uint)controlPointFormat);
    }

    public void SetControlPointStride(uint controlPointStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointStride, (nint)controlPointStride);
    }

    public void SetCurveBasis(MTLCurveBasis curveBasis)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveBasis, (nint)(uint)curveBasis);
    }

    public void SetCurveEndCaps(MTLCurveEndCaps curveEndCaps)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveEndCaps, (nint)(uint)curveEndCaps);
    }

    public void SetCurveType(MTLCurveType curveType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveType, (nint)(uint)curveType);
    }

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBuffer, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(uint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBufferOffset, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexType, (nint)(uint)indexType);
    }

    public void SetRadiusBuffer(MTLBuffer radiusBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBuffer, radiusBuffer.NativePtr);
    }

    public void SetRadiusBufferOffset(uint radiusBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBufferOffset, (nint)radiusBufferOffset);
    }

    public void SetRadiusFormat(MTLAttributeFormat radiusFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusFormat, (nint)(uint)radiusFormat);
    }

    public void SetRadiusStride(uint radiusStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusStride, (nint)radiusStride);
    }

    public void SetSegmentControlPointCount(uint segmentControlPointCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentControlPointCount, (nint)segmentControlPointCount);
    }

    public void SetSegmentCount(uint segmentCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentCount, (nint)segmentCount);
    }

    public static MTLAccelerationStructureCurveGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureCurveGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureCurveGeometryDescriptorSelector.Descriptor));

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
