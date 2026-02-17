namespace Metal.NET;

public class MTLFXSpatialScalerBase : IDisposable
{
    public MTLFXSpatialScalerBase(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFXSpatialScalerBase()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXSpatialScalerBase value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXSpatialScalerBase(nint value)
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

    public void SetInputContentWidth(uint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetInputContentWidth, (nint)width);
    }

    public void SetInputContentHeight(uint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetInputContentHeight, (nint)height);
    }

    public void SetColorTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetColorTexture, pTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetOutputTexture, pTexture.NativePtr);
    }

    public void SetFence(MTLFence pFence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetFence, pFence.NativePtr);
    }

}

file class MTLFXSpatialScalerBaseSelector
{
    public static readonly Selector SetInputContentWidth = Selector.Register("setInputContentWidth:");
    public static readonly Selector SetInputContentHeight = Selector.Register("setInputContentHeight:");
    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");
    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");
    public static readonly Selector SetFence = Selector.Register("setFence:");
}
