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

    public void SetBuffer(MTLBuffer buffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMotionKeyframeDataSelector.SetBuffer, buffer.NativePtr);
    }

    public void SetOffset(uint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMotionKeyframeDataSelector.SetOffset, (nint)offset);
    }

    public static MTLMotionKeyframeData Data()
    {
        var result = new MTLMotionKeyframeData(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLMotionKeyframeDataSelector.Data));

        return result;
    }

}

file class MTLMotionKeyframeDataSelector
{
    public static readonly Selector SetBuffer = Selector.Register("setBuffer:");
    public static readonly Selector SetOffset = Selector.Register("setOffset:");
    public static readonly Selector Data = Selector.Register("data");
}
