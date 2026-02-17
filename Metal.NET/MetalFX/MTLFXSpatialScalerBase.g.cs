namespace Metal.NET;

file class MTLFXSpatialScalerBaseSelector
{
    public static readonly Selector SetInputContentWidth_ = Selector.Register("setInputContentWidth:");
    public static readonly Selector SetInputContentHeight_ = Selector.Register("setInputContentHeight:");
    public static readonly Selector SetColorTexture_ = Selector.Register("setColorTexture:");
    public static readonly Selector SetOutputTexture_ = Selector.Register("setOutputTexture:");
    public static readonly Selector SetFence_ = Selector.Register("setFence:");
}

public class MTLFXSpatialScalerBase : IDisposable
{
    public MTLFXSpatialScalerBase(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void SetInputContentWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetInputContentWidth_, (nint)width);
    }

    public void SetInputContentHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetInputContentHeight_, (nint)height);
    }

    public void SetColorTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetColorTexture_, pTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetOutputTexture_, pTexture.NativePtr);
    }

    public void SetFence(MTLFence pFence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetFence_, pFence.NativePtr);
    }

}
