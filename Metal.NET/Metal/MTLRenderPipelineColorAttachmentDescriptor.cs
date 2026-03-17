namespace Metal.NET;

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

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public Bool8 IsBlendingEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.IsBlendingEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetBlendingEnabled, value);
    }

    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SourceRGBBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceRGBBlendFactor, (nuint)value);
    }

    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.DestinationRGBBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationRGBBlendFactor, (nuint)value);
    }

    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.RgbBlendOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetRgbBlendOperation, (nuint)value);
    }

    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SourceAlphaBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.DestinationAlphaBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.AlphaBlendOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetAlphaBlendOperation, (nuint)value);
    }

    public MTLColorWriteMask WriteMask
    {
        get => (MTLColorWriteMask)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.WriteMask);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetWriteMask, (nuint)value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public Bool8 IsBlendingEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.IsBlendingEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetBlendingEnabled, value);
    }

    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SourceRGBBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceRGBBlendFactor, (nuint)value);
    }

    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.DestinationRGBBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationRGBBlendFactor, (nuint)value);
    }

    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.RgbBlendOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetRgbBlendOperation, (nuint)value);
    }

    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SourceAlphaBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.DestinationAlphaBlendFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.AlphaBlendOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetAlphaBlendOperation, (nuint)value);
    }

    public MTLColorWriteMask WriteMask
    {
        get => (MTLColorWriteMask)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.WriteMask);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetWriteMask, (nuint)value);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)pixelFormat);
    }

    public void SetIsBlendingEnabled(bool isBlendingEnabled)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetIsBlendingEnabled, isBlendingEnabled);
    }

    public void SetSourceRGBBlendFactor(MTLBlendFactor sourceRGBBlendFactor)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceRGBBlendFactor, (nuint)sourceRGBBlendFactor);
    }

    public void SetDestinationRGBBlendFactor(MTLBlendFactor destinationRGBBlendFactor)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationRGBBlendFactor, (nuint)destinationRGBBlendFactor);
    }

    public void SetRgbBlendOperation(MTLBlendOperation rgbBlendOperation)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetRgbBlendOperation, (nuint)rgbBlendOperation);
    }

    public void SetSourceAlphaBlendFactor(MTLBlendFactor sourceAlphaBlendFactor)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetSourceAlphaBlendFactor, (nuint)sourceAlphaBlendFactor);
    }

    public void SetDestinationAlphaBlendFactor(MTLBlendFactor destinationAlphaBlendFactor)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetDestinationAlphaBlendFactor, (nuint)destinationAlphaBlendFactor);
    }

    public void SetAlphaBlendOperation(MTLBlendOperation alphaBlendOperation)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetAlphaBlendOperation, (nuint)alphaBlendOperation);
    }

    public void SetWriteMask(MTLColorWriteMask writeMask)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorBindings.SetWriteMask, (nuint)writeMask);
    }
}

file static class MTLRenderPipelineColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPipelineColorAttachmentDescriptor");

    public static readonly Selector AlphaBlendOperation = "alphaBlendOperation";

    public static readonly Selector DestinationAlphaBlendFactor = "destinationAlphaBlendFactor";

    public static readonly Selector DestinationRGBBlendFactor = "destinationRGBBlendFactor";

    public static readonly Selector IsBlendingEnabled = "isBlendingEnabled";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector RgbBlendOperation = "rgbBlendOperation";

    public static readonly Selector SetAlphaBlendOperation = "setAlphaBlendOperation:";

    public static readonly Selector SetBlendingEnabled = "setBlendingEnabled:";

    public static readonly Selector SetDestinationAlphaBlendFactor = "setDestinationAlphaBlendFactor:";

    public static readonly Selector SetDestinationRGBBlendFactor = "setDestinationRGBBlendFactor:";

    public static readonly Selector SetIsBlendingEnabled = "setBlendingEnabled:";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";

    public static readonly Selector SetRgbBlendOperation = "setRgbBlendOperation:";

    public static readonly Selector SetSourceAlphaBlendFactor = "setSourceAlphaBlendFactor:";

    public static readonly Selector SetSourceRGBBlendFactor = "setSourceRGBBlendFactor:";

    public static readonly Selector SetWriteMask = "setWriteMask:";

    public static readonly Selector SourceAlphaBlendFactor = "sourceAlphaBlendFactor";

    public static readonly Selector SourceRGBBlendFactor = "sourceRGBBlendFactor";

    public static readonly Selector WriteMask = "writeMask";
}
