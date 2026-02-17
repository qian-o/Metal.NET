namespace Metal.NET;

public class MTLInstanceAccelerationStructureDescriptor : IDisposable
{
    public MTLInstanceAccelerationStructureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLInstanceAccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLInstanceAccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLInstanceAccelerationStructureDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLInstanceAccelerationStructureDescriptor");

    public static MTLInstanceAccelerationStructureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLInstanceAccelerationStructureDescriptor(ptr);
    }

    public void SetInstanceCount(uint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceCount, (nint)instanceCount);
    }

    public void SetInstanceDescriptorBuffer(MTLBuffer instanceDescriptorBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBuffer, instanceDescriptorBuffer.NativePtr);
    }

    public void SetInstanceDescriptorBufferOffset(uint instanceDescriptorBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBufferOffset, (nint)instanceDescriptorBufferOffset);
    }

    public void SetInstanceDescriptorStride(uint instanceDescriptorStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorStride, (nint)instanceDescriptorStride);
    }

    public void SetInstanceDescriptorType(MTLAccelerationStructureInstanceDescriptorType instanceDescriptorType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorType, (nint)(uint)instanceDescriptorType);
    }

    public void SetInstanceTransformationMatrixLayout(MTLMatrixLayout instanceTransformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceTransformationMatrixLayout, (nint)(uint)instanceTransformationMatrixLayout);
    }

    public void SetInstancedAccelerationStructures(NSArray instancedAccelerationStructures)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstancedAccelerationStructures, instancedAccelerationStructures.NativePtr);
    }

    public void SetMotionTransformBuffer(MTLBuffer motionTransformBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBuffer, motionTransformBuffer.NativePtr);
    }

    public void SetMotionTransformBufferOffset(uint motionTransformBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBufferOffset, (nint)motionTransformBufferOffset);
    }

    public void SetMotionTransformCount(uint motionTransformCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCount, (nint)motionTransformCount);
    }

    public void SetMotionTransformStride(uint motionTransformStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformStride, (nint)motionTransformStride);
    }

    public void SetMotionTransformType(MTLTransformType motionTransformType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformType, (nint)(uint)motionTransformType);
    }

    public static MTLInstanceAccelerationStructureDescriptor Descriptor()
    {
        var result = new MTLInstanceAccelerationStructureDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLInstanceAccelerationStructureDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLInstanceAccelerationStructureDescriptorSelector
{
    public static readonly Selector SetInstanceCount = Selector.Register("setInstanceCount:");
    public static readonly Selector SetInstanceDescriptorBuffer = Selector.Register("setInstanceDescriptorBuffer:");
    public static readonly Selector SetInstanceDescriptorBufferOffset = Selector.Register("setInstanceDescriptorBufferOffset:");
    public static readonly Selector SetInstanceDescriptorStride = Selector.Register("setInstanceDescriptorStride:");
    public static readonly Selector SetInstanceDescriptorType = Selector.Register("setInstanceDescriptorType:");
    public static readonly Selector SetInstanceTransformationMatrixLayout = Selector.Register("setInstanceTransformationMatrixLayout:");
    public static readonly Selector SetInstancedAccelerationStructures = Selector.Register("setInstancedAccelerationStructures:");
    public static readonly Selector SetMotionTransformBuffer = Selector.Register("setMotionTransformBuffer:");
    public static readonly Selector SetMotionTransformBufferOffset = Selector.Register("setMotionTransformBufferOffset:");
    public static readonly Selector SetMotionTransformCount = Selector.Register("setMotionTransformCount:");
    public static readonly Selector SetMotionTransformStride = Selector.Register("setMotionTransformStride:");
    public static readonly Selector SetMotionTransformType = Selector.Register("setMotionTransformType:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
