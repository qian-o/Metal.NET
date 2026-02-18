namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptor");

    public MTLRenderPipelineColorAttachmentDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLRenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLRenderPipelineColorAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.AlphaBlendOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetAlphaBlendOperation, (nuint)value);
    }

    public Bool8 BlendingEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.BlendingEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetBlendingEnabled, value);
    }

    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.DestinationAlphaBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetDestinationAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.DestinationRGBBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetDestinationRGBBlendFactor, (nuint)value);
    }

    public Bool8 IsBlendingEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.IsBlendingEnabled);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.PixelFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat, (nuint)value);
    }

    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.RgbBlendOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetRgbBlendOperation, (nuint)value);
    }

    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SourceAlphaBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetSourceAlphaBlendFactor, (nuint)value);
    }

    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SourceRGBBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetSourceRGBBlendFactor, (nuint)value);
    }

    public MTLColorWriteMask WriteMask
    {
        get => (MTLColorWriteMask)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.WriteMask));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetWriteMask, (nuint)value);
    }

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
}

file class MTLRenderPipelineColorAttachmentDescriptorSelector
{
    public static readonly Selector AlphaBlendOperation = Selector.Register("alphaBlendOperation");

    public static readonly Selector SetAlphaBlendOperation = Selector.Register("setAlphaBlendOperation:");

    public static readonly Selector BlendingEnabled = Selector.Register("blendingEnabled");

    public static readonly Selector SetBlendingEnabled = Selector.Register("setBlendingEnabled:");

    public static readonly Selector DestinationAlphaBlendFactor = Selector.Register("destinationAlphaBlendFactor");

    public static readonly Selector SetDestinationAlphaBlendFactor = Selector.Register("setDestinationAlphaBlendFactor:");

    public static readonly Selector DestinationRGBBlendFactor = Selector.Register("destinationRGBBlendFactor");

    public static readonly Selector SetDestinationRGBBlendFactor = Selector.Register("setDestinationRGBBlendFactor:");

    public static readonly Selector IsBlendingEnabled = Selector.Register("isBlendingEnabled");

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
}
