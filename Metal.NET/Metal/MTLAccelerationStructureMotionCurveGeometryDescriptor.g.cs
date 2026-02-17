namespace Metal.NET;

file class MTLAccelerationStructureMotionCurveGeometryDescriptorSelector
{
    public static readonly Selector SetControlPointBuffers_ = Selector.Register("setControlPointBuffers:");
    public static readonly Selector SetControlPointCount_ = Selector.Register("setControlPointCount:");
    public static readonly Selector SetControlPointFormat_ = Selector.Register("setControlPointFormat:");
    public static readonly Selector SetControlPointStride_ = Selector.Register("setControlPointStride:");
    public static readonly Selector SetCurveBasis_ = Selector.Register("setCurveBasis:");
    public static readonly Selector SetCurveEndCaps_ = Selector.Register("setCurveEndCaps:");
    public static readonly Selector SetCurveType_ = Selector.Register("setCurveType:");
    public static readonly Selector SetIndexBuffer_ = Selector.Register("setIndexBuffer:");
    public static readonly Selector SetIndexBufferOffset_ = Selector.Register("setIndexBufferOffset:");
    public static readonly Selector SetIndexType_ = Selector.Register("setIndexType:");
    public static readonly Selector SetRadiusBuffers_ = Selector.Register("setRadiusBuffers:");
    public static readonly Selector SetRadiusFormat_ = Selector.Register("setRadiusFormat:");
    public static readonly Selector SetRadiusStride_ = Selector.Register("setRadiusStride:");
    public static readonly Selector SetSegmentControlPointCount_ = Selector.Register("setSegmentControlPointCount:");
    public static readonly Selector SetSegmentCount_ = Selector.Register("setSegmentCount:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureMotionCurveGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureMotionCurveGeometryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointBuffers_, controlPointBuffers.NativePtr);
    }

    public void SetControlPointCount(nuint controlPointCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointCount_, (nint)controlPointCount);
    }

    public void SetControlPointFormat(MTLAttributeFormat controlPointFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointFormat_, (nint)(uint)controlPointFormat);
    }

    public void SetControlPointStride(nuint controlPointStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetControlPointStride_, (nint)controlPointStride);
    }

    public void SetCurveBasis(MTLCurveBasis curveBasis)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveBasis_, (nint)(uint)curveBasis);
    }

    public void SetCurveEndCaps(MTLCurveEndCaps curveEndCaps)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveEndCaps_, (nint)(uint)curveEndCaps);
    }

    public void SetCurveType(MTLCurveType curveType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetCurveType_, (nint)(uint)curveType);
    }

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexBuffer_, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(nuint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexBufferOffset_, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetIndexType_, (nint)(uint)indexType);
    }

    public void SetRadiusBuffers(NSArray radiusBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusBuffers_, radiusBuffers.NativePtr);
    }

    public void SetRadiusFormat(MTLAttributeFormat radiusFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusFormat_, (nint)(uint)radiusFormat);
    }

    public void SetRadiusStride(nuint radiusStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetRadiusStride_, (nint)radiusStride);
    }

    public void SetSegmentControlPointCount(nuint segmentControlPointCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetSegmentControlPointCount_, (nint)segmentControlPointCount);
    }

    public void SetSegmentCount(nuint segmentCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.SetSegmentCount_, (nint)segmentCount);
    }

    public static MTLAccelerationStructureMotionCurveGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureMotionCurveGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureMotionCurveGeometryDescriptorSelector.Descriptor));

        return result;
    }

}
