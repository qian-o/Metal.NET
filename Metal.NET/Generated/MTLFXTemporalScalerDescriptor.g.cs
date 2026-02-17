using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXTemporalScalerDescriptor_Selectors
{
    internal static readonly Selector setColorTextureFormat_ = Selector.Register("setColorTextureFormat:");
    internal static readonly Selector setDepthTextureFormat_ = Selector.Register("setDepthTextureFormat:");
    internal static readonly Selector setMotionTextureFormat_ = Selector.Register("setMotionTextureFormat:");
    internal static readonly Selector setOutputTextureFormat_ = Selector.Register("setOutputTextureFormat:");
    internal static readonly Selector setInputWidth_ = Selector.Register("setInputWidth:");
    internal static readonly Selector setInputHeight_ = Selector.Register("setInputHeight:");
    internal static readonly Selector setOutputWidth_ = Selector.Register("setOutputWidth:");
    internal static readonly Selector setOutputHeight_ = Selector.Register("setOutputHeight:");
    internal static readonly Selector setAutoExposureEnabled_ = Selector.Register("setAutoExposureEnabled:");
    internal static readonly Selector setInputContentPropertiesEnabled_ = Selector.Register("setInputContentPropertiesEnabled:");
    internal static readonly Selector setRequiresSynchronousInitialization_ = Selector.Register("setRequiresSynchronousInitialization:");
    internal static readonly Selector setReactiveMaskTextureEnabled_ = Selector.Register("setReactiveMaskTextureEnabled:");
    internal static readonly Selector setReactiveMaskTextureFormat_ = Selector.Register("setReactiveMaskTextureFormat:");
    internal static readonly Selector setInputContentMinScale_ = Selector.Register("setInputContentMinScale:");
    internal static readonly Selector setInputContentMaxScale_ = Selector.Register("setInputContentMaxScale:");
    internal static readonly Selector newTemporalScaler_ = Selector.Register("newTemporalScaler:");
    internal static readonly Selector newTemporalScaler_pCompiler_ = Selector.Register("newTemporalScaler:pCompiler:");
    internal static readonly Selector supportedInputContentMinScale_ = Selector.Register("supportedInputContentMinScale:");
    internal static readonly Selector supportedInputContentMaxScale_ = Selector.Register("supportedInputContentMaxScale:");
    internal static readonly Selector supportsDevice_ = Selector.Register("supportsDevice:");
    internal static readonly Selector supportsMetal4FX_ = Selector.Register("supportsMetal4FX:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFXTemporalScalerDescriptor
{
    public readonly nint NativePtr;

    public MTLFXTemporalScalerDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXTemporalScalerDescriptor o) => o.NativePtr;
    public static implicit operator MTLFXTemporalScalerDescriptor(nint ptr) => new MTLFXTemporalScalerDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXTemporalScalerDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setColorTextureFormat_, (nint)(uint)format);
    }

    public void SetDepthTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setDepthTextureFormat_, (nint)(uint)format);
    }

    public void SetMotionTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setMotionTextureFormat_, (nint)(uint)format);
    }

    public void SetOutputTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setOutputTextureFormat_, (nint)(uint)format);
    }

    public void SetInputWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setInputWidth_, (nint)width);
    }

    public void SetInputHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setInputHeight_, (nint)height);
    }

    public void SetOutputWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setOutputWidth_, (nint)width);
    }

    public void SetOutputHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setOutputHeight_, (nint)height);
    }

    public void SetAutoExposureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setAutoExposureEnabled_, (nint)enabled.Value);
    }

    public void SetInputContentPropertiesEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setInputContentPropertiesEnabled_, (nint)enabled.Value);
    }

    public void SetRequiresSynchronousInitialization(Bool8 requiresSynchronousInitialization)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setRequiresSynchronousInitialization_, (nint)requiresSynchronousInitialization.Value);
    }

    public void SetReactiveMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setReactiveMaskTextureEnabled_, (nint)enabled.Value);
    }

    public void SetReactiveMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setReactiveMaskTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetInputContentMinScale(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setInputContentMinScale_, scale);
    }

    public void SetInputContentMaxScale(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.setInputContentMaxScale_, scale);
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.newTemporalScaler_, pDevice.NativePtr);
        return new MTLFXTemporalScaler(__result);
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptor_Selectors.newTemporalScaler_pCompiler_, pDevice.NativePtr, pCompiler.NativePtr);
        return new MTLFXTemporalScaler(__result);
    }

    public static float SupportedInputContentMinScale(MTLDevice pDevice)
    {
        return BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptor_Selectors.supportedInputContentMinScale_, pDevice.NativePtr));
    }

    public static float SupportedInputContentMaxScale(MTLDevice pDevice)
    {
        return BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptor_Selectors.supportedInputContentMaxScale_, pDevice.NativePtr));
    }

    public static Bool8 SupportsDevice(MTLDevice pDevice)
    {
        return (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptor_Selectors.supportsDevice_, pDevice.NativePtr) != 0;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice pDevice)
    {
        return (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptor_Selectors.supportsMetal4FX_, pDevice.NativePtr) != 0;
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
