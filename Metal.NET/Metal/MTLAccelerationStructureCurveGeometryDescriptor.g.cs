namespace Metal.NET;

file class MTLAccelerationStructureCurveGeometryDescriptorSelector
{
    public static readonly Selector SetControlPointBuffer_ = Selector.Register("setControlPointBuffer:");
    public static readonly Selector SetControlPointBufferOffset_ = Selector.Register("setControlPointBufferOffset:");
    public static readonly Selector SetControlPointCount_ = Selector.Register("setControlPointCount:");
    public static readonly Selector SetControlPointFormat_ = Selector.Register("setControlPointFormat:");
    public static readonly Selector SetControlPointStride_ = Selector.Register("setControlPointStride:");
    public static readonly Selector SetCurveBasis_ = Selector.Register("setCurveBasis:");
    public static readonly Selector SetCurveEndCaps_ = Selector.Register("setCurveEndCaps:");
    public static readonly Selector SetCurveType_ = Selector.Register("setCurveType:");
    public static readonly Selector SetIndexBuffer_ = Selector.Register("setIndexBuffer:");
    public static readonly Selector SetIndexBufferOffset_ = Selector.Register("setIndexBufferOffset:");
    public static readonly Selector SetIndexType_ = Selector.Register("setIndexType:");
    public static readonly Selector SetRadiusBuffer_ = Selector.Register("setRadiusBuffer:");
    public static readonly Selector SetRadiusBufferOffset_ = Selector.Register("setRadiusBufferOffset:");
    public static readonly Selector SetRadiusFormat_ = Selector.Register("setRadiusFormat:");
    public static readonly Selector SetRadiusStride_ = Selector.Register("setRadiusStride:");
    public static readonly Selector SetSegmentControlPointCount_ = Selector.Register("setSegmentControlPointCount:");
    public static readonly Selector SetSegmentCount_ = Selector.Register("setSegmentCount:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureCurveGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureCurveGeometryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBuffer_, controlPointBuffer.NativePtr);
    }

    public void SetControlPointBufferOffset(nuint controlPointBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointBufferOffset_, (nint)controlPointBufferOffset);
    }

    public void SetControlPointCount(nuint controlPointCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointCount_, (nint)controlPointCount);
    }

    public void SetControlPointFormat(MTLAttributeFormat controlPointFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointFormat_, (nint)(uint)controlPointFormat);
    }

    public void SetControlPointStride(nuint controlPointStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetControlPointStride_, (nint)controlPointStride);
    }

    public void SetCurveBasis(MTLCurveBasis curveBasis)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveBasis_, (nint)(uint)curveBasis);
    }

    public void SetCurveEndCaps(MTLCurveEndCaps curveEndCaps)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveEndCaps_, (nint)(uint)curveEndCaps);
    }

    public void SetCurveType(MTLCurveType curveType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetCurveType_, (nint)(uint)curveType);
    }

    public void SetIndexBuffer(MTLBuffer indexBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBuffer_, indexBuffer.NativePtr);
    }

    public void SetIndexBufferOffset(nuint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexBufferOffset_, (nint)indexBufferOffset);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetIndexType_, (nint)(uint)indexType);
    }

    public void SetRadiusBuffer(MTLBuffer radiusBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBuffer_, radiusBuffer.NativePtr);
    }

    public void SetRadiusBufferOffset(nuint radiusBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusBufferOffset_, (nint)radiusBufferOffset);
    }

    public void SetRadiusFormat(MTLAttributeFormat radiusFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusFormat_, (nint)(uint)radiusFormat);
    }

    public void SetRadiusStride(nuint radiusStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetRadiusStride_, (nint)radiusStride);
    }

    public void SetSegmentControlPointCount(nuint segmentControlPointCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentControlPointCount_, (nint)segmentControlPointCount);
    }

    public void SetSegmentCount(nuint segmentCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCurveGeometryDescriptorSelector.SetSegmentCount_, (nint)segmentCount);
    }

    public static MTLAccelerationStructureCurveGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureCurveGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureCurveGeometryDescriptorSelector.Descriptor));

        return result;
    }

}
