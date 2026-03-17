namespace Metal.NET;

/// <summary>
/// Descriptor for a primitive acceleration structure that directly references geometric shapes, such as triangles and bounding boxes.
/// </summary>
public class MTL4PrimitiveAccelerationStructureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4AccelerationStructureDescriptor(nativePtr, ownership), INativeObject<MTL4PrimitiveAccelerationStructureDescriptor>
{
    #region INativeObject
    public static new MTL4PrimitiveAccelerationStructureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4PrimitiveAccelerationStructureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4PrimitiveAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTL4PrimitiveAccelerationStructureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Associates the array of geometry descriptors that comprise this primitive acceleration structure.
    /// </summary>
    public MTLAccelerationStructureGeometryDescriptor[] GeometryDescriptors
    {
        get => GetArrayProperty<MTLAccelerationStructureGeometryDescriptor>(MTL4PrimitiveAccelerationStructureDescriptorBindings.GeometryDescriptors);
        set => SetArrayProperty(MTL4PrimitiveAccelerationStructureDescriptorBindings.SetGeometryDescriptors, value);
    }

    /// <summary>
    /// Configures the motion border mode.
    /// </summary>
    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveC.MsgSendUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionEndBorderMode);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionEndBorderMode, (uint)value);
    }

    /// <summary>
    /// Configures the motion end time for this geometry.
    /// </summary>
    public float MotionEndTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionEndTime);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionEndTime, value);
    }

    /// <summary>
    /// Sets the motion keyframe count.
    /// </summary>
    public nuint MotionKeyframeCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionKeyframeCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionKeyframeCount, value);
    }

    /// <summary>
    /// Configures the behavior when the ray-tracing system samples the acceleration structure before the motion start time.
    /// </summary>
    public MTLMotionBorderMode MotionStartBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveC.MsgSendUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionStartBorderMode);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionStartBorderMode, (uint)value);
    }

    /// <summary>
    /// Configures the motion start time for this geometry.
    /// </summary>
    public float MotionStartTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionStartTime);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionStartTime, value);
    }
    #endregion
}

file static class MTL4PrimitiveAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PrimitiveAccelerationStructureDescriptor");

    public static readonly Selector GeometryDescriptors = "geometryDescriptors";

    public static readonly Selector MotionEndBorderMode = "motionEndBorderMode";

    public static readonly Selector MotionEndTime = "motionEndTime";

    public static readonly Selector MotionKeyframeCount = "motionKeyframeCount";

    public static readonly Selector MotionStartBorderMode = "motionStartBorderMode";

    public static readonly Selector MotionStartTime = "motionStartTime";

    public static readonly Selector SetGeometryDescriptors = "setGeometryDescriptors:";

    public static readonly Selector SetMotionEndBorderMode = "setMotionEndBorderMode:";

    public static readonly Selector SetMotionEndTime = "setMotionEndTime:";

    public static readonly Selector SetMotionKeyframeCount = "setMotionKeyframeCount:";

    public static readonly Selector SetMotionStartBorderMode = "setMotionStartBorderMode:";

    public static readonly Selector SetMotionStartTime = "setMotionStartTime:";
}
