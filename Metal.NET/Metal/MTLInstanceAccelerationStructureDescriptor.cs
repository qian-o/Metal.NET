namespace Metal.NET;

public class MTLInstanceAccelerationStructureDescriptor(nint nativePtr) : MTLAccelerationStructureDescriptor(nativePtr)
{
    public MTLInstanceAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLInstanceAccelerationStructureDescriptorSelector.Class))
    {
    }

    public nuint InstanceCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.InstanceCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceCount, value);
    }

    public MTLBuffer? InstanceDescriptorBuffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBuffer, value?.NativePtr ?? 0);
    }

    public nuint InstanceDescriptorBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBufferOffset, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorStride, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorType, (nuint)value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.InstanceTransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public NSArray? InstancedAccelerationStructures
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.InstancedAccelerationStructures));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetInstancedAccelerationStructures, value?.NativePtr ?? 0);
    }

    public MTLBuffer? MotionTransformBuffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.MotionTransformBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBuffer, value?.NativePtr ?? 0);
    }

    public nuint MotionTransformBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.MotionTransformBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBufferOffset, value);
    }

    public nuint MotionTransformCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.MotionTransformCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCount, value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.MotionTransformStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformStride, value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.MotionTransformType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorSelector.SetMotionTransformType, (nint)value);
    }

    public static MTLInstanceAccelerationStructureDescriptor? Descriptor()
    {
        return GetNullableObject<MTLInstanceAccelerationStructureDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLInstanceAccelerationStructureDescriptorSelector.Class, MTLInstanceAccelerationStructureDescriptorSelector.Descriptor));
    }
}

file static class MTLInstanceAccelerationStructureDescriptorSelector
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
