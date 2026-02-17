namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptor : IDisposable
{
    public MTL4RenderPipelineColorAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTL4RenderPipelineColorAttachmentDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.Reset);
    }

    public void SetAlphaBlendOperation(MTLBlendOperation alphaBlendOperation)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetAlphaBlendOperation, (nint)(uint)alphaBlendOperation);
    }

    public void SetBlendingState(MTL4BlendState blendingState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetBlendingState, (nint)(uint)blendingState);
    }

    public void SetDestinationAlphaBlendFactor(MTLBlendFactor destinationAlphaBlendFactor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetDestinationAlphaBlendFactor, (nint)(uint)destinationAlphaBlendFactor);
    }

    public void SetDestinationRGBBlendFactor(MTLBlendFactor destinationRGBBlendFactor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetDestinationRGBBlendFactor, (nint)(uint)destinationRGBBlendFactor);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat, (nint)(uint)pixelFormat);
    }

    public void SetRgbBlendOperation(MTLBlendOperation rgbBlendOperation)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetRgbBlendOperation, (nint)(uint)rgbBlendOperation);
    }

    public void SetSourceAlphaBlendFactor(MTLBlendFactor sourceAlphaBlendFactor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetSourceAlphaBlendFactor, (nint)(uint)sourceAlphaBlendFactor);
    }

    public void SetSourceRGBBlendFactor(MTLBlendFactor sourceRGBBlendFactor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetSourceRGBBlendFactor, (nint)(uint)sourceRGBBlendFactor);
    }

    public void SetWriteMask(uint writeMask)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetWriteMask, (nint)writeMask);
    }

}

file class MTL4RenderPipelineColorAttachmentDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetAlphaBlendOperation = Selector.Register("setAlphaBlendOperation:");

    public static readonly Selector SetBlendingState = Selector.Register("setBlendingState:");

    public static readonly Selector SetDestinationAlphaBlendFactor = Selector.Register("setDestinationAlphaBlendFactor:");

    public static readonly Selector SetDestinationRGBBlendFactor = Selector.Register("setDestinationRGBBlendFactor:");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector SetRgbBlendOperation = Selector.Register("setRgbBlendOperation:");

    public static readonly Selector SetSourceAlphaBlendFactor = Selector.Register("setSourceAlphaBlendFactor:");

    public static readonly Selector SetSourceRGBBlendFactor = Selector.Register("setSourceRGBBlendFactor:");

    public static readonly Selector SetWriteMask = Selector.Register("setWriteMask:");
}
