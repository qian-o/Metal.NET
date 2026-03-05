namespace Metal.NET;

public class MTLPrimitiveAccelerationStructureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureDescriptor(nativePtr, ownership), INativeObject<MTLPrimitiveAccelerationStructureDescriptor>
{
    #region INativeObject
    public static new MTLPrimitiveAccelerationStructureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLPrimitiveAccelerationStructureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLPrimitiveAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTLPrimitiveAccelerationStructureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLAccelerationStructureGeometryDescriptor[] GeometryDescriptors
    {
        get => GetArrayProperty<MTLAccelerationStructureGeometryDescriptor>(MTLPrimitiveAccelerationStructureDescriptorBindings.GeometryDescriptors);
        set => SetArrayProperty(MTLPrimitiveAccelerationStructureDescriptorBindings.SetGeometryDescriptors, value);
    }

    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveC.MsgSendUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionEndBorderMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionEndBorderMode, (uint)value);
    }

    public float MotionEndTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionEndTime);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionEndTime, value);
    }

    public nuint MotionKeyframeCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionKeyframeCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionKeyframeCount, value);
    }

    public MTLMotionBorderMode MotionStartBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveC.MsgSendUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionStartBorderMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionStartBorderMode, (uint)value);
    }

    public float MotionStartTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionStartTime);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionStartTime, value);
    }

    public static MTLPrimitiveAccelerationStructureDescriptor Descriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLPrimitiveAccelerationStructureDescriptorBindings.Class, MTLPrimitiveAccelerationStructureDescriptorBindings.Descriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLPrimitiveAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLPrimitiveAccelerationStructureDescriptor");

    public static readonly Selector Descriptor = "descriptor";

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
