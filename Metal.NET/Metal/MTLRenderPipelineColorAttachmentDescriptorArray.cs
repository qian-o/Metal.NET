namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineColorAttachmentDescriptorArraySelector.Class))
    {
    }

    public MTLRenderPipelineColorAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        return GetNullableObject<MTLRenderPipelineColorAttachmentDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArraySelector.Object, attachmentIndex));
    }

    public void SetObject(MTLRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLRenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
