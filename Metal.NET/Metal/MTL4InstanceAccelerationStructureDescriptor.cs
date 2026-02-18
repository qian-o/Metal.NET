namespace Metal.NET;

public class MTL4InstanceAccelerationStructureDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4InstanceAccelerationStructureDescriptor");

    public MTL4InstanceAccelerationStructureDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4InstanceAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4InstanceAccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint InstanceCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.InstanceCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetInstanceCount, value);
    }

    public MTL4BufferRange InstanceDescriptorBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.InstanceDescriptorBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorBuffer, value);
    }

    public nuint InstanceDescriptorStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.InstanceDescriptorStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorStride, value);
    }

    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.InstanceDescriptorType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetInstanceDescriptorType, (ulong)value);
    }

    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.InstanceTransformationMatrixLayout));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetInstanceTransformationMatrixLayout, (ulong)value);
    }

    public MTL4BufferRange MotionTransformBuffer
    {
        get => ObjectiveCRuntime.MsgSendMTL4BufferRange(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.MotionTransformBuffer);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetMotionTransformBuffer, value);
    }

    public nuint MotionTransformCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.MotionTransformCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetMotionTransformCount, value);
    }

    public nuint MotionTransformStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.MotionTransformStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetMotionTransformStride, value);
    }

    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.MotionTransformType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorSelector.SetMotionTransformType, (ulong)value);
    }

    public static implicit operator nint(MTL4InstanceAccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4InstanceAccelerationStructureDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTL4InstanceAccelerationStructureDescriptorSelector
{
    public static readonly Selector InstanceCount = Selector.Register("instanceCount");

    public static readonly Selector SetInstanceCount = Selector.Register("setInstanceCount:");

    public static readonly Selector InstanceDescriptorBuffer = Selector.Register("instanceDescriptorBuffer");

    public static readonly Selector SetInstanceDescriptorBuffer = Selector.Register("setInstanceDescriptorBuffer:");

    public static readonly Selector InstanceDescriptorStride = Selector.Register("instanceDescriptorStride");

    public static readonly Selector SetInstanceDescriptorStride = Selector.Register("setInstanceDescriptorStride:");

    public static readonly Selector InstanceDescriptorType = Selector.Register("instanceDescriptorType");

    public static readonly Selector SetInstanceDescriptorType = Selector.Register("setInstanceDescriptorType:");

    public static readonly Selector InstanceTransformationMatrixLayout = Selector.Register("instanceTransformationMatrixLayout");

    public static readonly Selector SetInstanceTransformationMatrixLayout = Selector.Register("setInstanceTransformationMatrixLayout:");

    public static readonly Selector MotionTransformBuffer = Selector.Register("motionTransformBuffer");

    public static readonly Selector SetMotionTransformBuffer = Selector.Register("setMotionTransformBuffer:");

    public static readonly Selector MotionTransformCount = Selector.Register("motionTransformCount");

    public static readonly Selector SetMotionTransformCount = Selector.Register("setMotionTransformCount:");

    public static readonly Selector MotionTransformStride = Selector.Register("motionTransformStride");

    public static readonly Selector SetMotionTransformStride = Selector.Register("setMotionTransformStride:");

    public static readonly Selector MotionTransformType = Selector.Register("motionTransformType");

    public static readonly Selector SetMotionTransformType = Selector.Register("setMotionTransformType:");
}
