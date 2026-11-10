namespace Metal.NET;

public readonly struct MTLPrimitiveAccelerationStructureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLAccelerationStructureDescriptor(MTLPrimitiveAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLPrimitiveAccelerationStructureDescriptor value) => new(value.NativePtr);

    public MTLPrimitiveAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTLPrimitiveAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTLPrimitiveAccelerationStructureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTLAccelerationStructureGeometryDescriptor> GeometryDescriptors
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.GeometryDescriptors));
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetGeometryDescriptors, value.NativePtr);
    }

    public MTLMotionBorderMode MotionStartBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveC.MsgSendUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionStartBorderMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionStartBorderMode, (uint)value);
    }

    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveC.MsgSendUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionEndBorderMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionEndBorderMode, (uint)value);
    }

    public float MotionStartTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionStartTime);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionStartTime, value);
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

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }

    public static nint Descriptor()
    {
        return ObjectiveC.MsgSendNInt(MTLPrimitiveAccelerationStructureDescriptorBindings.Class, MTLPrimitiveAccelerationStructureDescriptorBindings.Descriptor);
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

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
