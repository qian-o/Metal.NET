using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXFrameInterpolatorDescriptor_Selectors
{
    internal static readonly Selector setColorTextureFormat_ = Selector.Register("setColorTextureFormat:");
    internal static readonly Selector setOutputTextureFormat_ = Selector.Register("setOutputTextureFormat:");
    internal static readonly Selector setDepthTextureFormat_ = Selector.Register("setDepthTextureFormat:");
    internal static readonly Selector setMotionTextureFormat_ = Selector.Register("setMotionTextureFormat:");
    internal static readonly Selector setUITextureFormat_ = Selector.Register("setUITextureFormat:");
    internal static readonly Selector setScaler_ = Selector.Register("setScaler:");
    internal static readonly Selector setInputWidth_ = Selector.Register("setInputWidth:");
    internal static readonly Selector setInputHeight_ = Selector.Register("setInputHeight:");
    internal static readonly Selector setOutputWidth_ = Selector.Register("setOutputWidth:");
    internal static readonly Selector setOutputHeight_ = Selector.Register("setOutputHeight:");
    internal static readonly Selector newFrameInterpolator_ = Selector.Register("newFrameInterpolator:");
    internal static readonly Selector newFrameInterpolator_pCompiler_ = Selector.Register("newFrameInterpolator:pCompiler:");
    internal static readonly Selector supportsMetal4FX_ = Selector.Register("supportsMetal4FX:");
    internal static readonly Selector supportsDevice_ = Selector.Register("supportsDevice:");
}

public class MTLFXFrameInterpolatorDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXFrameInterpolatorDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXFrameInterpolatorDescriptor o) => o.NativePtr;
    public static implicit operator MTLFXFrameInterpolatorDescriptor(nint ptr) => new MTLFXFrameInterpolatorDescriptor(ptr);

    ~MTLFXFrameInterpolatorDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXFrameInterpolatorDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat colorTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setColorTextureFormat_, (nint)(uint)colorTextureFormat);
    }

    public void SetOutputTextureFormat(MTLPixelFormat outputTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setOutputTextureFormat_, (nint)(uint)outputTextureFormat);
    }

    public void SetDepthTextureFormat(MTLPixelFormat depthTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setDepthTextureFormat_, (nint)(uint)depthTextureFormat);
    }

    public void SetMotionTextureFormat(MTLPixelFormat motionTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setMotionTextureFormat_, (nint)(uint)motionTextureFormat);
    }

    public void SetUITextureFormat(MTLPixelFormat uiTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setUITextureFormat_, (nint)(uint)uiTextureFormat);
    }

    public void SetScaler(MTLFXFrameInterpolatableScaler scaler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setScaler_, scaler.NativePtr);
    }

    public void SetInputWidth(nuint inputWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setInputWidth_, (nint)inputWidth);
    }

    public void SetInputHeight(nuint inputHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setInputHeight_, (nint)inputHeight);
    }

    public void SetOutputWidth(nuint outputWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setOutputWidth_, (nint)outputWidth);
    }

    public void SetOutputHeight(nuint outputHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.setOutputHeight_, (nint)outputHeight);
    }

    public MTLFXFrameInterpolator NewFrameInterpolator(MTLDevice pDevice)
    {
        var __r = new MTLFXFrameInterpolator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.newFrameInterpolator_, pDevice.NativePtr));
        return __r;
    }

    public MTLFXFrameInterpolator NewFrameInterpolator(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        var __r = new MTLFXFrameInterpolator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptor_Selectors.newFrameInterpolator_pCompiler_, pDevice.NativePtr, pCompiler.NativePtr));
        return __r;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXFrameInterpolatorDescriptor_Selectors.supportsMetal4FX_, device.NativePtr) != 0;
        return __r;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXFrameInterpolatorDescriptor_Selectors.supportsDevice_, device.NativePtr) != 0;
        return __r;
    }

}
