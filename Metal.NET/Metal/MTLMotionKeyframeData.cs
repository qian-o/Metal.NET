namespace Metal.NET;

public class MTLMotionKeyframeData(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLMotionKeyframeData() : this(ObjectiveCRuntime.AllocInit(MTLMotionKeyframeDataBindings.Class))
    {
    }

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMotionKeyframeDataBindings.Buffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBuffer(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetBuffer, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataBindings.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetOffset, value);
    }

    public static MTLMotionKeyframeData? Data()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLMotionKeyframeDataBindings.Class, MTLMotionKeyframeDataBindings.Data);
        return ptr is not 0 ? new MTLMotionKeyframeData(ptr) : null;
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
