using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPipelineColorAttachmentDescriptor_Selectors
{
    internal static readonly Selector setAlphaBlendOperation_ = Selector.Register("setAlphaBlendOperation:");
    internal static readonly Selector setBlendingEnabled_ = Selector.Register("setBlendingEnabled:");
    internal static readonly Selector setDestinationAlphaBlendFactor_ = Selector.Register("setDestinationAlphaBlendFactor:");
    internal static readonly Selector setDestinationRGBBlendFactor_ = Selector.Register("setDestinationRGBBlendFactor:");
    internal static readonly Selector setPixelFormat_ = Selector.Register("setPixelFormat:");
    internal static readonly Selector setRgbBlendOperation_ = Selector.Register("setRgbBlendOperation:");
    internal static readonly Selector setSourceAlphaBlendFactor_ = Selector.Register("setSourceAlphaBlendFactor:");
    internal static readonly Selector setSourceRGBBlendFactor_ = Selector.Register("setSourceRGBBlendFactor:");
    internal static readonly Selector setWriteMask_ = Selector.Register("setWriteMask:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLRenderPipelineColorAttachmentDescriptor
{
    public readonly nint NativePtr;

    public MTLRenderPipelineColorAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPipelineColorAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLRenderPipelineColorAttachmentDescriptor(nint ptr) => new MTLRenderPipelineColorAttachmentDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptor");

    public static MTLRenderPipelineColorAttachmentDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLRenderPipelineColorAttachmentDescriptor(ptr);
    }

    public MTLRenderPipelineColorAttachmentDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLRenderPipelineColorAttachmentDescriptor(ptr);
    }

    public static MTLRenderPipelineColorAttachmentDescriptor New()
    {
        return Alloc().Init();
    }

    public void SetAlphaBlendOperation(MTLBlendOperation alphaBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setAlphaBlendOperation_, (nint)(uint)alphaBlendOperation);
    }

    public void SetBlendingEnabled(Bool8 blendingEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setBlendingEnabled_, (nint)blendingEnabled.Value);
    }

    public void SetDestinationAlphaBlendFactor(MTLBlendFactor destinationAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setDestinationAlphaBlendFactor_, (nint)(uint)destinationAlphaBlendFactor);
    }

    public void SetDestinationRGBBlendFactor(MTLBlendFactor destinationRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setDestinationRGBBlendFactor_, (nint)(uint)destinationRGBBlendFactor);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetRgbBlendOperation(MTLBlendOperation rgbBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setRgbBlendOperation_, (nint)(uint)rgbBlendOperation);
    }

    public void SetSourceAlphaBlendFactor(MTLBlendFactor sourceAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setSourceAlphaBlendFactor_, (nint)(uint)sourceAlphaBlendFactor);
    }

    public void SetSourceRGBBlendFactor(MTLBlendFactor sourceRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setSourceRGBBlendFactor_, (nint)(uint)sourceRGBBlendFactor);
    }

    public void SetWriteMask(nuint writeMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptor_Selectors.setWriteMask_, (nint)writeMask);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
