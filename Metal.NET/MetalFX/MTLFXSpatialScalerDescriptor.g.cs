using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXSpatialScalerDescriptor_Selectors
{
    internal static readonly Selector setColorTextureFormat_ = Selector.Register("setColorTextureFormat:");
    internal static readonly Selector setOutputTextureFormat_ = Selector.Register("setOutputTextureFormat:");
    internal static readonly Selector setInputWidth_ = Selector.Register("setInputWidth:");
    internal static readonly Selector setInputHeight_ = Selector.Register("setInputHeight:");
    internal static readonly Selector setOutputWidth_ = Selector.Register("setOutputWidth:");
    internal static readonly Selector setOutputHeight_ = Selector.Register("setOutputHeight:");
    internal static readonly Selector setColorProcessingMode_ = Selector.Register("setColorProcessingMode:");
    internal static readonly Selector newSpatialScaler_ = Selector.Register("newSpatialScaler:");
    internal static readonly Selector newSpatialScaler_pCompiler_ = Selector.Register("newSpatialScaler:pCompiler:");
    internal static readonly Selector supportsDevice_ = Selector.Register("supportsDevice:");
    internal static readonly Selector supportsMetal4FX_ = Selector.Register("supportsMetal4FX:");
}

public class MTLFXSpatialScalerDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXSpatialScalerDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXSpatialScalerDescriptor o) => o.NativePtr;
    public static implicit operator MTLFXSpatialScalerDescriptor(nint ptr) => new MTLFXSpatialScalerDescriptor(ptr);

    ~MTLFXSpatialScalerDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXSpatialScalerDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.setColorTextureFormat_, (nint)(uint)format);
    }

    public void SetOutputTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.setOutputTextureFormat_, (nint)(uint)format);
    }

    public void SetInputWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.setInputWidth_, (nint)width);
    }

    public void SetInputHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.setInputHeight_, (nint)height);
    }

    public void SetOutputWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.setOutputWidth_, (nint)width);
    }

    public void SetOutputHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.setOutputHeight_, (nint)height);
    }

    public void SetColorProcessingMode(MTLFXSpatialScalerColorProcessingMode mode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.setColorProcessingMode_, (nint)(uint)mode);
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice)
    {
        var __r = new MTLFXSpatialScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.newSpatialScaler_, pDevice.NativePtr));
        return __r;
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        var __r = new MTLFXSpatialScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptor_Selectors.newSpatialScaler_pCompiler_, pDevice.NativePtr, pCompiler.NativePtr));
        return __r;
    }

    public static Bool8 SupportsDevice(MTLDevice pDevice)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXSpatialScalerDescriptor_Selectors.supportsDevice_, pDevice.NativePtr) != 0;
        return __r;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice pDevice)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXSpatialScalerDescriptor_Selectors.supportsMetal4FX_, pDevice.NativePtr) != 0;
        return __r;
    }

}
