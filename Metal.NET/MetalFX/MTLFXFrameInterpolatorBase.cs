namespace Metal.NET;

public class MTLFXFrameInterpolatorBase : IDisposable
{
    public MTLFXFrameInterpolatorBase(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetColorTexture, colorTexture.NativePtr);
    }

    public void SetPrevColorTexture(MTLTexture prevColorTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetPrevColorTexture, prevColorTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture depthTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDepthTexture, depthTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture motionTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionTexture, motionTexture.NativePtr);
    }

    public void SetMotionVectorScaleX(float scaleX)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionVectorScaleX, scaleX);
    }

    public void SetMotionVectorScaleY(float scaleY)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionVectorScaleY, scaleY);
    }

    public void SetDeltaTime(float deltaTime)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDeltaTime, deltaTime);
    }

    public void SetNearPlane(float nearPlane)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetNearPlane, nearPlane);
    }

    public void SetFarPlane(float farPlane)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFarPlane, farPlane);
    }

    public void SetFieldOfView(float fieldOfView)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFieldOfView, fieldOfView);
    }

    public void SetAspectRatio(float aspectRatio)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetAspectRatio, aspectRatio);
    }

    public void SetUITexture(MTLTexture uiTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetUITexture, uiTexture.NativePtr);
    }

    public void SetJitterOffsetX(float jitterOffsetX)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetJitterOffsetX, jitterOffsetX);
    }

    public void SetJitterOffsetY(float jitterOffsetY)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetJitterOffsetY, jitterOffsetY);
    }

    public void SetIsUITextureComposited(Bool8 uiTextureComposited)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetIsUITextureComposited, (nint)uiTextureComposited.Value);
    }

    public void SetShouldResetHistory(Bool8 shouldResetHistory)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetShouldResetHistory, (nint)shouldResetHistory.Value);
    }

    public void SetOutputTexture(MTLTexture outputTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetOutputTexture, outputTexture.NativePtr);
    }

    public void SetFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFence, fence.NativePtr);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDepthReversed, (nint)depthReversed.Value);
    }

}

file class MTLFXFrameInterpolatorBaseSelector
{
    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector SetPrevColorTexture = Selector.Register("setPrevColorTexture:");

    public static readonly Selector SetDepthTexture = Selector.Register("setDepthTexture:");

    public static readonly Selector SetMotionTexture = Selector.Register("setMotionTexture:");

    public static readonly Selector SetMotionVectorScaleX = Selector.Register("setMotionVectorScaleX:");

    public static readonly Selector SetMotionVectorScaleY = Selector.Register("setMotionVectorScaleY:");

    public static readonly Selector SetDeltaTime = Selector.Register("setDeltaTime:");

    public static readonly Selector SetNearPlane = Selector.Register("setNearPlane:");

    public static readonly Selector SetFarPlane = Selector.Register("setFarPlane:");

    public static readonly Selector SetFieldOfView = Selector.Register("setFieldOfView:");

    public static readonly Selector SetAspectRatio = Selector.Register("setAspectRatio:");

    public static readonly Selector SetUITexture = Selector.Register("setUITexture:");

    public static readonly Selector SetJitterOffsetX = Selector.Register("setJitterOffsetX:");

    public static readonly Selector SetJitterOffsetY = Selector.Register("setJitterOffsetY:");

    public static readonly Selector SetIsUITextureComposited = Selector.Register("setIsUITextureComposited:");

    public static readonly Selector SetShouldResetHistory = Selector.Register("setShouldResetHistory:");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector SetFence = Selector.Register("setFence:");

    public static readonly Selector SetDepthReversed = Selector.Register("setDepthReversed:");
}
