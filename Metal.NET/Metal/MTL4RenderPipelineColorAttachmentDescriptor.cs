namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4RenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineColorAttachmentDescriptorBindings.Class))
    {
    }

    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.AlphaBlendOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetAlphaBlendOperation, (nuint)value);
    }

    public MTL4BlendState BlendingState
    {
        get => (MTL4BlendState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.BlendingState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetBlendingState, (nint)value);
    }

    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.DestinationAlphaBlendFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetDestinationAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.DestinationRGBBlendFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetDestinationRGBBlendFactor, (nuint)value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.RgbBlendOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetRgbBlendOperation, (nuint)value);
    }

    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SourceAlphaBlendFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetSourceAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SourceRGBBlendFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetSourceRGBBlendFactor, (nuint)value);
    }

    public MTLColorWriteMask WriteMask
    {
        get => (MTLColorWriteMask)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.WriteMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetWriteMask, (nuint)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.Reset);
    }
}

file static class MTL4RenderPipelineColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineColorAttachmentDescriptor");

    public static readonly Selector AlphaBlendOperation = Selector.Register("alphaBlendOperation");

    public static readonly Selector BlendingState = Selector.Register("blendingState");

    public static readonly Selector DestinationAlphaBlendFactor = Selector.Register("destinationAlphaBlendFactor");

    public static readonly Selector DestinationRGBBlendFactor = Selector.Register("destinationRGBBlendFactor");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector RgbBlendOperation = Selector.Register("rgbBlendOperation");

    public static readonly Selector SetAlphaBlendOperation = Selector.Register("setAlphaBlendOperation:");

    public static readonly Selector SetBlendingState = Selector.Register("setBlendingState:");

    public static readonly Selector SetDestinationAlphaBlendFactor = Selector.Register("setDestinationAlphaBlendFactor:");

    public static readonly Selector SetDestinationRGBBlendFactor = Selector.Register("setDestinationRGBBlendFactor:");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector SetRgbBlendOperation = Selector.Register("setRgbBlendOperation:");

    public static readonly Selector SetSourceAlphaBlendFactor = Selector.Register("setSourceAlphaBlendFactor:");

    public static readonly Selector SetSourceRGBBlendFactor = Selector.Register("setSourceRGBBlendFactor:");

    public static readonly Selector SetWriteMask = Selector.Register("setWriteMask:");

    public static readonly Selector SourceAlphaBlendFactor = Selector.Register("sourceAlphaBlendFactor");

    public static readonly Selector SourceRGBBlendFactor = Selector.Register("sourceRGBBlendFactor");

    public static readonly Selector WriteMask = Selector.Register("writeMask");
}
