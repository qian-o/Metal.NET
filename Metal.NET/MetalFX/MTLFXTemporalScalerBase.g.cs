namespace Metal.NET;

file class MTLFXTemporalScalerBaseSelector
{
    public static readonly Selector SetInputContentWidth_ = Selector.Register("setInputContentWidth:");
    public static readonly Selector SetInputContentHeight_ = Selector.Register("setInputContentHeight:");
    public static readonly Selector SetColorTexture_ = Selector.Register("setColorTexture:");
    public static readonly Selector SetDepthTexture_ = Selector.Register("setDepthTexture:");
    public static readonly Selector SetMotionTexture_ = Selector.Register("setMotionTexture:");
    public static readonly Selector SetOutputTexture_ = Selector.Register("setOutputTexture:");
    public static readonly Selector SetExposureTexture_ = Selector.Register("setExposureTexture:");
    public static readonly Selector SetPreExposure_ = Selector.Register("setPreExposure:");
    public static readonly Selector SetJitterOffsetX_ = Selector.Register("setJitterOffsetX:");
    public static readonly Selector SetJitterOffsetY_ = Selector.Register("setJitterOffsetY:");
    public static readonly Selector SetMotionVectorScaleX_ = Selector.Register("setMotionVectorScaleX:");
    public static readonly Selector SetMotionVectorScaleY_ = Selector.Register("setMotionVectorScaleY:");
    public static readonly Selector SetReactiveMaskTexture_ = Selector.Register("setReactiveMaskTexture:");
    public static readonly Selector SetReset_ = Selector.Register("setReset:");
    public static readonly Selector SetDepthReversed_ = Selector.Register("setDepthReversed:");
    public static readonly Selector SetFence_ = Selector.Register("setFence:");
}

public class MTLFXTemporalScalerBase : IDisposable
{
    public MTLFXTemporalScalerBase(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFXTemporalScalerBase()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXTemporalScalerBase value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalScalerBase(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetInputContentWidth_, (nint)width);
    }

    public void SetInputContentHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetInputContentHeight_, (nint)height);
    }

    public void SetColorTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetColorTexture_, pTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetDepthTexture_, pTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionTexture_, pTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetOutputTexture_, pTexture.NativePtr);
    }

    public void SetExposureTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetExposureTexture_, pTexture.NativePtr);
    }

    public void SetPreExposure(float preExposure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetPreExposure_, preExposure);
    }

    public void SetJitterOffsetX(float offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetJitterOffsetX_, offset);
    }

    public void SetJitterOffsetY(float offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetJitterOffsetY_, offset);
    }

    public void SetMotionVectorScaleX(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionVectorScaleX_, scale);
    }

    public void SetMotionVectorScaleY(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionVectorScaleY_, scale);
    }

    public void SetReactiveMaskTexture(MTLTexture reactiveMaskTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetReactiveMaskTexture_, reactiveMaskTexture.NativePtr);
    }

    public void SetReset(Bool8 reset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetReset_, (nint)reset.Value);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetDepthReversed_, (nint)depthReversed.Value);
    }

    public void SetFence(MTLFence pFence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetFence_, pFence.NativePtr);
    }

}
