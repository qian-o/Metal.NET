namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLTileRenderPipelineColorAttachmentDescriptorArray>
{
    public static MTLTileRenderPipelineColorAttachmentDescriptorArray Create(nint nativePtr) => new(nativePtr, true);

    public static MTLTileRenderPipelineColorAttachmentDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLTileRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLTileRenderPipelineColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return new(nativePtr, true);
    }

    public void SetObject(MTLTileRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
