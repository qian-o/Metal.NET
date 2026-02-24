namespace Metal.NET;

public class MTL4IndirectInstanceAccelerationStructureDescriptor(nint nativePtr) : MTL4AccelerationStructureDescriptor(nativePtr), INativeObject<MTL4IndirectInstanceAccelerationStructureDescriptor>
{
    public static new MTL4IndirectInstanceAccelerationStructureDescriptor Create(nint nativePtr) => new(nativePtr);
    public MTL4IndirectInstanceAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4IndirectInstanceAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTL4BufferRange InstanceCountBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, value);
    }

    public MTL4BufferRange InstanceDescriptorBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public nuint MaxInstanceCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MaxInstanceCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMaxInstanceCount, value);
    }

    public nuint MaxMotionTransformCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MaxMotionTransformCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMaxMotionTransformCount, value);
    }

    public MTL4BufferRange MotionTransformBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
    }

    public MTL4BufferRange MotionTransformCountBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }
}

file static class MTL4IndirectInstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4IndirectInstanceAccelerationStructureDescriptor");

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
}
