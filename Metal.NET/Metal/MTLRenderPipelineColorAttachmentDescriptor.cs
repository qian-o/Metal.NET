namespace Metal.NET;

public readonly struct MTLRenderPipelineColorAttachmentDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineColorAttachmentDescriptorBindings.Class))
    {
    }

    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.AlphaBlendOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetAlphaBlendOperation, (nuint)value);
    }

    public bool BlendingEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.BlendingEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetBlendingEnabled, (Bool8)value);
    }

    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.DestinationAlphaBlendFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.DestinationRGBBlendFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationRGBBlendFactor, (nuint)value);
    }

    public bool IsBlendingEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.IsBlendingEnabled);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.RgbBlendOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetRgbBlendOperation, (nuint)value);
    }

    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SourceAlphaBlendFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SourceRGBBlendFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceRGBBlendFactor, (nuint)value);
    }

    public MTLColorWriteMask WriteMask
    {
        get => (MTLColorWriteMask)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.WriteMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetWriteMask, (nuint)value);
    }
}

file static class MTLRenderPipelineColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptor");

    public static readonly Selector AlphaBlendOperation = Selector.Register("alphaBlendOperation");

    public static readonly Selector BlendingEnabled = Selector.Register("isBlendingEnabled");

    public static readonly Selector DestinationAlphaBlendFactor = Selector.Register("destinationAlphaBlendFactor");

    public static readonly Selector DestinationRGBBlendFactor = Selector.Register("destinationRGBBlendFactor");

    public static readonly Selector IsBlendingEnabled = Selector.Register("isBlendingEnabled");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector RgbBlendOperation = Selector.Register("rgbBlendOperation");

    public static readonly Selector SetAlphaBlendOperation = Selector.Register("setAlphaBlendOperation:");

    public static readonly Selector SetBlendingEnabled = Selector.Register("setBlendingEnabled:");

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
