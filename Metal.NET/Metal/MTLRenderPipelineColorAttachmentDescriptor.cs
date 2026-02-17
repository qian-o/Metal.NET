namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptor : IDisposable
{
    public MTLRenderPipelineColorAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPipelineColorAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptor");

    public MTLRenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public MTLBlendOperation AlphaBlendOperation
    {
        get => (MTLBlendOperation)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.AlphaBlendOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetAlphaBlendOperation, (uint)value);
    }

    public Bool8 BlendingEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.BlendingEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetBlendingEnabled, value);
    }

    public MTLBlendFactor DestinationAlphaBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.DestinationAlphaBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetDestinationAlphaBlendFactor, (uint)value);
    }

    public MTLBlendFactor DestinationRGBBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.DestinationRGBBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetDestinationRGBBlendFactor, (uint)value);
    }

    public Bool8 IsBlendingEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.IsBlendingEnabled);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.PixelFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat, (uint)value);
    }

    public MTLBlendOperation RgbBlendOperation
    {
        get => (MTLBlendOperation)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.RgbBlendOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetRgbBlendOperation, (uint)value);
    }

    public MTLBlendFactor SourceAlphaBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SourceAlphaBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetSourceAlphaBlendFactor, (uint)value);
    }

    public MTLBlendFactor SourceRGBBlendFactor
    {
        get => (MTLBlendFactor)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SourceRGBBlendFactor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetSourceRGBBlendFactor, (uint)value);
    }

    public nuint WriteMask
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.WriteMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorSelector.SetWriteMask, (nuint)value);
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
