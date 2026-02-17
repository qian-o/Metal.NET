namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineColorAttachmentDescriptor");

    public MTL4RenderPipelineColorAttachmentDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4RenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4RenderPipelineColorAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.AlphaBlendOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetAlphaBlendOperation, (uint)value);
    }

    public MTL4BlendState BlendingState
    {
        get => (MTL4BlendState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.BlendingState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetBlendingState, (uint)value);
    }

    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.DestinationAlphaBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetDestinationAlphaBlendFactor, (uint)value);
    }

    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.DestinationRGBBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetDestinationRGBBlendFactor, (uint)value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.PixelFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat, (uint)value);
    }

    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.RgbBlendOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetRgbBlendOperation, (uint)value);
    }

    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SourceAlphaBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetSourceAlphaBlendFactor, (uint)value);
    }

    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SourceRGBBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetSourceRGBBlendFactor, (uint)value);
    }

    public MTLColorWriteMask WriteMask
    {
        get => (MTLColorWriteMask)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.WriteMask));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.SetWriteMask, (uint)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorSelector.Reset);
    }

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
}

file class MTL4RenderPipelineColorAttachmentDescriptorSelector
{
    public static readonly Selector AlphaBlendOperation = Selector.Register("alphaBlendOperation");

    public static readonly Selector SetAlphaBlendOperation = Selector.Register("setAlphaBlendOperation:");

    public static readonly Selector BlendingState = Selector.Register("blendingState");

    public static readonly Selector SetBlendingState = Selector.Register("setBlendingState:");

    public static readonly Selector DestinationAlphaBlendFactor = Selector.Register("destinationAlphaBlendFactor");

    public static readonly Selector SetDestinationAlphaBlendFactor = Selector.Register("setDestinationAlphaBlendFactor:");

    public static readonly Selector DestinationRGBBlendFactor = Selector.Register("destinationRGBBlendFactor");

    public static readonly Selector SetDestinationRGBBlendFactor = Selector.Register("setDestinationRGBBlendFactor:");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector RgbBlendOperation = Selector.Register("rgbBlendOperation");

    public static readonly Selector SetRgbBlendOperation = Selector.Register("setRgbBlendOperation:");

    public static readonly Selector SourceAlphaBlendFactor = Selector.Register("sourceAlphaBlendFactor");

    public static readonly Selector SetSourceAlphaBlendFactor = Selector.Register("setSourceAlphaBlendFactor:");

    public static readonly Selector SourceRGBBlendFactor = Selector.Register("sourceRGBBlendFactor");

    public static readonly Selector SetSourceRGBBlendFactor = Selector.Register("setSourceRGBBlendFactor:");

    public static readonly Selector WriteMask = Selector.Register("writeMask");

    public static readonly Selector SetWriteMask = Selector.Register("setWriteMask:");

    public static readonly Selector Reset = Selector.Register("reset");
}
