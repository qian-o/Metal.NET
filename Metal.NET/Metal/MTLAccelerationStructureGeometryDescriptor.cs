namespace Metal.NET;

public class MTLAccelerationStructureGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureGeometryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetAllowDuplicateIntersectionFunctionInvocation, (nint)allowDuplicateIntersectionFunctionInvocation.Value);
    }

    public void SetIntersectionFunctionTableOffset(uint intersectionFunctionTableOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetIntersectionFunctionTableOffset, (nint)intersectionFunctionTableOffset);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetOpaque(Bool8 opaque)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetOpaque, (nint)opaque.Value);
    }

    public void SetPrimitiveDataBuffer(MTLBuffer primitiveDataBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBuffer, primitiveDataBuffer.NativePtr);
    }

    public void SetPrimitiveDataBufferOffset(uint primitiveDataBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBufferOffset, (nint)primitiveDataBufferOffset);
    }

    public void SetPrimitiveDataElementSize(uint primitiveDataElementSize)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataElementSize, (nint)primitiveDataElementSize);
    }

    public void SetPrimitiveDataStride(uint primitiveDataStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataStride, (nint)primitiveDataStride);
    }

}

file class MTLAccelerationStructureGeometryDescriptorSelector
{
    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = Selector.Register("setAllowDuplicateIntersectionFunctionInvocation:");

    public static readonly Selector SetIntersectionFunctionTableOffset = Selector.Register("setIntersectionFunctionTableOffset:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetOpaque = Selector.Register("setOpaque:");

    public static readonly Selector SetPrimitiveDataBuffer = Selector.Register("setPrimitiveDataBuffer:");

    public static readonly Selector SetPrimitiveDataBufferOffset = Selector.Register("setPrimitiveDataBufferOffset:");

    public static readonly Selector SetPrimitiveDataElementSize = Selector.Register("setPrimitiveDataElementSize:");

    public static readonly Selector SetPrimitiveDataStride = Selector.Register("setPrimitiveDataStride:");
}
