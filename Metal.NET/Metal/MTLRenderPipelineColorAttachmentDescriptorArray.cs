namespace Metal.NET;

public partial class MTLRenderPipelineColorAttachmentDescriptorArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptorArray");

    public MTLRenderPipelineColorAttachmentDescriptorArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLRenderPipelineColorAttachmentDescriptor? @object(nuint attachmentIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArraySelector.Object, attachmentIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetObject(MTLRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLRenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
