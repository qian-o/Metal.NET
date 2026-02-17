namespace Metal.NET;

file class MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector
{
    public static readonly Selector SetBoundingBoxBuffer_ = Selector.Register("setBoundingBoxBuffer:");
    public static readonly Selector SetBoundingBoxBufferOffset_ = Selector.Register("setBoundingBoxBufferOffset:");
    public static readonly Selector SetBoundingBoxCount_ = Selector.Register("setBoundingBoxCount:");
    public static readonly Selector SetBoundingBoxStride_ = Selector.Register("setBoundingBoxStride:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureBoundingBoxGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLAccelerationStructureBoundingBoxGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureBoundingBoxGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureBoundingBoxGeometryDescriptor");

    public void SetBoundingBoxBuffer(MTLBuffer boundingBoxBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffer_, boundingBoxBuffer.NativePtr);
    }

    public void SetBoundingBoxBufferOffset(nuint boundingBoxBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBufferOffset_, (nint)boundingBoxBufferOffset);
    }

    public void SetBoundingBoxCount(nuint boundingBoxCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount_, (nint)boundingBoxCount);
    }

    public void SetBoundingBoxStride(nuint boundingBoxStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride_, (nint)boundingBoxStride);
    }

    public static MTLAccelerationStructureBoundingBoxGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureBoundingBoxGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.Descriptor));

        return result;
    }

}
