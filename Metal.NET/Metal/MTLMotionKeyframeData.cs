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

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLMotionKeyframeData");

    public MTLBuffer Buffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMotionKeyframeDataSelector.Buffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataSelector.SetBuffer, value.NativePtr);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataSelector.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMotionKeyframeDataSelector.SetOffset, value);
    }

    public static implicit operator nint(MTLMotionKeyframeData value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLMotionKeyframeData(nint value)
    {
        return new(value);
    }

    public static MTLMotionKeyframeData Data()
    {
        MTLMotionKeyframeData result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLMotionKeyframeDataSelector.Data));

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

file class MTLMotionKeyframeDataSelector
{
    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");

    public static readonly Selector Data = Selector.Register("data");
}
