namespace Metal.NET;

/// <summary>A color render target that specifies the color configuration and color operations for a render pipeline.</summary>
public class MTLRenderPipelineColorAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineColorAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLRenderPipelineColorAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineColorAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPipelineColorAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPipelineColorAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring render pipeline states - Properties

    /// <summary>The pixel format of the color attachment’s texture.</summary>
    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    /// <summary>A bitmask that restricts which color channels are written into the texture.</summary>
    public MTLColorWriteMask WriteMask
    {
        get => (MTLColorWriteMask)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.WriteMask);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetWriteMask, (nuint)value);
    }
    #endregion

    #region Controlling blend operations - Properties

    /// <summary>A Boolean value that determines whether blending is enabled.</summary>
    public Bool8 IsBlendingEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.IsBlendingEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetBlendingEnabled, value);
    }

    /// <summary>The blend operation assigned for the alpha data.</summary>
    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.AlphaBlendOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetAlphaBlendOperation, (nuint)value);
    }

    /// <summary>The blend operation assigned for the RGB data.</summary>
    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.RgbBlendOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetRgbBlendOperation, (nuint)value);
    }
    #endregion

    #region Configuring blend factors - Properties

    /// <summary>The destination blend factor (DBF) used by the alpha blend operation.</summary>
    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.DestinationAlphaBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationAlphaBlendFactor, (nuint)value);
    }

    /// <summary>The destination blend factor (DBF) used by the RGB blend operation.</summary>
    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.DestinationRGBBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationRGBBlendFactor, (nuint)value);
    }

    /// <summary>The source blend factor (SBF) used by the alpha blend operation.</summary>
    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SourceAlphaBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceAlphaBlendFactor, (nuint)value);
    }

    /// <summary>The source blend factor (SBF) used by the RGB blend operation.</summary>
    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SourceRGBBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceRGBBlendFactor, (nuint)value);
    }
    #endregion

    /// <summary>Deprecated: please use isBlendingEnabled instead</summary>
    [Obsolete("please use isBlendingEnabled instead")]
    public Bool8 BlendingEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.BlendingEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetBlendingEnabled, value);
    }
}

file static class MTLRenderPipelineColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPipelineColorAttachmentDescriptor");

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
