namespace Metal.NET;

public class MTLInstanceAccelerationStructureDescriptor(nint nativePtr) : MTLAccelerationStructureDescriptor(nativePtr), INativeObject<MTLInstanceAccelerationStructureDescriptor>
{
    public static new MTLInstanceAccelerationStructureDescriptor Create(nint nativePtr) => new(nativePtr);

    public MTLInstanceAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLInstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public nuint InstanceCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceCount, value);
    }

    public MTLBuffer InstanceDescriptorBuffer
    {
        get => GetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => SetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
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

    public NSArray InstancedAccelerationStructures
    {
        get => GetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.InstancedAccelerationStructures);
        set => SetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.SetInstancedAccelerationStructures, value);
    }

    public MTLBuffer MotionTransformBuffer
    {
        get => GetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => SetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
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

    public static MTLInstanceAccelerationStructureDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLInstanceAccelerationStructureDescriptorBindings.Class, MTLInstanceAccelerationStructureDescriptorBindings.Descriptor);

        return new(nativePtr);
    }
}

file static class MTLInstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLInstanceAccelerationStructureDescriptor");

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
}
