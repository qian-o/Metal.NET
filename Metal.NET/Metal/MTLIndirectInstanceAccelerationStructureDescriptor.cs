namespace Metal.NET;

public class MTLIndirectInstanceAccelerationStructureDescriptor : IDisposable
{
    public MTLIndirectInstanceAccelerationStructureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceCountBuffer, instanceCountBuffer.NativePtr);
    }

    public void SetInstanceCountBufferOffset(uint instanceCountBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceCountBufferOffset, (nint)instanceCountBufferOffset);
    }

    public void SetInstanceDescriptorBuffer(MTLBuffer instanceDescriptorBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBuffer, instanceDescriptorBuffer.NativePtr);
    }

    public void SetInstanceDescriptorBufferOffset(uint instanceDescriptorBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBufferOffset, (nint)instanceDescriptorBufferOffset);
    }

    public void SetInstanceDescriptorStride(uint instanceDescriptorStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorStride, (nint)instanceDescriptorStride);
    }

    public void SetInstanceDescriptorType(MTLAccelerationStructureInstanceDescriptorType instanceDescriptorType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorType, (nint)(uint)instanceDescriptorType);
    }

    public void SetInstanceTransformationMatrixLayout(MTLMatrixLayout instanceTransformationMatrixLayout)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceTransformationMatrixLayout, (nint)(uint)instanceTransformationMatrixLayout);
    }

    public void SetMaxInstanceCount(uint maxInstanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMaxInstanceCount, (nint)maxInstanceCount);
    }

    public void SetMaxMotionTransformCount(uint maxMotionTransformCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMaxMotionTransformCount, (nint)maxMotionTransformCount);
    }

    public void SetMotionTransformBuffer(MTLBuffer motionTransformBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBuffer, motionTransformBuffer.NativePtr);
    }

    public void SetMotionTransformBufferOffset(uint motionTransformBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBufferOffset, (nint)motionTransformBufferOffset);
    }

    public void SetMotionTransformCountBuffer(MTLBuffer motionTransformCountBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCountBuffer, motionTransformCountBuffer.NativePtr);
    }

    public void SetMotionTransformCountBufferOffset(uint motionTransformCountBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCountBufferOffset, (nint)motionTransformCountBufferOffset);
    }

    public void SetMotionTransformStride(uint motionTransformStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformStride, (nint)motionTransformStride);
    }

    public void SetMotionTransformType(MTLTransformType motionTransformType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformType, (nint)(uint)motionTransformType);
    }

    public static MTLIndirectInstanceAccelerationStructureDescriptor Descriptor()
    {
        MTLIndirectInstanceAccelerationStructureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLIndirectInstanceAccelerationStructureDescriptorSelector.Descriptor));

        return result;
    }

}

file class MTLIndirectInstanceAccelerationStructureDescriptorSelector
{
    public static readonly Selector SetInstanceCountBuffer = Selector.Register("setInstanceCountBuffer:");

    public static readonly Selector SetInstanceCountBufferOffset = Selector.Register("setInstanceCountBufferOffset:");

    public static readonly Selector SetInstanceDescriptorBuffer = Selector.Register("setInstanceDescriptorBuffer:");

    public static readonly Selector SetInstanceDescriptorBufferOffset = Selector.Register("setInstanceDescriptorBufferOffset:");

    public static readonly Selector SetInstanceDescriptorStride = Selector.Register("setInstanceDescriptorStride:");

    public static readonly Selector SetInstanceDescriptorType = Selector.Register("setInstanceDescriptorType:");

    public static readonly Selector SetInstanceTransformationMatrixLayout = Selector.Register("setInstanceTransformationMatrixLayout:");

    public static readonly Selector SetMaxInstanceCount = Selector.Register("setMaxInstanceCount:");

    public static readonly Selector SetMaxMotionTransformCount = Selector.Register("setMaxMotionTransformCount:");

    public static readonly Selector SetMotionTransformBuffer = Selector.Register("setMotionTransformBuffer:");

    public static readonly Selector SetMotionTransformBufferOffset = Selector.Register("setMotionTransformBufferOffset:");

    public static readonly Selector SetMotionTransformCountBuffer = Selector.Register("setMotionTransformCountBuffer:");

    public static readonly Selector SetMotionTransformCountBufferOffset = Selector.Register("setMotionTransformCountBufferOffset:");

    public static readonly Selector SetMotionTransformStride = Selector.Register("setMotionTransformStride:");

    public static readonly Selector SetMotionTransformType = Selector.Register("setMotionTransformType:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
