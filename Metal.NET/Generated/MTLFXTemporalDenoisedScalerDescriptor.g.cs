using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXTemporalDenoisedScalerDescriptor_Selectors
{
    internal static readonly Selector setColorTextureFormat_ = Selector.Register("setColorTextureFormat:");
    internal static readonly Selector setDepthTextureFormat_ = Selector.Register("setDepthTextureFormat:");
    internal static readonly Selector setMotionTextureFormat_ = Selector.Register("setMotionTextureFormat:");
    internal static readonly Selector setDiffuseAlbedoTextureFormat_ = Selector.Register("setDiffuseAlbedoTextureFormat:");
    internal static readonly Selector setSpecularAlbedoTextureFormat_ = Selector.Register("setSpecularAlbedoTextureFormat:");
    internal static readonly Selector setNormalTextureFormat_ = Selector.Register("setNormalTextureFormat:");
    internal static readonly Selector setRoughnessTextureFormat_ = Selector.Register("setRoughnessTextureFormat:");
    internal static readonly Selector setSpecularHitDistanceTextureFormat_ = Selector.Register("setSpecularHitDistanceTextureFormat:");
    internal static readonly Selector setDenoiseStrengthMaskTextureFormat_ = Selector.Register("setDenoiseStrengthMaskTextureFormat:");
    internal static readonly Selector setTransparencyOverlayTextureFormat_ = Selector.Register("setTransparencyOverlayTextureFormat:");
    internal static readonly Selector setOutputTextureFormat_ = Selector.Register("setOutputTextureFormat:");
    internal static readonly Selector setInputWidth_ = Selector.Register("setInputWidth:");
    internal static readonly Selector setInputHeight_ = Selector.Register("setInputHeight:");
    internal static readonly Selector setOutputWidth_ = Selector.Register("setOutputWidth:");
    internal static readonly Selector setOutputHeight_ = Selector.Register("setOutputHeight:");
    internal static readonly Selector setRequiresSynchronousInitialization_ = Selector.Register("setRequiresSynchronousInitialization:");
    internal static readonly Selector setAutoExposureEnabled_ = Selector.Register("setAutoExposureEnabled:");
    internal static readonly Selector setInputContentPropertiesEnabled_ = Selector.Register("setInputContentPropertiesEnabled:");
    internal static readonly Selector setInputContentMinScale_ = Selector.Register("setInputContentMinScale:");
    internal static readonly Selector setInputContentMaxScale_ = Selector.Register("setInputContentMaxScale:");
    internal static readonly Selector setReactiveMaskTextureEnabled_ = Selector.Register("setReactiveMaskTextureEnabled:");
    internal static readonly Selector setReactiveMaskTextureFormat_ = Selector.Register("setReactiveMaskTextureFormat:");
    internal static readonly Selector setSpecularHitDistanceTextureEnabled_ = Selector.Register("setSpecularHitDistanceTextureEnabled:");
    internal static readonly Selector setDenoiseStrengthMaskTextureEnabled_ = Selector.Register("setDenoiseStrengthMaskTextureEnabled:");
    internal static readonly Selector setTransparencyOverlayTextureEnabled_ = Selector.Register("setTransparencyOverlayTextureEnabled:");
    internal static readonly Selector newTemporalDenoisedScaler_ = Selector.Register("newTemporalDenoisedScaler:");
    internal static readonly Selector newTemporalDenoisedScaler_compiler_ = Selector.Register("newTemporalDenoisedScaler:compiler:");
    internal static readonly Selector supportedInputContentMinScale_ = Selector.Register("supportedInputContentMinScale:");
    internal static readonly Selector supportedInputContentMaxScale_ = Selector.Register("supportedInputContentMaxScale:");
    internal static readonly Selector supportsMetal4FX_ = Selector.Register("supportsMetal4FX:");
    internal static readonly Selector supportsDevice_ = Selector.Register("supportsDevice:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFXTemporalDenoisedScalerDescriptor
{
    public readonly nint NativePtr;

    public MTLFXTemporalDenoisedScalerDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXTemporalDenoisedScalerDescriptor o) => o.NativePtr;
    public static implicit operator MTLFXTemporalDenoisedScalerDescriptor(nint ptr) => new MTLFXTemporalDenoisedScalerDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXTemporalDenoisedScalerDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setColorTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetDepthTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setDepthTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetMotionTextureFormat(MTLPixelFormat pixelFormal)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setMotionTextureFormat_, (nint)(uint)pixelFormal);
    }

    public void SetDiffuseAlbedoTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setDiffuseAlbedoTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetSpecularAlbedoTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setSpecularAlbedoTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetNormalTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setNormalTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetRoughnessTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setRoughnessTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetSpecularHitDistanceTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setSpecularHitDistanceTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetDenoiseStrengthMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setDenoiseStrengthMaskTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetTransparencyOverlayTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setTransparencyOverlayTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetOutputTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setOutputTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetInputWidth(nuint inputWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setInputWidth_, (nint)inputWidth);
    }

    public void SetInputHeight(nuint inputHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setInputHeight_, (nint)inputHeight);
    }

    public void SetOutputWidth(nuint outputWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setOutputWidth_, (nint)outputWidth);
    }

    public void SetOutputHeight(nuint outputHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setOutputHeight_, (nint)outputHeight);
    }

    public void SetRequiresSynchronousInitialization(Bool8 requiresSynchronousInitialization)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setRequiresSynchronousInitialization_, (nint)requiresSynchronousInitialization.Value);
    }

    public void SetAutoExposureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setAutoExposureEnabled_, (nint)enabled.Value);
    }

    public void SetInputContentPropertiesEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setInputContentPropertiesEnabled_, (nint)enabled.Value);
    }

    public void SetInputContentMinScale(float inputContentMinScale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setInputContentMinScale_, inputContentMinScale);
    }

    public void SetInputContentMaxScale(float inputContentMaxScale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setInputContentMaxScale_, inputContentMaxScale);
    }

    public void SetReactiveMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setReactiveMaskTextureEnabled_, (nint)enabled.Value);
    }

    public void SetReactiveMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setReactiveMaskTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetSpecularHitDistanceTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setSpecularHitDistanceTextureEnabled_, (nint)enabled.Value);
    }

    public void SetDenoiseStrengthMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setDenoiseStrengthMaskTextureEnabled_, (nint)enabled.Value);
    }

    public void SetTransparencyOverlayTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.setTransparencyOverlayTextureEnabled_, (nint)enabled.Value);
    }

    public MTLFXTemporalDenoisedScaler NewTemporalDenoisedScaler(MTLDevice device)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.newTemporalDenoisedScaler_, device.NativePtr);
        return new MTLFXTemporalDenoisedScaler(__result);
    }

    public MTLFXTemporalDenoisedScaler NewTemporalDenoisedScaler(MTLDevice device, MTL4Compiler compiler)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptor_Selectors.newTemporalDenoisedScaler_compiler_, device.NativePtr, compiler.NativePtr);
        return new MTLFXTemporalDenoisedScaler(__result);
    }

    public static float SupportedInputContentMinScale(MTLDevice device)
    {
        return BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalDenoisedScalerDescriptor_Selectors.supportedInputContentMinScale_, device.NativePtr));
    }

    public static float SupportedInputContentMaxScale(MTLDevice device)
    {
        return BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalDenoisedScalerDescriptor_Selectors.supportedInputContentMaxScale_, device.NativePtr));
    }

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        return (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalDenoisedScalerDescriptor_Selectors.supportsMetal4FX_, device.NativePtr) != 0;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        return (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalDenoisedScalerDescriptor_Selectors.supportsDevice_, device.NativePtr) != 0;
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
