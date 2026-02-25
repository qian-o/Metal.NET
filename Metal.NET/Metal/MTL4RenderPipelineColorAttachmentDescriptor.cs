namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4RenderPipelineColorAttachmentDescriptor>
{
    public static MTL4RenderPipelineColorAttachmentDescriptor Null { get; } = new(0, false);

    public static MTL4RenderPipelineColorAttachmentDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4RenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineColorAttachmentDescriptorBindings.Class), true)
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

    public static readonly Selector AlphaBlendOperation = "alphaBlendOperation";

    public static readonly Selector BlendingState = "blendingState";

    public static readonly Selector DestinationAlphaBlendFactor = "destinationAlphaBlendFactor";

    public static readonly Selector DestinationRGBBlendFactor = "destinationRGBBlendFactor";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector Reset = "reset";

    public static readonly Selector RgbBlendOperation = "rgbBlendOperation";

    public static readonly Selector SetAlphaBlendOperation = "setAlphaBlendOperation:";

    public static readonly Selector SetBlendingState = "setBlendingState:";

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
