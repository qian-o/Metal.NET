namespace Metal.NET;

public readonly struct MTL4IndirectInstanceAccelerationStructureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4AccelerationStructureDescriptor(MTL4IndirectInstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator MTLAccelerationStructureDescriptor(MTL4IndirectInstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4IndirectInstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public MTL4IndirectInstanceAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTL4IndirectInstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTL4IndirectInstanceAccelerationStructureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4BufferRange InstanceDescriptorBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    public nuint MaxInstanceCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MaxInstanceCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMaxInstanceCount, value);
    }

    public MTL4BufferRange InstanceCountBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveC.MsgSendULong(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    public MTL4BufferRange MotionTransformBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
    }

    public nuint MaxMotionTransformCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MaxMotionTransformCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMaxMotionTransformCount, value);
    }

    public MTL4BufferRange MotionTransformCountBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveC.MsgSendLong(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }
}

file static class MTL4IndirectInstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4IndirectInstanceAccelerationStructureDescriptor");

    public static readonly Selector InstanceCountBuffer = "instanceCountBuffer";

    public static readonly Selector InstanceDescriptorBuffer = "instanceDescriptorBuffer";

    public static readonly Selector InstanceDescriptorStride = "instanceDescriptorStride";

    public static readonly Selector InstanceDescriptorType = "instanceDescriptorType";

    public static readonly Selector InstanceTransformationMatrixLayout = "instanceTransformationMatrixLayout";

    public static readonly Selector MaxInstanceCount = "maxInstanceCount";

    public static readonly Selector MaxMotionTransformCount = "maxMotionTransformCount";

    public static readonly Selector MotionTransformBuffer = "motionTransformBuffer";

    public static readonly Selector MotionTransformCountBuffer = "motionTransformCountBuffer";

    public static readonly Selector MotionTransformStride = "motionTransformStride";

    public static readonly Selector MotionTransformType = "motionTransformType";

    public static readonly Selector SetInstanceCountBuffer = "setInstanceCountBuffer:";

    public static readonly Selector SetInstanceDescriptorBuffer = "setInstanceDescriptorBuffer:";

    public static readonly Selector SetInstanceDescriptorStride = "setInstanceDescriptorStride:";

    public static readonly Selector SetInstanceDescriptorType = "setInstanceDescriptorType:";

    public static readonly Selector SetInstanceTransformationMatrixLayout = "setInstanceTransformationMatrixLayout:";

    public static readonly Selector SetMaxInstanceCount = "setMaxInstanceCount:";

    public static readonly Selector SetMaxMotionTransformCount = "setMaxMotionTransformCount:";

    public static readonly Selector SetMotionTransformBuffer = "setMotionTransformBuffer:";

    public static readonly Selector SetMotionTransformCountBuffer = "setMotionTransformCountBuffer:";

    public static readonly Selector SetMotionTransformStride = "setMotionTransformStride:";

    public static readonly Selector SetMotionTransformType = "setMotionTransformType:";

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
