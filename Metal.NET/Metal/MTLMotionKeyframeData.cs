namespace Metal.NET;

public class MTLMotionKeyframeData(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLMotionKeyframeData() : this(ObjectiveCRuntime.AllocInit(MTLMotionKeyframeDataSelector.Class))
    {
    }

    public MTLBuffer? Buffer
    {
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMotionKeyframeDataSelector.Buffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataSelector.SetBuffer, value?.NativePtr ?? 0);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataSelector.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataSelector.SetOffset, value);
    }

    public static MTLMotionKeyframeData? Data()
    {
        return GetNullableObject<MTLMotionKeyframeData>(ObjectiveCRuntime.MsgSendPtr(MTLMotionKeyframeDataSelector.Class, MTLMotionKeyframeDataSelector.Data));
    }
}

file static class MTLMotionKeyframeDataSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLMotionKeyframeData");

    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector Data = Selector.Register("data");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
