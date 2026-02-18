namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorArraySelector.Class))
    {
    }

    public MTLRenderPassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        return GetNullableObject<MTLRenderPassSampleBufferAttachmentDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArraySelector.Object, attachmentIndex));
    }

    public void SetObject(MTLRenderPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
