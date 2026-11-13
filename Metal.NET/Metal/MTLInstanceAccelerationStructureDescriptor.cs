namespace Metal.NET;

public readonly struct MTLInstanceAccelerationStructureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLAccelerationStructureDescriptor(MTLInstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLInstanceAccelerationStructureDescriptor value) => new(value.NativePtr);

    public MTLInstanceAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTLInstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTLInstanceAccelerationStructureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLBuffer InstanceDescriptorBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value.NativePtr);
    }

    public nuint InstanceDescriptorBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBufferOffset, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    public nuint InstanceCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceCount, value);
    }

    public NSArray<MTLAccelerationStructure> InstancedAccelerationStructures
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstancedAccelerationStructures));
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstancedAccelerationStructures, value.NativePtr);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveC.MsgSendULong(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    public MTLBuffer MotionTransformBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value.NativePtr);
    }

    public nuint MotionTransformBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBufferOffset, value);
    }

    public nuint MotionTransformCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCount, value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveC.MsgSendLong(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLInstanceAccelerationStructureDescriptorBindings.Class, MTLInstanceAccelerationStructureDescriptorBindings.Descriptor);
    }
}

file static class MTLInstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLInstanceAccelerationStructureDescriptor");

    public static readonly Selector Descriptor = "descriptor";

    public static readonly Selector InstanceCount = "instanceCount";

    public static readonly Selector InstancedAccelerationStructures = "instancedAccelerationStructures";

    public static readonly Selector InstanceDescriptorBuffer = "instanceDescriptorBuffer";

    public static readonly Selector InstanceDescriptorBufferOffset = "instanceDescriptorBufferOffset";

    public static readonly Selector InstanceDescriptorStride = "instanceDescriptorStride";

    public static readonly Selector InstanceDescriptorType = "instanceDescriptorType";

    public static readonly Selector InstanceTransformationMatrixLayout = "instanceTransformationMatrixLayout";

    public static readonly Selector MotionTransformBuffer = "motionTransformBuffer";

    public static readonly Selector MotionTransformBufferOffset = "motionTransformBufferOffset";

    public static readonly Selector MotionTransformCount = "motionTransformCount";

    public static readonly Selector MotionTransformStride = "motionTransformStride";

    public static readonly Selector MotionTransformType = "motionTransformType";

    public static readonly Selector SetInstanceCount = "setInstanceCount:";

    public static readonly Selector SetInstancedAccelerationStructures = "setInstancedAccelerationStructures:";

    public static readonly Selector SetInstanceDescriptorBuffer = "setInstanceDescriptorBuffer:";

    public static readonly Selector SetInstanceDescriptorBufferOffset = "setInstanceDescriptorBufferOffset:";

    public static readonly Selector SetInstanceDescriptorStride = "setInstanceDescriptorStride:";

    public static readonly Selector SetInstanceDescriptorType = "setInstanceDescriptorType:";

    public static readonly Selector SetInstanceTransformationMatrixLayout = "setInstanceTransformationMatrixLayout:";

    public static readonly Selector SetMotionTransformBuffer = "setMotionTransformBuffer:";

    public static readonly Selector SetMotionTransformBufferOffset = "setMotionTransformBufferOffset:";

    public static readonly Selector SetMotionTransformCount = "setMotionTransformCount:";

    public static readonly Selector SetMotionTransformStride = "setMotionTransformStride:";

    public static readonly Selector SetMotionTransformType = "setMotionTransformType:";

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
