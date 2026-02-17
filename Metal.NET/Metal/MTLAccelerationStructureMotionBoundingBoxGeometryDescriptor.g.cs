namespace Metal.NET;

public class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public void SetBoundingBoxBuffers(NSArray boundingBoxBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffers, boundingBoxBuffers.NativePtr);
    }

    public void SetBoundingBoxCount(uint boundingBoxCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount, (nint)boundingBoxCount);
    }

    public void SetBoundingBoxStride(uint boundingBoxStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride, (nint)boundingBoxStride);
    }

    public static MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector
{
    public static readonly Selector SetBoundingBoxBuffers = Selector.Register("setBoundingBoxBuffers:");
    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");
    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
