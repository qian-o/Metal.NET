namespace Metal.NET;

/// <summary>
/// Descriptor for an “indirect” instance acceleration structure that allows providing the instance count and motion transform count indirectly, through buffer references.
/// </summary>
public class MTL4IndirectInstanceAccelerationStructureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4AccelerationStructureDescriptor(nativePtr, ownership), INativeObject<MTL4IndirectInstanceAccelerationStructureDescriptor>
{
    #region INativeObject
    public static new MTL4IndirectInstanceAccelerationStructureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4IndirectInstanceAccelerationStructureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4IndirectInstanceAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTL4IndirectInstanceAccelerationStructureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Provides a reference to a buffer containing the number of instances in the instance descriptor buffer, formatted as a 32-bit unsigned integer.
    /// </summary>
    public MTL4BufferRange InstanceCountBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceCountBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceCountBuffer, value);
    }

    /// <summary>
    /// Assigns a reference to a buffer containing instance descriptors for acceleration structures to reference.
    /// </summary>
    public MTL4BufferRange InstanceDescriptorBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
    }

    /// <summary>
    /// Sets the stride, in bytes, between instance descriptors in the instance descriptor buffer.
    /// </summary>
    public nuint InstanceDescriptorStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    /// <summary>
    /// Controls the type of instance descriptor that the instance descriptor buffer references.
    /// </summary>
    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveC.MsgSendULong(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    /// <summary>
    /// Specifies the layout for the transformation matrices in the instance descriptor buffer and the motion transformation matrix buffer.
    /// </summary>
    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    /// <summary>
    /// Controls the maximum number of instance descriptors the instance descriptor buffer can reference.
    /// </summary>
    public nuint MaxInstanceCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MaxInstanceCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMaxInstanceCount, value);
    }

    /// <summary>
    /// Controls the maximum number of motion transforms in the motion transform buffer.
    /// </summary>
    public nuint MaxMotionTransformCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MaxMotionTransformCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMaxMotionTransformCount, value);
    }

    /// <summary>
    /// A buffer containing transformation information for instance motion keyframes, formatted according to the motion transform type.
    /// </summary>
    public MTL4BufferRange MotionTransformBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
    }

    /// <summary>
    /// Associates a buffer reference containing the number of motion transforms in the motion transform buffer, formatted as a 32-bit unsigned integer.
    /// </summary>
    public MTL4BufferRange MotionTransformCountBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformCountBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformCountBuffer, value);
    }

    /// <summary>
    /// Sets the stride for motion transform.
    /// </summary>
    public nuint MotionTransformStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    /// <summary>
    /// Sets the type of motion transforms, either as a matrix or individual components.
    /// </summary>
    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveC.MsgSendLong(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4IndirectInstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }
    #endregion
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
}
