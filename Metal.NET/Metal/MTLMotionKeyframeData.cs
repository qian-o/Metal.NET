namespace Metal.NET;

public class MTLMotionKeyframeData(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLMotionKeyframeData() : this(ObjectiveCRuntime.AllocInit(MTLMotionKeyframeDataBindings.Class))
    {
    }

    public MTLBuffer? Buffer
    {
        get => GetProperty(ref field, MTLMotionKeyframeDataBindings.Buffer);
        set => SetProperty(ref field, MTLMotionKeyframeDataBindings.SetBuffer, value);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataBindings.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetOffset, value);
    }

    public static MTLMotionKeyframeData? Data()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLMotionKeyframeDataBindings.Class, MTLMotionKeyframeDataBindings.Data);

        if (nativePtr is 0)
        {
            return null;
        }

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr);
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
