namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptorArray(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineColorAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLRenderPipelineColorAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
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
