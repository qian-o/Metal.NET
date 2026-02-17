namespace Metal.NET;

file class MTLInstanceAccelerationStructureDescriptorSelector
{
    public static readonly Selector SetInstanceCount_ = Selector.Register("setInstanceCount:");
    public static readonly Selector SetInstanceDescriptorBuffer_ = Selector.Register("setInstanceDescriptorBuffer:");
    public static readonly Selector SetInstanceDescriptorBufferOffset_ = Selector.Register("setInstanceDescriptorBufferOffset:");
    public static readonly Selector SetInstanceDescriptorStride_ = Selector.Register("setInstanceDescriptorStride:");
    public static readonly Selector SetInstanceDescriptorType_ = Selector.Register("setInstanceDescriptorType:");
    public static readonly Selector SetInstanceTransformationMatrixLayout_ = Selector.Register("setInstanceTransformationMatrixLayout:");
    public static readonly Selector SetInstancedAccelerationStructures_ = Selector.Register("setInstancedAccelerationStructures:");
    public static readonly Selector SetMotionTransformBuffer_ = Selector.Register("setMotionTransformBuffer:");
    public static readonly Selector SetMotionTransformBufferOffset_ = Selector.Register("setMotionTransformBufferOffset:");
    public static readonly Selector SetMotionTransformCount_ = Selector.Register("setMotionTransformCount:");
    public static readonly Selector SetMotionTransformStride_ = Selector.Register("setMotionTransformStride:");
    public static readonly Selector SetMotionTransformType_ = Selector.Register("setMotionTransformType:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}

public class MTLInstanceAccelerationStructureDescriptor : IDisposable
{
    public MTLInstanceAccelerationStructureDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void SetInstanceCount(nuint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceCount_, (nint)instanceCount);
    }

    public void SetInstanceDescriptorBuffer(MTLBuffer instanceDescriptorBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBuffer_, instanceDescriptorBuffer.NativePtr);
    }

    public void SetInstanceDescriptorBufferOffset(nuint instanceDescriptorBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBufferOffset_, (nint)instanceDescriptorBufferOffset);
    }

    public void SetInstanceDescriptorStride(nuint instanceDescriptorStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorStride_, (nint)instanceDescriptorStride);
    }

    public void SetInstanceDescriptorType(MTLAccelerationStructureInstanceDescriptorType instanceDescriptorType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorType_, (nint)(uint)instanceDescriptorType);
    }

    public void SetInstanceTransformationMatrixLayout(MTLMatrixLayout instanceTransformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceTransformationMatrixLayout_, (nint)(uint)instanceTransformationMatrixLayout);
    }

    public void SetInstancedAccelerationStructures(NSArray instancedAccelerationStructures)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstancedAccelerationStructures_, instancedAccelerationStructures.NativePtr);
    }

    public void SetMotionTransformBuffer(MTLBuffer motionTransformBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBuffer_, motionTransformBuffer.NativePtr);
    }

    public void SetMotionTransformBufferOffset(nuint motionTransformBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBufferOffset_, (nint)motionTransformBufferOffset);
    }

    public void SetMotionTransformCount(nuint motionTransformCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCount_, (nint)motionTransformCount);
    }

    public void SetMotionTransformStride(nuint motionTransformStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformStride_, (nint)motionTransformStride);
    }

    public void SetMotionTransformType(MTLTransformType motionTransformType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformType_, (nint)(uint)motionTransformType);
    }

    public static MTLInstanceAccelerationStructureDescriptor Descriptor()
    {
        var result = new MTLInstanceAccelerationStructureDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLInstanceAccelerationStructureDescriptorSelector.Descriptor));

        return result;
    }

}
