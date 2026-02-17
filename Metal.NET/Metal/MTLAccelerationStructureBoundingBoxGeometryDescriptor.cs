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

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureBoundingBoxGeometryDescriptor");

    public MTLBuffer BoundingBoxBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffer, value.NativePtr);
    }

    public nuint BoundingBoxBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBufferOffset, value);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount, value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.BoundingBoxStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride, value);
    }

    public static implicit operator nint(MTLAccelerationStructureBoundingBoxGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureBoundingBoxGeometryDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLAccelerationStructureBoundingBoxGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureBoundingBoxGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector.Descriptor));

        return result;
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

file class MTLAccelerationStructureBoundingBoxGeometryDescriptorSelector
{
    public static readonly Selector BoundingBoxBuffer = Selector.Register("boundingBoxBuffer");

    public static readonly Selector SetBoundingBoxBuffer = Selector.Register("setBoundingBoxBuffer:");

    public static readonly Selector BoundingBoxBufferOffset = Selector.Register("boundingBoxBufferOffset");

    public static readonly Selector SetBoundingBoxBufferOffset = Selector.Register("setBoundingBoxBufferOffset:");

    public static readonly Selector BoundingBoxCount = Selector.Register("boundingBoxCount");

    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");

    public static readonly Selector BoundingBoxStride = Selector.Register("boundingBoxStride");

    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
