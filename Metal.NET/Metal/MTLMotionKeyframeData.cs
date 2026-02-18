namespace Metal.NET;

public partial class MTLMotionKeyframeData : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLMotionKeyframeData");

    public MTLMotionKeyframeData(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMotionKeyframeDataSelector.Buffer);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataSelector.SetBuffer, value?.NativePtr ?? 0);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataSelector.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataSelector.SetOffset, value);
    }

    public static MTLMotionKeyframeData? Data()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLMotionKeyframeDataSelector.Data);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLMotionKeyframeDataSelector
{
    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector Data = Selector.Register("data");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
