namespace Metal.NET;

public readonly struct MTLIndirectInstanceAccelerationStructureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLAccelerationStructureDescriptor(MTLIndirectInstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLIndirectInstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public MTLIndirectInstanceAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTLIndirectInstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTLIndirectInstanceAccelerationStructureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLBuffer InstanceDescriptorBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value.NativePtr);
    }

    public nuint InstanceDescriptorBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBufferOffset, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    public nuint MaxInstanceCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MaxInstanceCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMaxInstanceCount, value);
    }

    public MTLBuffer InstanceCountBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, value.NativePtr);
    }

    public nuint InstanceCountBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBufferOffset, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveC.MsgSendULong(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    public MTLBuffer MotionTransformBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value.NativePtr);
    }

    public nuint MotionTransformBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBufferOffset, value);
    }

    public nuint MaxMotionTransformCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MaxMotionTransformCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMaxMotionTransformCount, value);
    }

    public MTLBuffer MotionTransformCountBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, value.NativePtr);
    }

    public nuint MotionTransformCountBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBufferOffset, value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveC.MsgSendLong(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLIndirectInstanceAccelerationStructureDescriptorBindings.Class, MTLIndirectInstanceAccelerationStructureDescriptorBindings.Descriptor);
    }
}

file static class MTLIndirectInstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLIndirectInstanceAccelerationStructureDescriptor");

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector InstanceCountBuffer = "instanceCountBuffer";

    public static readonly Selector InstanceCountBufferOffset = "instanceCountBufferOffset";

    public static readonly Selector InstanceDescriptorBuffer = "instanceDescriptorBuffer";

    public static readonly Selector InstanceDescriptorBufferOffset = "instanceDescriptorBufferOffset";

    public static readonly Selector InstanceDescriptorStride = "instanceDescriptorStride";

    public static readonly Selector InstanceDescriptorType = "instanceDescriptorType";

    public static readonly Selector InstanceTransformationMatrixLayout = "instanceTransformationMatrixLayout";

    public static readonly Selector MaxInstanceCount = "maxInstanceCount";

    public static readonly Selector MaxMotionTransformCount = "maxMotionTransformCount";

    public static readonly Selector MotionTransformBuffer = "motionTransformBuffer";

    public static readonly Selector MotionTransformBufferOffset = "motionTransformBufferOffset";

    public static readonly Selector MotionTransformCountBuffer = "motionTransformCountBuffer";

    public static readonly Selector MotionTransformCountBufferOffset = "motionTransformCountBufferOffset";

    public static readonly Selector MotionTransformStride = "motionTransformStride";

    public static readonly Selector MotionTransformType = "motionTransformType";

    public static readonly Selector SetInstanceCountBuffer = "setInstanceCountBuffer:";

    public static readonly Selector SetInstanceCountBufferOffset = "setInstanceCountBufferOffset:";

    public static readonly Selector SetInstanceDescriptorBuffer = "setInstanceDescriptorBuffer:";

    public static readonly Selector SetInstanceDescriptorBufferOffset = "setInstanceDescriptorBufferOffset:";

    public static readonly Selector SetInstanceDescriptorStride = "setInstanceDescriptorStride:";

    public static readonly Selector SetInstanceDescriptorType = "setInstanceDescriptorType:";

    public static readonly Selector SetInstanceTransformationMatrixLayout = "setInstanceTransformationMatrixLayout:";

    public static readonly Selector SetMaxInstanceCount = "setMaxInstanceCount:";

    public static readonly Selector SetMaxMotionTransformCount = "setMaxMotionTransformCount:";

    public static readonly Selector SetMotionTransformBuffer = "setMotionTransformBuffer:";

    public static readonly Selector SetMotionTransformBufferOffset = "setMotionTransformBufferOffset:";

    public static readonly Selector SetMotionTransformCountBuffer = "setMotionTransformCountBuffer:";

    public static readonly Selector SetMotionTransformCountBufferOffset = "setMotionTransformCountBufferOffset:";

    public static readonly Selector SetMotionTransformStride = "setMotionTransformStride:";

    public static readonly Selector SetMotionTransformType = "setMotionTransformType:";

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
