namespace Metal.NET;

file class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector
{
    public static readonly Selector SetBoundingBoxBuffers_ = Selector.Register("setBoundingBoxBuffers:");
    public static readonly Selector SetBoundingBoxCount_ = Selector.Register("setBoundingBoxCount:");
    public static readonly Selector SetBoundingBoxStride_ = Selector.Register("setBoundingBoxStride:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffers_, boundingBoxBuffers.NativePtr);
    }

    public void SetBoundingBoxCount(nuint boundingBoxCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount_, (nint)boundingBoxCount);
    }

    public void SetBoundingBoxStride(nuint boundingBoxStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride_, (nint)boundingBoxStride);
    }

    public static MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.Descriptor));

        return result;
    }

}
