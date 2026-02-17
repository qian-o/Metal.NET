namespace Metal.NET;

public class MTLFXFrameInterpolator : IDisposable
{
    public MTLFXFrameInterpolator(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFXFrameInterpolator()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXFrameInterpolator value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXFrameInterpolator(nint value)
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

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }

}

file class MTLFXFrameInterpolatorSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
