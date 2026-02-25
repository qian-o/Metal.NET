namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptorArray(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLTileRenderPipelineColorAttachmentDescriptorArray>
{
    public static MTLTileRenderPipelineColorAttachmentDescriptorArray Create(nint nativePtr) => new(nativePtr);

    public static MTLTileRenderPipelineColorAttachmentDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLTileRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLTileRenderPipelineColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return new(nativePtr);
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
