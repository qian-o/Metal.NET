namespace Metal.NET;

public class MTLIndirectInstanceAccelerationStructureDescriptor : IDisposable
{
    public MTLIndirectInstanceAccelerationStructureDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIndirectInstanceAccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIndirectInstanceAccelerationStructureDescriptor");

    public MTLBuffer InstanceCountBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.InstanceCountBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceCountBuffer, value.NativePtr);
    }

    public nuint InstanceCountBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.InstanceCountBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceCountBufferOffset, value);
    }

    public MTLBuffer InstanceDescriptorBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBuffer, value.NativePtr);
    }

    public nuint InstanceDescriptorBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBufferOffset, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorStride, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorType, (uint)value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.InstanceTransformationMatrixLayout));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceTransformationMatrixLayout, (uint)value);
    }

    public nuint MaxInstanceCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.MaxInstanceCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMaxInstanceCount, value);
    }

    public nuint MaxMotionTransformCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.MaxMotionTransformCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMaxMotionTransformCount, value);
    }

    public MTLBuffer MotionTransformBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBuffer, value.NativePtr);
    }

    public nuint MotionTransformBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBufferOffset, value);
    }

    public MTLBuffer MotionTransformCountBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformCountBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCountBuffer, value.NativePtr);
    }

    public nuint MotionTransformCountBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformCountBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCountBufferOffset, value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformStride, value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformType, (uint)value);
    }

    public static implicit operator nint(MTLIndirectInstanceAccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectInstanceAccelerationStructureDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLIndirectInstanceAccelerationStructureDescriptor Descriptor()
    {
        MTLIndirectInstanceAccelerationStructureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLIndirectInstanceAccelerationStructureDescriptorSelector.Descriptor));

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

file class MTLIndirectInstanceAccelerationStructureDescriptorSelector
{
    public static readonly Selector InstanceCountBuffer = Selector.Register("instanceCountBuffer");

    public static readonly Selector SetInstanceCountBuffer = Selector.Register("setInstanceCountBuffer:");

    public static readonly Selector InstanceCountBufferOffset = Selector.Register("instanceCountBufferOffset");

    public static readonly Selector SetInstanceCountBufferOffset = Selector.Register("setInstanceCountBufferOffset:");

    public static readonly Selector InstanceDescriptorBuffer = Selector.Register("instanceDescriptorBuffer");

    public static readonly Selector SetInstanceDescriptorBuffer = Selector.Register("setInstanceDescriptorBuffer:");

    public static readonly Selector InstanceDescriptorBufferOffset = Selector.Register("instanceDescriptorBufferOffset");

    public static readonly Selector SetInstanceDescriptorBufferOffset = Selector.Register("setInstanceDescriptorBufferOffset:");

    public static readonly Selector InstanceDescriptorStride = Selector.Register("instanceDescriptorStride");

    public static readonly Selector SetInstanceDescriptorStride = Selector.Register("setInstanceDescriptorStride:");

    public static readonly Selector InstanceDescriptorType = Selector.Register("instanceDescriptorType");

    public static readonly Selector SetInstanceDescriptorType = Selector.Register("setInstanceDescriptorType:");

    public static readonly Selector InstanceTransformationMatrixLayout = Selector.Register("instanceTransformationMatrixLayout");

    public static readonly Selector SetInstanceTransformationMatrixLayout = Selector.Register("setInstanceTransformationMatrixLayout:");

    public static readonly Selector MaxInstanceCount = Selector.Register("maxInstanceCount");

    public static readonly Selector SetMaxInstanceCount = Selector.Register("setMaxInstanceCount:");

    public static readonly Selector MaxMotionTransformCount = Selector.Register("maxMotionTransformCount");

    public static readonly Selector SetMaxMotionTransformCount = Selector.Register("setMaxMotionTransformCount:");

    public static readonly Selector MotionTransformBuffer = Selector.Register("motionTransformBuffer");

    public static readonly Selector SetMotionTransformBuffer = Selector.Register("setMotionTransformBuffer:");

    public static readonly Selector MotionTransformBufferOffset = Selector.Register("motionTransformBufferOffset");

    public static readonly Selector SetMotionTransformBufferOffset = Selector.Register("setMotionTransformBufferOffset:");

    public static readonly Selector MotionTransformCountBuffer = Selector.Register("motionTransformCountBuffer");

    public static readonly Selector SetMotionTransformCountBuffer = Selector.Register("setMotionTransformCountBuffer:");

    public static readonly Selector MotionTransformCountBufferOffset = Selector.Register("motionTransformCountBufferOffset");

    public static readonly Selector SetMotionTransformCountBufferOffset = Selector.Register("setMotionTransformCountBufferOffset:");

    public static readonly Selector MotionTransformStride = Selector.Register("motionTransformStride");

    public static readonly Selector SetMotionTransformStride = Selector.Register("setMotionTransformStride:");

    public static readonly Selector MotionTransformType = Selector.Register("motionTransformType");

    public static readonly Selector SetMotionTransformType = Selector.Register("setMotionTransformType:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
