namespace Metal.NET;

file class MTL4RenderPipelineColorAttachmentDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetAlphaBlendOperation_ = Selector.Register("setAlphaBlendOperation:");
    public static readonly Selector SetBlendingState_ = Selector.Register("setBlendingState:");
    public static readonly Selector SetDestinationAlphaBlendFactor_ = Selector.Register("setDestinationAlphaBlendFactor:");
    public static readonly Selector SetDestinationRGBBlendFactor_ = Selector.Register("setDestinationRGBBlendFactor:");
    public static readonly Selector SetPixelFormat_ = Selector.Register("setPixelFormat:");
    public static readonly Selector SetRgbBlendOperation_ = Selector.Register("setRgbBlendOperation:");
    public static readonly Selector SetSourceAlphaBlendFactor_ = Selector.Register("setSourceAlphaBlendFactor:");
    public static readonly Selector SetSourceRGBBlendFactor_ = Selector.Register("setSourceRGBBlendFactor:");
    public static readonly Selector SetWriteMask_ = Selector.Register("setWriteMask:");
}

public class MTL4RenderPipelineColorAttachmentDescriptor : IDisposable
{
    public MTL4RenderPipelineColorAttachmentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4RenderPipelineColorAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4RenderPipelineColorAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4RenderPipelineColorAttachmentDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineColorAttachmentDescriptor");

    public static MTL4RenderPipelineColorAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTL4RenderPipelineColorAttachmentDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.Reset);
    }

    public void SetAlphaBlendOperation(MTLBlendOperation alphaBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetAlphaBlendOperation_, (nint)(uint)alphaBlendOperation);
    }

    public void SetBlendingState(MTL4BlendState blendingState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetBlendingState_, (nint)(uint)blendingState);
    }

    public void SetDestinationAlphaBlendFactor(MTLBlendFactor destinationAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetDestinationAlphaBlendFactor_, (nint)(uint)destinationAlphaBlendFactor);
    }

    public void SetDestinationRGBBlendFactor(MTLBlendFactor destinationRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetDestinationRGBBlendFactor_, (nint)(uint)destinationRGBBlendFactor);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetRgbBlendOperation(MTLBlendOperation rgbBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetRgbBlendOperation_, (nint)(uint)rgbBlendOperation);
    }

    public void SetSourceAlphaBlendFactor(MTLBlendFactor sourceAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetSourceAlphaBlendFactor_, (nint)(uint)sourceAlphaBlendFactor);
    }

    public void SetSourceRGBBlendFactor(MTLBlendFactor sourceRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetSourceRGBBlendFactor_, (nint)(uint)sourceRGBBlendFactor);
    }

    public void SetWriteMask(nuint writeMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetWriteMask_, (nint)writeMask);
    }

}
