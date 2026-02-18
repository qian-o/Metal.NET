namespace Metal.NET;

public class MTLPrimitiveAccelerationStructureDescriptor(nint nativePtr) : MTLAccelerationStructureDescriptor(nativePtr)
{
    public MTLPrimitiveAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLPrimitiveAccelerationStructureDescriptorSelector.Class))
    {
    }

    public NSArray? GeometryDescriptors
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.GeometryDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetGeometryDescriptors, value?.NativePtr ?? 0);
    }

    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.MotionEndBorderMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionEndBorderMode, (uint)value);
    }

    public float MotionEndTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.MotionEndTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionEndTime, value);
    }

    public nuint MotionKeyframeCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.MotionKeyframeCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionKeyframeCount, value);
    }

    public MTLMotionBorderMode MotionStartBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.MotionStartBorderMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionStartBorderMode, (uint)value);
    }

    public float MotionStartTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.MotionStartTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionStartTime, value);
    }

    public static MTLPrimitiveAccelerationStructureDescriptor? Descriptor()
    {
        return GetNullableObject<MTLPrimitiveAccelerationStructureDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLPrimitiveAccelerationStructureDescriptorSelector.Class, MTLPrimitiveAccelerationStructureDescriptorSelector.Descriptor));
    }
}

file static class MTLPrimitiveAccelerationStructureDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPrimitiveAccelerationStructureDescriptor");

    public static readonly Selector Descriptor = Selector.Register("descriptor");

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
