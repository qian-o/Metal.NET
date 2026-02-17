namespace Metal.NET;

public class MTLFXTemporalScalerBase : IDisposable
{
    public MTLFXTemporalScalerBase(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetInputContentWidth(uint width)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetInputContentWidth, (nint)width);
    }

    public void SetInputContentHeight(uint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetInputContentHeight, (nint)height);
    }

    public void SetColorTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetColorTexture, pTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetDepthTexture, pTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionTexture, pTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetOutputTexture, pTexture.NativePtr);
    }

    public void SetExposureTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetExposureTexture, pTexture.NativePtr);
    }

    public void SetPreExposure(float preExposure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetPreExposure, preExposure);
    }

    public void SetJitterOffsetX(float offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetJitterOffsetX, offset);
    }

    public void SetJitterOffsetY(float offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetJitterOffsetY, offset);
    }

    public void SetMotionVectorScaleX(float scale)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionVectorScaleX, scale);
    }

    public void SetMotionVectorScaleY(float scale)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionVectorScaleY, scale);
    }

    public void SetReactiveMaskTexture(MTLTexture reactiveMaskTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetReactiveMaskTexture, reactiveMaskTexture.NativePtr);
    }

    public void SetReset(Bool8 reset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetReset, (nint)reset.Value);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetDepthReversed, (nint)depthReversed.Value);
    }

    public void SetFence(MTLFence pFence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetFence, pFence.NativePtr);
    }

}

file class MTLFXTemporalScalerBaseSelector
{
    public static readonly Selector SetInputContentWidth = Selector.Register("setInputContentWidth:");

    public static readonly Selector SetInputContentHeight = Selector.Register("setInputContentHeight:");

    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector SetDepthTexture = Selector.Register("setDepthTexture:");

    public static readonly Selector SetMotionTexture = Selector.Register("setMotionTexture:");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector SetExposureTexture = Selector.Register("setExposureTexture:");

    public static readonly Selector SetPreExposure = Selector.Register("setPreExposure:");

    public static readonly Selector SetJitterOffsetX = Selector.Register("setJitterOffsetX:");

    public static readonly Selector SetJitterOffsetY = Selector.Register("setJitterOffsetY:");

    public static readonly Selector SetMotionVectorScaleX = Selector.Register("setMotionVectorScaleX:");

    public static readonly Selector SetMotionVectorScaleY = Selector.Register("setMotionVectorScaleY:");

    public static readonly Selector SetReactiveMaskTexture = Selector.Register("setReactiveMaskTexture:");

    public static readonly Selector SetReset = Selector.Register("setReset:");

    public static readonly Selector SetDepthReversed = Selector.Register("setDepthReversed:");

    public static readonly Selector SetFence = Selector.Register("setFence:");
}
