namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLTileRenderPipelineColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineColorAttachmentDescriptorSelector.Class))
    {
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorSelector.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat, (nuint)value);
    }
}

file static class MTLTileRenderPipelineColorAttachmentDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptor");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");
}
