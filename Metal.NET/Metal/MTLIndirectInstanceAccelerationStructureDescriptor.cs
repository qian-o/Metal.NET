namespace Metal.NET;

public class MTLIndirectInstanceAccelerationStructureDescriptor(nint nativePtr) : MTLAccelerationStructureDescriptor(nativePtr)
{
    public MTLIndirectInstanceAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIndirectInstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTLBuffer? InstanceCountBuffer
    {
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, value);
    }

    public nuint InstanceCountBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBufferOffset, value);
    }

    public MTLBuffer? InstanceDescriptorBuffer
    {
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
    }

    public nuint InstanceDescriptorBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBufferOffset, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public nuint MaxInstanceCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MaxInstanceCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMaxInstanceCount, value);
    }

    public nuint MaxMotionTransformCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MaxMotionTransformCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMaxMotionTransformCount, value);
    }

    public MTLBuffer? MotionTransformBuffer
    {
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
    }

    public nuint MotionTransformBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBufferOffset, value);
    }

    public MTLBuffer? MotionTransformCountBuffer
    {
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, value);
    }

    public nuint MotionTransformCountBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBufferOffset, value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }

    public static MTLIndirectInstanceAccelerationStructureDescriptor? Descriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLIndirectInstanceAccelerationStructureDescriptorBindings.Class, MTLIndirectInstanceAccelerationStructureDescriptorBindings.Descriptor);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }
}

file static class MTLIndirectInstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIndirectInstanceAccelerationStructureDescriptor");

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
}
