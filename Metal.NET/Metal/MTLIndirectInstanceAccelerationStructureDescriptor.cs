namespace Metal.NET;

public class MTLIndirectInstanceAccelerationStructureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureDescriptor(nativePtr, ownership), INativeObject<MTLIndirectInstanceAccelerationStructureDescriptor>
{
    #region INativeObject
    public static new MTLIndirectInstanceAccelerationStructureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectInstanceAccelerationStructureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIndirectInstanceAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTLIndirectInstanceAccelerationStructureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBuffer InstanceDescriptorBuffer
    {
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
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
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, value);
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
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
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
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, value);
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

    public MTLBuffer InstanceDescriptorBuffer
    {
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
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
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, value);
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
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
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
        get => GetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBuffer);
        set => SetProperty(ref field, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, value);
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

    public void SetInstanceDescriptorBuffer(MTLBuffer instanceDescriptorBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, instanceDescriptorBuffer.NativePtr);
    }

    public void SetInstanceDescriptorBufferOffset(nuint instanceDescriptorBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBufferOffset, instanceDescriptorBufferOffset);
    }

    public void SetInstanceDescriptorStride(nuint instanceDescriptorStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, instanceDescriptorStride);
    }

    public void SetMaxInstanceCount(nuint maxInstanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMaxInstanceCount, maxInstanceCount);
    }

    public void SetInstanceCountBuffer(MTLBuffer instanceCountBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, instanceCountBuffer.NativePtr);
    }

    public void SetInstanceCountBufferOffset(nuint instanceCountBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBufferOffset, instanceCountBufferOffset);
    }

    public void SetInstanceDescriptorType(MTLAccelerationStructureInstanceDescriptorType instanceDescriptorType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)instanceDescriptorType);
    }

    public void SetMotionTransformBuffer(MTLBuffer motionTransformBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, motionTransformBuffer.NativePtr);
    }

    public void SetMotionTransformBufferOffset(nuint motionTransformBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBufferOffset, motionTransformBufferOffset);
    }

    public void SetMaxMotionTransformCount(nuint maxMotionTransformCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMaxMotionTransformCount, maxMotionTransformCount);
    }

    public void SetMotionTransformCountBuffer(MTLBuffer motionTransformCountBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, motionTransformCountBuffer.NativePtr);
    }

    public void SetMotionTransformCountBufferOffset(nuint motionTransformCountBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBufferOffset, motionTransformCountBufferOffset);
    }

    public void SetInstanceTransformationMatrixLayout(MTLMatrixLayout instanceTransformationMatrixLayout)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)instanceTransformationMatrixLayout);
    }

    public void SetMotionTransformType(MTLTransformType motionTransformType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)motionTransformType);
    }

    public void SetMotionTransformStride(nuint motionTransformStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, motionTransformStride);
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
}
