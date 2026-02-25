namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRenderPipelineColorAttachmentDescriptor>
{
    public static MTLRenderPipelineColorAttachmentDescriptor Null { get; } = new(0, false);

    public static MTLRenderPipelineColorAttachmentDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLRenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineColorAttachmentDescriptorBindings.Class), true)
    {
    }

    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.AlphaBlendOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetAlphaBlendOperation, (nuint)value);
    }

    public Bool8 BlendingEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.BlendingEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetBlendingEnabled, value);
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

    public Bool8 IsBlendingEnabled
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

    public static readonly Selector AlphaBlendOperation = "alphaBlendOperation";

    public static readonly Selector BlendingEnabled = "isBlendingEnabled";

    public static readonly Selector DestinationAlphaBlendFactor = "destinationAlphaBlendFactor";

    public static readonly Selector DestinationRGBBlendFactor = "destinationRGBBlendFactor";

    public static readonly Selector IsBlendingEnabled = "isBlendingEnabled";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector RgbBlendOperation = "rgbBlendOperation";

    public static readonly Selector SetAlphaBlendOperation = "setAlphaBlendOperation:";

    public static readonly Selector SetBlendingEnabled = "setBlendingEnabled:";

    public static readonly Selector SetDestinationAlphaBlendFactor = "setDestinationAlphaBlendFactor:";

    public static readonly Selector SetDestinationRGBBlendFactor = "setDestinationRGBBlendFactor:";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";

    public static readonly Selector SetRgbBlendOperation = "setRgbBlendOperation:";

    public static readonly Selector SetSourceAlphaBlendFactor = "setSourceAlphaBlendFactor:";

    public static readonly Selector SetSourceRGBBlendFactor = "setSourceRGBBlendFactor:";

    public static readonly Selector SetWriteMask = "setWriteMask:";

    public static readonly Selector SourceAlphaBlendFactor = "sourceAlphaBlendFactor";

    public static readonly Selector SourceRGBBlendFactor = "sourceRGBBlendFactor";

    public static readonly Selector WriteMask = "writeMask";
}
