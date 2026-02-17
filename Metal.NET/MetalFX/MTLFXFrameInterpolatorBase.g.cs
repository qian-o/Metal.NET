namespace Metal.NET;

file class MTLFXFrameInterpolatorBaseSelector
{
    public static readonly Selector SetColorTexture_ = Selector.Register("setColorTexture:");
    public static readonly Selector SetPrevColorTexture_ = Selector.Register("setPrevColorTexture:");
    public static readonly Selector SetDepthTexture_ = Selector.Register("setDepthTexture:");
    public static readonly Selector SetMotionTexture_ = Selector.Register("setMotionTexture:");
    public static readonly Selector SetMotionVectorScaleX_ = Selector.Register("setMotionVectorScaleX:");
    public static readonly Selector SetMotionVectorScaleY_ = Selector.Register("setMotionVectorScaleY:");
    public static readonly Selector SetDeltaTime_ = Selector.Register("setDeltaTime:");
    public static readonly Selector SetNearPlane_ = Selector.Register("setNearPlane:");
    public static readonly Selector SetFarPlane_ = Selector.Register("setFarPlane:");
    public static readonly Selector SetFieldOfView_ = Selector.Register("setFieldOfView:");
    public static readonly Selector SetAspectRatio_ = Selector.Register("setAspectRatio:");
    public static readonly Selector SetUITexture_ = Selector.Register("setUITexture:");
    public static readonly Selector SetJitterOffsetX_ = Selector.Register("setJitterOffsetX:");
    public static readonly Selector SetJitterOffsetY_ = Selector.Register("setJitterOffsetY:");
    public static readonly Selector SetIsUITextureComposited_ = Selector.Register("setIsUITextureComposited:");
    public static readonly Selector SetShouldResetHistory_ = Selector.Register("setShouldResetHistory:");
    public static readonly Selector SetOutputTexture_ = Selector.Register("setOutputTexture:");
    public static readonly Selector SetFence_ = Selector.Register("setFence:");
    public static readonly Selector SetDepthReversed_ = Selector.Register("setDepthReversed:");
}

public class MTLFXFrameInterpolatorBase : IDisposable
{
    public MTLFXFrameInterpolatorBase(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFXFrameInterpolatorBase()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXFrameInterpolatorBase value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXFrameInterpolatorBase(nint value)
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

    public void SetColorTexture(MTLTexture colorTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetColorTexture_, colorTexture.NativePtr);
    }

    public void SetPrevColorTexture(MTLTexture prevColorTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetPrevColorTexture_, prevColorTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture depthTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDepthTexture_, depthTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture motionTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionTexture_, motionTexture.NativePtr);
    }

    public void SetMotionVectorScaleX(float scaleX)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionVectorScaleX_, scaleX);
    }

    public void SetMotionVectorScaleY(float scaleY)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionVectorScaleY_, scaleY);
    }

    public void SetDeltaTime(float deltaTime)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDeltaTime_, deltaTime);
    }

    public void SetNearPlane(float nearPlane)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetNearPlane_, nearPlane);
    }

    public void SetFarPlane(float farPlane)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFarPlane_, farPlane);
    }

    public void SetFieldOfView(float fieldOfView)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFieldOfView_, fieldOfView);
    }

    public void SetAspectRatio(float aspectRatio)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetAspectRatio_, aspectRatio);
    }

    public void SetUITexture(MTLTexture uiTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetUITexture_, uiTexture.NativePtr);
    }

    public void SetJitterOffsetX(float jitterOffsetX)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetJitterOffsetX_, jitterOffsetX);
    }

    public void SetJitterOffsetY(float jitterOffsetY)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetJitterOffsetY_, jitterOffsetY);
    }

    public void SetIsUITextureComposited(Bool8 uiTextureComposited)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetIsUITextureComposited_, (nint)uiTextureComposited.Value);
    }

    public void SetShouldResetHistory(Bool8 shouldResetHistory)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetShouldResetHistory_, (nint)shouldResetHistory.Value);
    }

    public void SetOutputTexture(MTLTexture outputTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetOutputTexture_, outputTexture.NativePtr);
    }

    public void SetFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFence_, fence.NativePtr);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDepthReversed_, (nint)depthReversed.Value);
    }

}
