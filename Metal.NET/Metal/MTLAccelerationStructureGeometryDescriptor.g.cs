namespace Metal.NET;

file class MTLAccelerationStructureGeometryDescriptorSelector
{
    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation_ = Selector.Register("setAllowDuplicateIntersectionFunctionInvocation:");
    public static readonly Selector SetIntersectionFunctionTableOffset_ = Selector.Register("setIntersectionFunctionTableOffset:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetOpaque_ = Selector.Register("setOpaque:");
    public static readonly Selector SetPrimitiveDataBuffer_ = Selector.Register("setPrimitiveDataBuffer:");
    public static readonly Selector SetPrimitiveDataBufferOffset_ = Selector.Register("setPrimitiveDataBufferOffset:");
    public static readonly Selector SetPrimitiveDataElementSize_ = Selector.Register("setPrimitiveDataElementSize:");
    public static readonly Selector SetPrimitiveDataStride_ = Selector.Register("setPrimitiveDataStride:");
}

public class MTLAccelerationStructureGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureGeometryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLAccelerationStructureGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureGeometryDescriptor(nint value)
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

    public void SetAllowDuplicateIntersectionFunctionInvocation(Bool8 allowDuplicateIntersectionFunctionInvocation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetAllowDuplicateIntersectionFunctionInvocation_, (nint)allowDuplicateIntersectionFunctionInvocation.Value);
    }

    public void SetIntersectionFunctionTableOffset(nuint intersectionFunctionTableOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetIntersectionFunctionTableOffset_, (nint)intersectionFunctionTableOffset);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetOpaque(Bool8 opaque)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetOpaque_, (nint)opaque.Value);
    }

    public void SetPrimitiveDataBuffer(MTLBuffer primitiveDataBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBuffer_, primitiveDataBuffer.NativePtr);
    }

    public void SetPrimitiveDataBufferOffset(nuint primitiveDataBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBufferOffset_, (nint)primitiveDataBufferOffset);
    }

    public void SetPrimitiveDataElementSize(nuint primitiveDataElementSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataElementSize_, (nint)primitiveDataElementSize);
    }

    public void SetPrimitiveDataStride(nuint primitiveDataStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataStride_, (nint)primitiveDataStride);
    }

}
