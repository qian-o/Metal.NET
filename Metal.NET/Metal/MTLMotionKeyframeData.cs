namespace Metal.NET;

public class MTLMotionKeyframeData(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLMotionKeyframeData>
{
    public static MTLMotionKeyframeData Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLMotionKeyframeData Null => Create(0, false);
    public static MTLMotionKeyframeData Empty => Null;

    public MTLMotionKeyframeData() : this(ObjectiveCRuntime.AllocInit(MTLMotionKeyframeDataBindings.Class), true)
    {
    }

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLMotionKeyframeDataBindings.Buffer);
        set => SetProperty(ref field, MTLMotionKeyframeDataBindings.SetBuffer, value);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataBindings.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetOffset, value);
    }

    public static MTLMotionKeyframeData Data()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLMotionKeyframeDataBindings.Class, MTLMotionKeyframeDataBindings.Data);

        return new(nativePtr, false);
    }
}

file static class MTLMotionKeyframeDataBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLMotionKeyframeData");

    public static readonly Selector Buffer = "buffer";

    public static readonly Selector Data = "data";

    public static readonly Selector Offset = "offset";

    public static readonly Selector SetBuffer = "setBuffer:";

    public static readonly Selector SetOffset = "setOffset:";
}
