namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptor : IDisposable
{
    public MTLRenderPipelineColorAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetAlphaBlendOperation, (nint)(uint)alphaBlendOperation);
    }

    public void SetBlendingEnabled(Bool8 blendingEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetBlendingEnabled, (nint)blendingEnabled.Value);
    }

    public void SetDestinationAlphaBlendFactor(MTLBlendFactor destinationAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetDestinationAlphaBlendFactor, (nint)(uint)destinationAlphaBlendFactor);
    }

    public void SetDestinationRGBBlendFactor(MTLBlendFactor destinationRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetDestinationRGBBlendFactor, (nint)(uint)destinationRGBBlendFactor);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat, (nint)(uint)pixelFormat);
    }

    public void SetRgbBlendOperation(MTLBlendOperation rgbBlendOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetRgbBlendOperation, (nint)(uint)rgbBlendOperation);
    }

    public void SetSourceAlphaBlendFactor(MTLBlendFactor sourceAlphaBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetSourceAlphaBlendFactor, (nint)(uint)sourceAlphaBlendFactor);
    }

    public void SetSourceRGBBlendFactor(MTLBlendFactor sourceRGBBlendFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetSourceRGBBlendFactor, (nint)(uint)sourceRGBBlendFactor);
    }

    public void SetWriteMask(uint writeMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetWriteMask, (nint)writeMask);
    }

}

file class MTLRenderPipelineColorAttachmentDescriptorSelector
{
    public static readonly Selector SetAlphaBlendOperation = Selector.Register("setAlphaBlendOperation:");
    public static readonly Selector SetBlendingEnabled = Selector.Register("setBlendingEnabled:");
    public static readonly Selector SetDestinationAlphaBlendFactor = Selector.Register("setDestinationAlphaBlendFactor:");
    public static readonly Selector SetDestinationRGBBlendFactor = Selector.Register("setDestinationRGBBlendFactor:");
    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");
    public static readonly Selector SetRgbBlendOperation = Selector.Register("setRgbBlendOperation:");
    public static readonly Selector SetSourceAlphaBlendFactor = Selector.Register("setSourceAlphaBlendFactor:");
    public static readonly Selector SetSourceRGBBlendFactor = Selector.Register("setSourceRGBBlendFactor:");
    public static readonly Selector SetWriteMask = Selector.Register("setWriteMask:");
}
