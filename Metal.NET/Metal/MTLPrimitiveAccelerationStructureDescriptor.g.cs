namespace Metal.NET;

public class MTLPrimitiveAccelerationStructureDescriptor : IDisposable
{
    public MTLPrimitiveAccelerationStructureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLPrimitiveAccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLPrimitiveAccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPrimitiveAccelerationStructureDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLPrimitiveAccelerationStructureDescriptor");

    public static MTLPrimitiveAccelerationStructureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLPrimitiveAccelerationStructureDescriptor(ptr);
    }

    public void SetGeometryDescriptors(NSArray geometryDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetGeometryDescriptors, geometryDescriptors.NativePtr);
    }

    public void SetMotionEndBorderMode(MTLMotionBorderMode motionEndBorderMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionEndBorderMode, (nint)(uint)motionEndBorderMode);
    }

    public void SetMotionEndTime(float motionEndTime)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionEndTime, motionEndTime);
    }

    public void SetMotionKeyframeCount(uint motionKeyframeCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionKeyframeCount, (nint)motionKeyframeCount);
    }

    public void SetMotionStartBorderMode(MTLMotionBorderMode motionStartBorderMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionStartBorderMode, (nint)(uint)motionStartBorderMode);
    }

    public void SetMotionStartTime(float motionStartTime)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionStartTime, motionStartTime);
    }

    public static MTLPrimitiveAccelerationStructureDescriptor Descriptor()
    {
        var result = new MTLPrimitiveAccelerationStructureDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLPrimitiveAccelerationStructureDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLPrimitiveAccelerationStructureDescriptorSelector
{
    public static readonly Selector SetGeometryDescriptors = Selector.Register("setGeometryDescriptors:");
    public static readonly Selector SetMotionEndBorderMode = Selector.Register("setMotionEndBorderMode:");
    public static readonly Selector SetMotionEndTime = Selector.Register("setMotionEndTime:");
    public static readonly Selector SetMotionKeyframeCount = Selector.Register("setMotionKeyframeCount:");
    public static readonly Selector SetMotionStartBorderMode = Selector.Register("setMotionStartBorderMode:");
    public static readonly Selector SetMotionStartTime = Selector.Register("setMotionStartTime:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
