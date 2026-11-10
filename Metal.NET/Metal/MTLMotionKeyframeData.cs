namespace Metal.NET;

public readonly struct MTLMotionKeyframeData(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLMotionKeyframeData value) => new(value.NativePtr);

    public MTLMotionKeyframeData() : this(ObjectiveC.AllocInit(MTLMotionKeyframeDataBindings.Class))
    {
    }

    public MTLMotionKeyframeData Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLBuffer Buffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMotionKeyframeDataBindings.Buffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetBuffer, value.NativePtr);
    }

    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataBindings.Offset);
        set => ObjectiveC.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetOffset, value);
    }

    public static nint Data()
    {
        return ObjectiveC.MsgSendNInt(MTLMotionKeyframeDataBindings.Class, MTLMotionKeyframeDataBindings.Data);
    }
}

file static class MTLMotionKeyframeDataBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLMotionKeyframeData");

    public static readonly Selector Buffer = "buffer";

    public static readonly Selector Data = "data";

    public static readonly Selector Offset = "offset";

    public static readonly Selector SetBuffer = "setBuffer:";

    public static readonly Selector SetOffset = "setOffset:";
}
