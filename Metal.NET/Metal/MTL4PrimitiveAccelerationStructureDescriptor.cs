namespace Metal.NET;

public class MTL4PrimitiveAccelerationStructureDescriptor(nint nativePtr) : MTL4AccelerationStructureDescriptor(nativePtr)
{
    public MTL4PrimitiveAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PrimitiveAccelerationStructureDescriptorSelector.Class))
    {
    }

    public NSArray? GeometryDescriptors
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.GeometryDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.SetGeometryDescriptors, value?.NativePtr ?? 0);
    }

    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.MotionEndBorderMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.SetMotionEndBorderMode, (uint)value);
    }

    public float MotionEndTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.MotionEndTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.SetMotionEndTime, value);
    }

    public nuint MotionKeyframeCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.MotionKeyframeCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.SetMotionKeyframeCount, value);
    }

    public MTLMotionBorderMode MotionStartBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.MotionStartBorderMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.SetMotionStartBorderMode, (uint)value);
    }

    public float MotionStartTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.MotionStartTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorSelector.SetMotionStartTime, value);
    }
}

file static class MTL4PrimitiveAccelerationStructureDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PrimitiveAccelerationStructureDescriptor");

    public static readonly Selector GeometryDescriptors = Selector.Register("geometryDescriptors");

    public static readonly Selector MotionEndBorderMode = Selector.Register("motionEndBorderMode");

    public static readonly Selector MotionEndTime = Selector.Register("motionEndTime");

    public static readonly Selector MotionKeyframeCount = Selector.Register("motionKeyframeCount");

    public static readonly Selector MotionStartBorderMode = Selector.Register("motionStartBorderMode");

    public static readonly Selector MotionStartTime = Selector.Register("motionStartTime");

    public static readonly Selector SetGeometryDescriptors = Selector.Register("setGeometryDescriptors:");

    public static readonly Selector SetMotionEndBorderMode = Selector.Register("setMotionEndBorderMode:");

    public static readonly Selector SetMotionEndTime = Selector.Register("setMotionEndTime:");

    public static readonly Selector SetMotionKeyframeCount = Selector.Register("setMotionKeyframeCount:");

    public static readonly Selector SetMotionStartBorderMode = Selector.Register("setMotionStartBorderMode:");

    public static readonly Selector SetMotionStartTime = Selector.Register("setMotionStartTime:");
}
