namespace Metal.NET;

public class MTLAccelerationStructureBoundingBoxGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffer, boundingBoxBuffer.NativePtr);
    }

    public void SetBoundingBoxBufferOffset(uint boundingBoxBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBufferOffset, (nint)boundingBoxBufferOffset);
    }

    public void SetBoundingBoxCount(uint boundingBoxCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount, (nint)boundingBoxCount);
    }

    public void SetBoundingBoxStride(uint boundingBoxStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride, (nint)boundingBoxStride);
    }

    public static MTLAccelerationStructureBoundingBoxGeometryDescriptor Descriptor()
    {
        var result = new MTLAccelerationStructureBoundingBoxGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector
{
    public static readonly Selector SetBoundingBoxBuffer = Selector.Register("setBoundingBoxBuffer:");
    public static readonly Selector SetBoundingBoxBufferOffset = Selector.Register("setBoundingBoxBufferOffset:");
    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");
    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
