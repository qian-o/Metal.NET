using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4RenderPipelineColorAttachmentDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setAlphaBlendOperation_ = Selector.Register("setAlphaBlendOperation:");
    internal static readonly Selector setBlendingState_ = Selector.Register("setBlendingState:");
    internal static readonly Selector setDestinationAlphaBlendFactor_ = Selector.Register("setDestinationAlphaBlendFactor:");
    internal static readonly Selector setDestinationRGBBlendFactor_ = Selector.Register("setDestinationRGBBlendFactor:");
    internal static readonly Selector setPixelFormat_ = Selector.Register("setPixelFormat:");
    internal static readonly Selector setRgbBlendOperation_ = Selector.Register("setRgbBlendOperation:");
    internal static readonly Selector setSourceAlphaBlendFactor_ = Selector.Register("setSourceAlphaBlendFactor:");
    internal static readonly Selector setSourceRGBBlendFactor_ = Selector.Register("setSourceRGBBlendFactor:");
    internal static readonly Selector setWriteMask_ = Selector.Register("setWriteMask:");
}

public class MTL4RenderPipelineColorAttachmentDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4RenderPipelineColorAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4RenderPipelineColorAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTL4RenderPipelineColorAttachmentDescriptor(nint ptr) => new MTL4RenderPipelineColorAttachmentDescriptor(ptr);

    ~MTL4RenderPipelineColorAttachmentDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineColorAttachmentDescriptor");

    public static MTL4RenderPipelineColorAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTL4RenderPipelineColorAttachmentDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.reset);
    }

    public void SetAlphaBlendOperation(MTLBlendOperation alphaBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setAlphaBlendOperation_, (nint)(uint)alphaBlendOperation);
    }

    public void SetBlendingState(MTL4BlendState blendingState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setBlendingState_, (nint)(uint)blendingState);
    }

    public void SetDestinationAlphaBlendFactor(MTLBlendFactor destinationAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setDestinationAlphaBlendFactor_, (nint)(uint)destinationAlphaBlendFactor);
    }

    public void SetDestinationRGBBlendFactor(MTLBlendFactor destinationRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setDestinationRGBBlendFactor_, (nint)(uint)destinationRGBBlendFactor);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetRgbBlendOperation(MTLBlendOperation rgbBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setRgbBlendOperation_, (nint)(uint)rgbBlendOperation);
    }

    public void SetSourceAlphaBlendFactor(MTLBlendFactor sourceAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setSourceAlphaBlendFactor_, (nint)(uint)sourceAlphaBlendFactor);
    }

    public void SetSourceRGBBlendFactor(MTLBlendFactor sourceRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setSourceRGBBlendFactor_, (nint)(uint)sourceRGBBlendFactor);
    }

    public void SetWriteMask(nuint writeMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptor_Selectors.setWriteMask_, (nint)writeMask);
    }

}
