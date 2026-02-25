namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLTileRenderPipelineColorAttachmentDescriptor>
{
    public static MTLTileRenderPipelineColorAttachmentDescriptor Null => Create(0, false);
    public static MTLTileRenderPipelineColorAttachmentDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLTileRenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineColorAttachmentDescriptorBindings.Class), true)
    {
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }
}

file static class MTLTileRenderPipelineColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptor");

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";
}
