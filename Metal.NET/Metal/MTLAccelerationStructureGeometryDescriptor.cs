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

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.IntersectionFunctionTableOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetIntersectionFunctionTableOffset, (nuint)value);
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetLabel, value.NativePtr);
    }

    public Bool8 Opaque
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.Opaque);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetOpaque, value);
    }

    public MTLBuffer PrimitiveDataBuffer
    {
        get => new MTLBuffer(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.PrimitiveDataBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBuffer, value.NativePtr);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.PrimitiveDataBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBufferOffset, (nuint)value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.PrimitiveDataElementSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataElementSize, (nuint)value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.PrimitiveDataStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataStride, (nuint)value);
    }

}

file class MTLAccelerationStructureGeometryDescriptorSelector
{
    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = Selector.Register("allowDuplicateIntersectionFunctionInvocation");

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = Selector.Register("setAllowDuplicateIntersectionFunctionInvocation:");

    public static readonly Selector IntersectionFunctionTableOffset = Selector.Register("intersectionFunctionTableOffset");

    public static readonly Selector SetIntersectionFunctionTableOffset = Selector.Register("setIntersectionFunctionTableOffset:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Opaque = Selector.Register("opaque");

    public static readonly Selector SetOpaque = Selector.Register("setOpaque:");

    public static readonly Selector PrimitiveDataBuffer = Selector.Register("primitiveDataBuffer");

    public static readonly Selector SetPrimitiveDataBuffer = Selector.Register("setPrimitiveDataBuffer:");

    public static readonly Selector PrimitiveDataBufferOffset = Selector.Register("primitiveDataBufferOffset");

    public static readonly Selector SetPrimitiveDataBufferOffset = Selector.Register("setPrimitiveDataBufferOffset:");

    public static readonly Selector PrimitiveDataElementSize = Selector.Register("primitiveDataElementSize");

    public static readonly Selector SetPrimitiveDataElementSize = Selector.Register("setPrimitiveDataElementSize:");

    public static readonly Selector PrimitiveDataStride = Selector.Register("primitiveDataStride");

    public static readonly Selector SetPrimitiveDataStride = Selector.Register("setPrimitiveDataStride:");
}
