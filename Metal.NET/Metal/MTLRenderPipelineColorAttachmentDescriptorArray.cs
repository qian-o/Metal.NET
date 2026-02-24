namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLRenderPipelineColorAttachmentDescriptorArray>
{
    public static MTLRenderPipelineColorAttachmentDescriptorArray Create(nint nativePtr) => new(nativePtr);
    public MTLRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineColorAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLRenderPipelineColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return new(nativePtr);
    }

    public void SetObject(MTLRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLRenderPipelineColorAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
