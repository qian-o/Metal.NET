namespace Metal.NET;

public class MTLMotionKeyframeData : IDisposable
{
    public MTLMotionKeyframeData(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLMotionKeyframeData()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLMotionKeyframeData value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLMotionKeyframeData(nint value)
    {
        return new(value);
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLMotionKeyframeData");

    public MTLBuffer Buffer
    {
        get => new MTLBuffer(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMotionKeyframeDataSelector.Buffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataSelector.SetBuffer, value.NativePtr);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataSelector.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataSelector.SetOffset, (nuint)value);
    }

    public static MTLMotionKeyframeData Data()
    {
        MTLMotionKeyframeData result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLMotionKeyframeDataSelector.Data));

        return result;
    }

}

file class MTLMotionKeyframeDataSelector
{
    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");

    public static readonly Selector Data = Selector.Register("data");
}
