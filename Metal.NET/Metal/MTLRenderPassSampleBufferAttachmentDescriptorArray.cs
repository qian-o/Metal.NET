namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLRenderPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLRenderPassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public void SetObject(MTLRenderPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
