namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLTileRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineColorAttachmentDescriptorArraySelector.Class))
    {
    }

    public MTLTileRenderPipelineColorAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        return GetNullableObject<MTLTileRenderPipelineColorAttachmentDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArraySelector.Object, attachmentIndex));
    }

    public void SetObject(MTLTileRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLTileRenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
