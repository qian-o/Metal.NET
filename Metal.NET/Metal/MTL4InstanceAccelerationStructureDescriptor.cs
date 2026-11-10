namespace Metal.NET;

public readonly struct MTL4InstanceAccelerationStructureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTL4AccelerationStructureDescriptor(MTL4InstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator MTLAccelerationStructureDescriptor(MTL4InstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4InstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public MTL4InstanceAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTL4InstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTL4InstanceAccelerationStructureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4BufferRange InstanceDescriptorBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    public nuint InstanceCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceCount, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveC.MsgSendULong(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    public MTL4BufferRange MotionTransformBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
    }

    public nuint MotionTransformCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.MotionTransformCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetMotionTransformCount, value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveC.MsgSendLong(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }
}

file static class MTL4InstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4InstanceAccelerationStructureDescriptor");

    public static readonly Selector InstanceCount = "instanceCount";

    public static readonly Selector InstanceDescriptorBuffer = "instanceDescriptorBuffer";

    public static readonly Selector InstanceDescriptorStride = "instanceDescriptorStride";

    public static readonly Selector InstanceDescriptorType = "instanceDescriptorType";

    public static readonly Selector InstanceTransformationMatrixLayout = "instanceTransformationMatrixLayout";

    public static readonly Selector MotionTransformBuffer = "motionTransformBuffer";

    public static readonly Selector MotionTransformCount = "motionTransformCount";

    public static readonly Selector MotionTransformStride = "motionTransformStride";

    public static readonly Selector MotionTransformType = "motionTransformType";

    public static readonly Selector SetInstanceCount = "setInstanceCount:";

    public static readonly Selector SetInstanceDescriptorBuffer = "setInstanceDescriptorBuffer:";

    public static readonly Selector SetInstanceDescriptorStride = "setInstanceDescriptorStride:";

    public static readonly Selector SetInstanceDescriptorType = "setInstanceDescriptorType:";

    public static readonly Selector SetInstanceTransformationMatrixLayout = "setInstanceTransformationMatrixLayout:";

    public static readonly Selector SetMotionTransformBuffer = "setMotionTransformBuffer:";

    public static readonly Selector SetMotionTransformCount = "setMotionTransformCount:";

    public static readonly Selector SetMotionTransformStride = "setMotionTransformStride:";

    public static readonly Selector SetMotionTransformType = "setMotionTransformType:";

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
