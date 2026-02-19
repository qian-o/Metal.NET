namespace Metal.NET;

public class MTL4PrimitiveAccelerationStructureDescriptor(nint nativePtr) : MTL4AccelerationStructureDescriptor(nativePtr)
{
    public MTL4PrimitiveAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PrimitiveAccelerationStructureDescriptorBindings.Class))
    {
    }

    public NSArray? GeometryDescriptors
    {
        get => GetProperty(ref field, MTL4PrimitiveAccelerationStructureDescriptorBindings.GeometryDescriptors);
        set => SetProperty(ref field, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetGeometryDescriptors, value);
    }

    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionEndBorderMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionEndBorderMode, (nuint)value);
    }

    public float MotionEndTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionEndTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionEndTime, value);
    }

    public nuint MotionKeyframeCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionKeyframeCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionKeyframeCount, value);
    }

    public MTLMotionBorderMode MotionStartBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionStartBorderMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionStartBorderMode, (nuint)value);
    }

    public float MotionStartTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionStartTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionStartTime, value);
    }
}

file static class MTL4PrimitiveAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PrimitiveAccelerationStructureDescriptor");

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
