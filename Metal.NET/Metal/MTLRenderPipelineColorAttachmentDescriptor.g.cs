namespace Metal.NET;

file class MTLRenderPipelineColorAttachmentDescriptorSelector
{
    public static readonly Selector SetAlphaBlendOperation_ = Selector.Register("setAlphaBlendOperation:");
    public static readonly Selector SetBlendingEnabled_ = Selector.Register("setBlendingEnabled:");
    public static readonly Selector SetDestinationAlphaBlendFactor_ = Selector.Register("setDestinationAlphaBlendFactor:");
    public static readonly Selector SetDestinationRGBBlendFactor_ = Selector.Register("setDestinationRGBBlendFactor:");
    public static readonly Selector SetPixelFormat_ = Selector.Register("setPixelFormat:");
    public static readonly Selector SetRgbBlendOperation_ = Selector.Register("setRgbBlendOperation:");
    public static readonly Selector SetSourceAlphaBlendFactor_ = Selector.Register("setSourceAlphaBlendFactor:");
    public static readonly Selector SetSourceRGBBlendFactor_ = Selector.Register("setSourceRGBBlendFactor:");
    public static readonly Selector SetWriteMask_ = Selector.Register("setWriteMask:");
}

public class MTLRenderPipelineColorAttachmentDescriptor : IDisposable
{
    public MTLRenderPipelineColorAttachmentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLRenderPipelineColorAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPipelineColorAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPipelineColorAttachmentDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptor");

    public static MTLRenderPipelineColorAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLRenderPipelineColorAttachmentDescriptor(ptr);
    }

    public void SetAlphaBlendOperation(MTLBlendOperation alphaBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetAlphaBlendOperation_, (nint)(uint)alphaBlendOperation);
    }

    public void SetBlendingEnabled(Bool8 blendingEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetBlendingEnabled_, (nint)blendingEnabled.Value);
    }

    public void SetDestinationAlphaBlendFactor(MTLBlendFactor destinationAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetDestinationAlphaBlendFactor_, (nint)(uint)destinationAlphaBlendFactor);
    }

    public void SetDestinationRGBBlendFactor(MTLBlendFactor destinationRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetDestinationRGBBlendFactor_, (nint)(uint)destinationRGBBlendFactor);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetRgbBlendOperation(MTLBlendOperation rgbBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetRgbBlendOperation_, (nint)(uint)rgbBlendOperation);
    }

    public void SetSourceAlphaBlendFactor(MTLBlendFactor sourceAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetSourceAlphaBlendFactor_, (nint)(uint)sourceAlphaBlendFactor);
    }

    public void SetSourceRGBBlendFactor(MTLBlendFactor sourceRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetSourceRGBBlendFactor_, (nint)(uint)sourceRGBBlendFactor);
    }

    public void SetWriteMask(nuint writeMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetWriteMask_, (nint)writeMask);
    }

}
