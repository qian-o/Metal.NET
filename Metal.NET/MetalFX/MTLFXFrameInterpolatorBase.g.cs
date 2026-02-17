using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXFrameInterpolatorBase_Selectors
{
    internal static readonly Selector setColorTexture_ = Selector.Register("setColorTexture:");
    internal static readonly Selector setPrevColorTexture_ = Selector.Register("setPrevColorTexture:");
    internal static readonly Selector setDepthTexture_ = Selector.Register("setDepthTexture:");
    internal static readonly Selector setMotionTexture_ = Selector.Register("setMotionTexture:");
    internal static readonly Selector setMotionVectorScaleX_ = Selector.Register("setMotionVectorScaleX:");
    internal static readonly Selector setMotionVectorScaleY_ = Selector.Register("setMotionVectorScaleY:");
    internal static readonly Selector setDeltaTime_ = Selector.Register("setDeltaTime:");
    internal static readonly Selector setNearPlane_ = Selector.Register("setNearPlane:");
    internal static readonly Selector setFarPlane_ = Selector.Register("setFarPlane:");
    internal static readonly Selector setFieldOfView_ = Selector.Register("setFieldOfView:");
    internal static readonly Selector setAspectRatio_ = Selector.Register("setAspectRatio:");
    internal static readonly Selector setUITexture_ = Selector.Register("setUITexture:");
    internal static readonly Selector setJitterOffsetX_ = Selector.Register("setJitterOffsetX:");
    internal static readonly Selector setJitterOffsetY_ = Selector.Register("setJitterOffsetY:");
    internal static readonly Selector setIsUITextureComposited_ = Selector.Register("setIsUITextureComposited:");
    internal static readonly Selector setShouldResetHistory_ = Selector.Register("setShouldResetHistory:");
    internal static readonly Selector setOutputTexture_ = Selector.Register("setOutputTexture:");
    internal static readonly Selector setFence_ = Selector.Register("setFence:");
    internal static readonly Selector setDepthReversed_ = Selector.Register("setDepthReversed:");
}

public class MTLFXFrameInterpolatorBase : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXFrameInterpolatorBase(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXFrameInterpolatorBase o) => o.NativePtr;
    public static implicit operator MTLFXFrameInterpolatorBase(nint ptr) => new MTLFXFrameInterpolatorBase(ptr);

    ~MTLFXFrameInterpolatorBase() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public void SetColorTexture(MTLTexture colorTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setColorTexture_, colorTexture.NativePtr);
    }

    public void SetPrevColorTexture(MTLTexture prevColorTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setPrevColorTexture_, prevColorTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture depthTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setDepthTexture_, depthTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture motionTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setMotionTexture_, motionTexture.NativePtr);
    }

    public void SetMotionVectorScaleX(float scaleX)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setMotionVectorScaleX_, scaleX);
    }

    public void SetMotionVectorScaleY(float scaleY)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setMotionVectorScaleY_, scaleY);
    }

    public void SetDeltaTime(float deltaTime)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setDeltaTime_, deltaTime);
    }

    public void SetNearPlane(float nearPlane)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setNearPlane_, nearPlane);
    }

    public void SetFarPlane(float farPlane)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setFarPlane_, farPlane);
    }

    public void SetFieldOfView(float fieldOfView)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setFieldOfView_, fieldOfView);
    }

    public void SetAspectRatio(float aspectRatio)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setAspectRatio_, aspectRatio);
    }

    public void SetUITexture(MTLTexture uiTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setUITexture_, uiTexture.NativePtr);
    }

    public void SetJitterOffsetX(float jitterOffsetX)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setJitterOffsetX_, jitterOffsetX);
    }

    public void SetJitterOffsetY(float jitterOffsetY)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setJitterOffsetY_, jitterOffsetY);
    }

    public void SetIsUITextureComposited(Bool8 uiTextureComposited)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setIsUITextureComposited_, (nint)uiTextureComposited.Value);
    }

    public void SetShouldResetHistory(Bool8 shouldResetHistory)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setShouldResetHistory_, (nint)shouldResetHistory.Value);
    }

    public void SetOutputTexture(MTLTexture outputTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setOutputTexture_, outputTexture.NativePtr);
    }

    public void SetFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setFence_, fence.NativePtr);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorBase_Selectors.setDepthReversed_, (nint)depthReversed.Value);
    }

}
