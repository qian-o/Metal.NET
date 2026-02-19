namespace Metal.NET;

public readonly struct MTLRenderPassSampleBufferAttachmentDescriptorArray(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLRenderPassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);
        return ptr is not 0 ? new MTLRenderPassSampleBufferAttachmentDescriptor(ptr) : default;
    }

    public void SetObject(MTLRenderPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
