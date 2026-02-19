namespace Metal.NET;

public readonly struct MTLMotionKeyframeData(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLMotionKeyframeData() : this(ObjectiveCRuntime.AllocInit(MTLMotionKeyframeDataBindings.Class))
    {
    }

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMotionKeyframeDataBindings.Buffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetBuffer, value?.NativePtr ?? 0);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataBindings.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetOffset, value);
    }

    public static MTLMotionKeyframeData? Data()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLMotionKeyframeDataBindings.Class, MTLMotionKeyframeDataBindings.Data);
        return ptr is not 0 ? new MTLMotionKeyframeData(ptr) : default;
    }
}

file static class MTLMotionKeyframeDataBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLMotionKeyframeData");

    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector Data = Selector.Register("data");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
