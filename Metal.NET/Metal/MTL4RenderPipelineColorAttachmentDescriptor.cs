namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4RenderPipelineColorAttachmentDescriptor>
{
    #region INativeObject
    public static new MTL4RenderPipelineColorAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderPipelineColorAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4RenderPipelineColorAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPipelineColorAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Configures the alpha blending operation.
    /// </summary>
    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.AlphaBlendOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetAlphaBlendOperation, (nuint)value);
    }

    /// <summary>
    /// Configure the blend state for color attachments the pipeline state uses.
    /// </summary>
    public MTL4BlendState BlendingState
    {
        get => (MTL4BlendState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.BlendingState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetBlendingState, (nint)value);
    }

    /// <summary>
    /// Configures the destination-alpha blend factor.
    /// </summary>
    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.DestinationAlphaBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetDestinationAlphaBlendFactor, (nuint)value);
    }

    /// <summary>
    /// Configures the destination RGB blend factor.
    /// </summary>
    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.DestinationRGBBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetDestinationRGBBlendFactor, (nuint)value);
    }

    /// <summary>
    /// Configures the pixel format.
    /// </summary>
    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    /// <summary>
    /// Configures the RGB blend operation.
    /// </summary>
    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.RgbBlendOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetRgbBlendOperation, (nuint)value);
    }

    /// <summary>
    /// Configures the source-alpha blend factor.
    /// </summary>
    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SourceAlphaBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetSourceAlphaBlendFactor, (nuint)value);
    }

    /// <summary>
    /// Configures the source RGB blend factor.
    /// </summary>
    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SourceRGBBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetSourceRGBBlendFactor, (nuint)value);
    }

    /// <summary>
    /// Configures the color write mask.
    /// </summary>
    public MTLColorWriteMask WriteMask
    {
        get => (MTLColorWriteMask)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.WriteMask);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.SetWriteMask, (nuint)value);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Resets this descriptor to its default state.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorBindings.Reset);
    }
    #endregion
}

file static class MTL4RenderPipelineColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4RenderPipelineColorAttachmentDescriptor");

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
