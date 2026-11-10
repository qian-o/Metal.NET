namespace Metal.NET;

public readonly struct MTL4PrimitiveAccelerationStructureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4AccelerationStructureDescriptor(MTL4PrimitiveAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator MTLAccelerationStructureDescriptor(MTL4PrimitiveAccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4PrimitiveAccelerationStructureDescriptor value) => new(value.NativePtr);

    public MTL4PrimitiveAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTL4PrimitiveAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTL4PrimitiveAccelerationStructureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTL4AccelerationStructureGeometryDescriptor> GeometryDescriptors
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.GeometryDescriptors));
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetGeometryDescriptors, value.NativePtr);
    }

    public MTLMotionBorderMode MotionStartBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveC.MsgSendUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionStartBorderMode);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionStartBorderMode, (uint)value);
    }

    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveC.MsgSendUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionEndBorderMode);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionEndBorderMode, (uint)value);
    }

    public float MotionStartTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionStartTime);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionStartTime, value);
    }

    public float MotionEndTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionEndTime);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionEndTime, value);
    }

    public nuint MotionKeyframeCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.MotionKeyframeCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetMotionKeyframeCount, value);
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PrimitiveAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }
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

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
