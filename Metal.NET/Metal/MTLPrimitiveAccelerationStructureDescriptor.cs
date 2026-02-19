namespace Metal.NET;

public class MTLPrimitiveAccelerationStructureDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLPrimitiveAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLPrimitiveAccelerationStructureDescriptorBindings.Class))
    {
    }

    public NSArray? GeometryDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.GeometryDescriptors);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetGeometryDescriptors, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionEndBorderMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionEndBorderMode, (uint)value);
    }

    public float MotionEndTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionEndTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionEndTime, value);
    }

    public nuint MotionKeyframeCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionKeyframeCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionKeyframeCount, value);
    }

    public MTLMotionBorderMode MotionStartBorderMode
    {
        get => (MTLMotionBorderMode)ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionStartBorderMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionStartBorderMode, (uint)value);
    }

    public float MotionStartTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.MotionStartTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorBindings.SetMotionStartTime, value);
    }

    public static MTLPrimitiveAccelerationStructureDescriptor? Descriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLPrimitiveAccelerationStructureDescriptorBindings.Class, MTLPrimitiveAccelerationStructureDescriptorBindings.Descriptor);
        return ptr is not 0 ? new MTLPrimitiveAccelerationStructureDescriptor(ptr) : null;
    }
}

file static class MTLPrimitiveAccelerationStructureDescriptorBindings
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
