namespace Metal.NET;

public class MTL4IndirectInstanceAccelerationStructureDescriptor(nint nativePtr) : MTL4AccelerationStructureDescriptor(nativePtr)
{
    public MTL4IndirectInstanceAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4IndirectInstanceAccelerationStructureDescriptorSelector.Class))
    {
    }

    public MTL4BufferRange InstanceCountBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.InstanceCountBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceCountBuffer, value);
    }

    public MTL4BufferRange InstanceDescriptorBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBuffer, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorStride, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.InstanceDescriptorType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorType, (nuint)value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.InstanceTransformationMatrixLayout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    public nuint MaxInstanceCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.MaxInstanceCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetMaxInstanceCount, value);
    }

    public nuint MaxMotionTransformCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.MaxMotionTransformCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetMaxMotionTransformCount, value);
    }

    public MTL4BufferRange MotionTransformBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformBuffer, value);
    }

    public MTL4BufferRange MotionTransformCountBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformCountBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformCountBuffer, value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformStride, value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.MotionTransformType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorSelector.SetMotionTransformType, (nint)value);
    }
}

file static class MTL4IndirectInstanceAccelerationStructureDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4IndirectInstanceAccelerationStructureDescriptor");

    public static readonly Selector InstanceCountBuffer = Selector.Register("instanceCountBuffer");

    public static readonly Selector InstanceDescriptorBuffer = Selector.Register("instanceDescriptorBuffer");

    public static readonly Selector InstanceDescriptorStride = Selector.Register("instanceDescriptorStride");

    public static readonly Selector InstanceDescriptorType = Selector.Register("instanceDescriptorType");

    public static readonly Selector InstanceTransformationMatrixLayout = Selector.Register("instanceTransformationMatrixLayout");

    public static readonly Selector MaxInstanceCount = Selector.Register("maxInstanceCount");

    public static readonly Selector MaxMotionTransformCount = Selector.Register("maxMotionTransformCount");

    public static readonly Selector MotionTransformBuffer = Selector.Register("motionTransformBuffer");

    public static readonly Selector MotionTransformCountBuffer = Selector.Register("motionTransformCountBuffer");

    public static readonly Selector MotionTransformStride = Selector.Register("motionTransformStride");

    public static readonly Selector MotionTransformType = Selector.Register("motionTransformType");

    public static readonly Selector SetInstanceCountBuffer = Selector.Register("setInstanceCountBuffer:");

    public static readonly Selector SetInstanceDescriptorBuffer = Selector.Register("setInstanceDescriptorBuffer:");

    public static readonly Selector SetInstanceDescriptorStride = Selector.Register("setInstanceDescriptorStride:");

    public static readonly Selector SetInstanceDescriptorType = Selector.Register("setInstanceDescriptorType:");

    public static readonly Selector SetInstanceTransformationMatrixLayout = Selector.Register("setInstanceTransformationMatrixLayout:");

    public static readonly Selector SetMaxInstanceCount = Selector.Register("setMaxInstanceCount:");

    public static readonly Selector SetMaxMotionTransformCount = Selector.Register("setMaxMotionTransformCount:");

    public static readonly Selector SetMotionTransformBuffer = Selector.Register("setMotionTransformBuffer:");

    public static readonly Selector SetMotionTransformCountBuffer = Selector.Register("setMotionTransformCountBuffer:");

    public static readonly Selector SetMotionTransformStride = Selector.Register("setMotionTransformStride:");

    public static readonly Selector SetMotionTransformType = Selector.Register("setMotionTransformType:");
}
