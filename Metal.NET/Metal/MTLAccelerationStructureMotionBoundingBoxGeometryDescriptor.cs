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

    public NSArray BoundingBoxBuffers
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.BoundingBoxBuffers));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxBuffers, value.NativePtr);
    }

    public nuint BoundingBoxCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.BoundingBoxCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxCount, (nuint)value);
    }

    public nuint BoundingBoxStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.BoundingBoxStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.SetBoundingBoxStride, (nuint)value);
    }

    public static MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptorSelector
{
    public static readonly Selector BoundingBoxBuffers = Selector.Register("boundingBoxBuffers");

    public static readonly Selector SetBoundingBoxBuffers = Selector.Register("setBoundingBoxBuffers:");

    public static readonly Selector BoundingBoxCount = Selector.Register("boundingBoxCount");

    public static readonly Selector SetBoundingBoxCount = Selector.Register("setBoundingBoxCount:");

    public static readonly Selector BoundingBoxStride = Selector.Register("boundingBoxStride");

    public static readonly Selector SetBoundingBoxStride = Selector.Register("setBoundingBoxStride:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
