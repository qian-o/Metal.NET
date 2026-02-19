namespace Metal.NET;

public readonly struct MTLInstanceAccelerationStructureDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLInstanceAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLInstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public nuint InstanceCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceCount, value);
    }

    public MTLBuffer? InstanceDescriptorBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value?.NativePtr ?? 0);
    }

    public nuint InstanceDescriptorBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBufferOffset, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public NSArray? InstancedAccelerationStructures
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstancedAccelerationStructures);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstancedAccelerationStructures, value?.NativePtr ?? 0);
    }

    public MTLBuffer? MotionTransformBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value?.NativePtr ?? 0);
    }

    public nuint MotionTransformBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBufferOffset, value);
    }

    public nuint MotionTransformCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCount, value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }

    public static MTLInstanceAccelerationStructureDescriptor? Descriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLInstanceAccelerationStructureDescriptorBindings.Class, MTLInstanceAccelerationStructureDescriptorBindings.Descriptor);
        return ptr is not 0 ? new MTLInstanceAccelerationStructureDescriptor(ptr) : default;
    }
}

file static class MTLInstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLInstanceAccelerationStructureDescriptor");

    public static readonly Selector Descriptor = Selector.Register("descriptor");

    public static readonly Selector InstanceCount = Selector.Register("instanceCount");

    public static readonly Selector InstancedAccelerationStructures = Selector.Register("instancedAccelerationStructures");

    public static readonly Selector InstanceDescriptorBuffer = Selector.Register("instanceDescriptorBuffer");

    public static readonly Selector InstanceDescriptorBufferOffset = Selector.Register("instanceDescriptorBufferOffset");

    public static readonly Selector InstanceDescriptorStride = Selector.Register("instanceDescriptorStride");

    public static readonly Selector InstanceDescriptorType = Selector.Register("instanceDescriptorType");

    public static readonly Selector InstanceTransformationMatrixLayout = Selector.Register("instanceTransformationMatrixLayout");

    public static readonly Selector MotionTransformBuffer = Selector.Register("motionTransformBuffer");

    public static readonly Selector MotionTransformBufferOffset = Selector.Register("motionTransformBufferOffset");

    public static readonly Selector MotionTransformCount = Selector.Register("motionTransformCount");

    public static readonly Selector MotionTransformStride = Selector.Register("motionTransformStride");

    public static readonly Selector MotionTransformType = Selector.Register("motionTransformType");

    public static readonly Selector SetInstanceCount = Selector.Register("setInstanceCount:");

    public static readonly Selector SetInstancedAccelerationStructures = Selector.Register("setInstancedAccelerationStructures:");

    public static readonly Selector SetInstanceDescriptorBuffer = Selector.Register("setInstanceDescriptorBuffer:");

    public static readonly Selector SetInstanceDescriptorBufferOffset = Selector.Register("setInstanceDescriptorBufferOffset:");

    public static readonly Selector SetInstanceDescriptorStride = Selector.Register("setInstanceDescriptorStride:");

    public static readonly Selector SetInstanceDescriptorType = Selector.Register("setInstanceDescriptorType:");

    public static readonly Selector SetInstanceTransformationMatrixLayout = Selector.Register("setInstanceTransformationMatrixLayout:");

    public static readonly Selector SetMotionTransformBuffer = Selector.Register("setMotionTransformBuffer:");

    public static readonly Selector SetMotionTransformBufferOffset = Selector.Register("setMotionTransformBufferOffset:");

    public static readonly Selector SetMotionTransformCount = Selector.Register("setMotionTransformCount:");

    public static readonly Selector SetMotionTransformStride = Selector.Register("setMotionTransformStride:");

    public static readonly Selector SetMotionTransformType = Selector.Register("setMotionTransformType:");
}
