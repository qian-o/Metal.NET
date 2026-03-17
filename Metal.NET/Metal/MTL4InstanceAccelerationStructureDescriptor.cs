namespace Metal.NET;

/// <summary>
/// Descriptor for an instance acceleration structure.
/// </summary>
public class MTL4InstanceAccelerationStructureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4AccelerationStructureDescriptor(nativePtr, ownership), INativeObject<MTL4InstanceAccelerationStructureDescriptor>
{
    #region INativeObject
    public static new MTL4InstanceAccelerationStructureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4InstanceAccelerationStructureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4InstanceAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTL4InstanceAccelerationStructureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Controls the number of instance descriptors in the instance descriptor buffer references.
    /// </summary>
    public nuint InstanceCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceCount, value);
    }

    /// <summary>
    /// Assigns a reference to a buffer containing instance descriptors for acceleration structures to reference.
    /// </summary>
    public MTL4BufferRange InstanceDescriptorBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceDescriptorBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorBuffer, value);
    }

    /// <summary>
    /// Sets the stride, in bytes, between instance descriptors the instance descriptor buffer references.
    /// </summary>
    public nuint InstanceDescriptorStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceDescriptorStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorStride, value);
    }

    /// <summary>
    /// The type of instance descriptor that the instance descriptor buffer references.
    /// </summary>
    public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
    {
        get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveC.MsgSendULong(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceDescriptorType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceDescriptorType, (nuint)value);
    }

    /// <summary>
    /// Specifies the layout for the transformation matrices in the instance descriptor buffer and the motion transformation matrix buffer.
    /// </summary>
    public MTLMatrixLayout InstanceTransformationMatrixLayout
    {
        get => (MTLMatrixLayout)ObjectiveC.MsgSendLong(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.InstanceTransformationMatrixLayout);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetInstanceTransformationMatrixLayout, (nint)value);
    }

    /// <summary>
    /// A buffer containing transformation information for instance motion keyframes, formatted according to the motion transform type.
    /// </summary>
    public MTL4BufferRange MotionTransformBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.MotionTransformBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetMotionTransformBuffer, value);
    }

    /// <summary>
    /// Controls the total number of motion transforms in the motion transform buffer.
    /// </summary>
    public nuint MotionTransformCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.MotionTransformCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetMotionTransformCount, value);
    }

    /// <summary>
    /// Specify the stride for motion transform.
    /// </summary>
    public nuint MotionTransformStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.MotionTransformStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetMotionTransformStride, value);
    }

    /// <summary>
    /// Controls the type of motion transforms, either as a matrix or individual components.
    /// </summary>
    public MTLTransformType MotionTransformType
    {
        get => (MTLTransformType)ObjectiveC.MsgSendLong(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.MotionTransformType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4InstanceAccelerationStructureDescriptorBindings.SetMotionTransformType, (nint)value);
    }
    #endregion
}

file static class MTL4InstanceAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4InstanceAccelerationStructureDescriptor");

    public static readonly Selector InstanceCount = "instanceCount";

    public static readonly Selector InstanceDescriptorBuffer = "instanceDescriptorBuffer";

    public static readonly Selector InstanceDescriptorStride = "instanceDescriptorStride";

    public static readonly Selector InstanceDescriptorType = "instanceDescriptorType";

    public static readonly Selector InstanceTransformationMatrixLayout = "instanceTransformationMatrixLayout";

    public static readonly Selector MotionTransformBuffer = "motionTransformBuffer";

    public static readonly Selector MotionTransformCount = "motionTransformCount";

    public static readonly Selector MotionTransformStride = "motionTransformStride";

    public static readonly Selector MotionTransformType = "motionTransformType";

    public static readonly Selector SetInstanceCount = "setInstanceCount:";

    public static readonly Selector SetInstanceDescriptorBuffer = "setInstanceDescriptorBuffer:";

    public static readonly Selector SetInstanceDescriptorStride = "setInstanceDescriptorStride:";

    public static readonly Selector SetInstanceDescriptorType = "setInstanceDescriptorType:";

    public static readonly Selector SetInstanceTransformationMatrixLayout = "setInstanceTransformationMatrixLayout:";

    public static readonly Selector SetMotionTransformBuffer = "setMotionTransformBuffer:";

    public static readonly Selector SetMotionTransformCount = "setMotionTransformCount:";

    public static readonly Selector SetMotionTransformStride = "setMotionTransformStride:";

    public static readonly Selector SetMotionTransformType = "setMotionTransformType:";
}
