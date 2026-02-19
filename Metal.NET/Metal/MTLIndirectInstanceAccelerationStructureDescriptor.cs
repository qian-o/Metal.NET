namespace Metal.NET;

public class MTLIndirectInstanceAccelerationStructureDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLIndirectInstanceAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIndirectInstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTLBuffer? InstanceCountBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBuffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBuffer(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public nuint InstanceCountBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBufferOffset, value);
    }

    public MTLBuffer? InstanceDescriptorBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBuffer(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value?.NativePtr ?? 0);
            field = value;
        }
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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBuffer(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public nuint MotionTransformBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBufferOffset, value);
    }

    public MTLBuffer? MotionTransformCountBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBuffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBuffer(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, value?.NativePtr ?? 0);
            field = value;
        }
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
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLIndirectInstanceAccelerationStructureDescriptorBindings.Class, MTLIndirectInstanceAccelerationStructureDescriptorBindings.Descriptor);
        return ptr is not 0 ? new MTLIndirectInstanceAccelerationStructureDescriptor(ptr) : null;
    }
}

file static class MTLIndirectInstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIndirectInstanceAccelerationStructureDescriptor");

    public static readonly Selector Descriptor = Selector.Register("descriptor");

    public static readonly Selector InstanceCountBuffer = Selector.Register("instanceCountBuffer");

    public static readonly Selector InstanceCountBufferOffset = Selector.Register("instanceCountBufferOffset");

    public static readonly Selector InstanceDescriptorBuffer = Selector.Register("instanceDescriptorBuffer");

    public static readonly Selector InstanceDescriptorBufferOffset = Selector.Register("instanceDescriptorBufferOffset");

    public static readonly Selector InstanceDescriptorStride = Selector.Register("instanceDescriptorStride");

    public static readonly Selector InstanceDescriptorType = Selector.Register("instanceDescriptorType");

    public static readonly Selector InstanceTransformationMatrixLayout = Selector.Register("instanceTransformationMatrixLayout");

    public static readonly Selector MaxInstanceCount = Selector.Register("maxInstanceCount");

    public static readonly Selector MaxMotionTransformCount = Selector.Register("maxMotionTransformCount");

    public static readonly Selector MotionTransformBuffer = Selector.Register("motionTransformBuffer");

    public static readonly Selector MotionTransformBufferOffset = Selector.Register("motionTransformBufferOffset");

    public static readonly Selector MotionTransformCountBuffer = Selector.Register("motionTransformCountBuffer");

    public static readonly Selector MotionTransformCountBufferOffset = Selector.Register("motionTransformCountBufferOffset");

    public static readonly Selector MotionTransformStride = Selector.Register("motionTransformStride");

    public static readonly Selector MotionTransformType = Selector.Register("motionTransformType");

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
}
