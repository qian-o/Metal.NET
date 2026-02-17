namespace Metal.NET;

file class MTLIndirectInstanceAccelerationStructureDescriptorSelector
{
    public static readonly Selector SetInstanceCountBuffer_ = Selector.Register("setInstanceCountBuffer:");
    public static readonly Selector SetInstanceCountBufferOffset_ = Selector.Register("setInstanceCountBufferOffset:");
    public static readonly Selector SetInstanceDescriptorBuffer_ = Selector.Register("setInstanceDescriptorBuffer:");
    public static readonly Selector SetInstanceDescriptorBufferOffset_ = Selector.Register("setInstanceDescriptorBufferOffset:");
    public static readonly Selector SetInstanceDescriptorStride_ = Selector.Register("setInstanceDescriptorStride:");
    public static readonly Selector SetInstanceDescriptorType_ = Selector.Register("setInstanceDescriptorType:");
    public static readonly Selector SetInstanceTransformationMatrixLayout_ = Selector.Register("setInstanceTransformationMatrixLayout:");
    public static readonly Selector SetMaxInstanceCount_ = Selector.Register("setMaxInstanceCount:");
    public static readonly Selector SetMaxMotionTransformCount_ = Selector.Register("setMaxMotionTransformCount:");
    public static readonly Selector SetMotionTransformBuffer_ = Selector.Register("setMotionTransformBuffer:");
    public static readonly Selector SetMotionTransformBufferOffset_ = Selector.Register("setMotionTransformBufferOffset:");
    public static readonly Selector SetMotionTransformCountBuffer_ = Selector.Register("setMotionTransformCountBuffer:");
    public static readonly Selector SetMotionTransformCountBufferOffset_ = Selector.Register("setMotionTransformCountBufferOffset:");
    public static readonly Selector SetMotionTransformStride_ = Selector.Register("setMotionTransformStride:");
    public static readonly Selector SetMotionTransformType_ = Selector.Register("setMotionTransformType:");
    public static readonly Selector Descriptor = Selector.Register("descriptor");
}

public class MTLIndirectInstanceAccelerationStructureDescriptor : IDisposable
{
    public MTLIndirectInstanceAccelerationStructureDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIndirectInstanceAccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIndirectInstanceAccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectInstanceAccelerationStructureDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLIndirectInstanceAccelerationStructureDescriptor");

    public void SetInstanceCountBuffer(MTLBuffer instanceCountBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceCountBuffer_, instanceCountBuffer.NativePtr);
    }

    public void SetInstanceCountBufferOffset(nuint instanceCountBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceCountBufferOffset_, (nint)instanceCountBufferOffset);
    }

    public void SetInstanceDescriptorBuffer(MTLBuffer instanceDescriptorBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBuffer_, instanceDescriptorBuffer.NativePtr);
    }

    public void SetInstanceDescriptorBufferOffset(nuint instanceDescriptorBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBufferOffset_, (nint)instanceDescriptorBufferOffset);
    }

    public void SetInstanceDescriptorStride(nuint instanceDescriptorStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorStride_, (nint)instanceDescriptorStride);
    }

    public void SetInstanceDescriptorType(MTLAccelerationStructureInstanceDescriptorType instanceDescriptorType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorType_, (nint)(uint)instanceDescriptorType);
    }

    public void SetInstanceTransformationMatrixLayout(MTLMatrixLayout instanceTransformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceTransformationMatrixLayout_, (nint)(uint)instanceTransformationMatrixLayout);
    }

    public void SetMaxInstanceCount(nuint maxInstanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMaxInstanceCount_, (nint)maxInstanceCount);
    }

    public void SetMaxMotionTransformCount(nuint maxMotionTransformCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMaxMotionTransformCount_, (nint)maxMotionTransformCount);
    }

    public void SetMotionTransformBuffer(MTLBuffer motionTransformBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBuffer_, motionTransformBuffer.NativePtr);
    }

    public void SetMotionTransformBufferOffset(nuint motionTransformBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBufferOffset_, (nint)motionTransformBufferOffset);
    }

    public void SetMotionTransformCountBuffer(MTLBuffer motionTransformCountBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCountBuffer_, motionTransformCountBuffer.NativePtr);
    }

    public void SetMotionTransformCountBufferOffset(nuint motionTransformCountBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCountBufferOffset_, (nint)motionTransformCountBufferOffset);
    }

    public void SetMotionTransformStride(nuint motionTransformStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformStride_, (nint)motionTransformStride);
    }

    public void SetMotionTransformType(MTLTransformType motionTransformType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformType_, (nint)(uint)motionTransformType);
    }

    public static MTLIndirectInstanceAccelerationStructureDescriptor Descriptor()
    {
        var result = new MTLIndirectInstanceAccelerationStructureDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLIndirectInstanceAccelerationStructureDescriptorSelector.Descriptor));

        return result;
    }

}
