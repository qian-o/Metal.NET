namespace Metal.NET;

public class MTLPrimitiveAccelerationStructureDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPrimitiveAccelerationStructureDescriptor");

    public MTLPrimitiveAccelerationStructureDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLPrimitiveAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLPrimitiveAccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray GeometryDescriptors
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.GeometryDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetGeometryDescriptors, value.NativePtr);
    }

    public MTLMotionBorderMode MotionEndBorderMode
    {
        get => (MTLMotionBorderMode)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.MotionEndBorderMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionEndBorderMode, (nuint)value);
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
        get => (MTLMotionBorderMode)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.MotionStartBorderMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionStartBorderMode, (nuint)value);
    }

    public float MotionStartTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.MotionStartTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptorSelector.SetMotionStartTime, value);
    }

    public static implicit operator nint(MTLPrimitiveAccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPrimitiveAccelerationStructureDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLPrimitiveAccelerationStructureDescriptor Descriptor()
    {
        MTLPrimitiveAccelerationStructureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLPrimitiveAccelerationStructureDescriptorSelector.Descriptor));

        return result;
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLPrimitiveAccelerationStructureDescriptorSelector
{
    public static readonly Selector GeometryDescriptors = Selector.Register("geometryDescriptors");

    public static readonly Selector SetGeometryDescriptors = Selector.Register("setGeometryDescriptors:");

    public static readonly Selector MotionEndBorderMode = Selector.Register("motionEndBorderMode");

    public static readonly Selector SetMotionEndBorderMode = Selector.Register("setMotionEndBorderMode:");

    public static readonly Selector MotionEndTime = Selector.Register("motionEndTime");

    public static readonly Selector SetMotionEndTime = Selector.Register("setMotionEndTime:");

    public static readonly Selector MotionKeyframeCount = Selector.Register("motionKeyframeCount");

    public static readonly Selector SetMotionKeyframeCount = Selector.Register("setMotionKeyframeCount:");

    public static readonly Selector MotionStartBorderMode = Selector.Register("motionStartBorderMode");

    public static readonly Selector SetMotionStartBorderMode = Selector.Register("setMotionStartBorderMode:");

    public static readonly Selector MotionStartTime = Selector.Register("motionStartTime");

    public static readonly Selector SetMotionStartTime = Selector.Register("setMotionStartTime:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
