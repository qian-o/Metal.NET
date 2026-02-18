namespace Metal.NET;

public class MTL4AccelerationStructureGeometryDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureGeometryDescriptor");

    public MTL4AccelerationStructureGeometryDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4AccelerationStructureGeometryDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4AccelerationStructureGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.IntersectionFunctionTableOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.SetIntersectionFunctionTableOffset, value);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.SetLabel, value.NativePtr);
    }

    public Bool8 Opaque
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.Opaque);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.SetOpaque, value);
    }

    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.PrimitiveDataBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.PrimitiveDataElementSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataElementSize, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.PrimitiveDataStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorSelector.SetPrimitiveDataStride, value);
    }

    public static implicit operator nint(MTL4AccelerationStructureGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4AccelerationStructureGeometryDescriptor(nint value)
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
}

file class MTL4AccelerationStructureGeometryDescriptorSelector
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

    public static readonly Selector PrimitiveDataElementSize = Selector.Register("primitiveDataElementSize");

    public static readonly Selector SetPrimitiveDataElementSize = Selector.Register("setPrimitiveDataElementSize:");

    public static readonly Selector PrimitiveDataStride = Selector.Register("primitiveDataStride");

    public static readonly Selector SetPrimitiveDataStride = Selector.Register("setPrimitiveDataStride:");
}
