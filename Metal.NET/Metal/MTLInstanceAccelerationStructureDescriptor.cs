namespace Metal.NET;

public class MTLInstanceAccelerationStructureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureDescriptor(nativePtr, ownership), INativeObject<MTLInstanceAccelerationStructureDescriptor>
{
    #region INativeObject
    public static new MTLInstanceAccelerationStructureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLInstanceAccelerationStructureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLInstanceAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTLInstanceAccelerationStructureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint InstanceCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceCount, value);
    }

    public MTLBuffer InstanceDescriptorBuffer
    {
        get => GetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => SetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
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

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveC.MsgSendULong(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public MTLAccelerationStructure[] InstancedAccelerationStructures
    {
        get => GetArrayProperty<MTLAccelerationStructure>(MTLInstanceAccelerationStructureDescriptorBindings.InstancedAccelerationStructures);
        set => SetArrayProperty(MTLInstanceAccelerationStructureDescriptorBindings.SetInstancedAccelerationStructures, value);
    }

    public MTLBuffer MotionTransformBuffer
    {
        get => GetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => SetProperty(ref field, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
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

    public nuint MotionTransformStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveC.MsgSendLong(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveC.MsgSend(NativePtr, MTLInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }

    public static MTLInstanceAccelerationStructureDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLInstanceAccelerationStructureDescriptorBindings.Class, MTLInstanceAccelerationStructureDescriptorBindings.Descriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
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
}
