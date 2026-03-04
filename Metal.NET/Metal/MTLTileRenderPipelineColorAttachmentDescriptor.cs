namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLTileRenderPipelineColorAttachmentDescriptor>
{
    #region INativeObject
    public static MTLTileRenderPipelineColorAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLTileRenderPipelineColorAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTileRenderPipelineColorAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLTileRenderPipelineColorAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }
}

file static class MTLTileRenderPipelineColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTileRenderPipelineColorAttachmentDescriptor");

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";
}
